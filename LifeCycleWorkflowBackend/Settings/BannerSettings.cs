using LifeCycleWorkflowBackend.Settings.IO;
using LifeCycleWorkflowBackend.Settings.OperationSettings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.Settings
{
    public enum Banner
    {
        TheBay,
        Saks,
        O5
    }

    public class BannerSettings
    {
        //Template related variables
        [JsonProperty(PropertyName = "WipOutputDirectory")]
        private string _wipOutputDirectory;

        [JsonProperty(PropertyName = "FinalOutputDirectory")]
        private string _finalOutputDirectory;

        [JsonProperty(PropertyName = "DefaulOutputFilename")]
        private string _defaulOutputFilename;

        [JsonProperty(PropertyName = "OutputDate")]
        private DateTime _outputDate;

        [JsonProperty(PropertyName = "Banner")]
        private Banner _banner;
        private string _outputFilenameWip;
        private string _outputFilenameFinal;


        //Input related variables
        public string InputFilenameWorkflow { get; private set; }
        public string InputFilenameInactiveUpc { get; private set; }
        public string InputFilenameBitReport { get; private set; }
        public string InputFilenameNosCombined { get; private set; }

        //Exposed Template Variables
        public string TemplateFullnameWip { get; private set; }
        public string TemplateFullnameFinal { get; private set; }

        [JsonIgnore]
        public DateTime OutputDate => _outputDate;

        //Worksheet Settings
        [JsonProperty(PropertyName = "WorksheetSettings")]
        [JsonConverter(typeof(IBaseOperationConverter))]
        public IBaseOperationSettings WorksheetSettings { get; private set; }

        [JsonIgnore]
        public string OutputFileFullnameWip => _outputFilenameWip;
        [JsonIgnore]
        public string OutputFileFullnameFinal => _outputFilenameFinal;


        /// <summary>
        /// Constructs an object that represent each banner's basic settings.
        /// </summary>
        [JsonConstructor]
        public BannerSettings(Banner banner, 
            string inputFilenameWorkflow, string inputFilenameInactiveUpc, string inputFilenameBitReport,
            string templateFullnameWip, string templateFullnameFinal,
            IBaseOperationSettings worksheetSettings,
            string wipOutputDirectory = null, string finalOutputDirectory = null, string defaulOutputFilename = null,
            string inputFilenameNosCombined = null, DateTime? outputDate = null)
        {
            _wipOutputDirectory = wipOutputDirectory ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _finalOutputDirectory = finalOutputDirectory ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _defaulOutputFilename = defaulOutputFilename ?? "OutputFile";
            _outputDate = outputDate ?? DateTime.Now;
            _banner = banner;
            InputFilenameWorkflow = inputFilenameWorkflow;
            InputFilenameInactiveUpc = inputFilenameInactiveUpc;
            InputFilenameBitReport = inputFilenameBitReport;
            InputFilenameNosCombined = inputFilenameNosCombined;
            TemplateFullnameWip = templateFullnameWip;
            TemplateFullnameFinal = templateFullnameFinal;
            WorksheetSettings = worksheetSettings;

            ConstructOutputName();
            Validate();
        }

        private void Validate()
        {
            if (!Directory.Exists(_wipOutputDirectory))
            {
                throw new ArgumentException(_banner.ToString() + " Directory does not exist.", "OutputDirectoryWip");
            }

            if (!Directory.Exists(_finalOutputDirectory))
            {
                throw new ArgumentException(_banner.ToString() + " Directory does not exist.", "OutputDirectoryFinal");
            }

            if (string.IsNullOrEmpty(InputFilenameWorkflow))
            {
                throw new ArgumentException(_banner.ToString() + " Workflow input is null or empty.", "InputFilenameWorkflow");
            }

            if (string.IsNullOrEmpty(InputFilenameInactiveUpc))
            {
                throw new ArgumentException(_banner.ToString() + " Inactive UPC input is null or empty.", "InputFilenameInactiveUpc");
            }

            if (string.IsNullOrEmpty(InputFilenameBitReport))
            {
                throw new ArgumentException(_banner.ToString() + " BIT report input is null or empty.", "InputFilenameBitReport");
            }

            if (_banner == Banner.TheBay)
            {
                if (string.IsNullOrEmpty(InputFilenameNosCombined))
                {
                    throw new ArgumentException(_banner.ToString() + " NOS combined must is null or empty.", "InputFilenameNosCombined");
                }
            }

            if (string.IsNullOrEmpty(TemplateFullnameWip))
            {
                throw new ArgumentException(_banner.ToString() + " Template filename WIP is null or empty.", "TemplateFilenameWip");
            }

            if (string.IsNullOrEmpty(TemplateFullnameFinal))
            {
                throw new ArgumentException(_banner.ToString() + " Template filename Final is null or empty.", "TemplateFilenameFinal");
            }

            if (WorksheetSettings == null)
            {
                throw new ArgumentNullException("WorksheetSettings from banner {0} is empty", _banner.ToString());
            }

        }

        private void ConstructOutputName()
        {
            string temp = _wipOutputDirectory + "\\" + _outputDate.ToString("MM.dd.yyyy_") + _defaulOutputFilename + "_Wip.xlsm";

            if (File.Exists(temp))
            {
                _outputFilenameWip = _wipOutputDirectory + "\\" + _outputDate.ToString("MM.dd.yyyy") + DateTime.Now.ToString("_HH.mm.ss_") + _defaulOutputFilename + "_Wip.xlsm";
            }
            else
            {
                _outputFilenameWip = temp;
            }

            temp = _finalOutputDirectory + "\\" + _outputDate.ToString("MM.dd.yyyy_") + _defaulOutputFilename + "_Final.xlsx";

            if (File.Exists(temp))
            {
                _outputFilenameFinal = _finalOutputDirectory + "\\" + _outputDate.ToString("MM.dd.yyyy") + DateTime.Now.ToString("_HH.mm.ss_") + _defaulOutputFilename + "_Final.xlsx";
            }
            else
            {
                _outputFilenameFinal = temp;
            }
        }
    }
}
