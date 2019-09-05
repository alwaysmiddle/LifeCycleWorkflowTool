using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var lastCellAddress = worksheet.RangeUsed().LastCell().Address;
            File.WriteAllLines(csvFileName, worksheet.Rows(1, lastCellAddress.RowNumber)
                .Select(r => string.Join(",", r.Cells(1, lastCellAddress.ColumnNumber)
                        .Select(cell =>
                        {
                            var cellValue = cell.GetValue<string>();
                            return cellValue.Contains(",") ? $"\"{cellValue}\"" : cellValue;
                        }
                        ))));

            return dt;
        }
    }
}
