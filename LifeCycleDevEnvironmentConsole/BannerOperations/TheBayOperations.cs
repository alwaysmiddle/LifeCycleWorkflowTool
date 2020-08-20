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

        //Wip worksheets
        private Worksheet summaryWsWip;
        private Worksheet inactiveWsWip;
        private Worksheet inactiveDataWsWip;
        private Worksheet detailsProductWsWip;
        private Worksheet detailsProductDataWsWip;
        private Worksheet inventoryValueWsWip;
        private Worksheet nosCombineWsWip;

        //Final worksheets
        private Worksheet summaryWsFinal;
        private Worksheet inactiveWsFinal;
        private Worksheet detailsProductWsFinal;
        private Worksheet nosCombinedFinal;

        //Column names for special rules
        private readonly string specialRuleGroupId = "PIM PRODUCTS Group ID";
        private readonly string specialRuleDivisionId = "PIM PRODUCTS Divisionid";

        public TheBayOperations(BannerSettings settings) : base(settings)
        {
            _theBaySettings = settings;
            _theBayWorksheetSettings = (TheBayOperationSettings)settings.WorksheetSettings;
        }

        public void RunOperation()
        {
            excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);
            WipWbInitialization();
            FinalWbInitialization();

            excelApp.Calculation = XlCalculation.xlCalculationManual;
            excelApp.Visible = true;

            try
            {
                //SummaryChart
                string dateAddress = _theBayWorksheetSettings.SummarySettings.ReportSettings.DateAddress;
                summaryWsWip.Range[dateAddress].Value = _theBaySettings.OutputDate.ToOADate();

                //WipBitReportOp();
                //WipNosCombinedOp();
                //WipInactiveUpcOp();
                WipWorkflowOp();

                excelApp.Calculate();

                WipWbFormatAsValuesOnly(false);

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

        private void WipWbInitialization()
        {
            try
            {
                wipWb = excelApp.Workbooks.Open(_theBaySettings.OutputFileFullnameWip);
            }
            catch (Exception ex)
            {
                //TODO Error Workbook failed to open.
                Console.WriteLine("Workbook open failed.");
            }

            try
            {
                summaryWsWip = wipWb.Worksheets[_theBayWorksheetSettings.SummarySettings.ReportSettings.WorksheetName];
                inactiveWsWip = wipWb.Worksheets[_theBayWorksheetSettings.InactiveUpcSettings.WipSettings.WorksheetName];
                inactiveDataWsWip = wipWb.Worksheets[_theBayWorksheetSettings.InactiveUpcSettings.DataSourceSettings.WorksheetName];
                detailsProductWsWip = wipWb.Worksheets[_theBayWorksheetSettings.WorkflowSettings.WipSettings.WorksheetName];
                detailsProductDataWsWip = wipWb.Worksheets[_theBayWorksheetSettings.WorkflowSettings.DataSourceSettings.WorksheetName];
                inventoryValueWsWip = wipWb.Worksheets[_theBayWorksheetSettings.BitreportSettings.WipSettings.WorksheetName];
                nosCombineWsWip = wipWb.Worksheets[_theBayWorksheetSettings.NosCombinedSettings.WipSettings.WorksheetName];
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
                finalWb = excelApp.Workbooks.Open(_theBaySettings.OutputFileFullnameFinal);
            }
            catch (Exception ex)
            {
                //TODO Error Workbook failed to open.
                Console.WriteLine("Workbook open failed.");
            }

            try
            {
                summaryWsFinal = finalWb.Worksheets[_theBayWorksheetSettings.SummarySettings.FinalSettings.WorksheetName];
                inactiveWsFinal = finalWb.Worksheets[_theBayWorksheetSettings.InactiveUpcSettings.FinalSettings.WorksheetName];
                detailsProductWsFinal = finalWb.Worksheets[_theBayWorksheetSettings.WorkflowSettings.FinalSettings.WorksheetName];
                nosCombinedFinal = finalWb.Worksheets[_theBayWorksheetSettings.NosCombinedSettings.FinalSettings.WorksheetName];
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
                inactiveWsWip.ConvertAllDataUnderRowToValues(_theBayWorksheetSettings.InactiveUpcSettings.WipSettings.HeaderRow);
                detailsProductWsWip.ConvertAllDataUnderRowToValues(_theBayWorksheetSettings.WorkflowSettings.WipSettings.HeaderRow);
                nosCombineWsWip.ConvertAllDataUnderRowToValues(_theBayWorksheetSettings.NosCombinedSettings.WipSettings.HeaderRow);

                string readingAddress = _theBayWorksheetSettings.SummarySettings.ReportSettings.ReadingAddress;
                summaryWsWip.Range[readingAddress].Value2 = summaryWsWip.Range[readingAddress].Value2;
            }
        }


        //===================================================WIP OPERATIONS======================================================
        #region TheBayWip
        private void WipBitReportOp()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();
            System.Data.DataTable templateDataTable = new System.Data.DataTable();

            BitReportHandler bitReport = new BitReportHandler(_theBaySettings.InputFilenameBitReport);
            templateDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.OutputFileFullnameWip, inventoryValueWsWip.Name);
            inputDataTable = bitReport.JoinWithDataTable(templateDataTable);

            string writingAddress = string.Format("A{0}", _theBayWorksheetSettings.BitreportSettings.WipSettings.WritingRow);
            inputDataTable.WriteToExcelSheets(inventoryValueWsWip, writingAddress);

            CommonOperations.FormatColumnsAsAccounting(inventoryValueWsWip, "OH $ @R");
        }

        private void WipNosCombinedOp()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();

            inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameNosCombined, 1);

            inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>(specialRuleGroupId, specialRuleDivisionId, 27, 5);
            inputDataTable.UpdateValueOfTwoColumns<double>(specialRuleGroupId, specialRuleDivisionId, 28, 7, 28, 5);

            string writingAddress = string.Format("A{0}", _theBayWorksheetSettings.NosCombinedSettings.DataSourceSettings.WritingRow);
            inputDataTable.WriteToExcelSheets(nosCombineWsWip, writingAddress, false);
            nosCombineWsWip.ProcessFormulaRow(
                refTable: inputDataTable,
                formulaRow: _theBayWorksheetSettings.NosCombinedSettings.WipSettings.FormulaRow,
                headerRow: _theBayWorksheetSettings.NosCombinedSettings.WipSettings.ReferenceRow,
                outputRow: _theBayWorksheetSettings.NosCombinedSettings.WipSettings.WritingRow);
        }

        private void WipInactiveUpcOp()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();

            //Inactive UPC
            inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameInactiveUpc, 1);

            inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>(specialRuleGroupId, specialRuleDivisionId, 27, 5);
            inputDataTable.UpdateValueOfTwoColumns<double>(specialRuleGroupId, specialRuleDivisionId, 28, 7, 28, 5);

            string writingAddress = string.Format("A{0}", _theBayWorksheetSettings.InactiveUpcSettings.DataSourceSettings.WritingRow);
            inputDataTable.WriteToExcelSheets(inactiveDataWsWip, writingAddress, true);
            inactiveWsWip.ProcessFormulaRow(
                refTable: inputDataTable,
                formulaRow: _theBayWorksheetSettings.InactiveUpcSettings.WipSettings.FormulaRow,
                headerRow: _theBayWorksheetSettings.InactiveUpcSettings.WipSettings.ReferenceRow,
                outputRow: _theBayWorksheetSettings.InactiveUpcSettings.WipSettings.WritingRow);

            inactiveWsWip.Calculate();
        }

        private void WipWorkflowOp()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();

            inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameWorkflow, 1);

            inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>(specialRuleGroupId, specialRuleDivisionId, 27, 5);
            inputDataTable.UpdateValueOfTwoColumns<double>(specialRuleGroupId, specialRuleDivisionId, 28, 7, 28, 5);

            string writingAddress = string.Format("A{0}", _theBayWorksheetSettings.WorkflowSettings.DataSourceSettings.WritingRow);
            inputDataTable.WriteToExcelSheets(detailsProductDataWsWip, writingAddress, true);
            detailsProductWsWip.ProcessFormulaRow(refTable: inputDataTable,
                formulaRow: _theBayWorksheetSettings.WorkflowSettings.WipSettings.FormulaRow,
                headerRow: _theBayWorksheetSettings.WorkflowSettings.WipSettings.ReferenceRow,
                outputRow: _theBayWorksheetSettings.WorkflowSettings.WipSettings.WritingRow);

            inputDataTable = null;
            detailsProductWsWip.Calculate();

            CommonOperations.ReworkFurRule(detailsProductWsWip);
        }
        #endregion

        //===================================================Final OPERATIONS====================================================
        #region TheBayFinal
        private void CopyToFinalWb()
        {
            //Temp variables
            string writingAddress; //excel writing address for datatables and final workbook
            string readingAddress; //excel reading address to aquire data areas
            int colCount; //temporary count for resizing purposes
            int rowCount;

            finalWb.Activate();

            //Summary Chart
            readingAddress = _theBayWorksheetSettings.SummarySettings.ReportSettings.ReadingAddress;
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
        #endregion
    }
}
