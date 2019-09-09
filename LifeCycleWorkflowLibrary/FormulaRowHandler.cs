using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeCycleWorkflowLibrary
{
    class FormulaRowHandler
    {
        private WorksheetCustomSettings customSettings = new WorksheetCustomSettings();
        private static IXLWorksheet passedWorksheet { get; set; }
        public static string MatchHeaderOperationKeyword { get; set; } = "MatchHeader";

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
                MessageBox.Show("Worksheet: " + worksheet.Name + " custom settings reading failed!");
            }
        }

        public void ProcessFormulaRow(DataTable dataSource)
        {
            int lastColNum = passedWorksheet.LastColumnUsed().ColumnNumber();

            if (passedWorksheet.Row(customSettings.FormulaeRow).IsEmpty())
            {
                MessageBox.Show("Worksheet: " + passedWorksheet.Name + " Row: " + customSettings.FormulaeRow +
                                " is empty!");
            }
            else
            {
                foreach (var formulaRowCell in passedWorksheet.Row(customSettings.FormulaeRow).CellsUsed())
                {
                    //Data matching operation
                    if(formulaRowCell.Value.ToString().IndexOf(MatchHeaderOperationKeyword) >= 0)
                    {
                        MatchDataColumn(formulaRowCell, dataSource);
                    }
                }      
            }

        }

        private void MatchDataColumn(IXLCell cell, DataTable sourceTable)
        {

        }

        private void CopyFormula(IXLCell cell)
        {

        }
        
    }
}
