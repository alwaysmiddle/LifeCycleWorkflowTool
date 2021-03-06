﻿using LifeCycleWorkflowBackend.Settings;
using System;
using System.Data;
using System.IO;
using System.Text;

namespace LifeCycleDevEnvironmentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SettingsIO.CreateDefaultSettingsProfile(Banner.TheBay, false);
            BannerSettings settingsLoaded = SettingsIO.LoadBannerSettingsFromFile(Banner.TheBay);

            string outputPath = settingsLoaded.OutputFileFullnameWip;
            //string loadedPath = Path.GetFullPath(settingsLoaded.TemplateFullnameWip);
            //Console.WriteLine(loadedPath);
            File.Copy(settingsLoaded.TemplateFullnameWip, outputPath, true);
         
            Console.WriteLine(settingsLoaded.OutputFileFullnameFinal);

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
