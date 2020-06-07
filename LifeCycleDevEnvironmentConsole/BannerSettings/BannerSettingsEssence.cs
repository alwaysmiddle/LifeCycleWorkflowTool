using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public partial class BannerSettings
    {
        public class BannerSettingsEssence
        {
            private Banner _banner;

            public string OutputDirectoryWip { get; set; }
            public string OutputDirectoryFinal { get; set; }
            public string DefaultOutputFilename { get; set; } = "OutputFile";
            public DateTime OutputDate { get; set; } = DateTime.Now;
            public string InputFilenameWorkflow { get; set; }
            public string InputFilenameInactiveUpc { get; set; }
            public string InputFilenameBitReport { get; set; }
            public string InputFilenameNosCombined { get; set; }
            public string TemplateFilenameWip { get; set; }
            public string TemplateFilenameFinal { get; set; }

            public BannerSettingsEssence(Banner banner)
            {
                _banner = banner;
            }


            private void Validate()
            {
                if(!Directory.Exists(OutputDirectoryWip))
                {
                    throw new ArgumentException("Directory does not exist.", "OutputDirectoryWip");
                }

                if (!Directory.Exists(OutputDirectoryFinal))
                {
                    throw new ArgumentException("Directory does not exist.", "OutputDirectoryFinal");
                }

                if (string.IsNullOrEmpty(InputFilenameWorkflow))
                {
                    throw new ArgumentException("Workflow input is null or empty.", "InputFilenameWorkflow");
                }

                if (string.IsNullOrEmpty(InputFilenameInactiveUpc))
                {
                    throw new ArgumentException("Inactive UPC input is null or empty.", "InputFilenameInactiveUpc");
                }

                if (string.IsNullOrEmpty(InputFilenameBitReport))
                {
                    throw new ArgumentException("BIT report input is null or empty.", "InputFilenameBitReport");
                }

                if (_banner == Banner.TheBay)
                {
                    if (string.IsNullOrEmpty(InputFilenameNosCombined))
                    {
                        throw new ArgumentException("NOS combined must is null or empty.", "InputFilenameNosCombined");
                    }
                }

                if (string.IsNullOrEmpty(TemplateFilenameWip))
                {
                    throw new ArgumentException("Template filename WIP is null or empty.", "TemplateFilenameWip");
                }

                if (string.IsNullOrEmpty(TemplateFilenameFinal))
                {
                    throw new ArgumentException("Template filename Final is null or empty.", "TemplateFilenameFinal");
                }
            }

            public BannerSettings GetNewInstance()
            {
                Validate();
                return new BannerSettings(this);
            }

        }
    }
}
