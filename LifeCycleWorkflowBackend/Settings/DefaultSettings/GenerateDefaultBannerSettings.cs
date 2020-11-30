using System;
using System.IO;

namespace LifeCycleWorkflowBackend.Settings.DefaultSettings
{
    /// <summary>
    /// Generate default settings that come with inital installation.
    /// </summary>
    public static class GenerateDefaultBannerSettings
    {
        static string _defaultOutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static BannerSettings SaksBannerDefault()
        {
            BannerSettings saksSettings = new BannerSettings();

            saksSettings.TheBanner = Banner.Saks;
            saksSettings.OutputFolderWip = _defaultOutputDirectory;
            saksSettings.OutputFolderFinal = _defaultOutputDirectory;
            saksSettings.DefaultOutputFilename = "Saks_Daily_Workflow";

            saksSettings.TemplateFullnameWip = string.Empty;
            saksSettings.TemplateFullnameFinal = string.Empty;
            saksSettings.InputFilenameBitReport = string.Empty;
            saksSettings.InputFilenameWorkflow = string.Empty;
            saksSettings.InputFilenameInactiveUpc = string.Empty;

            saksSettings.WorksheetSettings = GenerateDefaultWorkSheetSettings.SaksDefault();
            saksSettings.OutputDate = DateTime.Now;
            saksSettings.BannerPassword = "ecom678";
            saksSettings.WipWbValuesOnly = true;

            return saksSettings;
        }


        public static BannerSettings O5BannerDefault()
        {
            BannerSettings o5Settings = new BannerSettings();

            o5Settings.TheBanner = Banner.O5;
            o5Settings.OutputFolderWip = _defaultOutputDirectory;
            o5Settings.OutputFolderFinal = _defaultOutputDirectory;
            o5Settings.DefaultOutputFilename = "O5_Daily_Workflow";

            o5Settings.TemplateFullnameWip = string.Empty;
            o5Settings.TemplateFullnameFinal = string.Empty;
            o5Settings.InputFilenameBitReport = string.Empty;
            o5Settings.InputFilenameWorkflow = string.Empty;
            o5Settings.InputFilenameInactiveUpc = string.Empty;

            o5Settings.WorksheetSettings = GenerateDefaultWorkSheetSettings.O5Default();
            o5Settings.OutputDate = DateTime.Now;
            o5Settings.BannerPassword = "ecom678";
            o5Settings.WipWbValuesOnly = true;

            return o5Settings;
        }

        //TheBay settings
        public static BannerSettings TheBayBannerDefault()
        {
            BannerSettings theBaySettings = new BannerSettings();

            theBaySettings.TheBanner = Banner.TheBay;
            theBaySettings.OutputFolderWip = _defaultOutputDirectory;
            theBaySettings.OutputFolderFinal = _defaultOutputDirectory;
            theBaySettings.DefaultOutputFilename = "TheBay_Daily_Workflow";

            theBaySettings.TemplateFullnameWip = string.Empty;
            theBaySettings.TemplateFullnameFinal = string.Empty;
            theBaySettings.InputFilenameBitReport = string.Empty;
            theBaySettings.InputFilenameWorkflow = string.Empty;
            theBaySettings.InputFilenameInactiveUpc = string.Empty;
            theBaySettings.InputFilenameNosCombined = string.Empty;

            theBaySettings.WorksheetSettings = GenerateDefaultWorkSheetSettings.TheBayDefault();
            theBaySettings.OutputDate = DateTime.Now;
            theBaySettings.BannerPassword = "ecom678";
            theBaySettings.WipWbValuesOnly = true;

            return theBaySettings;
        }
    }
}
