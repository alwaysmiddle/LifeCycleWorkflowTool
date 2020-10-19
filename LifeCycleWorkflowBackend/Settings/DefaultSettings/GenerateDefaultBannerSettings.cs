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
            BannerSettings saksSettings = new BannerSettings(
                banner: Banner.Saks,
                wipOutputDirectory: _defaultOutputDirectory,
                finalOutputDirectory: _defaultOutputDirectory,
                defaulOutputFilename: "Saks_Daily_Workflow",
                templateFullnameWip: string.Empty,
                templateFullnameFinal: string.Empty,
                inputFilenameBitReport: string.Empty,
                inputFilenameWorkflow: string.Empty,
                inputFilenameInactiveUpc: string.Empty,
                worksheetSettings: GenerateDefaultWorkSheetSettings.SaksDefault(),
                outputDate: null
                );

            return saksSettings;
        }


        public static BannerSettings O5BannerDefault()
        {
            BannerSettings o5Settings = new BannerSettings(
                banner: Banner.O5,
                wipOutputDirectory: _defaultOutputDirectory,
                finalOutputDirectory: _defaultOutputDirectory,
                defaulOutputFilename: "O5_Daily_Workflow",
                templateFullnameWip: string.Empty,
                templateFullnameFinal: string.Empty,
                inputFilenameBitReport: string.Empty,
                inputFilenameWorkflow: string.Empty,
                inputFilenameInactiveUpc: string.Empty,
                outputDate: null,
                worksheetSettings: GenerateDefaultWorkSheetSettings.O5Default()
                );

            return o5Settings;
        }

        public static BannerSettings TheBayBannerDefault()
        {
            //TheBay settings
            BannerSettings theBaySettings = new BannerSettings(
            banner: Banner.TheBay,
            wipOutputDirectory: _defaultOutputDirectory,
            finalOutputDirectory: _defaultOutputDirectory,
            defaulOutputFilename: "TheBay_Daily_Workflow",
            templateFullnameWip: string.Empty,
            templateFullnameFinal: string.Empty,
            inputFilenameBitReport: string.Empty,
            inputFilenameWorkflow: string.Empty,
            inputFilenameInactiveUpc: string.Empty,
            inputFilenameNosCombined: string.Empty,
            worksheetSettings: GenerateDefaultWorkSheetSettings.TheBayDefault(),
            outputDate: new DateTime(2020, 9, 24)
            );

            return theBaySettings;
        }
    }
}
