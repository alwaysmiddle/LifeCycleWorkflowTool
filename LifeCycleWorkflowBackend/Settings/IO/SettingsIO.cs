using LifeCycleWorkflowBackend.Settings.DefaultSettings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.Settings
{
    public static class SettingsIO
    {
        #region Public Variables
        static string DefaultSettingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LifeCycle Workflow Automation");

        const string DEFAULT_SAKS_BANNER_SETTING_NAME = "SaksSettings.json";
        const string DEFAULT_O5_BANNER_SETTING_NAME = "O5Settings.json";
        const string DEFAULT_THEBAY_BANNER_SETTING_NAME = "TheBaySettings.json";
        #endregion

        /// <summary>
        /// Overwrites or creates default settings file depending on banner passed.
        /// </summary>
        public static void CreateDefaultSettingsProfile(Banner banner, bool overwrite = false)
        {
            if (!Directory.Exists(DefaultSettingsDirectory))
            {
                Directory.CreateDirectory(DefaultSettingsDirectory);
            }

            switch (banner)
            {
                case Banner.TheBay:
                    {
                        var theBayFilename = Path.Combine(DefaultSettingsDirectory, DEFAULT_THEBAY_BANNER_SETTING_NAME);
                        CreateBannerDefaultSettingsFile(theBayFilename, GenerateDefaultBannerSettings.TheBayBannerDefault(), overwrite);
                        break;
                    }

                case Banner.Saks:
                    {
                        var saksFilename = Path.Combine(DefaultSettingsDirectory, DEFAULT_SAKS_BANNER_SETTING_NAME);
                        CreateBannerDefaultSettingsFile(saksFilename, GenerateDefaultBannerSettings.SaksBannerDefault(), overwrite);
                        break;
                    }
                case Banner.O5:
                    {
                        var O5Filename = Path.Combine(DefaultSettingsDirectory, DEFAULT_O5_BANNER_SETTING_NAME);
                        CreateBannerDefaultSettingsFile(O5Filename, GenerateDefaultBannerSettings.O5BannerDefault(), overwrite);
                        break;
                    }
                default:
                    {
                        throw new Exception("The passed banner is not a valid banner.");
                    }
            }
        }


        /// <summary>
        /// Returns full filepath for banner settings file if it was created
        /// </summary>
        public static string GetFullBannerSettingsFilename(Banner banner)
        {
            switch (banner)
            {
                case Banner.TheBay:
                    {
                        return Path.Combine(DefaultSettingsDirectory, DEFAULT_THEBAY_BANNER_SETTING_NAME);
                    }

                case Banner.Saks:
                    {
                        return Path.Combine(DefaultSettingsDirectory, DEFAULT_SAKS_BANNER_SETTING_NAME);
                    }
                case Banner.O5:
                    {
                        return Path.Combine(DefaultSettingsDirectory, DEFAULT_O5_BANNER_SETTING_NAME);
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }


        public static BannerSettings LoadBannerSettingsFromFile(Banner banner)
        {
            switch (banner)
            {
                case Banner.TheBay:
                    {
                        var theBayFilename = Path.Combine(DefaultSettingsDirectory, DEFAULT_THEBAY_BANNER_SETTING_NAME);
                        return LoadSettingsFrom(theBayFilename);
                    }

                case Banner.Saks:
                    {
                        var saksFilename = Path.Combine(DefaultSettingsDirectory, DEFAULT_SAKS_BANNER_SETTING_NAME);
                        return LoadSettingsFrom(saksFilename);
                    }
                case Banner.O5:
                    {
                        var O5Filename = Path.Combine(DefaultSettingsDirectory, DEFAULT_O5_BANNER_SETTING_NAME);
                        return LoadSettingsFrom(O5Filename);
                    }
                default:
                    {
                        throw new Exception("The passed banner is not a valid banner.");
                    }
            }
        }

        #region Helper Functions
        /// <summary>
        /// Helper function that writes the settings to the passed file location.
        /// </summary>
        private static void CreateBannerDefaultSettingsFile(string filename, object settingObj, bool overwrite)
        {
            if (!File.Exists(filename) || overwrite)
            {
                string jsonFile = JsonConvert.SerializeObject(settingObj, Formatting.Indented);
                File.WriteAllText(filename, jsonFile);
            }
        }


        private static BannerSettings LoadSettingsFrom(string filepath)
        {
            using (StreamReader file = File.OpenText(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (BannerSettings)serializer.Deserialize(file, typeof(BannerSettings));
            }
        }
        #endregion
    }
}
