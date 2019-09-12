using ClosedXML.Excel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LifeCycleWorkflowLibrary
{
    class FormulaRowHandler
    {
        private WorksheetCustomSettings customSettings = new WorksheetCustomSettings();
        private static IXLWorksheet passedWorksheet { get; set; }
        public static string MatchHeaderOperationKeyword { get; set; } = Globals.MatchHeaderOperationKeyword;
        private DataTable dt { get; set; }

        /// <summary>
        /// Reads the option settings for the worksheet passed in.
        /// </summary>
        /// <param name="worksheetName"></param>
        public FormulaRowHandler(IXLWorksheet worksheet)
        {
            //Read Settings
            customSettings = WorksheetCustomSettingsHolder.Load().SettingsCollection[worksheet.Name];
            if (WorksheetCustomSettingsHolder.Load().SettingsCollection.TryGetValue(worksheet.Name, out customSettings))
            {
                passedWorksheet = worksheet;
            }
            else
            {
                //TODO convert this into Debug
                MessageBox.Show("Worksheet: " + worksheet.Name + " custom settings reading failed!");
            }
        }

        public void ProcessFormulaRow(DataTable dataSource)
        {
            if (passedWorksheet.Row(customSettings.FormulaeRow).IsEmpty())
            {
                //TODO convert this into debug
                MessageBox.Show("Worksheet: " + passedWorksheet.Name + " Row: " + customSettings.FormulaeRow +
                                " is empty!");
            }
            else
            {
                dt = new DataTable();
                dt = dataSource;
                foreach (IXLCell formulaRowCell in passedWorksheet.Row(customSettings.FormulaeRow).CellsUsed())
                {
                    //Data matching operation

                    if (!formulaRowCell.HasFormula && formulaRowCell.Value.ToString().IndexOf(MatchHeaderOperationKeyword) >= 0)
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

        private void MatchDataColumn(IXLCell cell)
        {
            string header = passedWorksheet.Cell(customSettings.ReferenceRow, cell.Address.ColumnNumber).Value.ToString();
            if (dt.Columns.Contains(header))
            {
                var list = dt.Rows.OfType<DataRow>().Select(row => row.Field<string>(header)).ToList();
                passedWorksheet.Cell(customSettings.HeaderRow + 1, cell.Address.ColumnNumber).InsertData(list);
                list = null;
            }

        }

        private void CopyFormula(IXLCell cell)
        {
            //fetch addresses of the column directly below
            int lastRow = passedWorksheet.LastRowUsed().RowNumber();
            var sameColumnHeaderCellAddress = passedWorksheet.Cell(customSettings.HeaderRow + 1, cell.Address.ColumnNumber).Address;
            var sameColumnLastCellAddress = passedWorksheet.Cell(passedWorksheet.LastRowUsed().RowNumber(), cell.Address.ColumnNumber).Address;

            //writing formula to cell
            passedWorksheet.Range(sameColumnHeaderCellAddress + ":" + sameColumnLastCellAddress).FormulaR1C1 = cell.FormulaR1C1;
        }
        
    }
}
