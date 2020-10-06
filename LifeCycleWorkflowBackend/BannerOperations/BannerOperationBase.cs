using LifeCycleWorkflowBackend.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.BannerOperations
{
    public class BannerOperationBase
    {
        protected BannerSettings _settings { get; set; }
        public BannerOperationBase(BannerSettings settings)
        {
            _settings = settings;

            File.Copy(_settings.TemplateFullnameWip, _settings.OutputFileFullnameWip, true);
            File.Copy(_settings.TemplateFullnameFinal, _settings.OutputFileFullnameFinal, true);
        }
    }
}
