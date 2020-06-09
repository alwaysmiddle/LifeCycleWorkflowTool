using Microsoft.Office.Interop.Excel;
using ProcessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.BannerOperations
{
    public sealed class TheBayOperations : BannerOperationBase
    {
        private BannerSettings _theBaySettings { get; set; }
        public TheBayOperations(BannerSettings settings) : base(settings)
        {
            _theBaySettings = settings;
        }

        public void RunOperation()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();
            System.Data.DataTable templateDataTable = new System.Data.DataTable();

            Application excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);

            Workbook wb = excelApp.Workbooks.Open(_theBaySettings.OutputFileFullNameWip);
            excelApp.Visible = false;
            try
            {
                Worksheet inactiveWs = wb.Worksheets["UPC_Looker"];
                Worksheet detailsProductWs = wb.Worksheets["Details-Products"];
                Worksheet inventoryValueWs = wb.Worksheets["Ttl_Inv"];

                //Bit report
                BitReportHandler bitReport = new BitReportHandler(_theBaySettings.InputFilenameBitReport);
                templateDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.OutputFileFullNameWip, inventoryValueWs.Name);
                inputDataTable = bitReport.JoinWithDataTable(templateDataTable);

                inputDataTable.WriteToExcelSheets(inventoryValueWs, "A1");

                //Inactive UPC
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameInactiveUpc, 1);

                inputDataTable.WriteToExcelSheets(inactiveWs, "A1", true);
                inputDataTable = null;

                //////Workflow DM
                //inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameWorkflow, 1);

                //inputDataTable.WriteToExcelSheets((Worksheet)wb.Worksheets["DM_Data"], "A1", true);
                //detailsProductWs.ProcessFormulaRow(inputDataTable, 3, 4, 8);
                //inputDataTable = null;
                //wb.Save();
                //detailsProductWs.Calculate();
                ////detailsProductWs.ConvertAllDataUnderRowToValues(7);
                //O5ReworkFurRule(detailsProductWs);

                excelApp.Calculate();
                wb.Save();
            }
            catch (Exception ex)
            {
                //TODO handle exception
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                excelApp.DisplayAlerts = false;
                wb.Save();
                wb.Close();
                excelApp.Quit();

                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(excelApp);

                excelProcess.Dispose();
            }
        }

        private void O5ReworkFurRule(Worksheet ws)
        {
            Range furAttributeRange = ws.FindColumnInHeaderRow<string>("ReWork_Status", 7);
            System.Data.DataTable dt = new System.Data.DataTable();

            if (furAttributeRange.Cells.Count > 1)
            {
                string writeToAddress = furAttributeRange.Cells[2, 1].Address; //cell under rework column name
                dt = ExcelUtilities.OledbExcelFileAsTable(ws.Parent.Fullname, ws.Name, furAttributeRange.Resize[ColumnSize: 5].Address);

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
    }
}
