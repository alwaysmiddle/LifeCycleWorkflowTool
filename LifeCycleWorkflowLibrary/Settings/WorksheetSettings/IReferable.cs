using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary.Settings.WorksheetSettings
{
    interface IReferable
    {
        int GetReferenceRow();
        int GetFormulaRow();
    }
}
