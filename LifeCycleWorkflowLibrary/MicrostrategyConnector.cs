using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LifeCycleWorkflowLibrary
{
    /// <summary>
    /// This class is repsonsible to transform the data from bay microstrategy report (BIT) into datatable format.
    /// </summary>
    public static class MicrostrategyConnector
    {
        /// <summary>
        /// BIT report formatting is altered on server side, this class target a value to search for then convert rest of the report into single delimited csv format.
        /// Then parsing the single delimieted csv file into datatable.
        /// </summary>
        /// <param name="filePath">Excel file path that contains information from BIT report.</param>
        /// <param name="findThisOnSheet">Look for this value on first sheet of passed workbook.</param>
        /// <returns></returns>
        public static DataTable ReadBitReport(string filePath, string findThisOnSheet)
        {
            DataTable dt = new DataTable();

            XLWorkbook wb = new XLWorkbook(filePath);
            IXLWorksheet ws = wb.Worksheet(1);

            var cellsFound = ws.Search(findThisOnSheet, System.Globalization.CompareOptions.IgnoreCase);
            IXLCell firstCellFound = cellsFound.First();

            //Generate Unique filepath
            //Ref: https://stackoverflow.com/questions/581570/how-can-i-create-a-temp-file-with-a-specific-extension-with-net
            string csvFileName = Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";

            var lastCellAddress = ws.RangeUsed().LastCell().Address;
            File.WriteAllLines(csvFileName, ws.Rows(firstCellFound.Address.RowNumber, lastCellAddress.RowNumber)
                .Select(r => string.Join(",", r.Cells(1, lastCellAddress.ColumnNumber)
                        .Select(cell =>
                        {
                            var cellValue = cell.GetValue<string>();
                            return cellValue.Contains(",") ? $"\"{cellValue}\"" : cellValue;
                        }
                        ))));


            var oldLines = System.IO.File.ReadAllLines(csvFileName);
            var newLines = oldLines.Where(line => line.IndexOf("Total", StringComparison.OrdinalIgnoreCase) < 0);
            List<string> cleansedNewLines = new List<string>();

            foreach (var line in newLines)
            {
                var temp = line.Replace(",,", ",");
                cleansedNewLines.Add(temp);
            }

            File.WriteAllLines(csvFileName, cleansedNewLines);
            dt = DataTableImporter.ReadCsvFile(csvFileName);

            File.Delete(csvFileName);
            return dt;
        }
    }
}
