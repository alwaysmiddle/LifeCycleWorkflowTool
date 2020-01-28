using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary.Settings
{
    class WorkflowWorksheet : WorksheetSettingsBase
    {
        public string WorksheetName { get; protected set; }
        public HbcBanner Banner { get; protected set; }
        public ProcessType WorksheetProcessType { get; protected set; }

        public WorkflowWorksheet(int HeaderRow, string StartingAddress ) : base(HeaderRow, StartingAddress)
        {
        }

    }
}
