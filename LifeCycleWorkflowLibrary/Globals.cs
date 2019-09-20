using System;

namespace LifeCycleWorkflowLibrary
{
    public static class Globals
    {

        public enum ProcessType
        {
            WorkInProgress,
            Final
        }

        public enum Banner
        {
            TheBay
        }

        public static class General
        {
            public static class StateControl
            {
                //State Control
                public static bool ManualInputFilesLoadedCheck { get; set; } = false;
                public static bool WipFileProcessing { get; set; } = false;
                public static bool FinalFileProcesing { get; set; } = false;
                public static bool WipFileProcessSucessful { get; set; } = false;
                public static bool FinalFilePrcoessSucessful { get; set; } = false;
            }
            //Critical Keywords
            public static string MatchHeaderOperationKeyword { get; set; } = "MatchHeader";

            //User Inputs
            public static DateTime OutputFileDate { get; set; }
        }

        public static class TheBay
        {
            public static class PathHolder
            {
                //Filenames
                public static string OutputWipFile { get; set; }
                public static string OutputFinalFile { get; set; }
                public static string WsOptionsDefaultFileName { get; set; } = "WsOptionsTheBayDefault.json";

                //Foldernames
                public static string DefaultWipOutputFolder
                {
                    get
                    {
                        return Properties.Settings.Default.OutputLocationTheBayWip;
                    }
                }
                public static string DefaultFinalOutputFolder {
                    get
                    {
                        return Properties.Settings.Default.OutputLocationTheBayFinal;
                    }
                }
                    
            }

            public static class TemplateWorksheetNames
            {
                //Worksheet Names
                public static string NosCombined { get; set; } = "NOS_Colour_Combined";
                public static string InactiveUpc { get; set; } = "Inactive_UPC";
                public static string InactiveUpcData { get; set; } = "UPC_Looker";
                public static string DetailsProduct { get; set; } = "Details_Products";
                public static string DetailsProductData { get; set; } = "Looker_Data";
            }
        }
    }
}
