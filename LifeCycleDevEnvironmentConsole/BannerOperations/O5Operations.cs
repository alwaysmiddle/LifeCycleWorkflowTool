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
                wb.Save();
                detailsProductWs.Calculate();
                //detailsProductWs.ConvertAllDataUnderRowToValues(7);
                CommonOperations.ReworkFurRule(detailsProductWs);

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
    }
}
