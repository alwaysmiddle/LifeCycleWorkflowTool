using LifeCycleWorkflowBackend.Settings;
using LifeCycleWorkflowBackend.Settings.OperationSettings;
using LifeCycleWorkflowBackend.Utilities;
using Microsoft.Office.Interop.Excel;
using ProcessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.BannerOperations
{
    public sealed class O5Operations : BannerOperationBase
    {
        private BannerSettings _o5Settings;
        private BaseOperationSettings _o5WorksheetSettings;

        private Microsoft.Office.Interop.Excel.Application excelApp;
        private Workbook wipWb;
        private Workbook finalWb;

        //Wip worksheets
        private Worksheet reportWsWip;
        private Worksheet inactiveWsWip;
        private Worksheet detailsProductWsWip;
        private Worksheet detailsProductDataWsWip;
        private Worksheet inventoryValueWsWip;

        //Final worksheets
        private Worksheet reportWsFinal;
        private Worksheet inactiveWsFinal;
        private Worksheet detailsProductWsFinal;

        public O5Operations(BannerSettings settings) : base(settings)
        {
            _o5Settings = settings;
            _o5WorksheetSettings = (BaseOperationSettings)settings.WorksheetSettings;
        }
        


        public void RunOperation()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();
            System.Data.DataTable templateDataTable = new System.Data.DataTable();

            excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);

            WipWbInitialization();
            FinalWbInitialization();

            excelApp.Calculation = XlCalculation.xlCalculationManual;
            excelApp.Visible = false;
            try
            {
                //SummaryChart
                string dateAddress = _o5WorksheetSettings.SummarySettings.ReportSettings.DateAddress;
                reportWsWip.Range[dateAddress].Value = _o5Settings.OutputDate.ToOADate();

                WipBitReportOp();
                WipInactiveUpcOp();
                WipWorkflowOp();

                O5SpeicalRule1(detailsProductWsWip, _o5WorksheetSettings.WorkflowSettings.WipSettings.HeaderRow);

                excelApp.Calculate();

                WipWbFormatAsValuesOnly(true);

                wipWb.Save();

                CopyToFinalWb();
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
        private void O5SpeicalRule1(Worksheet ws, int headerRow)
        {
            Range furAttributeRange = ws.FindColumnInHeaderRow<string>("Active_PIM", headerRow);
            System.Data.DataTable dt = new System.Data.DataTable();

            if (furAttributeRange.Cells.Count > 1)
            {
                string writeToAddress = furAttributeRange.Cells[2, 1].Address; //cell under rework column name
                dt = ExcelUtilities.ReadWorksheetRangeAsTable(ws, furAttributeRange.Resize[ColumnSize: 43].Address);

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

        private void WipWbInitialization()
        {
            try
            {
                wipWb = excelApp.Workbooks.Open(_o5Settings.OutputFileFullnameWip);
            }
            catch (Exception ex)
            {
                //TODO Error Workbook failed to open.
                Console.WriteLine("Workbook open failed.");
            }

            try
            {
                reportWsWip = wipWb.Worksheets[_o5WorksheetSettings.SummarySettings.ReportSettings.WorksheetName];
                inactiveWsWip = wipWb.Worksheets[_o5WorksheetSettings.InactiveUpcSettings.WipSettings.WorksheetName];
                detailsProductWsWip = wipWb.Worksheets[_o5WorksheetSettings.WorkflowSettings.WipSettings.WorksheetName];
                detailsProductDataWsWip = wipWb.Worksheets[_o5WorksheetSettings.WorkflowSettings.DataSourceSettings.WorksheetName];
                inventoryValueWsWip = wipWb.Worksheets[_o5WorksheetSettings.BitreportSettings.WipSettings.WorksheetName];
            }
            catch (Exception ex)
            {
                //TODO Error worksheet name not found
                Console.WriteLine("Worksheet within workbook not found.");
            }
        }

        private void FinalWbInitialization()
        {
            try
            {
                finalWb = excelApp.Workbooks.Open(_o5Settings.OutputFileFullnameFinal);
            }
            catch (Exception ex)
            {
                //TODO Error Workbook failed to open.
                Console.WriteLine("Workbook open failed.");
            }

            try
            {
                reportWsFinal = finalWb.Worksheets[_o5WorksheetSettings.SummarySettings.FinalSettings.WorksheetName];
                inactiveWsFinal = finalWb.Worksheets[_o5WorksheetSettings.InactiveUpcSettings.FinalSettings.WorksheetName];
                detailsProductWsFinal = finalWb.Worksheets[_o5WorksheetSettings.WorkflowSettings.FinalSettings.WorksheetName];
            }
            catch (Exception ex)
            {
                //TODO Error worksheet name not found
                Console.WriteLine("Worksheet within workbook not found.");
            }
        }

        /// <summary>
        /// Make the wip workbook values only at the end. If this is not turned on, final workbook will have external links to the wip workbook.
        /// </summary>
        private void WipWbFormatAsValuesOnly(bool valuesOnlyOn)
        {
            if (valuesOnlyOn)
            {
                inactiveWsWip.ConvertAllDataUnderRowToValues(_o5WorksheetSettings.InactiveUpcSettings.WipSettings.HeaderRow);
                detailsProductWsWip.ConvertAllDataUnderRowToValues(_o5WorksheetSettings.WorkflowSettings.WipSettings.HeaderRow);

                //Turn summary chart into values
                string readingAddress = _o5WorksheetSettings.SummarySettings.ReportSettings.ReadingAddress;
                reportWsWip.Range[readingAddress].Value2 = reportWsWip.Range[readingAddress].Value2;
            }
        }

        //===================================================WIP OPERATIONS======================================================
        #region O5Wip
        private void WipBitReportOp()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();
            System.Data.DataTable templateDataTable = new System.Data.DataTable();

            //Bit report
            BitReportHandler bitReport = new BitReportHandler(_o5Settings.InputFilenameBitReport);
            templateDataTable = ExcelUtilities.ReadExcelDataFileAsTable(_o5Settings.OutputFileFullnameWip, inventoryValueWsWip.Name);
            inputDataTable = bitReport.JoinWithDataTable(templateDataTable);

            string writingAddress = string.Format("A{0}", _o5WorksheetSettings.BitreportSettings.WipSettings.WritingRow);
            inputDataTable.WriteToExcelSheets(inventoryValueWsWip, writingAddress);
            CommonOperations.FormatColumnsAsAccounting(inventoryValueWsWip, "OH $ @R");
        }

        private void WipInactiveUpcOp()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();

            //Inactive UPC
            inputDataTable = ExcelUtilities.ReadExcelDataFileAsTable(_o5Settings.InputFilenameInactiveUpc, 1);

            string writingAddress = string.Format("A{0}", _o5WorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
            inputDataTable.WriteToExcelSheets(inactiveWsWip, writingAddress, false);
            inactiveWsWip.ProcessFormulaRow(
                refTable: inputDataTable,
                formulaRow: _o5WorksheetSettings.InactiveUpcSettings.WipSettings.FormulaRow,
                headerRow: _o5WorksheetSettings.InactiveUpcSettings.WipSettings.ReferenceRow,
                outputRow: _o5WorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
        }

        private void WipWorkflowOp()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();

            //Workflow DM
            inputDataTable = ExcelUtilities.ReadExcelDataFileAsTable(_o5Settings.InputFilenameWorkflow, 1);

            string writingAddress = string.Format("A{0}", _o5WorksheetSettings.WorkflowSettings.DataSourceSettings.WritingRow);
            inputDataTable.WriteToExcelSheets(detailsProductDataWsWip, writingAddress, true);
            detailsProductWsWip.ProcessFormulaRow(
                refTable: inputDataTable,
                formulaRow: _o5WorksheetSettings.WorkflowSettings.WipSettings.FormulaRow,
                headerRow: _o5WorksheetSettings.WorkflowSettings.WipSettings.ReferenceRow,
                outputRow: _o5WorksheetSettings.WorkflowSettings.WipSettings.WritingRow);

            detailsProductWsWip.Calculate();
            CommonOperations.ReworkFurRule(detailsProductWsWip, _o5WorksheetSettings.WorkflowSettings.WipSettings.HeaderRow);
        }
        #endregion

        //===================================================Final OPERATIONS====================================================
        #region O5Final
        private void CopyToFinalWb()
        {
            //Temp variables
            string writingAddress; //excel writing address for datatables and final workbook
            string readingAddress; //excel reading address to aquire data areas
            int colCount; //temporary count for resizing purposes
            int rowCount;

            finalWb.Activate();

            //Summary Chart
            readingAddress = _o5WorksheetSettings.SummarySettings.ReportSettings.ReadingAddress;
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
        #endregion
    }
}
