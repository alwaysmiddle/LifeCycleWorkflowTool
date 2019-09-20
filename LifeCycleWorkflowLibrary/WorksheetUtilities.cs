using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace LifeCycleWorkflowLibrary
{
    public class WorksheetUtilities
    {
        Worksheet ws { get; set; }

        public WorksheetUtilities(Worksheet worksheet)
        {
            ws = worksheet;
        }

        public void WriteArrayToCell<T>(T[,] Array2D, string CellAddress, bool Transpose = false)
        {
            int rowIncrement = Array2D.GetLength(0) - 1; //-1 because excel is 1 based index
            int colIncrement = Array2D.GetLength(1) - 1;

            int cellRow = ws.Range[CellAddress].Row;
            int cellCol = ws.Range[CellAddress].Column;

            if (Transpose)
            {
                ws.Range[ws.Cells[cellRow, cellCol], ws.Cells[cellRow + colIncrement, cellCol + rowIncrement]].Value2 = TransposeArray(Array2D);
            }
            else
            {
                ws.Range[ws.Cells[cellRow, cellCol], ws.Cells[cellRow + rowIncrement, cellCol + colIncrement]].Value2 = Array2D;
            }
        }

        public void WriteArrayToCell<T>(T[,] Array2D, int RowNumber, int ColumnNumber, bool Transpose = false)
        {
            int rowIncrement = Array2D.GetLength(0) - 1; //-1 because excel is 1 based index
            int colIncrement = Array2D.GetLength(1) - 1;

            if (Transpose)
            {
                ws.Range[ws.Cells[RowNumber, ColumnNumber], ws.Cells[RowNumber + colIncrement, ColumnNumber + rowIncrement]].Value2 = TransposeArray(Array2D);
            }
            else
            {
                ws.Range[ws.Cells[RowNumber, ColumnNumber], ws.Cells[RowNumber + rowIncrement, ColumnNumber + colIncrement]].Value2 = Array2D;
            }

        }

        public void WriteListToCell<T>(List<T> alist, string CellAddress, bool Transpose = false)
        {

        }

        public void WriteListToCell<T>(List<T> alist, int RowNumber, int ColumnNumber, bool Transpose = false)
        {

        }

        public void ClearAllDataUnderRow(int RowNumber)
        {
            if (ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row > RowNumber)
            {
                ws.Range[ws.Cells[RowNumber + 1, 1],
                        ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell)].Delete(XlDeleteShiftDirection.xlShiftUp);
            }
        }

        static T[,] TransposeArray<T>(T[,] array2D)
        {
            var rows = array2D.GetLength(0);
            var columns = array2D.GetLength(1);

            var result = new T[columns, rows];

            for (var c = 0; c < columns; c++)
            {
                for (var r = 0; r < rows; r++)
                {
                    result[c, r] = array2D[r, c];
                }
            }

            return result;
        }
    }
}
