using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary.Settings
{
    interface IReferable
    {
        int ReferenceRow { get; set; }
        int FormulaRow { get; set; }
    }
}
