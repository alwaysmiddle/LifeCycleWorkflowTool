using LifeCycleDevEnvironmentConsole.ExtensionMethods;
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
    public sealed class O5Operations : BannerOperationBase
    {
        private BannerSettings _o5Settings { get; set; }
        public O5Operations(BannerSettings settings) : base(settings)
        {
            _o5Settings = settings;
        }

        public void RunOperation()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();
            System.Data.DataTable templateDataTable = new System.Data.DataTable();

            Application excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);

            Workbook wb = excelApp.Workbooks.Open(_o5Settings.OutputFileFullNameWip);
            excelApp.Calculation = XlCalculation.xlCalculationManual;
            excelApp.Visible = false;
            try
            {
                Worksheet inactiveWs = wb.Worksheets["UPCS"];
                Worksheet detailsProductWs = wb.Worksheets["Details-Products"];
                Worksheet inventoryValueWs = wb.Worksheets["Ttl_Inv"];

                //Bit report
                BitReportHandler bitReport = new BitReportHandler(_o5Settings.InputFilenameBitReport);
                templateDataTable = ExcelUtilities.OledbExcelFileAsTable(_o5Settings.OutputFileFullNameWip, inventoryValueWs.Name);
                inputDataTable = bitReport.JoinWithDataTable(templateDataTable);

                inputDataTable.WriteToExcelSheets(inventoryValueWs, "A1");
                CommonOperations.FormatColumnsAsAccounting(inventoryValueWs, "OH $ @R");
                inputDataTable = null;
                bitReport = null;

                //Inactive UPC
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_o5Settings.InputFilenameInactiveUpc, 1);

                inputDataTable.WriteToExcelSheets(inactiveWs, "A3", false);
                inactiveWs.ProcessFormulaRow(inputDataTable, 1, 2, 3);
                inputDataTable = null;

                ////Workflow DM
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_o5Settings.InputFilenameWorkflow, 1);

                inputDataTable.WriteToExcelSheets((Worksheet)wb.Worksheets["DM_Data"], "A1", true);
                detailsProductWs.ProcessFormulaRow(inputDataTable, 3, 4, 8);
                inputDataTable = null;
               
                detailsProductWs.Calculate();
                wb.Save();

                //detailsProductWs.ConvertAllDataUnderRowToValues(7);
                CommonOperations.ReworkFurRule(detailsProductWs);
                O5SpeicalRule1(detailsProductWs);

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
                excelApp.Calculation = XlCalculation.xlCalculationAutomatic;
                wb.Save();
                wb.Close();
                excelApp.Quit();

                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(excelApp);

                excelProcess.Dispose();
            }
        }


        private void O5SpeicalRule1(Worksheet ws)
        {
            Range furAttributeRange = ws.FindColumnInHeaderRow<string>("Active_PIM", 7);
            System.Data.DataTable dt = new System.Data.DataTable();

            if (furAttributeRange.Cells.Count > 1)
            {
                string writeToAddress = furAttributeRange.Cells[2, 1].Address; //cell under rework column name
                dt = ExcelUtilities.OledbExcelFileAsTable(ws.Parent.Fullname, ws.Name, furAttributeRange.Resize[ColumnSize: 43].Address);

                var rowToUpdate = dt.AsEnumerable()
                    .Where(r => r.Field<string>("Active_PIM") == "Yes" && r.Field<string>("ReadyforProd_PIM") == "Yes" &&
                            r.Field<string>("Current_Workflow_Status") == "Not in PIM Workflow" || r.Field<string>("Current_Workflow_Status") == "Workflow Complete" );

                foreach (System.Data.DataRow row in rowToUpdate)
                {
                    row.SetField<string>(dt.Columns["Current_Workflow_Status"], "Not Flagged for eCOM");
                    row.SetField<string>(dt.Columns["Current Team"], "Merchants");
                }

                dt.WriteToExcelSheets(ws, writeToAddress, false);
            }
        }
    }
}
