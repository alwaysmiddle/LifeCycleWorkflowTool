﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LifeCycleWorkflowLibrary
{
    class FormulaRowHandler
    {
        private WorksheetCustomSettings customSettings { get; set; }
        private static Worksheet passedWorksheet { get; set; }
        private static Worksheet referenceWs { get; set; }
        private static WorksheetUtilities passedWorkSheetUtility { get; set; }
        private static string MatchHeaderOperationKeyword { get; set; } = Globals.General.MatchHeaderOperationKeyword;
        private static bool matchHeaderFunctionality { get; set; }

        /// <summary>
        /// Reads the option settings for the worksheet passed in.
        /// </summary>
        /// <param name="worksheetName"></param>
        public FormulaRowHandler(Worksheet worksheet, WorksheetCustomSettings settings, bool useMatchHeader = false)
        {
            passedWorksheet = worksheet;
            passedWorkSheetUtility = new WorksheetUtilities(passedWorksheet);
            customSettings = settings;
            matchHeaderFunctionality = useMatchHeader;

            initializeReferenceWorksheet();
        }

        private static void initializeReferenceWorksheet()
        {
            if (matchHeaderFunctionality)
            {
                Range referenceWsCell = passedWorksheet.Range["B4"];
                try
                {
                    referenceWs = passedWorksheet.Parent.Worksheets[referenceWsCell.Value];
                }
                catch
                {
                    matchHeaderFunctionality = false;
                }
            }
        }

        public void ProcessFormulaRow()
        {
            int lastCol = passedWorksheet.UsedRange.SpecialCells(XlCellType.xlCellTypeLastCell).Column;

            Range formulaRowCells = passedWorksheet.Range[
                passedWorksheet.Cells[customSettings.FormulaeRow, 1],
                passedWorksheet.Cells[customSettings.FormulaeRow, lastCol]];

            //Validate reference cell
            Range matchingWsName = passedWorksheet.Range["B4"];

            foreach (Range formulaRowCell in formulaRowCells)
            {
                //Data matching operation
                if(formulaRowCell.Value2 != null)
                {
                    if (formulaRowCell.HasFormula)
                    {
                        CopyFormula(formulaRowCell);
                    }else if (matchHeaderFunctionality && 
                        formulaRowCell.Value2.ToString().Trim().Equals(MatchHeaderOperationKeyword, StringComparison.OrdinalIgnoreCase))
                    {
                        MatchDataColumn(formulaRowCell, referenceWs);
                    }
                }
            }

            passedWorksheet.Calculate();

            //Get rid of all the formula, if data successfully calculated
            Range lastCell = passedWorksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell);
            
            if (lastCell.Row > customSettings.HeaderRow)
            {
                Range dataRange = passedWorksheet.Range[passedWorksheet.Cells[customSettings.HeaderRow + 1, 1], lastCell];
                dataRange.Value2 = dataRange.Value2;
            }
        }

        private void MatchDataColumn(Range cell, Worksheet referenceWs)
        {
            if(referenceWs.UsedRange.Cells.Count > 0)
            {
                Range resultRange = referenceWs.UsedRange.Rows[1].Find(
                    What: passedWorksheet.Cells[customSettings.ReferenceRow, cell.Column].Value2,
                    LookIn: XlFindLookIn.xlValues,
                    LookAt: XlLookAt.xlPart,
                    SearchOrder: XlSearchOrder.xlByRows,
                    SearchDirection: XlSearchDirection.xlNext
                    );

                if (resultRange != null)
                {
                    //Grab the range below the found cell
                    int lastRow = referenceWs.UsedRange.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
                    object[,] resultData = referenceWs.Range[resultRange.Offset[1, 0], referenceWs.Cells[lastRow, resultRange.Column]].Value2;
                    passedWorkSheetUtility.WriteArrayToCell<object>(resultData, referenceWs.Cells[customSettings.HeaderRow+1, cell.Column].Address);
                }
            }
        }

        private void CopyFormula(Range cell)
        {
            //writing formula to cell
            if (matchHeaderFunctionality)
            {
                //fetch addresses of the column directly below
                int lastRow = referenceWs.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;

                if (lastRow < 500000)
                {
                    var sameColumnHeaderCell = passedWorksheet.Cells[customSettings.HeaderRow + 1, cell.Column];
                    var sameColumnLastCell = passedWorksheet.Cells[lastRow, cell.Column];
                    passedWorksheet.Range[sameColumnHeaderCell, sameColumnLastCell].FormulaR1C1 = cell.FormulaR1C1;
                }
            }
            else
            {
                //fetch addresses of the column directly below
                int lastRow = referenceWs.UsedRange.SpecialCells(XlCellType.xlCellTypeLastCell).Row;

                if (lastRow < 500000)
                { 
                    var sameColumnHeaderCell = passedWorksheet.Cells[customSettings.HeaderRow + 1, cell.Column];
                    var sameColumnLastCell = passedWorksheet.Cells[lastRow - 1, cell.Column];
                    passedWorksheet.Range[sameColumnHeaderCell, sameColumnLastCell].FormulaR1C1 = cell.FormulaR1C1;
                }
            }
        }
    }
}
