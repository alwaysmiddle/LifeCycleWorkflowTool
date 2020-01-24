using LifeCycleWorkflowLibrary;

namespace LifeCycleWorkflowLibrary.Settings
{
    abstract class WorksheetSettingsBase
    {
        private int _headerRow;
        private string _startingAddress;   

        public int GetHeaderRowNumber()
        {
            return _headerRow;
        }

        public string GetStartingAddress()
        {
            return _startingAddress;
        }
    }
}
