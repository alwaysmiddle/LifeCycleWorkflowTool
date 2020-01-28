using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary.Settings
{
    class WorkflowWorksheet : WorksheetSettingsBase
    {
        public string WorksheetName { get; }
        private HbcBanner _banner;
        private ProcessType _worksheetProcessType;

        public WorkflowWorksheet(int HeaderRow, string StartingAddress, ) : base(HeaderRow, StartingAddress)
        {
        }

        public HbcBanner GetBanner()
        {
            return _banner;
        }

    }
}
