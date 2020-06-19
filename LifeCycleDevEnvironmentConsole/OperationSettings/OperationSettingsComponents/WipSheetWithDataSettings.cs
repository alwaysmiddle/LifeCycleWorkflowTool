using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings.OperationSettingsComponents
{
    class WipSheetWithDataSettings : IWipSheetSettings
    {
        public int HeaderRow { get; }
        public int FormulaRow { get; }
        public int ReferenceRow { get; }
        public string ReadingAddress { get; }
        public string WorksheetName { get; }
        public int WritingRow { get; }
    }
}
