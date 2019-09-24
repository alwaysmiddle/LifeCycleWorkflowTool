using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace LifeCycleWorkflowLibrary
{
    public static class TheBayManualFileProcess
    {
        private static string tempWipTemplateFileName { get; set; }
        private static string tempFinalTemplateFilename { get; set; }
        private static Dictionary<string, WorksheetCustomSettings> customSettings { get; set; }
        private static Excel.Application excel { get; set; }
        private static Workbook wipWb { get; set; }
        private static Workbook finalWb { get; set; }

        //==========WIP============
        public static void ProcessWipFiles()
        {
            InitializeWipProperties();
            //Generate the output filename
            string newWipFilename = "PIM_" + Globals.General.OutputFileDate.ToString("M.d.yyyy") + "_Daily_Workflow_Report_BAY";

            Workbooks wbs = excel.Workbooks;
            wipWb = wbs.Open(tempWipTemplateFileName);
            //Running Main Processes
            try
            {
                //excel.ScreenUpdating = false;
                excel.Calculation = XlCalculation.xlCalculationManual;
                //excel.EnableEvents = false;
                //excel.DisplayStatusBar = false;
                excel.PrintCommunication = false;    // Excel 2010+ only
                excel.DisplayAlerts = false;

                excel.Visible = true;


                TheBayManualFileProcess.ProcessNosCombinedFile(Properties.Settings.Default.TheBayManualDataLoadNosCombinedFile);
                TheBayManualFileProcess.ProcessInactiveUPC(Properties.Settings.Default.TheBayManualDataLoadInactiveUpcFile);
                TheBayManualFileProcess.ProcessProductDetails(Properties.Settings.Default.TheBayManualDataLoadNosFile);
                TheBayManualFileProcess.ProcessInventoryValue(Properties.Settings.Default.TheBayManualDataLoadInventoryAmountFile);
                TheBayManualFileProcess.UpdatePivots();
                TheBayManualFileProcess.UpdateDate();

                wipWb.Save();

                Globals.TheBay.PathHolder.OutputWipFile = tempWipTemplateFileName;
                Globals.General.StateControl.WipFileProcessSucessful = true;
            }
            catch
            {
                //TODO write error report
            }
            finally
            {
                excel.ScreenUpdating = true;
                excel.Calculation = XlCalculation.xlCalculationAutomatic;
                excel.EnableEvents = true;
                excel.DisplayStatusBar = true;
                excel.PrintCommunication = true;    // Excel 2010+ only

                wipWb.Save();
                wipWb.Close();
            }

            //After local file processing, copy to final destination (possible virutal LAN as destination)
            if (Globals.General.StateControl.WipFileProcessSucessful)
            {
                LifeCycleFileUtilities.CopyFile(tempWipTemplateFileName, StoredSettings.OutputDirectory.TheBay.WipOutputLocation, newWipFilename);
            }

            if (wipWb != null)
            {
                Marshal.ReleaseComObject(wipWb);
                wipWb = null;
            }
        }

        private static void InitializeWipProperties()
        {

            //Generate temperary local file for faster processing
            tempWipTemplateFileName = LifeCycleFileUtilities.CopyFile(
                StoredSettings.TemplateLocations.TheBay.WipTempalteLocation, Path.GetTempPath(), Guid.NewGuid().ToString());

            //Load all customSettings
            WorksheetCustomSettingsHolder allCustomSettings = new WorksheetCustomSettingsHolder();
            allCustomSettings = WorksheetCustomSettingsHolder.Load();

            customSettings = new Dictionary<string, WorksheetCustomSettings>();
            customSettings = allCustomSettings.SettingsCollection;

            excel = new Excel.Application();
        }


        //==========FINAL============
        public static void ProcessFinalFiles()
        {
            InitializeFinalProperties();

            Workbooks wbs = excel.Workbooks;
            wipWb = wbs.Open(tempWipTemplateFileName);
            finalWb = wbs.Open(tempFinalTemplateFilename);

            //Copy the template to the temporary outPut folder
            string newFinalFilename = Globals.General.OutputFileDate.ToString("MM.dd.yy") + "_Daily Workflow_Report_BAY";

            //Copy into final wb
            Worksheet wipSummaryChartWs = wipWb.Worksheets[Globals.TheBay.TemplateWorksheetNames.SummaryChart];
            Worksheet finalSummaryChartWs = finalWb.Worksheets["Summary Chart"];

            Range summaryChartRange = wipSummaryChartWs.Range[wipSummaryChartWs.Range["N1"],
                wipSummaryChartWs.Cells.SpecialCells(XlCellType.xlCellTypeLastCell)];

            summaryChartRange.Copy(finalSummaryChartWs.Range["N1"]);
            finalSummaryChartWs.Cells.Replace("#DIV/0!", 0);

            Worksheet wipInactiveWs = wipWb.Worksheets[Globals.TheBay.TemplateWorksheetNames.InactiveUpc];
            Worksheet finalInactiveWs = finalWb.Worksheets["Additional Color Sizes Report"];

            Range nosWsRange = wipInactiveWs.Range[wipInactiveWs.Range["C8"],
                wipInactiveWs.Cells.SpecialCells(XlCellType.xlCellTypeLastCell)];

            nosWsRange.Copy(finalInactiveWs.Range["C4"]);

            Worksheet wipDetailsWs = wipWb.Worksheets[Globals.TheBay.TemplateWorksheetNames.DetailsProduct];
            Worksheet finalDetailWs = finalWb.Worksheets["Workflow Details"];

            Range detailsWsRange = wipDetailsWs.Range[wipDetailsWs.Range["C8"],
                wipDetailsWs.Cells.SpecialCells(XlCellType.xlCellTypeLastCell)];

            detailsWsRange.Copy(finalDetailWs.Range["C4"]);

            finalWb.Save();

            excel.DisplayAlerts = false;
            wipWb.Close();
            finalWb.Close();

            Globals.TheBay.PathHolder.OutputFinalFile = tempFinalTemplateFilename;

            Globals.General.StateControl.FinalFilePrcoessSucessful = true;

            //After local file processing, copy to final destination (possible virutal LAN as destination)
            if (Globals.General.StateControl.FinalFilePrcoessSucessful)
            {
                LifeCycleFileUtilities.CopyFile(tempFinalTemplateFilename, StoredSettings.OutputDirectory.TheBay.WipOutputLocation, newFinalFilename);
            }
        }

        private static void InitializeFinalProperties()
        {
            tempFinalTemplateFilename =  LifeCycleFileUtilities.CopyFile(StoredSettings.TemplateLocations.TheBay.FinalTemplateLocation,
                 StoredSettings.OutputDirectory.TheBay.FinalOutputLocation, Guid.NewGuid().ToString());
        }
        

        //NosCombined
        private static void ProcessNosCombinedFile(string NosFileName)
        {
            try
            {
                string wsName = Globals.TheBay.TemplateWorksheetNames.NosCombined;
                Worksheet wsNos = wipWb.Worksheets[wsName];

                WorksheetCustomSettings nosSettings = new WorksheetCustomSettings();
                nosSettings = customSettings[wsName];

                object[,] data = DataImporter.ReadCsvFile(NosFileName, true);
                WorksheetOperation nosOperations = new WorksheetOperation(wsNos, nosSettings.HeaderRow);

                //load in data from csv files
                nosOperations.LoadDataAtCell<object>(data, nosSettings.HeaderRow + 1, 1);

                //modify data with special rules
                nosOperations.ChangeNumberInColumn("GROUP ID", "Divisionid", 27, 5);

                //Process formula
                FormulaRowHandler processWsFormula = new FormulaRowHandler(wsNos, nosSettings);
                processWsFormula.ProcessFormulaRow();

                nosOperations.CalculateAndPasteAsValues();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        //Inactive UPC
        private static void ProcessInactiveUPC(string InactiveUpcFilename)
        {
            try
            {
                string wsName = Globals.TheBay.TemplateWorksheetNames.InactiveUpc;
                string dataWsName = Globals.TheBay.TemplateWorksheetNames.InactiveUpcData;

                Worksheet wsInactive = wipWb.Worksheets[wsName];
                Worksheet wsInactiveData = wipWb.Worksheets[dataWsName];

                //reading customized settings
                WorksheetCustomSettings inactiveUpcSettings = new WorksheetCustomSettings();
                inactiveUpcSettings = customSettings[wsName];

                object[,] data = DataImporter.ReadCsvFile(InactiveUpcFilename);

                //Clear data in case there are some data left in the template
                WorksheetUtilities wsInactiveUtilities = new WorksheetUtilities(wsInactive);
                wsInactiveUtilities.ClearAllDataUnderRow(inactiveUpcSettings.HeaderRow + 1);

                //Start of Operations
                WorksheetOperation inactiveUpcOperations = new WorksheetOperation(wsInactive, inactiveUpcSettings.HeaderRow);
                WorksheetOperation inactiveUpcDataOperations = new WorksheetOperation(wsInactiveData);

                inactiveUpcDataOperations.LoadDataAtCell<object>(data, "A1"); //load data into UPC_Looker sheet
                wsInactive.Calculate();

                inactiveUpcDataOperations.ChangeNumberInColumn("GROUP ID", "Divisionid", 27, 5);

                //Process formula row
                FormulaRowHandler processWsFormula = new FormulaRowHandler(wsInactive, inactiveUpcSettings, true);
                processWsFormula.ProcessFormulaRow();

                //Add row reference
                inactiveUpcOperations.UpdateRowReferences("ROW_REFERENCE", 2);

                inactiveUpcOperations.CalculateAndPasteAsValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Details Product
        private static void ProcessProductDetails(string productDetailsFilename)
        {
            try
            {
                string wsName = Globals.TheBay.TemplateWorksheetNames.DetailsProduct;
                string dataWsName = Globals.TheBay.TemplateWorksheetNames.DetailsProductData;

                Worksheet wsDetailsProduct = wipWb.Worksheets[wsName];
                Worksheet wsDetailsProductData = wipWb.Worksheets[dataWsName];

                object[,] data = DataImporter.ReadCsvFile(productDetailsFilename);

                //reading customized settings
                WorksheetCustomSettings detailsProductSettings = new WorksheetCustomSettings();
                detailsProductSettings = customSettings[wsName];

                //Clear data in case there are some data left in the template
                WorksheetUtilities wsDetailsProductUtility = new WorksheetUtilities(wsDetailsProduct);
                wsDetailsProductUtility.ClearAllDataUnderRow(detailsProductSettings.HeaderRow);

                //Start of Operations
                WorksheetOperation detailsProductOperations = new WorksheetOperation(wsDetailsProduct, detailsProductSettings.HeaderRow);
                WorksheetOperation detailsProductDataOperations = new WorksheetOperation(wsDetailsProductData);

                detailsProductDataOperations.LoadDataAtCell<object>(data, "A1"); //load data into UPC_Looker sheet
                wsDetailsProduct.Calculate();

                detailsProductDataOperations.ChangeNumberInColumn("PIM PRODUCTS Group ID", "PIM PRODUCTS Divisionid", 27, 5); //Change GMM to
                //Process formula row
                FormulaRowHandler processWsFormula = new FormulaRowHandler(wsDetailsProduct, detailsProductSettings, true);
                processWsFormula.ProcessFormulaRow();
                detailsProductOperations.UpdateRowReferences("ROW_REFERENCE", 2);

                detailsProductOperations.CalculateAndPasteAsValues();

                detailsProductOperations.TheBaySpeicalRule1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //InventoryValue
        private static void ProcessInventoryValue(string inventoryValueFilename)
        {
            string wsName = Globals.TheBay.TemplateWorksheetNames.InventoryValue;

            //then send this file to process
            Worksheet wsInventoryValueWs = wipWb.Worksheets[wsName];

            //Read the inventory value file
            object[,] data = DataImporter.ReadBitReport(inventoryValueFilename, "DMM");

            //Beginning of operation
            WorksheetOperation inventoryValueOperations = new WorksheetOperation(wsInventoryValueWs);

            inventoryValueOperations.TheBaySpecialRule2(data);

        }

        //Update Pivot Tables
        private static void UpdatePivots()
        {
            wipWb.RefreshAll();

            //Worksheet pivots = wipWb.Worksheets[Globals.TheBay.TemplateWorksheetNames.Pivots];
            //PivotTables ptTables = pivots.PivotTables();
            //int count = ptTables.Count;
            //if (count > 0)
            //{
            //    for (int i = 1; i <= count; i++)
            //    {
            //        PivotTable pt = ptTables.Item(i);
            //        pt.RefreshTable();
            //    }
            //}

            //if (pivots != null)
            //{
            //    Marshal.ReleaseComObject(pivots);
            //    pivots = null;
            //}
        }

        //Update WF summary date
        private static void UpdateDate()
        {
            Worksheet wsSummaryChart = wipWb.Worksheets[Globals.TheBay.TemplateWorksheetNames.SummaryChart];
            wsSummaryChart.Range["N5"].Value2 = Globals.General.OutputFileDate;
        }
    }
}
