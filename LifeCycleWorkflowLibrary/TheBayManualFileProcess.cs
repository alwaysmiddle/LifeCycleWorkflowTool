using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LifeCycleWorkflowLibrary
{
    public static class TheBayManualFileProcess
    {
        private static string tempTemplateFileName { get; set; }
        private static Dictionary<string, WorksheetCustomSettings> customSettings { get; set; }
        public static void ProcessWipFiles()
        {
            InitializeProperties();
            //Generate the final output filename
            string newWipFilename = "PIM_" + Globals.General.OutputFileDate.ToString("M.d.yyyy") + "_Daily_Workflow_Report_BAY";

            //Running Main Processes
            TheBayManualFileProcess.ProcessNosCombinedFile(Properties.Settings.Default.TheBayManualDataLoadNosFile);
            //TheBayManualFileProcess.ProcessInactiveUPC(Properties.Settings.Default.TheBayManualDataLoadInactiveUpcFile);
            //TheBayManualFileProcess.ProcessProductDetails(Properties.Settings.Default.TheBayManualDataLoadNosFile);

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
        }

        public static void ProcessNosCombinedFile(string NosFileName)
        {
            FileInfo templateFile = new FileInfo(tempTemplateFileName);
            FileInfo dataFile = new FileInfo(NosFileName);
            using (ExcelPackage templatePackage = new ExcelPackage(templateFile))
            {
                var templateWb = templatePackage.Workbook;
                string wsName = Globals.TheBay.TemplateWorksheetNames.NosCombined;
                var wsNos = templateWb.Worksheets[wsName];
                //DataImporter.ReadCsvFile(NosFileName);
                
                WorksheetCustomSettings nosSettings = new WorksheetCustomSettings();
                nosSettings = customSettings[wsName];

                if (wsNos.Dimension.End.Row > nosSettings.HeaderRow)
                {
                    wsNos.Cells[nosSettings.HeaderRow + 1, 1, wsNos.Dimension.End.Row, wsNos.Dimension.End.Column].Clear();
                }

                var format = new ExcelTextFormat();
                format.Delimiter = ',';
                format.EOL = "\r";
                format.TextQualifier = '"';

                wsNos.Cells[nosSettings.HeaderRow + 1, 1].LoadFromText(dataFile, format);

                //DataImporter.WriteToExcelSheet(wsNos, wsNos.Cells[nosSettings.HeaderRow + 1, 1].Address);

                //FormulaRowHandler processWsFormula = new FormulaRowHandler(wsNos);
                //processWsFormula.ProcessFormulaRow(dt);

                templatePackage.Save();
            }

            //Process.Start(tempTemplateFileName);
        }

        public static bool ProcessInactiveUPC(string InactiveUpcFilename)
        {
            ////Input file validation
            //if (Globals.TheBayOutputWipFile == "" || Globals.TheBayOutputWipFile == null)
            //{
            //    //TODO Convert this to debug
            //    MessageBox.Show("The output file is not found, possibly due to copying error, or file permissions error");
            //    return false;
            //}

            //string wsName = Globals.TheBayTemplateWsNameInactiveUpc;
            //string dataWsName = Globals.TheBayTemplateWsNameInactiveUpcData;

            //XLWorkbook templateWb = new XLWorkbook(Globals.TheBayOutputWipFile);
            //templateWb.EventTracking = XLEventTracking.Disabled;
            //IXLWorksheet wsInactive = templateWb.Worksheet(wsName);
            //IXLWorksheet wsInactiveData = templateWb.Worksheet(dataWsName);
            //DataTable dt = DataTableImporter.ReadCsvFile(InactiveUpcFilename);

            ////reading customized settings
            //WorksheetCustomSettingsHolder allCustomSettings = new WorksheetCustomSettingsHolder();
            //allCustomSettings = WorksheetCustomSettingsHolder.Load();
            //WorksheetCustomSettings customSettings = new WorksheetCustomSettings();
            //customSettings = allCustomSettings.SettingsCollection[wsName];

            ////Load data into Inactive UPC data sheet
            //wsInactiveData.CellsUsed().Clear();

            //int columnPos = 1;
            //foreach (DataColumn dataCol in dt.Columns)
            //{
            //    wsInactiveData.Cell(1, columnPos).Value = dataCol.ColumnName;
            //    columnPos++;
            //}
            //wsInactiveData.Cell(2, 1).InsertData(dt);

            ////Process inactive UPC sheet from raw data.
            //if (wsInactive.LastRowUsed().RowNumber() > customSettings.HeaderRow)
            //{
            //    wsInactive.Range(wsInactive.Cell(customSettings.HeaderRow + 1, 1), wsInactive.LastCell()).Clear();
            //}

            //FormulaRowHandler processWsFormula = new FormulaRowHandler(wsInactive);
            //processWsFormula.ProcessFormulaRow(dt);

            //templateWb.Save();

            return false;
        }

        public static bool ProcessProductDetails(string productDetailsFilename)
        {
            ////Input file validation
            //if (Globals.TheBayOutputWipFile == "" || Globals.TheBayOutputWipFile == null)
            //{
            //    //TODO Convert this to debug
            //    MessageBox.Show("The output file is not found, possibly due to copying error, or file permissions error");
            //    return false;
            //}

            //string wsName = Globals.TheBayTemplateWsNameDetailsProduct;
            //string dataWsName = Globals.TheBayTemplateWsNameDetailsProductData;

            //XLWorkbook templateWb = new XLWorkbook(Globals.TheBayOutputWipFile);
            //templateWb.EventTracking = XLEventTracking.Disabled;
            //IXLWorksheet wsDetailsProduct = templateWb.Worksheet(wsName);
            //IXLWorksheet wsDetailsProductData = templateWb.Worksheet(dataWsName);
            //DataTable dt = DataTableImporter.ReadCsvFile(productDetailsFilename);

            ////reading customized settings
            //WorksheetCustomSettingsHolder allCustomSettings = new WorksheetCustomSettingsHolder();
            //allCustomSettings = WorksheetCustomSettingsHolder.Load();
            //WorksheetCustomSettings customSettings = new WorksheetCustomSettings();
            //customSettings = allCustomSettings.SettingsCollection[wsName];

            ////Load data into Inactive UPC data sheet
            //wsDetailsProductData.CellsUsed().Clear();

            //int columnPos = 1;
            //foreach (DataColumn dataCol in dt.Columns)
            //{
            //    wsDetailsProductData.Cell(1, columnPos).Value = dataCol.ColumnName;
            //    columnPos++;
            //}
            //wsDetailsProductData.Cell(2, 1).InsertData(dt);

            ////Process inactive UPC sheet from raw data.
            ////if (wsInactive.LastRowUsed().RowNumber() > customSettings.HeaderRow)
            ////{
            ////    wsInactive.Range(wsInactive.Cell(customSettings.HeaderRow + 1, 1), wsInactive.LastCell()).Clear();
            ////}

            ////FormulaRowHandler processWsFormula = new FormulaRowHandler(wsInactive);
            ////processWsFormula.ProcessFormulaRow(dt);

            //templateWb.Save();

            return false;
        }
    }
}
