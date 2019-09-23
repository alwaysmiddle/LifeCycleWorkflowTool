using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using Excel = Microsoft.Office.Interop.Excel;

namespace LifeCycleWorkflowLibrary
{
    public static class DataImporter
    {
        // Load a CSV file into an array of rows and columns.
        // Assume there may be blank lines but every line has
        // the same number of fields.
        public static object[,] ReadCsvFile(string filename, bool skipFirstLine = false)
        {
            List<string[]> allLines = new List<string[]>();
            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                bool firstLine = true;

                while (!parser.EndOfData)
                {
                    string[] line = parser.ReadFields();
                    if(line != null && line.Length > 0)
                    {
                        if(skipFirstLine && firstLine)
                        {
                            firstLine = false;
                        }
                        else
                        {
                            allLines.Add(line);
                        }
                    }
                }
            }

            // See how many rows and columns there are.
            int num_rows = allLines.Count;
            int num_cols = allLines[0].Length;

            // Allocate the data array.
            object[,] values = new object[num_rows, num_cols];

            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = allLines[r][c];
                }
            }

            // Return the values.
            return values;
        }



        /// <summary>
        /// BIT report formatting is altered on server side, this class target a value to search for then convert rest of the report into single delimited csv format.
        /// Then parsing the single delimieted csv file into datatable.
        /// </summary>
        /// <param name="filePath">Excel file path that contains information from BIT report.</param>
        /// <param name="findThisOnSheet">Look for this value on first sheet of passed workbook.</param>
        /// <returns></returns>
        public static object[,] ReadBitReport(string filePath, string findThisOnSheet)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbooks excelbooks = app.Workbooks;
            Excel.Workbook wb = excelbooks.Open(filePath);
            Excel.Worksheet ws = wb.Worksheets[1];

            //find a value on sheet, delete every row before excluding found cell's row.
            WorksheetUtilities wsUtilities = new WorksheetUtilities(ws);
            Excel.Range firstCellFound = wsUtilities.FindCellBasedOnValue<string>(findThisOnSheet);

            if (firstCellFound != null)
            {
                if (firstCellFound.Row > 1)
                {
                    ws.Range[ws.Cells[1, 1], firstCellFound.Offset[-1, 0]].EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                }
            }

            //Generate Unique filepath
            //Ref: https://stackoverflow.com/questions/581570/how-can-i-create-a-temp-file-with-a-specific-extension-with-net
            string csvFileName = Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";

            wb.SaveAs(csvFileName, Excel.XlFileFormat.xlCSVWindows);

            var oldLines = File.ReadAllLines(csvFileName);
            var newLines = oldLines.Where(line => line.IndexOf("Total", StringComparison.OrdinalIgnoreCase) < 0);
            List<string> cleansedNewLines = new List<string>();

            foreach (var line in newLines)
            {
                var temp = line.Replace(",,", ",");
                cleansedNewLines.Add(temp);
            }

            File.WriteAllLines(csvFileName, cleansedNewLines);

            object[,] data = ReadCsvFile(csvFileName);

            File.Delete(csvFileName);

            return data;
        }
    }
}
