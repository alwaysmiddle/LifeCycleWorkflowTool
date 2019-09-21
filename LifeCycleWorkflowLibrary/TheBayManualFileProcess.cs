using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

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
                excel.Visible = true;
                //TheBayManualFileProcess.ProcessNosCombinedFile(Properties.Settings.Default.TheBayManualDataLoadNosCombinedFile);
                TheBayManualFileProcess.ProcessInactiveUPC(Properties.Settings.Default.TheBayManualDataLoadInactiveUpcFile);
                //TheBayManualFileProcess.ProcessProductDetails(Properties.Settings.Default.TheBayManualDataLoadNosFile);
            }
            catch
            {
                excel.Quit();
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
                WorksheetUtilities wsNosUtility = new WorksheetUtilities(wsNos);

                object[,] data = DataImporter.ReadCsvFile(NosFileName, true);
                
                WorksheetCustomSettings nosSettings = new WorksheetCustomSettings();
                nosSettings = customSettings[wsName];

                //clear old data
                wsNosUtility.ClearAllDataUnderRow(nosSettings.HeaderRow);

                //load in data from csv files
                wsNosUtility.WriteArrayToCell<object>(data, nosSettings.HeaderRow + 1, 1);

                FormulaRowHandler processWsFormula = new FormulaRowHandler(wsNos, nosSettings);
                processWsFormula.ProcessFormulaRow();

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
                WorksheetUtilities wsInactiveUtility = new WorksheetUtilities(wsInactive);
                WorksheetUtilities wsInactiveDataUtility = new WorksheetUtilities(wsInactiveData);

                object[,] data = DataImporter.ReadCsvFile(InactiveUpcFilename);

                //reading customized settings
                WorksheetCustomSettings inactiveUpcSettings = new WorksheetCustomSettings();
                inactiveUpcSettings = customSettings[wsName];

                //Clear data in case there are some data left in the template
                wsInactiveData.UsedRange.Delete();
                wsInactiveUtility.ClearAllDataUnderRow(inactiveUpcSettings.HeaderRow);

                //load data in
                wsInactiveDataUtility.WriteArrayToCell<object>(data, "A1");

                //Process formula row
                FormulaRowHandler processWsFormula = new FormulaRowHandler(wsInactive, inactiveUpcSettings, true);
                processWsFormula.ProcessFormulaRow();

                //SpecialRules

                wipWb.Save();
            }catch(Exception ex)
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
                WorksheetUtilities wsDetailsProductUtility = new WorksheetUtilities(wsDetailsProduct);
                WorksheetUtilities wsDetailsProductDataUtility = new WorksheetUtilities(wsDetailsProductData);

                object[,] data = DataImporter.ReadCsvFile(productDetailsFilename);

                //reading customized settings
                WorksheetCustomSettings detailsProductSettings = new WorksheetCustomSettings();
                detailsProductSettings = customSettings[wsName];

                //Load data into Inactive UPC data sheet
                wsDetailsProductData.UsedRange.Delete();
                wsDetailsProductUtility.ClearAllDataUnderRow(detailsProductSettings.HeaderRow);

                wsDetailsProductDataUtility.WriteArrayToCell<object>(data, "A1");

                //Process formula row
                FormulaRowHandler processWsFormula = new FormulaRowHandler(wsDetailsProduct, detailsProductSettings, true);
                processWsFormula.ProcessFormulaRow();

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
