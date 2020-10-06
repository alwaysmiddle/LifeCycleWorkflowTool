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
        [JsonProperty]
        public int FormulaRow { get; private set; }
        [JsonProperty]
        public int ReferenceRow { get; private set; }
        [JsonProperty]
        public string WorksheetName { get; private set; }
        [JsonProperty]
        public int HeaderRow { get; private set; }
        [JsonProperty]
        public int WritingRow { get; private set; }
        [JsonProperty]
        public string ReadingAddress { get; private set; }

        [JsonConstructor]
        public WipSheetWithDataSettings(string worksheetName, string readingAddress,
            int headerRow, int formulaRow, int referenceRow,  int writingRow)
        {
            HeaderRow = headerRow;
            FormulaRow = formulaRow;
            FormulaRow = formulaRow;
            ReferenceRow = referenceRow;
            ReadingAddress = readingAddress;
            WorksheetName = worksheetName;
            WritingRow = writingRow;
        }
    }
}
