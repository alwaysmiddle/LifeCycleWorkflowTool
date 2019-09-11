using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary
{
    public static class Globals
    {
        public static string TheBayOutputWipFile { get; set; }
        public static string TheBayOutputFinalFile { get; set; }
        public static bool ManualInputFilesLoadedCheck { get; set; } = false;
        public static bool WipFileProcessing { get; set; } = false;
        public static bool FinalFileProcesing { get; set; } = false;
        public static bool WipFileProcessSucessful { get; set; } = false;
        public static bool FinalFilePrcoessSucessful { get; set; } = false;

        //Worksheet Names
        public static string TheBayTemplateWsNameNosCombined { get; set; } = "NOS_Colour_Combined";
        public static string TheBayTemplateWsNameInactiveUpc { get; set; } = "Inactive_UPC";
        public static string TheBayTemplateWsNameDetailsProduct { get; set; } = "Details_Product";
    }
}
