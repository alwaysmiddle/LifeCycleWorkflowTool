using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //saks
            string input1 = @"C:\Users\Middle\Desktop\WorkFlow Data\Saks\Input Files\DM_WORKFLOW_RPT20200605.xls";
            string input2 = @"C:\Users\Middle\Desktop\WorkFlow Data\Saks\Input Files\MIS-IB004A_2 - Saks-Ecomm by Colour Count.xlsx";
            string input3 = @"C:\Users\Middle\Desktop\WorkFlow Data\Saks\Input Files\DM_SAKS_OH_INACTV_UPC20200605.xls";

            //O5
            string o5Input1 = @"C:\Users\Middle\Desktop\WorkFlow Data\O5\Test Data\O5_DM_WORKFLOW_REPORT_O5.xlsx";
            string o5Input2 = @"C:\Users\Middle\Desktop\WorkFlow Data\O5\Test Data\MIS-IB004A_2 - SO5-Ecomm by Colour Count.xlsx";
            string o5Input3 = @"C:\Users\Middle\Desktop\WorkFlow Data\O5\Test Data\DM_O5_OH_INACTV_UPC20200512.xlsx";

            //The Bay
            string theBayInput1 = @"C:\Users\Middle\Desktop\WorkFlow Data\TheBay\Test Data\SFCC_Bay Workflow and Not On Site 2020-05-27T0843.csv";
            string theBayInput2 = @"C:\Users\Middle\Desktop\WorkFlow Data\TheBay\Test Data\BAY Ecomm by Colour Count 5.27.20.xlsx";
            string theBayInput3 = @"C:\Users\Middle\Desktop\WorkFlow Data\TheBay\Test Data\SFCC_Bay Inactive UPC 2020-05-27T0845.xlsx";
            string theBayInput4 = @"C:\Users\Middle\Desktop\WorkFlow Data\TheBay\Test Data\SFCC_Bay NOS combined 2020-05-27T0844.csv";

            string templateSaksWip = @"C:\Users\Middle\Desktop\WorkFlow Data\Saks\Template\Daily Workflow_Saks_Wip_Template_2020.xlsm";
            string templateO5Wip = @"C:\Users\Middle\Desktop\WorkFlow Data\O5\Template\Daily Workflow_O5_Wip_Template_2020.xlsm";
            string templateTheBayWip = @"C:\Users\Middle\Desktop\WorkFlow Data\TheBay\Template\Daily Workflow_TheBay_Wip_Template_2020.xlsm";
            string oDirectory = @"C:\Users\Middle\Desktop";

            ////saks settings
            //BannerSettings.BannerSettingsEssence settingsEssence = new BannerSettings.BannerSettingsEssence(Banner.Saks);
            //settingsEssence.DefaultOutputFilename = "_Saks_Workflow";
            //settingsEssence.OutputDate = new DateTime(2020, 6, 5);
            //settingsEssence.OutputDirectoryWip = oDirectory;
            //settingsEssence.OutputDirectoryFinal = oDirectory;
            //settingsEssence.TemplateFilenameWip = templateSaksWip;
            //settingsEssence.TemplateFilenameFinal = templateSaksWip;
            //settingsEssence.InputFilenameWorkflow = input1;
            //settingsEssence.InputFilenameBitReport = input2;
            //settingsEssence.InputFilenameInactiveUpc = input3;

            //BannerSettings saksSettings = settingsEssence.GetNewInstance();

            //Console.WriteLine("Starting Saks Operation");
            //SaksOperations saksOps = new SaksOperations(saksSettings);
            //saksOps.RunOperation();
            //Console.WriteLine("Saks Operation finished");

            ////O5 settings
            //BannerSettings.BannerSettingsEssence settingsEssence = new BannerSettings.BannerSettingsEssence(Banner.O5);
            //settingsEssence.DefaultOutputFilename = "O5_Workflow";
            //settingsEssence.OutputDate = new DateTime(2020, 5, 12);
            //settingsEssence.OutputDirectoryWip = oDirectory;
            //settingsEssence.OutputDirectoryFinal = oDirectory;
            //settingsEssence.TemplateFilenameWip = templateO5Wip;
            //settingsEssence.TemplateFilenameFinal = templateO5Wip;
            //settingsEssence.InputFilenameWorkflow = o5Input1;
            //settingsEssence.InputFilenameBitReport = o5Input2;
            //settingsEssence.InputFilenameInactiveUpc = o5Input3;

            //BannerSettings o5Settings = settingsEssence.GetNewInstance();

            //Console.WriteLine("Starting O5 Operation");

            //O5Operations o5Ops = new O5Operations(o5Settings);
            //o5Ops.RunOperation();
            //Console.WriteLine("O5 Operation finished");

            //TheBay settings
            BannerSettings.BannerSettingsEssence settingsEssence = new BannerSettings.BannerSettingsEssence(Banner.TheBay);
            settingsEssence.DefaultOutputFilename = "TheBay_Workflow";
            settingsEssence.OutputDate = new DateTime(2020, 5, 27);
            settingsEssence.OutputDirectoryWip = oDirectory;
            settingsEssence.OutputDirectoryFinal = oDirectory;
            settingsEssence.TemplateFilenameWip = templateTheBayWip;
            settingsEssence.TemplateFilenameFinal = templateTheBayWip;
            settingsEssence.InputFilenameWorkflow = theBayInput1;
            settingsEssence.InputFilenameBitReport = theBayInput2;
            settingsEssence.InputFilenameInactiveUpc = theBayInput3;
            settingsEssence.InputFilenameNosCombined = theBayInput4;

            BannerSettings theBaySettings = settingsEssence.GetNewInstance();

            Console.WriteLine("Starting TheBay Operation");
            TheBayOperations theBayOps = new TheBayOperations(theBaySettings);
            theBayOps.RunOperation();
            Console.WriteLine("TheBay Operation finished");

            Console.WriteLine("Operation Successful");
            Console.ReadKey();
        }

        public static string DumpDataTable(DataTable table)
        {
            string data = string.Empty;
            StringBuilder sb = new StringBuilder();

            if (null != table && null != table.Rows)
            {
                foreach (DataRow dataRow in table.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        sb.Append(item);
                        sb.Append(',');
                    }
                    sb.AppendLine();
                }

                data = sb.ToString();
            }
            return data;
        }
    }
}
