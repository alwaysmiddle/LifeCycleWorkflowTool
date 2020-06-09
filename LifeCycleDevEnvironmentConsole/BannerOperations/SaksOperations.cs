using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Data;
using ProcessManagement;

namespace LifeCycleDevEnvironmentConsole.BannerOperations
{
    public sealed class SaksOperations : BannerOperationBase
    {
        private BannerSettings _saksSetting { get; set; }

        public SaksOperations(BannerSettings settings) : base(settings)
        {
            _saksSetting = settings;
        }
        public void RunOperation()
        {
            System.Data.DataTable inputDataTable = new System.Data.DataTable();
            System.Data.DataTable templateDataTable = new System.Data.DataTable();

            Application excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);

            Workbook wb = excelApp.Workbooks.Open(_saksSetting.OutputFileFullNameWip);
            excelApp.Visible = false;
            try
            {
                Worksheet inactiveWs = wb.Worksheets["Additional Color Sizes Report"];
                Worksheet detailsProductWs = wb.Worksheets["Details-Products"];
                Worksheet inventoryValueWs = wb.Worksheets["Ttl_Inv"];

                //Bit report
                BitReportHandler bitReport = new BitReportHandler(_saksSetting.InputFilenameBitReport);
                templateDataTable = ExcelUtilities.OledbExcelFileAsTable(_saksSetting.OutputFileFullNameWip, inventoryValueWs.Name);
                inputDataTable = bitReport.JoinWithDataTable(templateDataTable);

                inputDataTable.WriteToExcelSheets(inventoryValueWs, "A1");

                //Inactive UPC
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_saksSetting.InputFilenameInactiveUpc, 1);
                SaksSpecialRule1(inputDataTable);
                inputDataTable.WriteToExcelSheets(inactiveWs, "A3", false);
                inactiveWs.ProcessFormulaRow(inputDataTable, 1, 2, 3);
                inputDataTable = null;

                ////Workflow DM
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_saksSetting.InputFilenameWorkflow, 1);
                SaksSpecialRule1(inputDataTable);
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


        /// <summary>
        /// This special rule changes group id from 34 to 33.
        /// </summary>
        /// <param name="dt"></param>
        private void SaksSpecialRule1(System.Data.DataTable dt)
        {
            foreach (System.Data.DataColumn col in dt.Columns)
            {
                if (col.ColumnName.IndexOf("group", StringComparison.OrdinalIgnoreCase) >= 0 && 
                    col.DataType == typeof(Double))
                {
                    System.Data.DataRow[] groupRows = dt.Select(string.Format("{0} = 34", col.ColumnName));
                    if (groupRows != null)
                    {
                        foreach (System.Data.DataRow row in groupRows)
                        {
                            row[col] = 33;
                        }
                    }
                }
                
            }
            
        }
    }
}
