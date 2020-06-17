using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings
{
    class BasicOperationSettings : IBasicTemplateRelationships
    {
        public string WipSheetName { get; private set; }
        public int WipHeaderRow { get; private set; }
        public string WipReadingAddress { get; private set; }
        public string FinalSheetName { get; private set; }
        public string FinalSheetWritingAddress { get; private set; }
    }
}
