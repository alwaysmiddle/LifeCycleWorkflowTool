using Newtonsoft.Json;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class WipSheetSettings
    {
        public string WorksheetName { get; }
        public int HeaderRow { get; }
        public int WritingRow { get; }
        public string ReadingAddress { get; }

        [JsonConstructor]
        public WipSheetSettings(string worksheetName, int headerRow, int writingRow, string readingAddress)
        {
            WorksheetName = worksheetName;
            HeaderRow = headerRow;
            WritingRow = writingRow;
            ReadingAddress = readingAddress;
        }
    }
}