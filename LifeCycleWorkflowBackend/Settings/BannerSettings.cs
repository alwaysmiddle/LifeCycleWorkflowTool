using LifeCycleWorkflowBackend.Settings.IO;
using LifeCycleWorkflowBackend.Settings.OperationSettings;
using Newtonsoft.Json;
using System;
using System.IO;


namespace LifeCycleWorkflowBackend.Settings
{
    public enum Banner
    {
        TheBay,
        Saks,
        O5,
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

        [JsonProperty(PropertyName = "Banner")]
        private Banner _banner;

        //Output Folder Directories
        [JsonIgnore]
        public string OutputFolderWip
        {
            get {
                if (string.IsNullOrEmpty(_wipOutputDirectory.Trim()))
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                return _wipOutputDirectory; 
            }
            set { _wipOutputDirectory = value; }
        }
        [JsonIgnore]
        public string OutputFolderFinal
        {
            get {
                if (string.IsNullOrEmpty(_finalOutputDirectory.Trim()))
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                return _finalOutputDirectory; 
            }
            set { _finalOutputDirectory = value; }
        }

        //Input related variables
        public string InputFilenameWorkflow { get; set; }
        public string InputFilenameInactiveUpc { get; set; }
        public string InputFilenameBitReport { get; set; }
        public string InputFilenameNosCombined { get; set; }

        //Exposed Template Variables
        public string TemplateFullnameWip { get; set; }
        public string TemplateFullnameFinal { get; set; }

        //Banner variables
        public Banner TheBanner
        {
            get
            {
                return _banner;
            }
            set
            {
                _banner = value;
            }
        }
        public string BannerPassword { get; set; }
        public DateTime OutputDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public string DefaultOutputFilename
        {
            get {
                if(string.IsNullOrEmpty(_defaulOutputFilename.Trim())){
                    return "Default_PlaceHolderName";
                }
                return _wipOutputDirectory; 
            }
            set { _defaulOutputFilename = value; }
        }

        //Options
        //write values in wip workbook in values only, rather than formula used for testing purposes to keep formula in the outputs
        public bool WipWbValuesOnly { get; set; }
        
        
        //Worksheet Settings
        [JsonProperty(PropertyName = "WorksheetSettings")]
        [JsonConverter(typeof(IBaseOperationConverter))]
        public IBaseOperationSettings WorksheetSettings { get; set; }

        [JsonIgnore]
        public string OutputFileFullnameWip {
            get
            {
                string temp = _wipOutputDirectory + "\\" + OutputDate.ToString("MM.dd.yyyy_") + _defaulOutputFilename + "_Wip.xlsm";

                if (File.Exists(temp))
                {
                    return _wipOutputDirectory + "\\" + OutputDate.ToString("MM.dd.yyyy") + DateTime.Now.ToString("_HH.mm.ss_") + _defaulOutputFilename + "_Wip.xlsm";
                }
                else
                {
                    return temp;
                }
            }
        }
        [JsonIgnore]
        public string OutputFileFullnameFinal
        {
            get
            {
                string temp = _finalOutputDirectory + "\\" + OutputDate.ToString("MM.dd.yyyy_") + _defaulOutputFilename + "_Final.xlsx";

                if (File.Exists(temp))
                {
                    return _finalOutputDirectory + "\\" + OutputDate.ToString("MM.dd.yyyy") + DateTime.Now.ToString("_HH.mm.ss_") + _defaulOutputFilename + "_Final.xlsx";
                }
                else
                {
                    return temp;
                }
            }
        }


        /// <summary>
        /// Constructs an object that represent each banner's basic settings.
        /// </summary>
        //[JsonConstructor]
        //public BannerSettings(Banner banner, 
        //    string inputFilenameWorkflow, string inputFilenameInactiveUpc, string inputFilenameBitReport,
        //    string templateFullnameWip, string templateFullnameFinal,
        //    IBaseOperationSettings worksheetSettings,
        //    string wipOutputDirectory = null, string finalOutputDirectory = null, string defaulOutputFilename = null,
        //    string inputFilenameNosCombined = null, DateTime? outputDate = null)
        //{
        //    _wipOutputDirectory = wipOutputDirectory ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    _finalOutputDirectory = finalOutputDirectory ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    _defaulOutputFilename = defaulOutputFilename ?? "OutputFile";
        //    _outputDate = outputDate ?? DateTime.Now;
        //    _banner = banner;
        //    InputFilenameWorkflow = inputFilenameWorkflow;
        //    InputFilenameInactiveUpc = inputFilenameInactiveUpc;
        //    InputFilenameBitReport = inputFilenameBitReport;
        //    InputFilenameNosCombined = inputFilenameNosCombined;
        //    TemplateFullnameWip = templateFullnameWip;
        //    TemplateFullnameFinal = templateFullnameFinal;
        //    WorksheetSettings = worksheetSettings;
        //}

        public void Validate()
        {

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
    }
}
