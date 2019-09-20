using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LifeCycleWorkflowLibrary
{
    class FormulaRowHandler
    {
        private WorksheetCustomSettings customSettings { get; set; }
        private static Worksheet passedWorksheet { get; set; }
        public static string MatchHeaderOperationKeyword { get; set; } = Globals.General.MatchHeaderOperationKeyword;

        /// <summary>
        /// Reads the option settings for the worksheet passed in.
        /// </summary>
        /// <param name="worksheetName"></param>
        public FormulaRowHandler(Worksheet worksheet, WorksheetCustomSettings settings)
        {
            passedWorksheet = worksheet;
            customSettings = settings;
        }

        public void ProcessFormulaRow()
        {
            int lastRow = passedWorksheet.UsedRange.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
            int lastCol = passedWorksheet.UsedRange.SpecialCells(XlCellType.xlCellTypeLastCell).Column;

            Range formulaRowCells = passedWorksheet.Range[
                passedWorksheet.Cells[customSettings.FormulaeRow, 1],
                passedWorksheet.Cells[customSettings.FormulaeRow, lastCol]];
            
            
            {
                foreach (Range formulaRowCell in formulaRowCells)
                {
                    //Data matching operation
                    if(formulaRowCell != null)
                    {
                        if (!formulaRowCell.HasFormula && 
                            formulaRowCell.Value.ToString().IndexOf(MatchHeaderOperationKeyword) >= 0)
                        {
                            MatchDataColumn(formulaRowCell);
                        }
                        else
                        {
                            CopyFormula(formulaRowCell);
                        }
                    }
                }
            }

        }

        //    private void MatchDataColumn(IXLCell cell)
        //    {
        //        string header = passedWorksheet.Cell(customSettings.ReferenceRow, cell.Address.ColumnNumber).Value.ToString();
        //        if (dt.Columns.Contains(header))
        //        {
        //            var list = dt.Rows.OfType<DataRow>().Select(row => row.Field<string>(header)).ToList();
        //            passedWorksheet.Cell(customSettings.HeaderRow + 1, cell.Address.ColumnNumber).InsertData(list);
        //            list = null;
        //        }

        //    }

        //    private void CopyFormula(IXLCell cell)
        //    {
        //        //fetch addresses of the column directly below
        //        int lastRow = passedWorksheet.LastRowUsed().RowNumber();
        //        var sameColumnHeaderCellAddress = passedWorksheet.Cell(customSettings.HeaderRow + 1, cell.Address.ColumnNumber).Address;
        //        var sameColumnLastCellAddress = passedWorksheet.Cell(passedWorksheet.LastRowUsed().RowNumber(), cell.Address.ColumnNumber).Address;

        //        //writing formula to cell
        //        passedWorksheet.Range(sameColumnHeaderCellAddress + ":" + sameColumnLastCellAddress).FormulaR1C1 = cell.FormulaR1C1;
        //    }

        //}
    }
