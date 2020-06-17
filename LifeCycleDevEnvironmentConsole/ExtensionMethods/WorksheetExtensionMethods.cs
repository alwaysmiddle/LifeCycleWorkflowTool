using Microsoft.Office.Interop.Excel;
using System;
using System.Data;

namespace LifeCycleDevEnvironmentConsole.ExtensionMethods
{
    /// <summary>
    /// This is the extension class for various components needed for workflow project.
    /// Extension methods are modeled after existing .net types for this specific project only.
    /// </summary>
    public static class WorksheetExtensionMethods
    {
        /// <summary>
        /// Deletes all rows under specified row, not including that row.
        /// </summary>
        public static void ClearAllRowsUnderRow(this Worksheet ws, int belowTheRow)
        {
            Range lastCell = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell);
            if (lastCell.Row > belowTheRow)
            {
                ws.Range["A" + belowTheRow + 1, lastCell].Delete(XlDeleteShiftDirection.xlShiftUp);
            }
        }

        /// <summary>
        /// Deletes all rows above specified row, not including that row.
        /// </summary>
        public static void ClearAllRowsAboveRow(this Worksheet ws, int aboveTheRow)
        {
            if(aboveTheRow > 1)
            ws.Rows[string.Format("1:{0}", aboveTheRow - 1)].Delete(XlDeleteShiftDirection.xlShiftUp);
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

        public static Range FindCellBasedOnValue<T>(this Worksheet ws, T searchValue, string searchRange = "", XlLookAt matchFullCell = XlLookAt.xlPart)
        {
            Range cellToSearch = null;
            
            if (searchRange == "")
            {
                cellToSearch = ws.UsedRange.Find(
                    What: searchValue,
                    LookIn: XlFindLookIn.xlValues,
                    LookAt: matchFullCell,
                    SearchOrder: XlSearchOrder.xlByRows,
                    SearchDirection: XlSearchDirection.xlNext
                    );
            }
            else
            {
                cellToSearch = ws.Range[searchRange].Find(
                    What: searchValue,
                    LookIn: XlFindLookIn.xlValues,
                    LookAt: matchFullCell,
                    SearchOrder: XlSearchOrder.xlByRows,
                    SearchDirection: XlSearchDirection.xlNext
                    );
            }
            return cellToSearch;
        }
    }
}
