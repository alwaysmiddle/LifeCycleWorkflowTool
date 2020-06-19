using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings
{
    class WipSheetSettings : IWipSheetSettings
    {
        public string WorksheetName { get; }
        public int HeaderRow { get; }
        public int WritingRow { get; }
        public string ReadingAddress { get; }
    }
}
