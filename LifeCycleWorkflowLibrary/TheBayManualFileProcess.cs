using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LifeCycleWorkflowLibrary
{
    public static class TheBayManualFileProcess
    {
        private static string tempWipTemplateFileName { get; set; }
        private static string tempFinalTemplateFilename { get; set; }
        private static Dictionary<string, WorksheetCustomSettings> customSettings { get; set; }
        private static Microsoft.Office.Interop.Excel.Application excel { get; set; }
        private static Workbook wipWb { get; set; }
        private static Workbook finalWb { get; set; }
        private static Dictionary<string, string> processedRanges {get; set;}

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

                excel.Visible = false;

                TheBayManualFileProcess.ProcessProductDetails(Properties.Settings.Default.TheBayManualDataLoadNosFile);
                TheBayManualFileProcess.ProcessInactiveUPC(Properties.Settings.Default.TheBayManualDataLoadInactiveUpcFile);
                TheBayManualFileProcess.ProcessNosCombinedFile(Properties.Settings.Default.TheBayManualDataLoadNosCombinedFile); 
                TheBayManualFileProcess.ProcessInventoryValue(Properties.Settings.Default.TheBayManualDataLoadInventoryAmountFile);
                excel.Calculate();
                TheBayManualFileProcess.ConvertToValuesOnly();

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
        }

        //==========FINAL============
        public static void ProcessFinalFiles()
        {
            InitializeFinalProperties();

            //Copy the template to the temporary outPut folder
            string newFinalFilename = Globals.General.OutputFileDate.ToString("MM.dd.yy") + "_Daily Workflow_Report_BAY";

            Workbooks wbs = excel.Workbooks;
            wipWb = wbs.Open(tempWipTemplateFileName);
            finalWb = wbs.Open(tempFinalTemplateFilename);

            try
            {
                //excel.ScreenUpdating = false;
                excel.Calculation = XlCalculation.xlCalculationManual;
                //excel.EnableEvents = false;
                //excel.DisplayStatusBar = false;
                excel.PrintCommunication = false;    // Excel 2010+ only
                excel.DisplayAlerts = false;

                CopySummaryChart();

                CopyDetailsProduct();

                CopyInactiveUpc();

                CopyNosCombined();

                finalWb.Final = true;
                finalWb.Save();
                
                excel.DisplayAlerts = false;
                wipWb.Close(0);
                finalWb.Close(0);
                wbs.Close();

                Globals.TheBay.PathHolder.OutputFinalFile = tempFinalTemplateFilename;

                Globals.General.StateControl.FinalFilePrcoessSucessful = true;

                //After local file processing, copy to final destination (possible virutal LAN as destination)
                if (Globals.General.StateControl.FinalFilePrcoessSucessful)
                {
                    LifeCycleFileUtilities.CopyFile(tempFinalTemplateFilename,
                        StoredSettings.OutputDirectory.TheBay.FinalOutputLocation, newFinalFilename);
                }
            }
            catch
            {
                //TODO add this to error log, file deletion failed.
            }
            finally
            {
                excel.ScreenUpdating = true;
                excel.EnableEvents = true;
                excel.DisplayStatusBar = true;
                excel.PrintCommunication = true;    // Excel 2010+ only

                File.Delete(Globals.TheBay.PathHolder.OutputFinalFile);
                File.Delete(Globals.TheBay.PathHolder.OutputWipFile);
                excel.Quit();

                if (wipWb != null)
                {
                    Marshal.ReleaseComObject(wipWb);
                    wipWb = null;
                }

                if (finalWb != null)
                {
                    Marshal.ReleaseComObject(finalWb);
                    finalWb = null;
                }

                if (wbs != null)
                {
                    Marshal.ReleaseComObject(wbs);
                    wbs = null;
                }

                if (excel != null)
                {
                    Marshal.ReleaseComObject(excel);
                    excel = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();

                KillSpecificExcelFileProcess(tempFinalTemplateFilename);
            }
        }

        private static void InitializeWipProperties()
        {
            processedRanges = null;
            processedRanges = new Dictionary<string, string>();
            //Generate temperary local file for faster processing
            tempWipTemplateFileName = LifeCycleFileUtilities.CopyFile(
                StoredSettings.TemplateLocations.TheBay.WipTempalteLocation, Path.GetTempPath(), Guid.NewGuid().ToString());

            //Load all customSettings
            WorksheetCustomSettingsHolder allCustomSettings = new WorksheetCustomSettingsHolder();
            allCustomSettings = WorksheetCustomSettingsHolder.Load();

            customSettings = new Dictionary<string, WorksheetCustomSettings>();
            customSettings = allCustomSettings.SettingsCollection;

            excel = new Microsoft.Office.Interop.Excel.Application();
        }

        private static void InitializeFinalProperties()
        {
            processedRanges = null;
            processedRanges = new Dictionary<string, string>();
            tempFinalTemplateFilename =  LifeCycleFileUtilities.CopyFile(StoredSettings.TemplateLocations.TheBay.FinalTemplateLocation,
                 Path.GetTempPath(), Guid.NewGuid().ToString());
        }
        

        //========================Wip Implementation============================

        //NosCombined
        private static void ProcessNosCombinedFile(string NosFileName)
        {
            try
            {
                string wsName = Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.NosCombined;
                Worksheet wsNos = wipWb.Worksheets[wsName];

                WorksheetCustomSettings nosSettings = new WorksheetCustomSettings();
                nosSettings = customSettings[wsName];

                object[,] data = DataImporter.ReadCsvFile(NosFileName, true);
                WorksheetOperation nosOperations = new WorksheetOperation(wsNos, nosSettings.HeaderRow);

                //load in data from csv files
                nosOperations.LoadDataAtCell<object>(data, nosSettings.HeaderRow + 1, 1);

                //modify data with special rules
                nosOperations.ChangeNumberInColumn("GROUP ID", "Divisionid", 27, 5);
                nosOperations.ChangeNumberInTwoColumn("Divisionid", "Group ID", 7, 28, 5, 28);

                //Process formula
                FormulaRowHandler processWsFormula = new FormulaRowHandler(wsNos, nosSettings);
                processWsFormula.ProcessFormulaRow();

                nosOperations.AddToValueList(processedRanges);

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
                string wsName = Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.InactiveUpc;
                string dataWsName = Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.InactiveUpcData;

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

                inactiveUpcDataOperations.ChangeNumberInColumn("PIM PRODUCTS Group ID", "PIM PRODUCTS Divisionid", 27, 5);
                inactiveUpcDataOperations.ChangeNumberInTwoColumn("PIM PRODUCTS Divisionid", "PIM PRODUCTS Group ID", 7, 28, 5, 28);

                //Process formula row
                FormulaRowHandler processWsFormula = new FormulaRowHandler(wsInactive, inactiveUpcSettings, true);
                processWsFormula.ProcessFormulaRow();

                //Add row reference
                inactiveUpcOperations.UpdateRowReferences("ROW_REFERENCE", 2);

                inactiveUpcOperations.AddToValueList(processedRanges);
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
                string wsName = Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.DetailsProduct;
                string dataWsName = Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.DetailsProductData;

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
                wsDetailsProduct.Calculate();//this calculation is for the row finding formula to update

                //reclassification
                detailsProductDataOperations.ChangeNumberInColumn("PIM PRODUCTS Group ID", "PIM PRODUCTS Divisionid", 27, 5);
                detailsProductDataOperations.ChangeNumberInTwoColumn("PIM PRODUCTS Divisionid", "PIM PRODUCTS Group ID", 7, 28, 5, 28);

                //Process formula row
                FormulaRowHandler processWsFormula = new FormulaRowHandler(wsDetailsProduct, detailsProductSettings, true);
                processWsFormula.ProcessFormulaRow();
                detailsProductOperations.UpdateRowReferences("ROW_REFERENCE", 2);

                detailsProductOperations.AddToValueList(processedRanges);

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
            string wsName = Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.InventoryValue;

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
        }

        //Update WF summary date
        private static void UpdateDate()
        {
            Worksheet wsSummaryChart = wipWb.Worksheets[Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.SummaryChart];
            wsSummaryChart.Range["N5"].Value2 = Globals.General.OutputFileDate;
        }

        //========================Final Implementation============================

        private static void CopySummaryChart()
        {
            //Copy Summary Chart
            string wipWsName = Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.SummaryChart;
            string finalWsName = Globals.TheBay.TemplateWorksheetNames.FinalTemplateNames.SummaryChart;

            Worksheet wipSummaryChartWs = wipWb.Worksheets[wipWsName];
            Worksheet finalSummaryChartWs = finalWb.Worksheets[finalWsName];

            WorksheetUtilities wipSummaryChartWsUtilities = new WorksheetUtilities(wipSummaryChartWs);

            //Copy the date
            finalSummaryChartWs.Range["N5"].Value2 = wipSummaryChartWs.Range["N5"].Value2;

            //Copy the WF summary, massive table
            Range summaryChartRange = wipSummaryChartWsUtilities.DefineCurrentAreaRange(wipSummaryChartWs.Range["N8"]);
            summaryChartRange.Value2 = summaryChartRange.Value2;
            summaryChartRange.Copy(finalSummaryChartWs.Range["N8"]);

            //Copy the chart below the main chart, small table
            Range reportChartRange = wipSummaryChartWsUtilities.DefineCurrentAreaRange(wipSummaryChartWs.Range["N78"]);
            reportChartRange.Value2 = reportChartRange.Value2;
            summaryChartRange.Copy(finalSummaryChartWs.Range["N78"]);

            try
            {
                finalSummaryChartWs.UsedRange.Replace("#DIV/0!", 0);
            }
            catch
            {
                //TODO write error to logfile that replacement of div/0 failed.
            }
        }

        private static void CopyDetailsProduct()
        {
            string wipWsName = Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.DetailsProduct;
            string finalWsName = Globals.TheBay.TemplateWorksheetNames.FinalTemplateNames.WorkflowDetails;

            Worksheet wipDetailsWs = wipWb.Worksheets[wipWsName];
            Worksheet finalDetailWs = finalWb.Worksheets[finalWsName];

            WorksheetOperation wipDetailsWsOperation = new WorksheetOperation(wipDetailsWs, customSettings[wipWsName].HeaderRow);
            Range copyFromCell = wipDetailsWs.Cells[customSettings[wipWsName].HeaderRow + 1, 1];
            wipDetailsWsOperation.CopyFromCurrentRegionToDestination(copyFromCell, finalDetailWs.Range["A4"]);
        }

        private static void CopyInactiveUpc()
        {
            string wipWsName = Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.InactiveUpc;
            string finalWsName = Globals.TheBay.TemplateWorksheetNames.FinalTemplateNames.AdditionalColor;

            Worksheet wipInactiveWs = wipWb.Worksheets[wipWsName];
            Worksheet finalInactiveWs = finalWb.Worksheets[finalWsName];

            WorksheetOperation wipInactiveUpcOperation = new WorksheetOperation(wipInactiveWs, customSettings[wipWsName].HeaderRow);
            WorksheetUtilities finalInactiveUpcUtilities = new WorksheetUtilities(finalInactiveWs);
            Range copyFromCell = wipInactiveWs.Cells[customSettings[wipWsName].HeaderRow + 1, 1];

            wipInactiveUpcOperation.CopyFromCurrentRegionToDestination(copyFromCell, finalInactiveWs.Range["A4"]);

            Range headerRange = finalInactiveWs.Range[finalInactiveWs.Cells[3, 1], 
                finalInactiveWs.Cells[3, finalInactiveWs.UsedRange.SpecialCells(XlCellType.xlCellTypeLastCell).Column]];

            Range findCell = finalInactiveUpcUtilities.FindCellBasedOnValue("DUPES REMOVED", headerRange.Address, XlLookAt.xlWhole);

            if(findCell != null)
            {
                findCell.EntireColumn.Delete(XlDeleteShiftDirection.xlShiftToLeft);
            }
        }

        private static void CopyNosCombined()
        {
            string wipWsName = Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.NosCombined;
            string finalWsName = Globals.TheBay.TemplateWorksheetNames.FinalTemplateNames.NosCombined;

            Worksheet wipInactiveWs = wipWb.Worksheets[wipWsName];
            Worksheet finalInactiveWs = finalWb.Worksheets[finalWsName];

            WorksheetOperation wipInactiveUpcOperation = new WorksheetOperation(wipInactiveWs, customSettings[wipWsName].HeaderRow);
            Range copyFromCell = wipInactiveWs.Cells[customSettings[wipWsName].HeaderRow, 1];

            wipInactiveUpcOperation.CopyFromCurrentRegionToDestination(copyFromCell, finalInactiveWs.Range["A1"]);
        }

        private static void ConvertToValuesOnly()
        {
            foreach(KeyValuePair<string, string> item in processedRanges)
            {
                Worksheet tempWs = wipWb.Worksheets[item.Key];
                tempWs.Range[item.Value].Value2 = tempWs.Range[item.Value].Value2;

                if (tempWs != null)
                {
                    Marshal.ReleaseComObject(tempWs);
                    tempWs = null;
                }
            }
        }

        private static void KillSpecificExcelFileProcess(string excelFileName)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;

            foreach (var process in processes)
            {
                if (process.MainWindowTitle == "Microsoft Excel - " + excelFileName)
                    process.Kill();
            }
        }
    }
}
