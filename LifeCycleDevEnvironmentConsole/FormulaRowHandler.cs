using LifeCycleDevEnvironmentConsole.ExtensionMethods;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole
{
    public static class FormulaRowHandler
    {
        public static void ProcessFormulaRow(this Worksheet ws, System.Data.DataTable refTable, int formulaRow, int headerRow, int outputRow)
        {
            int lastCol = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Column;

            Range formulaRowCells = ws.Range[ws.Cells[formulaRow, 1], ws.Cells[formulaRow, lastCol]];

            foreach (Range formulaRowCell in formulaRowCells)
            {
                Range headerRowCell = ws.Cells[headerRow, formulaRowCell.Column];
                //Data matching operation
                if (formulaRowCell.Value2 != null)
                {
                    if (formulaRowCell.HasFormula)
                    {
                        //autofill destination range must include source range
                        Range outputCell = ws.Cells[outputRow, formulaRowCell.Column];
                        outputCell.FormulaR1C1 = formulaRowCell.FormulaR1C1;
                        outputCell.AutoFill(ws.Range[ws.Cells[outputRow, formulaRowCell.Column], ws.Cells[outputRow + refTable.Rows.Count - 1, formulaRowCell.Column]]);
                    }
                    else
                    {
                        if(headerRowCell.Value2 == null)
                        {
                            continue;
                        }

                        #region Worksheet keywords operations: MatchHeader, ReplaceZero, ConvertBooleanToYesNo
                        string formulaCellStr = formulaRowCell.Value2.ToString().Trim();
                        string headerRowStr = headerRowCell.Value2.ToString().Trim();

                        if (refTable.Columns.Contains(headerRowStr))
                        {
                            if (formulaCellStr.Equals("MatchHeader", StringComparison.OrdinalIgnoreCase))
                            {
                                object[,] objArr = new object[refTable.Rows.Count, 1];
                                for (int i = 0; i < refTable.Rows.Count; i++)
                                {
                                    objArr[i, 0] = refTable.Rows[i][headerRowStr];
                                }

                                ws.WriteArrayToCell<object>(objArr, outputRow, formulaRowCell.Column);
                            }
                            else if (formulaCellStr.Equals("ReplaceZero", StringComparison.OrdinalIgnoreCase))
                            {
                                object[,] objArr = new object[refTable.Rows.Count, 1];
                                for (int i = 0; i < refTable.Rows.Count; i++)
                                {
                                    if (refTable.Rows[i][headerRowStr] != (object)0) {
                                        objArr[i, 0] = refTable.Rows[i][headerRowStr];
                                    }
                                    else
                                    {
                                        objArr[i, 0] = '-';
                                    }
                                }

                                ws.WriteArrayToCell<object>(objArr, outputRow, formulaRowCell.Column);
                            }
                            else if (formulaCellStr.Equals("ConvertBooleanToYesNo", StringComparison.OrdinalIgnoreCase))
                            {
                                object[,] objArr = new object[refTable.Rows.Count, 1];
                                for (int i = 0; i < refTable.Rows.Count; i++)
                                {
                                    if (refTable.Rows[i][headerRowStr].ToString().Trim().Equals("T"))
                                    {
                                        objArr[i, 0] = "Yes";
                                    }
                                    else
                                    {
                                        objArr[i, 0] = "No";
                                    }
                                }

                                ws.WriteArrayToCell<object>(objArr, outputRow, formulaRowCell.Column);
                            }
                        }else if(formulaCellStr.Equals("GenerateRowReference", StringComparison.OrdinalIgnoreCase))
                        {
                            var x = formulaRowCell.Offset[1, 0].Value2;
                            int num;

                            if (!ExcelUtilities.IsNumber(x))
                            {
                                if (!int.TryParse(x, out num))
                                {
                                    num = 2;
                                }
                            }
                            else
                            {
                                num = (int)x;
                            }

                            object[,] arr = new object[refTable.Rows.Count, 1];
                            for (int i = 0; i < refTable.Rows.Count; i++)
                            {
                                arr[i, 0] = (num + i);
                            }

                            ws.WriteArrayToCell<object>(arr, outputRow, formulaRowCell.Column);
                        }
                        else
                        {
                            ws.Range[ws.Cells[outputRow, formulaRowCell.Column], ws.Cells[outputRow + refTable.Rows.Count - 1, formulaRowCell.Column]].Value2 = "Column Name Not Found";
                        }

                        #endregion
                    }
                }
            }

        }
    }
}
