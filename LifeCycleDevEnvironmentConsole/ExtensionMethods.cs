using Microsoft.Office.Interop.Excel;
using System;
using System.Data;

namespace LifeCycleDevEnvironmentConsole
{
    /// <summary>
    /// This is the extension class for various components needed for workflow project.
    /// Extension methods are modeled after existing .net types for this specific project only.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// This method is responsible for writing a Datatable to a cell on any worksheet passed. 
        /// The table will be written as is, with all the contents continguously written to right and downward direction from the cell passed.
        /// </summary>
        public static void WriteToExcelSheets(this System.Data.DataTable dt, Worksheet ws, string cellAddress, Boolean writeHeaderRow = true)
        {
            if(dt.Rows.Count == 0 || dt.Columns.Count == 0)
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
        /// Deletes all rows under specified row, not including that row.
        /// </summary>
        public static void ClearAllDataUnderRow(this Worksheet ws, int startUnderRow)
        {
            Range lastCell = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell);
            if (lastCell.Row > startUnderRow)
            {
                ws.Range["A" + startUnderRow + 1, lastCell].Delete(XlDeleteShiftDirection.xlShiftUp);
            }
        }

        /// <summary>
        /// Converts all rows under specified row into values only.
        /// </summary>
        public static void ConvertAllDataUnderRowToValues(this Worksheet ws, int startUnderRow = 1)
        {
            Range lastCell = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell);

            if(lastCell.Row > startUnderRow)
            {
                ws.Range["A" + startUnderRow + 1, lastCell].Value2 = ws.Range["A" + startUnderRow + 1, lastCell].Value2;
            }
        }

        public static void WriteArrayToCell<T>(this Worksheet ws, T[,] Array2D, string CellAddress)
        {
            int rowIncrement = Array2D.GetLength(0);
            int colIncrement = Array2D.GetLength(1);

            int cellRow = ws.Range[CellAddress].Row;
            int cellCol = ws.Range[CellAddress].Column;
            
            ws.Cells[cellRow, cellCol].Resize[rowIncrement, colIncrement].Value2 = Array2D;
        }

        public static void WriteArrayToCell<T>(this Worksheet ws, T[,] Array2D, int RowNumber, int ColumnNumber)
        {
            int rowIncrement = Array2D.GetLength(0);
            int colIncrement = Array2D.GetLength(1);

            ws.Cells[RowNumber, ColumnNumber].Resize[rowIncrement, colIncrement].Value2 = Array2D;
        }

        public static Range FindColumnInHeaderRow<T>(this Worksheet ws, T searchValue, int rowOfHeaders, XlLookAt matchFullCell = XlLookAt.xlPart)
        {

            Range cellToSearch = null;
            Range lastCell = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell);

            Range headerRange = ws.Range["A" + rowOfHeaders, ws.Cells[rowOfHeaders, lastCell.Column]];
            cellToSearch = headerRange.Find(
                What: searchValue,
                LookIn: XlFindLookIn.xlValues,
                LookAt: matchFullCell,
                SearchOrder: XlSearchOrder.xlByRows,
                SearchDirection: XlSearchDirection.xlNext
                );

            if (lastCell.Row > rowOfHeaders)
            {
                return ws.Range[cellToSearch, ws.Cells[lastCell.Row, cellToSearch.Column]];
            }
            else
            {
                return cellToSearch;
            }
        }
    }
}
