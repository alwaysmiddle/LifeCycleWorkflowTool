﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;

namespace LifeCycleWorkflowLibrary
{
    /// <summary>
    /// This class is repository of all the operations that can be done on a sheet within this application.
    /// </summary>
    public class WorksheetOperation
    {
        private Worksheet ws { get; set; }
        private WorksheetUtilities wsUtilities { get; set; }
        private int headerRow { get; set; }


        public WorksheetOperation(Worksheet ReferenceWorksheet, int HeaderRow = 1)
        {
            ws = ReferenceWorksheet;
            headerRow = HeaderRow;
            wsUtilities = new WorksheetUtilities(ws);
        }

        //Data Loading

        public void LoadDataAtCell<T>(T[,] Data, int RowNumber, int ColNumber)
        {
            //clear old data
            wsUtilities.ClearAllDataUnderRow(headerRow);

            wsUtilities.WriteArrayToCell<T>(Data, RowNumber, ColNumber);
        }

        public void LoadDataAtCell<T>(T[,] data, string CellAddress)
        {
            //clear old data
            wsUtilities.ClearAllDataUnderRow(headerRow);

            wsUtilities.WriteArrayToCell<T>(data, CellAddress);
        }


        //========================Special Processes==========================

        /// <summary>
        /// Changes another column based on integer value of first column
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="columneName"></param>
        public void ChangeNumberInColumn(string RefenceColumnName, string ChangingColumnName, int ChangeFrom, int ChangeTo)
        {
            Range headerRange = ws.Range[ws.Cells[headerRow, 1],
                   ws.Cells[headerRow, ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Column]];
            Range referenceColumnCell = wsUtilities.FindCellBasedOnValue<string>(RefenceColumnName, headerRange.Address);
            Range changingColumnCell = wsUtilities.FindCellBasedOnValue<string>(ChangingColumnName, headerRange.Address);

            if (referenceColumnCell != null && changingColumnCell != null)
            {
                Range columnRange = ws.Range[referenceColumnCell.Offset[1, 0], ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, referenceColumnCell.Column]];
                Range changeColumnRange = ws.Range[changingColumnCell.Offset[1, 0], ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, changingColumnCell.Column]];
                object[,] array = columnRange.Value2;

                for (int i = 1; i <= array.GetLength(0); i++)
                {
                    if (int.Parse(array[i, 1].ToString()) == ChangeFrom)
                    {
                        array[i, 1] = ChangeTo;
                    }
                }

                changeColumnRange.Value2 = array;
            }
        }

        /// <summary>
        /// Make comparison of "Reference Column", then change "Changing Column" to another string value.
        /// </summary>
        /// <param name="RefenceColumnName"></param>
        /// <param name="ChangingColumnName"></param>
        /// <param name="ChangeFrom">Use equality of this value for comparison</param>
        /// <param name="ChangeTo"></param>
        /// <param name="IgnoreCase"></param>
        public void ChangeStringInColumn(string RefenceColumnName, string ChangingColumnName,
            string ChangeFrom, string ChangeTo, StringComparison IgnoreCase = StringComparison.OrdinalIgnoreCase)
        {
            Range headerRange = ws.Range[ws.Cells[headerRow, 1],
                   ws.Cells[headerRow, ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Column]];
            Range referenceColumnCell = wsUtilities.FindCellBasedOnValue<string>(RefenceColumnName, headerRange.Address);
            Range changingColumnCell = wsUtilities.FindCellBasedOnValue<string>(ChangingColumnName, headerRange.Address);

            if (referenceColumnCell != null && changingColumnCell != null)
            {
                Range columnRange = ws.Range[referenceColumnCell.Offset[1, 0], ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, referenceColumnCell.Column]];
                Range changeColumnRange = ws.Range[changingColumnCell.Offset[1, 0], ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, changingColumnCell.Column]];
                object[,] array = columnRange.Value2;
                object[,] changeArray = changeColumnRange.Value2;

                for (int i = 1; i <= array.GetLength(0); i++)
                {
                    if (array[i, 1].ToString().Trim().Equals(ChangeFrom, IgnoreCase))
                    {
                        changeArray[i, 1] = ChangeTo;
                    }
                }

                changeColumnRange.Value2 = changeArray;
            }
        }

        /// <summary>
        /// Filter "Re-Work: Complete Fur Attributes" on "Re-Work Status" Column (BI),
        /// Deselect "Exception" on current workflow status.
        /// Update current_workflow_status from “Awaiting Final Copy” to “Awaiting Complete Copy Attributes”
        /// Update Current Team from “Copy” to “Sample Management”
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="columneName"></param>
        public void TheBaySpeicalRule1()
        {
            Range headerRange = ws.Range[ws.Cells[headerRow, 1],
                   ws.Cells[headerRow, ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Column]];

            Range reworkStatusCell = wsUtilities.FindCellBasedOnValue<string>("ReWork_Status", headerRange.Address);
            Range currentWorkflowStatusCell = wsUtilities.FindCellBasedOnValue<string>("Current_Workflow_Status", headerRange.Address);
            Range currentTeamCell = wsUtilities.FindCellBasedOnValue<string>("Current Team", headerRange.Address);

            if (reworkStatusCell != null && currentWorkflowStatusCell != null && currentTeamCell != null)
            {

                Range reworkStatusRange = ws.Range[reworkStatusCell.Offset[1, 0],
                    ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, reworkStatusCell.Column]];
                Range currentWorkflowStatusRange = ws.Range[currentWorkflowStatusCell.Offset[1, 0],
                    ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, currentWorkflowStatusCell.Column]];
                Range currentTeamRange = ws.Range[currentTeamCell.Offset[1, 0],
                    ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, currentTeamCell.Column]];

                object[,] reworkStatusArray = reworkStatusRange.Value2;
                object[,] currentWorkflowStatusArray = currentWorkflowStatusRange.Value2;
                object[,] currentTeamArray = currentTeamRange.Value2;


                for (int i = 1; i <= reworkStatusArray.GetLength(0); i++)
                {
                    if (reworkStatusArray[i, 1] != null &&
                        reworkStatusArray[i, 1].ToString().Equals("Re-Work: Complete Fur Attributes", StringComparison.OrdinalIgnoreCase))
                    {
                        if (currentWorkflowStatusArray[i, 1].ToString().Equals("Awaiting Final Copy", StringComparison.OrdinalIgnoreCase))
                        {
                            currentWorkflowStatusArray[i, 1] = "Awaiting Complete Copy Attributes";
                            currentTeamArray[i, 1] = "Sample Management";
                        }
                    }
                }

                currentWorkflowStatusRange.Value2 = currentWorkflowStatusArray;
                currentTeamRange.Value2 = currentTeamArray;
            }
        }

        /// <summary>
        /// Total inventory calculation for TheBay.
        /// </summary>
        /// <param name="data"></param>
        public void TheBaySpecialRule2(object[,] data)
        {
            //Hard coded range for vlookup operations
            Range metricsRange = ws.Range[ws.Cells[3, 3], ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, 3]];
            object[,] rowValues = new object[1, 3];

            //use dictionary as lookup
            Dictionary<string, object[,]> dataDict = new Dictionary<string, object[,]>();

            //data is 0 based
            for (int i = 1; i < data.GetLength(0); i++)
            {
                try
                {
                    rowValues[0, 0] = data[i, 2];
                    rowValues[0, 1] = data[i, 3];
                    rowValues[0, 2] = data[i, 4];
                    dataDict.Add(data[i, 1].ToString(), rowValues);
                }
                catch
                {
                    //TODO add error report for dupilcated values in column, so dictionary can not index it.
                }
            }

            foreach (Range cell in metricsRange)
            {
                if (cell.Value2 != null)
                {
                    string tempStr = cell.Value2.ToString();
                    if (dataDict.ContainsKey(tempStr))
                    {
                        cell.Offset[0, 1].Resize[1, 3].Value2 = dataDict[tempStr];
                    }
                }
            }
        }


        /// <summary>
        /// Update the reference column row number for other worksheets.
        /// </summary>
        /// <param name="headerCell"></param>
        public void UpdateRowReferences(string ReferenceColumnName, int StartValue)
        {
            Range headerRange = ws.Range[ws.Cells[headerRow, 1],
                   ws.Cells[headerRow, ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Column]];
            Range columnHeaderCell = wsUtilities.FindCellBasedOnValue<string>(ReferenceColumnName, headerRange.Address);

            if (columnHeaderCell != null)
            {
                Range columnRange = ws.Range[columnHeaderCell.Offset[1, 0], ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, columnHeaderCell.Column]];
                object[,] array = columnRange.Value2;

                int refNumber = StartValue;

                for (int i = 1; i <= array.GetLength(0); i++)
                {
                    array[i, 1] = refNumber;
                    refNumber++;
                }
                columnRange.Value2 = array;
            }
        }

        public void CalculateAndPasteAsValues()
        {

            ws.Calculate();
            Range lastCell = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell);

            if (lastCell.Row > headerRow)
            {
                Range dataRange = ws.Range[ws.Cells[headerRow + 1, 1], lastCell];

                dataRange.Value2 = dataRange.Value2;
            }
        }
    }
}