using LifeCycleDevEnvironmentConsole.ExtensionMethods;
using LifeCycleDevEnvironmentConsole.Settings;
using LifeCycleDevEnvironmentConsole.Utilities;
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
            Workbook wb = excelApp.Workbooks.Open(_theBaySettings.OutputFileFullnameWip);
            
            excelApp.Calculation = XlCalculation.xlCalculationManual;
            excelApp.Visible = false;
            try
            {
                Worksheet inactiveWs = wb.Worksheets["Inactive_UPC"];
                Worksheet inactiveDataWs = wb.Worksheets["UPC_Looker"];
                Worksheet detailsProductWs = wb.Worksheets["Details-Products"];
                Worksheet detailsProductDataWs = wb.Worksheets["Looker_Data"];
                Worksheet inventoryValueWs = wb.Worksheets["Ttl_Inv"];
                Worksheet nosCombineWs = wb.Worksheets["NOS_Colour_Combined"];

                //Bit report
                BitReportHandler bitReport = new BitReportHandler(_theBaySettings.InputFilenameBitReport);
                templateDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.OutputFileFullnameWip, inventoryValueWs.Name);
                inputDataTable = bitReport.JoinWithDataTable(templateDataTable);

                inputDataTable.WriteToExcelSheets(inventoryValueWs, "A1");
                CommonOperations.FormatColumnsAsAccounting(inventoryValueWs, "OH $ @R");
                inputDataTable = null;
                bitReport = null;

                //NOS Combined

                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameNosCombined, 1);

                inputDataTable.WriteToExcelSheets(nosCombineWs, "A3", false);
                inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>("PIM PRODUCTS Group ID", "PIM PRODUCTS Divisionid", 27, 5);
                inputDataTable.UpdateValueOfTwoColumns<double>("PIM PRODUCTS Divisionid", "PIM PRODUCTS Group ID", 7, 28, 5, 28);
                nosCombineWs.ProcessFormulaRow(inputDataTable, 1, 2, 3);
                inputDataTable = null;

                inactiveWs.Calculate();
                wb.Save();

                //Inactive UPC
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameInactiveUpc, 1);

                inputDataTable.WriteToExcelSheets(inactiveDataWs, "A1", true);
                inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>("PIM PRODUCTS Group ID", "PIM PRODUCTS Divisionid", 27, 5);
                inputDataTable.UpdateValueOfTwoColumns<double>("PIM PRODUCTS Divisionid", "PIM PRODUCTS Group ID", 7, 28, 5, 28);
                inactiveWs.ProcessFormulaRow(inputDataTable, 3, 4, 8);
                inputDataTable = null;

                inactiveWs.Calculate();
                wb.Save();

                //Workflow DM
                inputDataTable = ExcelUtilities.OledbExcelFileAsTable(_theBaySettings.InputFilenameWorkflow, 1);

                inputDataTable.SetValueInColumnBasedOnReferenceColumn<double>("PIM PRODUCTS Group ID", "PIM PRODUCTS Divisionid", 27, 5);
                inputDataTable.UpdateValueOfTwoColumns<double>("PIM PRODUCTS Divisionid", "PIM PRODUCTS Group ID", 7, 28, 5, 28);
                inputDataTable.WriteToExcelSheets(detailsProductDataWs, "A1", true);
                detailsProductWs.ProcessFormulaRow(inputDataTable, 3, 4, 8);

                inputDataTable = null;

                detailsProductWs.Calculate();
                wb.Save();
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
                excelApp.Calculation = XlCalculation.xlCalculationAutomatic;
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
