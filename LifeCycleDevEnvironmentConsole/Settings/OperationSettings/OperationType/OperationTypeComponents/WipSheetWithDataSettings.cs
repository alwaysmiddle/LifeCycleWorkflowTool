using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class WipSheetWithDataSettings
    { 
        public int FormulaRow { get; }
        public int ReferenceRow { get; }
        public string WorksheetName { get; }
        public int HeaderRow { get; }
        public int WritingRow { get; }
        public string ReadingAddress { get; }

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
