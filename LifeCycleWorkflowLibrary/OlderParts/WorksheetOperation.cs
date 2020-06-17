using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        /// Change the value of another column, based on integer values of passed column.
        /// </summary>
        public void ChangeNumberInColumn(string RefenceColumnName, string ChangingColumnName, int ChangeFrom, int ChangeTo)
        {
            Range headerRange = ws.Range[ws.Cells[headerRow, 1],
                   ws.Cells[headerRow, ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Column]];
            Range referenceColumnCell = wsUtilities.FindCellBasedOnValue<string>(RefenceColumnName, headerRange.Address, XlLookAt.xlWhole);
            Range changingColumnCell = wsUtilities.FindCellBasedOnValue<string>(ChangingColumnName, headerRange.Address, XlLookAt.xlWhole);

            if (referenceColumnCell != null && changingColumnCell != null)
            {
                Range columnRange = ws.Range[referenceColumnCell.Offset[1, 0], ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, referenceColumnCell.Column]];
                Range changeColumnRange = ws.Range[changingColumnCell.Offset[1, 0], ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, changingColumnCell.Column]];
                object[,] array = columnRange.Value2;
                object[,] changeArray = changeColumnRange.Value2;

                for (int i = 1; i <= array.GetLength(0); i++)
                {
                    if (int.Parse(array[i, 1].ToString()) == ChangeFrom)
                    {
                        changeArray[i, 1] = ChangeTo;
                    }
                }

                changeColumnRange.Value2 = changeArray;
            }
        }

        /// <summary>
        /// Make comparison of "Reference Column", then change "Changing Column" to another string value.
        /// </summary>
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
        /// Find two columns based on name and change values of the these two columns when matched with criteria. 
        /// The value in the column have to match change1From AND match change2From in order to trigger the change.
        /// </summary>
        public void ChangeNumberInTwoColumn(string refenceColumnName1, string refenceColumnName2, 
            int change1From, int change2From, int change1To, int change2To)
        {
            Range headerRange = ws.Range[ws.Cells[headerRow, 1],
                   ws.Cells[headerRow, ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Column]];
            Range referenceColumn1Cell = wsUtilities.FindCellBasedOnValue<string>(refenceColumnName1, headerRange.Address);
            Range referenceColumn2Cell = wsUtilities.FindCellBasedOnValue<string>(refenceColumnName2, headerRange.Address);

            if (referenceColumn1Cell != null && referenceColumn2Cell != null)
            {
                Range referenceColumn1Range = ws.Range[referenceColumn1Cell.Offset[1, 0], ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, referenceColumn1Cell.Column]];
                Range referenceColumn2Range = ws.Range[referenceColumn2Cell.Offset[1, 0], ws.Cells[ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row, referenceColumn2Cell.Column]];
                object[,] array1 = referenceColumn1Range.Value2;
                object[,] array2 = referenceColumn2Range.Value2;

                for (int i = 1; i <= array1.GetLength(0); i++)
                {
                    if (int.Parse(array1[i, 1].ToString()) == change1From &&
                        int.Parse(array2[i, 1].ToString()) == change2From)
                    {
                        array1[i, 1] = change1To;
                        array2[i, 1] = change2To;
                    }
                }

                referenceColumn1Range.Value2 = array1;
                referenceColumn2Range.Value2 = array2;
            }
        }

        /// <summary>
        /// Only support single cell address parameter.
        /// </summary>
        /// <param name="CopyFromCell"></param>
        /// <param name="CopyToCell"></param>
        /// <param name="pasteType"></param>
        public void CopyFromCurrentRegionToDestination(Range CopyFromCell, Range CopyToCell, XlPasteType pasteType = XlPasteType.xlPasteAll)
        {
            if (CopyToCell.Count == 1 && CopyToCell.Count == 1)
            {
                Range copyRange = wsUtilities.DefineCurrentAreaRange(CopyFromCell);
                copyRange.Copy();
                CopyToCell.PasteSpecial(pasteType);
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
            ws.Calculate();
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
                        if (currentWorkflowStatusArray[i, 1]!= null && currentWorkflowStatusArray[i, 1].ToString().Equals("Awaiting Final Copy", StringComparison.OrdinalIgnoreCase))
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
            int lastRow = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;

            //Hard coded range for vlookup operations
            Range metricsRange = ws.Range[ws.Cells[3,3], ws.Cells[lastRow, 3]];

            //use dictionary as lookup
            Dictionary<string, object[,]> dataDict = new Dictionary<string, object[,]>();

            //data is 0 based
            for (int i = 1; i < data.GetLength(0); i++)
            {
                try
                {
                    object[,] rowValues = { { data[i, 2], data[i, 3], data[i, 4] }};
                    dataDict.Add(data[i, 1].ToString(), rowValues);
                }
                catch
                {
                    //TODO add error report for dupilcated values in column, so dictionary can not index it.
                }
            }

            int[,] defaultValues = { { 0, 0, 0 } };

            foreach (Range cell in metricsRange)
            {
                if (cell.Value2 != null)
                {
                    string tempStr = cell.Value2.ToString();
                    if (dataDict.ContainsKey(tempStr))
                    {
                        cell.Offset[0, 1].Resize[1, 3].Value2 = dataDict[tempStr];
                    }
                    else
                    {
                        cell.Offset[0,1].Resize[1,3].Value2 = defaultValues;
                    }
                }
            }

            //Sum the columns after matching
            ws.Range["D2"].Formula = string.Format("=SUM(D3:D{0})", lastRow);
            ws.Range["E2"].Formula = string.Format("=SUM(E3:E{0})", lastRow);
            ws.Range["F2"].Formula = string.Format("=SUM(F3:F{0})", lastRow);

            ws.Calculate();
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

        public void AddToValueList(Dictionary<string, string> rangeDict)
        {
            Range lastCell = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell);
            Range dataRangeOnSheet = ws.Range[ws.Cells[headerRow + 1, 1], lastCell];

            rangeDict.Add(ws.Name, dataRangeOnSheet.Address);
        }

    }
}
