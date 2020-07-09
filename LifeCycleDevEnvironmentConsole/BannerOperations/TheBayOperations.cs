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
    public sealed class TheBayOperations : BannerOperationBase
    {
        private BannerSettings _theBaySettings;
        private TheBayOperationSettings _theBayWorksheetSettings;

        private Microsoft.Office.Interop.Excel.Application excelApp;
        private Workbook wipWb;
        private Workbook finalWb;

        private Worksheet summaryWsWip;
        private Worksheet inactiveWsWip;
        private Worksheet inactiveDataWsWip;
        private Worksheet detailsProductWsWip;
        private Worksheet detailsProductDataWsWip;
        private Worksheet inventoryValueWsWip;
        private Worksheet nosCombineWsWip;
        private Worksheet summaryWsFinal;
        private Worksheet inactiveWsFinal;
        private Worksheet detailsProductWsFinal;
        private Worksheet nosCombinedFinal;

        public TheBayOperations(BannerSettings settings) : base(settings)
        {
            _theBaySettings = settings;
            _theBayWorksheetSettings = (TheBayOperationSettings)settings.WorksheetSettings;
        }

        public void RunOperation()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();
            System.Data.DataTable templateDataTable = new System.Data.DataTable();

            Application excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);
            Workbook wipWb = excelApp.Workbooks.Open(_theBaySettings.OutputFileFullnameWip);
            Workbook finalWb = excelApp.Workbooks.Open(_theBaySettings.OutputFileFullnameFinal);
            excelApp.Calculation = XlCalculation.xlCalculationManual;
            excelApp.Visible = false;

            try
            {
                Worksheet summaryWsWip = wipWb.Worksheets[_theBayWorksheetSettings.SummarySettings.ReportSettings.WorksheetName];
                Worksheet inactiveWsWip = wipWb.Worksheets[_theBayWorksheetSettings.InactiveUpcSettings.WipSettings.WorksheetName];
                Worksheet inactiveDataWsWip = wipWb.Worksheets[_theBayWorksheetSettings.InactiveUpcSettings.DataSourceSettings.WorksheetName];
                Worksheet detailsProductWsWip = wipWb.Worksheets[_theBayWorksheetSettings.WorkflowSettings.WipSettings.WorksheetName];
                Worksheet detailsProductDataWsWip = wipWb.Worksheets[_theBayWorksheetSettings.WorkflowSettings.DataSourceSettings.WorksheetName];
                Worksheet inventoryValueWsWip = wipWb.Worksheets[_theBayWorksheetSettings.BitreportSettings.WipSettings.WorksheetName];
                Worksheet nosCombineWsWip = wipWb.Worksheets[_theBayWorksheetSettings.NosCombinedSettings.WipSettings.WorksheetName];

                //Temp variables
                string writingAddress; //excel writing address for datatables and final workbook
                string readingAddress; //excel reading address to aquire data areas
                int colCount; //temporary count for resizing purposes
                int rowCount;

                //Special rule column names
                string specialRuleGroupId = "PIM PRODUCTS Group ID";
                string specialRuleDivisionId = "PIM PRODUCTS Divisionid";

                //SummaryChart
                string dateAddress = _theBayWorksheetSettings.SummarySettings.ReportSettings.DateAddress;
                summaryWsWip.Range[dateAddress].Value = _theBaySettings.OutputDate.ToOADate();

                //Bit report
                BitReportHandler bitReport = new BitReportHandler(_theBaySettings.InputFilenameBitReport);
                templateDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.OutputFileFullnameWip, inventoryValueWsWip.Name);
                inputDataTable = bitReport.JoinWithDataTable(templateDataTable);

                writingAddress = string.Format("A{0}", _theBayWorksheetSettings.BitreportSettings.WipSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(inventoryValueWsWip, writingAddress);

                CommonOperations.FormatColumnsAsAccounting(inventoryValueWsWip, "OH $ @R");
                inputDataTable = null;
                bitReport = null;

                //NOS Combined

                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameNosCombined, 1);

                inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>(specialRuleGroupId, specialRuleDivisionId, 27, 5);
                inputDataTable.UpdateValueOfTwoColumns<double>(specialRuleGroupId, specialRuleDivisionId, 28, 7, 28, 5);

                writingAddress = string.Format("A{0}", _theBayWorksheetSettings.NosCombinedSettings.DataSourceSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(nosCombineWsWip, writingAddress, false);
                nosCombineWsWip.ProcessFormulaRow(
                    refTable: inputDataTable,
                    formulaRow: _theBayWorksheetSettings.NosCombinedSettings.WipSettings.FormulaRow,
                    headerRow: _theBayWorksheetSettings.NosCombinedSettings.WipSettings.ReferenceRow,
                    outputRow: _theBayWorksheetSettings.NosCombinedSettings.WipSettings.WritingRow);
                inputDataTable = null;

                inactiveWsWip.Calculate();
                wipWb.Save();

                //Inactive UPC
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameInactiveUpc, 1);

                inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>(specialRuleGroupId, specialRuleDivisionId, 27, 5);
                inputDataTable.UpdateValueOfTwoColumns<double>(specialRuleGroupId, specialRuleDivisionId, 28, 7, 28, 5);

                writingAddress = string.Format("A{0}", _theBayWorksheetSettings.InactiveUpcSettings.DataSourceSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(inactiveDataWsWip, writingAddress, true);
                inactiveWsWip.ProcessFormulaRow(
                    refTable: inputDataTable,
                    formulaRow: _theBayWorksheetSettings.InactiveUpcSettings.WipSettings.FormulaRow,
                    headerRow: _theBayWorksheetSettings.InactiveUpcSettings.WipSettings.ReferenceRow,
                    outputRow: _theBayWorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
                inputDataTable = null;

                inactiveWsWip.Calculate();

                //Workflow DM
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameWorkflow, 1);

                inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>(specialRuleGroupId, specialRuleDivisionId, 27, 5);
                inputDataTable.UpdateValueOfTwoColumns<double>(specialRuleGroupId, specialRuleDivisionId, 28, 7, 28, 5);

                writingAddress = string.Format("A{0}", _theBayWorksheetSettings.WorkflowSettings.DataSourceSettings.WritingRow);
                inputDataTable.WriteToExcelSheets(detailsProductDataWsWip, writingAddress, true);
                detailsProductWsWip.ProcessFormulaRow(refTable: inputDataTable,
                    formulaRow: _theBayWorksheetSettings.WorkflowSettings.WipSettings.FormulaRow,
                    headerRow: _theBayWorksheetSettings.WorkflowSettings.WipSettings.ReferenceRow,
                    outputRow: _theBayWorksheetSettings.WorkflowSettings.WipSettings.WritingRow);

                inputDataTable = null;
                detailsProductWsWip.Calculate();
                CommonOperations.ReworkFurRule(detailsProductWsWip);

                excelApp.Calculate();
                //inactiveWsWip.ConvertAllDataUnderRowToValues(_theBayWorksheetSettings.InactiveUpcSettings.WipSettings.HeaderRow);
                //detailsProductWsWip.ConvertAllDataUnderRowToValues(_theBayWorksheetSettings.WorkflowSettings.WipSettings.HeaderRow);
                //nosCombineWsWip.ConvertAllDataUnderRowToValues(_theBayWorksheetSettings.NosCombinedSettings.WipSettings.HeaderRow);

                readingAddress = _theBayWorksheetSettings.SummarySettings.ReportSettings.ReadingAddress;
                //summaryWsWip.Range[readingAddress].Value2 = summaryWsWip.Range[readingAddress].Value2;
                wipWb.Save();

                //===============================Final Section================================

                Worksheet summaryWsFinal = finalWb.Worksheets[_theBayWorksheetSettings.SummarySettings.FinalSettings.WorksheetName];
                Worksheet inactiveWsFinal = finalWb.Worksheets[_theBayWorksheetSettings.InactiveUpcSettings.FinalSettings.WorksheetName];
                Worksheet detailsProductWsFinal = finalWb.Worksheets[_theBayWorksheetSettings.WorkflowSettings.FinalSettings.WorksheetName];
                Worksheet nosCombinedFinal = finalWb.Worksheets[_theBayWorksheetSettings.NosCombinedSettings.FinalSettings.WorksheetName];

                finalWb.Activate();

                //Summary Chart
                writingAddress = _theBayWorksheetSettings.SummarySettings.FinalSettings.WritingAddress;
                rowCount = summaryWsWip.Range[readingAddress].Rows.Count;
                colCount = summaryWsWip.Range[readingAddress].Columns.Count;
                summaryWsWip.Range[readingAddress].Copy(summaryWsFinal.Range[writingAddress].Resize[rowCount, colCount]);

                //Details Product
                readingAddress = detailsProductWsWip.ConvertColumnAddressToPreciseAddress(
                    _theBayWorksheetSettings.WorkflowSettings.WipSettings.ReadingAddress,
                    _theBayWorksheetSettings.WorkflowSettings.WipSettings.WritingRow);
                writingAddress = _theBayWorksheetSettings.WorkflowSettings.FinalSettings.WritingAddress;
                rowCount = detailsProductWsWip.Range[readingAddress].Rows.Count;
                colCount = detailsProductWsWip.Range[readingAddress].Columns.Count;
                detailsProductWsFinal.Range[writingAddress].Resize[rowCount, colCount].Value = detailsProductWsWip.Range[readingAddress].Value;

                //Inactive Upc
                readingAddress = inactiveWsWip.ConvertColumnAddressToPreciseAddress(
                    _theBayWorksheetSettings.InactiveUpcSettings.WipSettings.ReadingAddress,
                    _theBayWorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);
                writingAddress = _theBayWorksheetSettings.InactiveUpcSettings.FinalSettings.WritingAddress;
                rowCount = inactiveWsWip.Range[readingAddress].Rows.Count;
                colCount = inactiveWsWip.Range[readingAddress].Columns.Count;
                inactiveWsFinal.Range[writingAddress].Resize[rowCount, colCount].Value = inactiveWsWip.Range[readingAddress].Value;

                //Nos Combined
                readingAddress = nosCombineWsWip.ConvertColumnAddressToPreciseAddress(
                    _theBayWorksheetSettings.NosCombinedSettings.WipSettings.ReadingAddress,
                    _theBayWorksheetSettings.NosCombinedSettings.WipSettings.WritingRow);
                writingAddress = _theBayWorksheetSettings.InactiveUpcSettings.FinalSettings.WritingAddress;
                rowCount = nosCombineWsWip.Range[readingAddress].Rows.Count;
                colCount = nosCombineWsWip.Range[readingAddress].Columns.Count;
                inactiveWsFinal.Range[writingAddress].Resize[rowCount, colCount].Value = nosCombineWsWip.Range[readingAddress].Value;
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
    }
}
