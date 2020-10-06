using LifeCycleWorkflowBackend.Utilities;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.BannerOperations
{
    public static class CommonOperations
    {
        public static void ReworkFurRule(Worksheet ws, int headerRow)
        {
            Range furAttributeRange = ws.FindColumnInHeaderRow<string>("ReWork_Status", headerRow);
            System.Data.DataTable dt = new System.Data.DataTable();

            if (furAttributeRange.Cells.Count > 1)
            {
                string writeToAddress = furAttributeRange.Cells[2, 1].Address; //cell under rework column name
                dt = ExcelUtilities.ReadWorksheetRangeAsTable(ws, furAttributeRange.Resize[ColumnSize: 5].Address);

                var rowToUpdate = dt.AsEnumerable()
                    .Where(r => r.Field<string>("ReWork_Status") == "Re-Work: Complete Fur Attributes"
                                && r.Field<string>("Workflow Exception Type") == null);

                foreach (System.Data.DataRow row in rowToUpdate)
                {
                    row.SetField<string>(dt.Columns["Current_Workflow_Status"], "Awaiting Complete Copy Attributes");
                    row.SetField<string>(dt.Columns["Current Team"], "Sample Management");
                }

                dt.WriteToExcelSheets(ws, writeToAddress, false);
            }
        }

        public static void FormatColumnsAsAccounting(Worksheet ws, string columnHeader)
        {
            Range columnToFormat = ws.FindColumnInHeaderRow<string>(columnHeader, 1);

            columnToFormat.NumberFormat = "$#,##0.00_);($#,##0.00)";
        }
    }
}
