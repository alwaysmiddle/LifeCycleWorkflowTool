using LifeCycleWorkflowBackend.Settings;
using System;
using System.IO;

namespace LifeCycleWorkflowBackend.BannerOperations
{
    public class BannerOperationBase
    {
        protected BannerSettings _settings { get; set; }
        protected string _tempWipLocation { get; set; }
        protected string _tempFinalLocation { get; set; }

        public BannerOperationBase(BannerSettings settings)
        {
            _settings = settings;
            _tempWipLocation = Path.Combine(
                Path.GetTempPath(), 
                Guid.NewGuid().ToString() + "." + 
                new FileInfo(_settings.TemplateFullnameWip).Extension);

            _tempFinalLocation = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + "." + 
                new FileInfo(_settings.TemplateFullnameFinal).Extension);

            File.Copy(_settings.TemplateFullnameWip, _tempWipLocation, true);
            File.Copy(_settings.TemplateFullnameFinal, _tempFinalLocation, true);
        }
    }
}
