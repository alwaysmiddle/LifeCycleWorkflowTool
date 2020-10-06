using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Data;
using ProcessManagement;
using LifeCycleWorkflowBackend.Utilities;
using LifeCycleWorkflowBackend.Settings;
using LifeCycleWorkflowBackend.Settings.OperationSettings;

namespace LifeCycleWorkflowBackend.BannerOperations
{
    public sealed class SaksOperations : BannerOperationBase
    {
        private BannerSettings _saksSettings;
        private BaseOperationSettings _saksWorksheetSettings;

        public SaksOperations(BannerSettings settings) : base(settings)
        {
            _saksSettings = settings;
            _saksWorksheetSettings = (BaseOperationSettings)settings.WorksheetSettings;
        }
        public void RunOperation()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();
            System.Data.DataTable templateDataTable = new System.Data.DataTable();

            Application excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);

            Workbook wipWb = excelApp.Workbooks.Open(_saksSettings.OutputFileFullnameWip);
            Workbook finalWb = excelApp.Workbooks.Open(_saksSettings.OutputFileFullnameFinal);
            excelApp.Calculation = XlCalculation.xlCalculationManual;
            excelApp.Visible = false;

            try
            {
                Worksheet inventoryValueWs = wipWb.Worksheets[_saksWorksheetSettings.BitreportSettings.WipSettings.WorksheetName];
                Worksheet inactiveWs = wipWb.Worksheets[_saksWorksheetSettings.InactiveUpcSettings.WipSettings.WorksheetName];
                Worksheet detailsProductWs = wipWb.Worksheets[_saksWorksheetSettings.WorkflowSettings.WipSettings.WorksheetName];
                Worksheet detailsProductDataSourceWs = wipWb.Worksheets[_saksWorksheetSettings.WorkflowSettings.DataSourceSettings.WorksheetName];
                Worksheet reportWs = wipWb.Worksheets[_saksWorksheetSettings.SummarySettings.ReportSettings.WorksheetName];

                //Temp variables
                string writingAddress; //excel writing address for datatables and final workbook
                string readingAddress; //excel reading address to aquire data areas
                int colCount; //temporary count for resizing purposes
                int rowCount;

                //Special rule column names
                string specialRuleGroupId = "GROUP_ID";

                //SummaryChart
                string dateAddress = _saksWorksheetSettings.SummarySettings.ReportSettings.DateAddress;
                reportWs.Range[dateAddress].Value = _saksSettings.OutputDate.ToOADate();

                //Bit report
                wipWb.Activate();
                BitReportHandler bitReport = new BitReportHandler(_saksSettings.InputFilenameBitReport);
                templateDataTable = ExcelUtilities.ReadExcelDataFileAsTable(_saksSettings.OutputFileFullnameWip, inventoryValueWs.Name);
                inputDataTable = bitReport.JoinWithDataTable(templateDataTable);
                
                writingAddress = string.Format("A{0}", _saksWorksheetSettings.BitreportSettings.WipSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(inventoryValueWs, writingAddress);

                CommonOperations.FormatColumnsAsAccounting(inventoryValueWs, "OH $ @R");
                inputDataTable = null;
                bitReport = null;

                //Inactive UPC
                inputDataTable = ExcelUtilities.ReadExcelDataFileAsTable(_saksSettings.InputFilenameInactiveUpc, 1);
                SaksSpecialRule1(inputDataTable);
                writingAddress = string.Format("A{0}", _saksWorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(inactiveWs, writingAddress, false);
                inactiveWs.ProcessFormulaRow(
                    refTable: inputDataTable,
                    formulaRow: _saksWorksheetSettings.InactiveUpcSettings.WipSettings.FormulaRow,
                    headerRow: _saksWorksheetSettings.InactiveUpcSettings.WipSettings.ReferenceRow,
                    outputRow: _saksWorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
                inputDataTable = null;
                
                //Workflow DM
                inputDataTable = ExcelUtilities.ReadExcelDataFileAsTable(_saksSettings.InputFilenameWorkflow, 1);
                inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>(specialRuleGroupId, specialRuleGroupId, 34, 33);

                writingAddress = string.Format("A{0}", _saksWorksheetSettings.WorkflowSettings.DataSourceSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(detailsProductDataSourceWs, writingAddress, true);
                detailsProductWs.ProcessFormulaRow(
                    refTable: inputDataTable,
                    formulaRow: _saksWorksheetSettings.WorkflowSettings.WipSettings.FormulaRow,
                    headerRow: _saksWorksheetSettings.WorkflowSettings.WipSettings.ReferenceRow,
                    outputRow: _saksWorksheetSettings.WorkflowSettings.WipSettings.WritingRow);
                inputDataTable = null;
                detailsProductWs.Calculate();
                CommonOperations.ReworkFurRule(detailsProductWs, _saksWorksheetSettings.WorkflowSettings.WipSettings.HeaderRow);

                excelApp.Calculate();
                inactiveWs.ConvertAllDataUnderRowToValues(_saksWorksheetSettings.InactiveUpcSettings.WipSettings.HeaderRow);
                detailsProductWs.ConvertAllDataUnderRowToValues(_saksWorksheetSettings.WorkflowSettings.WipSettings.HeaderRow);

                //Turn summary chart into values
                readingAddress = _saksWorksheetSettings.SummarySettings.ReportSettings.ReadingAddress;
                reportWs.Range[readingAddress].Value2 = reportWs.Range[readingAddress].Value2;

                wipWb.Save();

                //===============================Final Section================================
                
                Worksheet reportWsFinal = finalWb.Worksheets[_saksWorksheetSettings.SummarySettings.FinalSettings.WorksheetName];
                Worksheet inactiveWsFinal = finalWb.Worksheets[_saksWorksheetSettings.InactiveUpcSettings.FinalSettings.WorksheetName];
                Worksheet detailsProductWsFinal = finalWb.Worksheets[_saksWorksheetSettings.WorkflowSettings.FinalSettings.WorksheetName];

                finalWb.Activate();

                //Summary Chart
                writingAddress = _saksWorksheetSettings.SummarySettings.FinalSettings.WritingAddress;
                rowCount = reportWs.Range[readingAddress].Rows.Count;
                colCount = reportWs.Range[readingAddress].Columns.Count;
                reportWs.Range[readingAddress].Copy(reportWsFinal.Range[writingAddress].Resize[rowCount, colCount]);

                //Details Product
                readingAddress = detailsProductWs.ConvertColumnAddressToPreciseAddress(
                    _saksWorksheetSettings.WorkflowSettings.WipSettings.ReadingAddress,
                    _saksWorksheetSettings.WorkflowSettings.WipSettings.WritingRow);
                writingAddress = _saksWorksheetSettings.WorkflowSettings.FinalSettings.WritingAddress;
                rowCount = detailsProductWs.Range[readingAddress].Rows.Count;
                colCount = detailsProductWs.Range[readingAddress].Columns.Count;
                detailsProductWsFinal.Range[writingAddress].Resize[rowCount, colCount].Value = detailsProductWs.Range[readingAddress].Value;

                //Inactive Upc
                readingAddress = inactiveWs.ConvertColumnAddressToPreciseAddress(
                    _saksWorksheetSettings.InactiveUpcSettings.WipSettings.ReadingAddress,
                    _saksWorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
                writingAddress = _saksWorksheetSettings.InactiveUpcSettings.FinalSettings.WritingAddress;
                rowCount = inactiveWs.Range[readingAddress].Rows.Count;
                colCount = inactiveWs.Range[readingAddress].Columns.Count;
                inactiveWsFinal.Range[writingAddress].Resize[rowCount, colCount].Value = inactiveWs.Range[readingAddress].Value;
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

        /// <summary>
        /// This special rule changes group id from 34 to 33.
        /// </summary>
        private void SaksSpecialRule1(System.Data.DataTable dt)
        {
            foreach (System.Data.DataColumn col in dt.Columns)
            {
                if (col.ColumnName.IndexOf("group", StringComparison.OrdinalIgnoreCase) >= 0 && 
                    col.DataType == typeof(Double))
                {
                    System.Data.DataRow[] groupRows = dt.Select(string.Format("{0} = 34", col.ColumnName));
                    if (groupRows != null)
                    {
                        foreach (System.Data.DataRow row in groupRows)
                        {
                            row[col] = 33;
                        }
                    }
                }
            }
        }
    }
}
