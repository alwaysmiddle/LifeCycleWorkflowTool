using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings
{
    interface IBasicTemplateRelationships
    {
        string WipSheetName { get; }
        int WipHeaderRow { get; }
        string WipReadingAddress { get; }
        string FinalSheetName { get; }
        string FinalSheetWritingAddress { get; }
    }
}
