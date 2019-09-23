using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace LifeCycleWorkflowLibrary
{
    public static class TheBayManualFileProcess
    {
        private static string tempTemplateFileName { get; set; }
        private static Dictionary<string, WorksheetCustomSettings> customSettings { get; set; }
        private static Excel.Application excel { get; set; }
        private static Workbook wipWb { get; set; }
        private static Workbook finalWb { get; set; }
        public static void ProcessWipFiles()
        {
            InitializeProperties();
            //Generate the final output filename
            string newWipFilename = "PIM_" + Globals.General.OutputFileDate.ToString("M.d.yyyy") + "_Daily_Workflow_Report_BAY";

            wipWb = excel.Workbooks.Open(tempTemplateFileName);
            //Running Main Processes
            try
            {
                excel.ScreenUpdating = false;
                excel.Calculation = Excel.XlCalculation.xlCalculationManual;
                excel.EnableEvents = false;
                excel.DisplayStatusBar = false;
                excel.PrintCommunication = false;    // Excel 2010+ only

                //TheBayManualFileProcess.ProcessNosCombinedFile(Properties.Settings.Default.TheBayManualDataLoadNosCombinedFile);
                //TheBayManualFileProcess.ProcessInactiveUPC(Properties.Settings.Default.TheBayManualDataLoadInactiveUpcFile);
                TheBayManualFileProcess.ProcessProductDetails(Properties.Settings.Default.TheBayManualDataLoadNosFile);

                excel.Visible = true;
            }
            catch
            {
                excel.Quit();
            }
            finally
            {
                excel.ScreenUpdating = true;
                excel.Calculation = Excel.XlCalculation.xlCalculationAutomatic;
                excel.EnableEvents = true;
                excel.DisplayStatusBar = true;
                excel.PrintCommunication = true;    // Excel 2010+ only

                excel.DisplayAlerts = false;
                excel.Quit();
                if (excel != null)
                {
                    Marshal.ReleaseComObject(excel);
                    excel = null;
                }
            }


            Globals.TheBay.PathHolder.OutputWipFile = tempTemplateFileName;
            Globals.General.StateControl.WipFileProcessSucessful = true;
        }

        public static void ProcessFinalFiles()
        {
            //Loading Final tempalte location saved in AppSetting
            //string path = Properties.Settings.Default.TheBayFinalTemplatePath;

            ////Copy the template to the desired outPut folder
            ////TODO Process the file locally first, then do the copy function afterwards
            //string newFinalFilename = lifeCycleDateTimePicker.Value.ToString("MM.dd.yyyy") + "_Daily_Workflow_Report_BAY";
            //string newFinalFullFilename = LifeCycleFileUtilities.CopyFile(path, Properties.Settings.Default.SaveLocationTheBayFinal, newFinalFilename);
            //Globals.TheBayOutputFinalFile = newFinalFullFilename;

            //Globals.FinalFilePrcoessSucessful = true;
        }
        private static void InitializeProperties()
        {
            //Generate temperary local file for faster processing
            tempTemplateFileName = LifeCycleFileUtilities.CopyFile(
                StoredSettings.TemplateLocations.TheBay.WipTempalteLocation, StoredSettings.OutputDirectory.TheBay.WipOutputLocation, Guid.NewGuid().ToString());

            //Load all customSettings
            WorksheetCustomSettingsHolder allCustomSettings = new WorksheetCustomSettingsHolder();
            allCustomSettings = WorksheetCustomSettingsHolder.Load();

            customSettings = new Dictionary<string, WorksheetCustomSettings>();
            customSettings = allCustomSettings.SettingsCollection;

            excel = new Excel.Application();
        }

        //NosCombined
        public static void ProcessNosCombinedFile(string NosFileName)
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
                
                wipWb.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                excel.Quit();
            }

}

        public static void ProcessInactiveUPC(string InactiveUpcFilename)
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

                wipWb.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                excel.Quit();
            }
        }

        public static void ProcessProductDetails(string productDetailsFilename)
        {
            try { 
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

                wipWb.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                excel.Quit();
            }
        }

        


    }
}
