using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class WipSheetWithDataSettings
    {
        public int FormulaRow { get; set; }
        public int ReferenceRow { get; set; }
        public string WorksheetName { get; set; }
        public int HeaderRow { get; set; }
        public int WritingRow { get; set; }
        public string ReadingAddress { get; set; }
    }
}
