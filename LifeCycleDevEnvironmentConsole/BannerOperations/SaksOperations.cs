using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Data;
using ProcessManagement;
using LifeCycleDevEnvironmentConsole.ExtensionMethods;
using LifeCycleDevEnvironmentConsole.Utilities;
using LifeCycleDevEnvironmentConsole.Settings;
using LifeCycleDevEnvironmentConsole.Settings.OperationSettings;

namespace LifeCycleDevEnvironmentConsole.BannerOperations
{
    public sealed class SaksOperations : BannerOperationBase
    {
        private BannerSettings _saksSetting { get;}
        private BaseOperationSettings _saksWorksheetSettings { get; }

        public SaksOperations(BannerSettings settings) : base(settings)
        {
            _saksSetting = settings;
            _saksWorksheetSettings = (BaseOperationSettings)settings.WorksheetSettings;
        }
        public void RunOperation()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();
            System.Data.DataTable templateDataTable = new System.Data.DataTable();

            Application excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);

            Workbook wipWb = excelApp.Workbooks.Open(_saksSetting.OutputFileFullnameWip);
            //Workbook finalWb = excelApp.Workbooks.Open(_saksSetting.OutputFileFullnameFinal);
            excelApp.Calculation = XlCalculation.xlCalculationManual;
            excelApp.Visible = false;

            try
            {
                Worksheet inventoryValueWs = wipWb.Worksheets[_saksWorksheetSettings.BitreportSettings.WipSettings.WorksheetName];
                Worksheet inactiveWs = wipWb.Worksheets[_saksWorksheetSettings.InactiveUpcSettings.WipSettings.WorksheetName];
                Worksheet detailsProductWs = wipWb.Worksheets[_saksWorksheetSettings.WorkflowSettings.WipSettings.WorksheetName];
                Worksheet detailsProductDataSourceWs = wipWb.Worksheets[_saksWorksheetSettings.WorkflowSettings.DataSourceSettings.WorksheetName];

                //Worksheet inactiveWsFinal = finalWb.Worksheets[_saksWorksheetSettings.InactiveUpcSettings.FinalSettings.WorksheetName];
                //Worksheet detailProductWsFinal = finalWb.Worksheets[_saksWorksheetSettings.WorkflowSettings.FinalSettings.WorksheetName];

                //Temp variables
                string writingAddress;

                //Bit report
                BitReportHandler bitReport = new BitReportHandler(_saksSetting.InputFilenameBitReport);
                templateDataTable = ExcelUtilities.OledbExcelFileAsTable(_saksSetting.OutputFileFullnameWip, inventoryValueWs.Name);
                inputDataTable = bitReport.JoinWithDataTable(templateDataTable);
                
                writingAddress = string.Format("A{0}", _saksWorksheetSettings.BitreportSettings.WipSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(inventoryValueWs, writingAddress);

                CommonOperations.FormatColumnsAsAccounting(inventoryValueWs, "OH $ @R");
                inputDataTable = null;
                bitReport = null;

                //Inactive UPC
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_saksSetting.InputFilenameInactiveUpc, 1);
                SaksSpecialRule1(inputDataTable);
                writingAddress = string.Format("A{0}", _saksWorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(inactiveWs, writingAddress, false);
                inactiveWs.ProcessFormulaRow(
                    refTable: inputDataTable,
                    formulaRow: _saksWorksheetSettings.InactiveUpcSettings.WipSettings.FormulaRow,
                    headerRow: _saksWorksheetSettings.InactiveUpcSettings.WipSettings.HeaderRow,
                    outputRow: _saksWorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
                inputDataTable = null;

                //Workflow DM
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_saksSetting.InputFilenameWorkflow, 1);
                inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>("GROUP_ID", "GROUP_ID", 34, 33);

                writingAddress = string.Format("A{0}", _saksWorksheetSettings.WorkflowSettings.DataSourceSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(detailsProductDataSourceWs, writingAddress, true);
                detailsProductWs.ProcessFormulaRow(
                    refTable: inputDataTable,
                    formulaRow: _saksWorksheetSettings.WorkflowSettings.WipSettings.FormulaRow,
                    headerRow: _saksWorksheetSettings.WorkflowSettings.WipSettings.ReferenceRow,
                    outputRow: _saksWorksheetSettings.WorkflowSettings.WipSettings.WritingRow);
                inputDataTable = null;
                wipWb.Save();
                detailsProductWs.Calculate();
                //detailsProductWs.ConvertAllDataUnderRowToValues(7);
                CommonOperations.ReworkFurRule(detailsProductWs);

                excelApp.Calculate();
                wipWb.Save();
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
                wipWb.Close();
                excelApp.Quit();

                Marshal.ReleaseComObject(wipWb);
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
