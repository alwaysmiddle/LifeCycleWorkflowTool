using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole
{
    public enum Banner
    {
        TheBay,
        Saks,
        O5
    }

    public partial class BannerSettings
    {
        //Template related variables
        private string _wipOutputDirectory;
        private string _finalOutputDirectory;
        private string _defaulOutputFilename;
        private DateTime _outputDate;

        //Input related variables
        public string InputFilenameWorkflow { get; }
        public string InputFilenameInactiveUpc { get; }
        public string InputFilenameBitReport { get; }
        public string InputFilenameNosCombined { get; }


        //Exposed Template Variables
        public string TemplateFullnameWip { get; }
        public string TemplateFullnameFinal { get; }
        public string OutputFileFullNameWip { get; }
        public string OutputFilenameFinal { get; }


        /// <summary>
        /// Constructs an object that represent each banner's basic settings.
        /// </summary>
        private BannerSettings(BannerSettingsEssence essence)
        {

            _wipOutputDirectory = essence.OutputDirectoryWip;
            _finalOutputDirectory = essence.OutputDirectoryFinal;
            _outputDate = essence.OutputDate;
            _defaulOutputFilename = essence.DefaultOutputFilename;

            TemplateFullnameWip = essence.TemplateFilenameWip;
            TemplateFullnameFinal = essence.TemplateFilenameFinal;
            InputFilenameWorkflow = essence.InputFilenameWorkflow;
            InputFilenameInactiveUpc = essence.InputFilenameInactiveUpc;
            InputFilenameBitReport = essence.InputFilenameBitReport;
            InputFilenameNosCombined = essence.InputFilenameNosCombined;

            
            string temp = _wipOutputDirectory + "\\" + _outputDate.ToString("MM.dd.yy_") + _defaulOutputFilename + "_Wip.xlsm";

            if (File.Exists(temp))
            {
                OutputFileFullNameWip = _wipOutputDirectory + "\\" + _outputDate.ToString("MM.dd.yy") + DateTime.Now.ToString("_HH.mm.ss_") + _defaulOutputFilename + "_Wip.xlsm";
            }
            else
            {
                OutputFileFullNameWip = temp;
            }

            temp = _finalOutputDirectory + "\\" + _outputDate.ToString("MM.dd.yy_") + _defaulOutputFilename + "_Final.xlsm";

            if (File.Exists(temp))
            {
                OutputFilenameFinal = _finalOutputDirectory + "\\" + _outputDate.ToString("MM.dd.yy") + DateTime.Now.ToString("_HH.mm.ss_") + _defaulOutputFilename + "_Final.xlsm";
            }
            else
            {
                OutputFilenameFinal = temp;
            }
        }
    }
}
