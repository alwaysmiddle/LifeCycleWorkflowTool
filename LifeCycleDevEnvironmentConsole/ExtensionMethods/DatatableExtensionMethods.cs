using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.ExtensionMethods
{
    public static class DatatableExtensionMethods
    {
        /// <summary>
        /// This method is responsible for writing a Datatable to a cell on any worksheet passed. 
        /// The table will be written as is, with all the contents continguously written to right and downward direction from the cell passed.
        /// </summary>
        public static void WriteToExcelSheets(this System.Data.DataTable dt, Worksheet ws, string cellAddress, Boolean writeHeaderRow = true)
        {
            if (dt.Rows.Count == 0 || dt.Columns.Count == 0)
            {
                throw new ArgumentException("DataTable passed is empty");
            }

            // Allocate the data array.
            object[,] values = new object[dt.Rows.Count, dt.Columns.Count];

            // Load the array.
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    values[r, c] = dt.Rows[r].ItemArray[c];
                }
            }

            int cellRow = ws.Range[cellAddress].Row;
            int cellCol = ws.Range[cellAddress].Column;

            if (writeHeaderRow)
            {
                string[,] headers = new string[1, dt.Columns.Count];

                int i = 0;

                foreach (DataColumn col in dt.Columns)
                {
                    headers[0, i] = col.ColumnName.ToString();
                    i++;
                }

                ws.Cells[cellRow, cellCol].Resize[1, dt.Columns.Count].Value2 = headers;
                ws.Cells[cellRow + 1, cellCol].Resize[dt.Rows.Count, dt.Columns.Count].Value2 = values;
            }
            else
            {
                ws.Cells[cellRow, cellCol].Resize[dt.Rows.Count, dt.Columns.Count].Value2 = values;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetValueInColumnBasedOnOneReferenceColumn<T>
            (this System.Data.DataTable dt, string refColumnName, string baseColumnName, T valueToRef, T valueToSet)
        {
            bool caseSensitivity = dt.CaseSensitive;
            dt.CaseSensitive = false;

            if (!dt.Columns.Contains(refColumnName)) throw new ArgumentException(string.Format("{0} does not exist inside this datatable.", refColumnName));
            if (!dt.Columns.Contains(baseColumnName)) throw new ArgumentException(string.Format("{0} does not exist inside this datatable.", baseColumnName));

            System.Data.DataRow[] groupRows = dt.Select(string.Format("{0} = {1}", refColumnName, valueToRef));
            if (groupRows != null)
            {
                foreach (System.Data.DataRow row in groupRows)
                {
                    row[dt.Columns[baseColumnName].Ordinal] = valueToSet;
                }
            }

            dt.CaseSensitive = caseSensitivity;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetValueInColumnBasedOnTwoReferenceColumn<T>(this System.Data.DataTable dt)
        {

        }
    }
}
