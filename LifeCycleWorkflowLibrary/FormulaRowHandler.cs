using Microsoft.Office.Interop.Excel;
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
        private static string MatchHeaderOperationKeyword { get; set; } = Globals.General.MatchHeaderOperationKeyword;
        private bool matchHeaderFunctionality { get; set; }

        /// <summary>
        /// Reads the option settings for the worksheet passed in.
        /// </summary>
        /// <param name="worksheetName"></param>
        public FormulaRowHandler(Worksheet worksheet, WorksheetCustomSettings settings, bool useMatchHeader = false)
        {
            passedWorksheet = worksheet;
            customSettings = settings;
            matchHeaderFunctionality = useMatchHeader;

            initializeReferenceWorksheet();
        }

        private void initializeReferenceWorksheet()
        {
            if (matchHeaderFunctionality)
            {
                Range referenceWsCell = passedWorksheet.Range["B4"];
                try
                {
                    referenceWs = new Worksheet();
                    referenceWs = passedWorksheet.Parent.Worksheets[referenceWsCell.Value2];
                }
                catch
                {
                    matchHeaderFunctionality = false;
                }
            }
        }

        public void ProcessFormulaRow()
        {
            int lastCol = passedWorksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Column;

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
                    referenceWs.Range[resultRange.Offset[1, 0], referenceWs.Cells[lastRow, resultRange.Column]].Copy();
                    passedWorksheet.Cells[customSettings.HeaderRow+1, cell.Column].PasteSpecial(XlPasteType.xlPasteValuesAndNumberFormats,
                                   XlPasteSpecialOperation.xlPasteSpecialOperationNone);
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

                if (lastRow < 500000)// prevents executions if the last row is set to very large number
                {
                    var sameColumnHeaderCell = passedWorksheet.Cells[customSettings.HeaderRow + 1, cell.Column];
                    var sameColumnLastCell = passedWorksheet.Cells[customSettings.HeaderRow + lastRow - 1, cell.Column];
                    passedWorksheet.Range[sameColumnHeaderCell, sameColumnLastCell].FormulaR1C1 = cell.FormulaR1C1;
                }
            }
            else
            {
                //fetch addresses of the column directly below
                int lastRow = passedWorksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;

                if (lastRow < 500000)// prevents executions if the last row is set to very large number
                { 
                    var sameColumnHeaderCell = passedWorksheet.Cells[customSettings.HeaderRow + 1, cell.Column];
                    var sameColumnLastCell = passedWorksheet.Cells[lastRow - 1, cell.Column];
                    passedWorksheet.Range[sameColumnHeaderCell, sameColumnLastCell].FormulaR1C1 = cell.FormulaR1C1;
                }
            }
        }
    }
}
