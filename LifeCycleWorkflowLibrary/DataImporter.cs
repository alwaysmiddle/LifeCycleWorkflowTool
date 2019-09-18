using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;

namespace LifeCycleWorkflowLibrary
{
    class DataImporter
    {
        private static List<string[]> csvList { get; set; }
        private static bool dataIsRead = false;

        public static void ReadCsvFile(string filename)
        {
            csvList = new List<string[]>();
            
            //TODO add error logging
            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.TrimWhiteSpace = true;

                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] thisline = parser.ReadFields();
                    csvList.Add(thisline);
                }
            }

            if(csvList.Count > 0)
            {
                dataIsRead = true;
            }
        }

        public static void WriteToExcelSheet(ExcelWorksheet worksheet, string startAddress, bool importHeader = true)
        {
            if (dataIsRead)
            {
                int row = worksheet.Cells[startAddress].Start.Row;
                int col = worksheet.Cells[startAddress].Start.Column;

                foreach (var line in csvList)
                {
                    col = worksheet.Cells[startAddress].Start.Column;
                    foreach (var cell in line)
                    {
                        worksheet.Cells[row, col].Value = cell;
                        col++;
                    }
                    row++;
                }
            }
        }
    }
}
