using LifeCycleDevEnvironmentConsole.ExtensionMethods;
using LifeCycleDevEnvironmentConsole.Settings;
using LifeCycleDevEnvironmentConsole.Settings.OperationSettings;
using LifeCycleDevEnvironmentConsole.Utilities;
using Microsoft.Office.Interop.Excel;
using ProcessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.BannerOperations
{
    public sealed class O5Operations : BannerOperationBase
    {
        private BannerSettings _o5Settings;
        private BaseOperationSettings _o5WorksheetSettings;

        public O5Operations(BannerSettings settings) : base(settings)
        {
            _o5Settings = settings;
            _o5WorksheetSettings = (BaseOperationSettings)settings.WorksheetSettings;
        }

        public void RunOperation()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();
            System.Data.DataTable templateDataTable = new System.Data.DataTable();

            Application excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);

            Workbook wipWb = excelApp.Workbooks.Open(_o5Settings.OutputFileFullnameWip);
            Workbook finalWb = excelApp.Workbooks.Open(_o5Settings.OutputFileFullnameFinal);
            excelApp.Calculation = XlCalculation.xlCalculationManual;
            excelApp.Visible = false;
            try
            {
                Worksheet reportWsWip = wipWb.Worksheets[_o5WorksheetSettings.SummarySettings.ReportSettings.WorksheetName];
                Worksheet inactiveWsWip = wipWb.Worksheets[_o5WorksheetSettings.InactiveUpcSettings.WipSettings.WorksheetName];
                Worksheet detailsProductWsWip = wipWb.Worksheets[_o5WorksheetSettings.WorkflowSettings.WipSettings.WorksheetName];
                Worksheet detailsProductDataWsWip = wipWb.Worksheets[_o5WorksheetSettings.WorkflowSettings.DataSourceSettings.WorksheetName];
                Worksheet inventoryValueWsWip = wipWb.Worksheets[_o5WorksheetSettings.BitreportSettings.WipSettings.WorksheetName];

                //Temp variables
                string writingAddress; //excel writing address for datatables and final workbook
                string readingAddress; //excel reading address to aquire data areas
                int colCount; //temporary count for resizing purposes
                int rowCount;

                //SummaryChart
                string dateAddress = _o5WorksheetSettings.SummarySettings.ReportSettings.DateAddress;
                reportWsWip.Range[dateAddress].Value = _o5Settings.OutputDate.ToOADate();

                //Bit report
                BitReportHandler bitReport = new BitReportHandler(_o5Settings.InputFilenameBitReport);
                templateDataTable = ExcelUtilities.OledbExcelFileAsTable(_o5Settings.OutputFileFullnameWip, inventoryValueWsWip.Name);
                inputDataTable = bitReport.JoinWithDataTable(templateDataTable);

                writingAddress = string.Format("A{0}", _o5WorksheetSettings.BitreportSettings.WipSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(inventoryValueWsWip, writingAddress);
                CommonOperations.FormatColumnsAsAccounting(inventoryValueWsWip, "OH $ @R");
                inputDataTable = null;
                bitReport = null;

                //Inactive UPC
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_o5Settings.InputFilenameInactiveUpc, 1);

                writingAddress = string.Format("A{0}", _o5WorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(inactiveWsWip, writingAddress, false);
                inactiveWsWip.ProcessFormulaRow(
                    refTable: inputDataTable,
                    formulaRow: _o5WorksheetSettings.InactiveUpcSettings.WipSettings.FormulaRow,
                    headerRow: _o5WorksheetSettings.InactiveUpcSettings.WipSettings.ReferenceRow,
                    outputRow: _o5WorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
                inputDataTable = null;

                //Workflow DM
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_o5Settings.InputFilenameWorkflow, 1);

                writingAddress = string.Format("A{0}", _o5WorksheetSettings.WorkflowSettings.DataSourceSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(detailsProductDataWsWip, writingAddress, true);
                detailsProductWsWip.ProcessFormulaRow(
                    refTable: inputDataTable,
                    formulaRow: _o5WorksheetSettings.WorkflowSettings.WipSettings.FormulaRow,
                    headerRow: _o5WorksheetSettings.WorkflowSettings.WipSettings.ReferenceRow,
                    outputRow: _o5WorksheetSettings.WorkflowSettings.WipSettings.WritingRow);
                inputDataTable = null;
               
                detailsProductWsWip.Calculate();
                CommonOperations.ReworkFurRule(detailsProductWsWip);
                O5SpeicalRule1(detailsProductWsWip);

                excelApp.Calculate();
                //inactiveWsWip.ConvertAllDataUnderRowToValues(_o5WorksheetSettings.InactiveUpcSettings.WipSettings.HeaderRow);
                //detailsProductWsWip.ConvertAllDataUnderRowToValues(_o5WorksheetSettings.WorkflowSettings.WipSettings.HeaderRow);

                //Turn summary chart into values
                readingAddress = _o5WorksheetSettings.SummarySettings.ReportSettings.ReadingAddress;
                //reportWsWip.Range[readingAddress].Value2 = reportWsWip.Range[readingAddress].Value2;

                wipWb.Save();

                //===============================Final Section================================

                Worksheet reportWsFinal = finalWb.Worksheets[_o5WorksheetSettings.SummarySettings.FinalSettings.WorksheetName];
                Worksheet inactiveWsFinal = finalWb.Worksheets[_o5WorksheetSettings.InactiveUpcSettings.FinalSettings.WorksheetName];
                Worksheet detailsProductWsFinal = finalWb.Worksheets[_o5WorksheetSettings.WorkflowSettings.FinalSettings.WorksheetName];

                finalWb.Activate();

                //Summary Chart
                writingAddress = _o5WorksheetSettings.SummarySettings.FinalSettings.WritingAddress;
                rowCount = reportWsWip.Range[readingAddress].Rows.Count;
                colCount = reportWsWip.Range[readingAddress].Columns.Count;
                reportWsWip.Range[readingAddress].Copy(reportWsFinal.Range[writingAddress].Resize[rowCount, colCount]);

                //Details Product
                readingAddress = detailsProductWsWip.ConvertColumnAddressToPreciseAddress(
                    _o5WorksheetSettings.WorkflowSettings.WipSettings.ReadingAddress,
                    _o5WorksheetSettings.WorkflowSettings.WipSettings.WritingRow);
                writingAddress = _o5WorksheetSettings.WorkflowSettings.FinalSettings.WritingAddress;
                rowCount = detailsProductWsWip.Range[readingAddress].Rows.Count;
                colCount = detailsProductWsWip.Range[readingAddress].Columns.Count;
                detailsProductWsFinal.Range[writingAddress].Resize[rowCount, colCount].Value = detailsProductWsWip.Range[readingAddress].Value;

                //Inactive Upc
                readingAddress = inactiveWsWip.ConvertColumnAddressToPreciseAddress(
                    _o5WorksheetSettings.InactiveUpcSettings.WipSettings.ReadingAddress,
                    _o5WorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
                writingAddress = _o5WorksheetSettings.InactiveUpcSettings.FinalSettings.WritingAddress;
                rowCount = inactiveWsWip.Range[readingAddress].Rows.Count;
                colCount = inactiveWsWip.Range[readingAddress].Columns.Count;
                inactiveWsFinal.Range[writingAddress].Resize[rowCount, colCount].Value = inactiveWsWip.Range[readingAddress].Value;
            }
            catch (Exception ex)
            {
                //TODO handle exception
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                excelApp.DisplayAlerts = false;
                excelApp.Calculation = XlCalculation.xlCalculationAutomatic;

                wipWb.Save();
                finalWb.Save();

                wipWb.Close();
                finalWb.Close();
                excelApp.Quit();

                Marshal.ReleaseComObject(wipWb);
                Marshal.ReleaseComObject(finalWb);
                Marshal.ReleaseComObject(excelApp);

                excelProcess.Dispose();
            }
        }

        //TODO O5 change reading size
        private void O5SpeicalRule1(Worksheet ws)
        {
            Range furAttributeRange = ws.FindColumnInHeaderRow<string>("Active_PIM", 7);
            System.Data.DataTable dt = new System.Data.DataTable();

            if (furAttributeRange.Cells.Count > 1)
            {
                string writeToAddress = furAttributeRange.Cells[2, 1].Address; //cell under rework column name
                dt = ExcelUtilities.OledbExcelFileAsTable(ws.Parent.Fullname, ws.Name, furAttributeRange.Resize[ColumnSize: 43].Address);

                var rowToUpdate = dt.AsEnumerable()
                    .Where(r => r.Field<string>("Active_PIM") == "Yes" && r.Field<string>("ReadyforProd_PIM") == "Yes" &&
                            r.Field<string>("Current_Workflow_Status") == "Not in PIM Workflow" || r.Field<string>("Current_Workflow_Status") == "Workflow Complete" );

                foreach (System.Data.DataRow row in rowToUpdate)
                {
                    row.SetField<string>(dt.Columns["Current_Workflow_Status"], "Not Flagged for eCOM");
                    row.SetField<string>(dt.Columns["Current Team"], "Merchants");
                }

                dt.WriteToExcelSheets(ws, writeToAddress, false);
            }
        }
    }
}
