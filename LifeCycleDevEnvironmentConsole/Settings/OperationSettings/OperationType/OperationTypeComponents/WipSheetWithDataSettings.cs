using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class WipSheetWithDataSettings : IWipSheetSettings
    {
        public int HeaderRow { get; }
        public int FormulaRow { get; }
        public int ReferenceRow { get; }
        public string ReadingAddress { get; }
        public string WorksheetName { get; }
        public int WritingRow { get; }

        [JsonConstructor]
        public WipSheetWithDataSettings(int headerRow, int formulaRow, int referenceRow, string readingAddress, string worksheetName, int writingRow)
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
