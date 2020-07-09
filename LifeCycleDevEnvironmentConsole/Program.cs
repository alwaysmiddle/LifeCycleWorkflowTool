using LifeCycleDevEnvironmentConsole.BannerOperations;
using LifeCycleDevEnvironmentConsole.Settings;
using LifeCycleDevEnvironmentConsole.Settings.DefaultSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace LifeCycleDevEnvironmentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string exeDir = Path.GetFullPath(Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\"));

            string saksPath = @"WorkFlow Data\Saks\";
            //saks
            string saksInput1 = Path.Combine(exeDir, saksPath, @"Input Files\DM_WORKFLOW_RPT20200709.xls");
            string saksInput2 = Path.Combine(exeDir, saksPath, @"Input Files\MIS-IB004A.2 - Saks (11).xlsx");
            string saksInput3 = Path.Combine(exeDir, saksPath, @"Input Files\DM_SAKS_OH_INACTV_UPC20200709.xls");

            string o5Path = @"WorkFlow Data\O5\";
            //O5
            string o5Input1 = Path.Combine(exeDir, o5Path, @"Test Data\O5_DM_WORKFLOW_REPORT_O5.xlsx");
            string o5Input2 = Path.Combine(exeDir, o5Path, @"Test Data\MIS-IB004A_2 - SO5-Ecomm by Colour Count.xlsx");
            string o5Input3 = Path.Combine(exeDir, o5Path, @"Test Data\DM_O5_OH_INACTV_UPC20200512.xlsx");

            string theBayPath = @"WorkFlow Data\TheBay\";
            //The Bay
            string theBayInput1 = Path.Combine(exeDir, theBayPath , @"Test Data\SFCC_Bay Workflow and Not On Site 2020-06-15T0838.csv");
            string theBayInput2 = Path.Combine(exeDir, theBayPath, @"Test Data\BAY Ecomm by Colour Count 6.15.20.xlsx");
            string theBayInput3 = Path.Combine(exeDir, theBayPath, @"Test Data\SFCC_Bay Inactive UPC 2020-06-15T0846.csv");
            string theBayInput4 = Path.Combine(exeDir, theBayPath, @"Test Data\SFCC_Bay NOS combined 2020-06-15T0845.csv");


            string templateSaksWip = Path.Combine(exeDir, saksPath, @"Template\Daily Workflow_Saks_Wip_Template_2020.xlsm");
            string templateO5Wip = Path.Combine(exeDir, o5Path, @"Template\Daily Workflow_O5_Wip_Template_2020.xlsm");
            string templateTheBayWip = Path.Combine(exeDir, theBayPath, @"Template\Daily Workflow_TheBay_Wip_Template_2020.xlsm");

            string templateSaksFinal = Path.Combine(exeDir, saksPath, @"Template\Daily Workflow_SAKS_Final_Template_2020.xlsx");
            string templateO5Final = Path.Combine(exeDir, o5Path, @"Template\Daily Workflow_O5_Final_Template_2020.xlsx");
            string templateTheBayFinal = Path.Combine(exeDir, theBayPath, @"Template\Daily Workflow_TheBay_Final_Template_2020.xlsx");

            string oDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Console.WriteLine(oDirectory);

            //saks settings
            BannerSettings saksSettings = new BannerSettings(
                banner: Banner.Saks,
                wipOutputDirectory: oDirectory,
                finalOutputDirectory: oDirectory,
                defaulOutputFilename: "Saks_Daily_Workflow",
                templateFullnameWip: templateSaksWip,
                templateFullnameFinal: templateSaksFinal,
                inputFilenameBitReport: saksInput2,
                inputFilenameWorkflow: saksInput1,
                inputFilenameInactiveUpc: saksInput3,
                worksheetSettings: GenerateDefaultSettings.GenerateSaksDefault(),
                outputDate: new DateTime(2020, 6, 16)
                );

            Console.WriteLine("Starting Saks Operation");
            SaksOperations saksOps = new SaksOperations(saksSettings);
            saksOps.RunOperation();
            Console.WriteLine("Saks Operation finished");

            //O5 settings
            //BannerSettings o5Settings = new BannerSettings(
            //    banner: Banner.O5,
            //    wipOutputDirectory: oDirectory,
            //    finalOutputDirectory: oDirectory,
            //    defaulOutputFilename: "O5_Daily_Workflow",
            //    templateFullnameWip: templateO5Wip,
            //    templateFullnameFinal: templateO5Final,
            //    inputFilenameBitReport: o5Input2,
            //    inputFilenameWorkflow: o5Input1,
            //    inputFilenameInactiveUpc: o5Input3,
            //    outputDate: new DateTime(2020, 6, 12),
            //    worksheetSettings: GenerateDefaultSettings.GenerateO5Default()
            //    );

            //Console.WriteLine("Starting O5 Operation");

            //O5Operations o5Ops = new O5Operations(o5Settings);
            //o5Ops.RunOperation();
            //Console.WriteLine("O5 Operation finished");

            //TheBay settings
            //BannerSettings theBaySettings = new BannerSettings(
            //    banner: Banner.TheBay,
            //    wipOutputDirectory: oDirectory,
            //    finalOutputDirectory: oDirectory,
            //    defaulOutputFilename: "TheBay_Daily_Workflow",
            //    templateFullnameWip: templateTheBayWip,
            //    templateFullnameFinal: templateTheBayFinal,
            //    inputFilenameBitReport: theBayInput2,
            //    inputFilenameWorkflow: theBayInput1,
            //    inputFilenameInactiveUpc: theBayInput3,
            //    inputFilenameNosCombined: theBayInput4,
            //    worksheetSettings: GenerateDefaultSettings.GenerateTheBayDefault(),
            //    outputDate: new DateTime(2020, 6, 15)
            //    );

            //Console.WriteLine("Starting TheBay Operation");
            //TheBayOperations theBayOps = new TheBayOperations(theBaySettings);
            //theBayOps.RunOperation();
            //Console.WriteLine("TheBay Operation finished");

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
