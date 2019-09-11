using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace LifeCycleWorkflowLibrary
{
    public static class TheBayManualFileProcess
    {
        public static bool ProcessNosCombinedFile(string NosFileName)
        {
            //Input file validation
            if (Globals.TheBayOutputWipFile == "" || Globals.TheBayOutputWipFile == null)
            {
                //TODO Convert this to debug
                MessageBox.Show("The output file is not found, possibly due to copying error, or file permissions error");
                return false;
            }

            string wsName = Globals.TheBayTemplateWsNameNosCombined;

            XLWorkbook templateWb = new XLWorkbook(Globals.TheBayOutputWipFile);
            IXLWorksheet wsNos = templateWb.Worksheet(wsName);
            DataTable dt = DataTableImporter.ReadCsvFile(NosFileName);

            //reading customized settings
            WorksheetCustomSettingsHolder allCustomSettings = new WorksheetCustomSettingsHolder();
            allCustomSettings = WorksheetCustomSettingsHolder.Load();
            WorksheetCustomSettings customSettings = new WorksheetCustomSettings();
            customSettings = allCustomSettings.SettingsCollection[wsName];

            if (wsNos.LastRowUsed().RowNumber() > customSettings.HeaderRow)
            {
                wsNos.Range(wsNos.Cell(customSettings.HeaderRow+1, 1), wsNos.LastCell()).Clear();
            }

            wsNos.Cell(customSettings.HeaderRow + 1, 1).InsertData(dt.AsEnumerable());

            FormulaRowHandler processWsFormula = new FormulaRowHandler(wsNos);
            processWsFormula.ProcessFormulaRow(dt);

            templateWb.Save();

            return false;
        }

        public static bool ProcessInactiveUPC(string InactiveUpcFilename)
        {
            //Input file validation
            if (Globals.TheBayOutputWipFile == "" || Globals.TheBayOutputWipFile == null)
            {
                //TODO Convert this to debug
                MessageBox.Show("The output file is not found, possibly due to copying error, or file permissions error");
                return false;
            }

            string wsName = Globals.TheBayTemplateWsNameInactiveUpc;
            string dataWsName = Globals.TheBayTemplateWsNameInactiveUpcData;

            XLWorkbook templateWb = new XLWorkbook(Globals.TheBayOutputWipFile);
            IXLWorksheet wsInactive = templateWb.Worksheet(wsName);
            IXLWorksheet wsInactiveData = templateWb.Worksheet(dataWsName);
            DataTable dt = DataTableImporter.ReadCsvFile(InactiveUpcFilename);

            //reading customized settings
            WorksheetCustomSettingsHolder allCustomSettings = new WorksheetCustomSettingsHolder();
            allCustomSettings = WorksheetCustomSettingsHolder.Load();
            WorksheetCustomSettings customSettings = new WorksheetCustomSettings();
            customSettings = allCustomSettings.SettingsCollection[wsName];

            //Load data into Inactive UPC data sheet
            wsInactiveData.CellsUsed().Clear();

            int columnPos = 1;
            foreach (DataColumn dataCol in dt.Columns)
            {
                wsInactiveData.Cell(1, columnPos).Value = dataCol.ColumnName;
                columnPos++;
            }
            wsInactiveData.Cell(2, 1).InsertData(dt);

            //Process inactive UPC sheet from raw data.
            if (wsInactive.LastRowUsed().RowNumber() > customSettings.HeaderRow)
            {
                wsInactive.Range(wsInactive.Cell(customSettings.HeaderRow + 1, 1), wsInactive.LastCell()).Clear();
            }

            FormulaRowHandler processWsFormula = new FormulaRowHandler(wsInactive);
            processWsFormula.ProcessFormulaRow(dt);

            templateWb.Save();

            return false;
        }

        public static bool ProcessProductDetails(string productDetailsFilename)
        {
            //Input file validation
            if (Globals.TheBayOutputWipFile == "" || Globals.TheBayOutputWipFile == null)
            {
                //TODO Convert this to debug
                MessageBox.Show("The output file is not found, possibly due to copying error, or file permissions error");
                return false;
            }

            string wsName = Globals.TheBayTemplateWsNameDetailsProduct;
            string dataWsName = Globals.TheBayTemplateWsNameDetailsProductData;

            XLWorkbook templateWb = new XLWorkbook(Globals.TheBayOutputWipFile);
            IXLWorksheet wsDetailsProduct = templateWb.Worksheet(wsName);
            IXLWorksheet wsDetailsProductData = templateWb.Worksheet(dataWsName);
            DataTable dt = DataTableImporter.ReadCsvFile(productDetailsFilename);

            //reading customized settings
            WorksheetCustomSettingsHolder allCustomSettings = new WorksheetCustomSettingsHolder();
            allCustomSettings = WorksheetCustomSettingsHolder.Load();
            WorksheetCustomSettings customSettings = new WorksheetCustomSettings();
            customSettings = allCustomSettings.SettingsCollection[wsName];

            //Load data into Inactive UPC data sheet
            wsDetailsProductData.CellsUsed().Clear();

            int columnPos = 1;
            foreach (DataColumn dataCol in dt.Columns)
            {
                wsDetailsProductData.Cell(1, columnPos).Value = dataCol.ColumnName;
                columnPos++;
            }
            wsDetailsProductData.Cell(2, 1).InsertData(dt);

            //Process inactive UPC sheet from raw data.
            //if (wsInactive.LastRowUsed().RowNumber() > customSettings.HeaderRow)
            //{
            //    wsInactive.Range(wsInactive.Cell(customSettings.HeaderRow + 1, 1), wsInactive.LastCell()).Clear();
            //}

            //FormulaRowHandler processWsFormula = new FormulaRowHandler(wsInactive);
            //processWsFormula.ProcessFormulaRow(dt);

            templateWb.Save();

            return false;
        }
    }
}
