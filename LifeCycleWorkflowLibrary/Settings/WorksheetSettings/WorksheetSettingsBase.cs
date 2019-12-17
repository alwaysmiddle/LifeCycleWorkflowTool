using LifeCycleWorkflowLibrary;

namespace LifeCycleWorkflowLibrary.Settings
{
    abstract class WorksheetSettingsBase
    {
        private readonly string _worksheetName;
        private readonly string _internalRef;
        private readonly HbcBanner _banner;
        private readonly int _headerRow;

        public WorksheetSettingsBase()
        {
           
        }
    }
}
