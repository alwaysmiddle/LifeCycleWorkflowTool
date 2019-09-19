using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary
{
    public class WorksheetUtilities
    {
        Worksheet _ws { get; set; }

        public WorksheetUtilities(Worksheet worksheet)
        {
            _ws = worksheet;
        }

        public void WriteArrayToCell<T>(T[,] Array2D, string CellAddress, bool Transpose = false)
        {
            int rowIncrement = Array2D.GetLength(0) - 1; //-1 because excel is 1 based index
            int colIncrement = Array2D.GetLength(1) - 1;

            int cellRow = _ws.Range[CellAddress].Row;
            int cellCol = _ws.Range[CellAddress].Column;

            if (Transpose)
            {
                _ws.Range[_ws.Cells[cellRow, cellCol], _ws.Cells[cellRow + colIncrement, cellCol + rowIncrement]].Value2 = TransposeArray(Array2D);
            }
            else
            {
                _ws.Range[_ws.Cells[cellRow, cellCol], _ws.Cells[cellRow + rowIncrement, cellCol + colIncrement]].Value2 = Array2D;
            }
        }

        public void WriteArrayToCell<T>(T[,] Array2D, int RowNumber, int ColumnNumber, bool Transpose = false)
        {
            int rowIncrement = Array2D.GetLength(0) - 1; //-1 because excel is 1 based index
            int colIncrement = Array2D.GetLength(1) - 1;

            if (Transpose)
            {
                _ws.Range[_ws.Cells[RowNumber, ColumnNumber], _ws.Cells[RowNumber + colIncrement, ColumnNumber + rowIncrement]].Value2 = TransposeArray(Array2D);
            }
            else
            {
                _ws.Range[_ws.Cells[RowNumber, ColumnNumber], _ws.Cells[RowNumber + rowIncrement, ColumnNumber + colIncrement]].Value2 = Array2D;
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
            if (_ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row > RowNumber)
            {
                _ws.Range[_ws.Cells[RowNumber + 1, 1],
                        _ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell)].Delete(XlDeleteShiftDirection.xlShiftUp);
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
