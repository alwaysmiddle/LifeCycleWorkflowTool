using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary
{
    public static class StoredSettings
    {
        private static void Save()
        {
            Properties.Settings.Default.Save();
        }


        /// <summary>
        /// The output files directory for this applications.
        /// </summary>
        public static class OutputDirectory
        {
            public static class TheBay
            {
                //TODO implement a default option checker

                public static bool UseDefaultLocation
                {
                    get
                    {
                        return Properties.Settings.Default.UseDefaultOutputLocations;
                    }
                    set
                    {
                        Properties.Settings.Default.UseDefaultOutputLocations = value;
                    }
                }


                //Work in progress output location
                public static string WipOutputLocation
                {
                    get
                    {
                        return Properties.Settings.Default.OutputLocationTheBayWip;
                    }
                    set
                    {
                        Properties.Settings.Default.OutputLocationTheBayWip = value;
                        Save();
                    }
                }

                //Work in progress output location
                public static string FinalOutputLocation
                {
                    get
                    {
                        return Properties.Settings.Default.OutputLocationTheBayFinal;
                    }
                    set
                    {
                        Properties.Settings.Default.OutputLocationTheBayFinal = value;
                        Save();
                    }
                }
            }
        }

        /// <summary>
        /// Template files locations.
        /// </summary>
        public static class TemplateLocations
        {
            //Template locations
            public static class TheBay
            {
                //TODO implement a default option checker

                //Work in progress output location
                public static string WipTempalteLocation
                {
                    get
                    {
                        return Properties.Settings.Default.TemplatePathTheBayWip;
                    }
                    set
                    {
                        Properties.Settings.Default.TemplatePathTheBayWip = value;
                        Save();
                    }
                }

                //Work in progress output location
                public static string FinalTemplateLocation
                {
                    get
                    {
                        return Properties.Settings.Default.TemplatePathTheBayFinal;
                    }
                    set
                    {
                        Properties.Settings.Default.TemplatePathTheBayFinal = value;
                        Save();
                    }
                }
            }
        }

        /// <summary>
        /// Manual input filenames stored as static properies. Provide read and write names for application to use.
        /// </summary>
        public static class ManualInputFileNames
        {
            public static class TheBay
            {
                public static string NosCombinedFile
                {
                    get
                    {
                        return Properties.Settings.Default.TheBayManualDataLoadNosCombinedFile;
                    }
                    set
                    {
                        Properties.Settings.Default.TheBayManualDataLoadNosCombinedFile = value;
                        Save();
                    }
                }

                public static string NotOnSiteFile
                {
                    get
                    {
                        return Properties.Settings.Default.TheBayManualDataLoadNosFile;
                    }
                    set
                    {
                        Properties.Settings.Default.TheBayManualDataLoadNosFile = value;
                        Save();
                    }
                }

                public static string InventoryAmountFile
                {
                    get
                    {
                        return Properties.Settings.Default.TheBayManualDataLoadInventoryAmountFile;
                    }
                    set
                    {
                        Properties.Settings.Default.TheBayManualDataLoadInventoryAmountFile = value;
                        Save();
                    }
                }

                public static string InactiveUpcFile
                {
                    get
                    {
                        return Properties.Settings.Default.TheBayManualDataLoadInactiveUpcFile;
                    }
                    set
                    {
                        Properties.Settings.Default.TheBayManualDataLoadInactiveUpcFile = value;
                        Save();
                    }
                }

            }
        }
    }
}
