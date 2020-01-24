using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary.Settings.WorksheetSettings
{
    class WorkflowWorksheet: WorksheetSettingsBase
    {
        private HbcBanner _banner;
        private ProcessType _worksheetProcessType;

        public HbcBanner GetBanner()
        {
            return _banner;
        }

        public ProcessType GetProcessType()
        {
            return _worksheetProcessType;
        }
    }
}
