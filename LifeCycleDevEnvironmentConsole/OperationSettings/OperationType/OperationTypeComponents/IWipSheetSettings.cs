using Newtonsoft.Json;

namespace LifeCycleDevEnvironmentConsole.OperationSettings.OperationType.OperationTypeComponents
{
    public interface IWipSheetSettings
    {
        int HeaderRow { get; }
        string ReadingAddress { get; }
        string WorksheetName { get; }
        int WritingRow { get; }
    }

    public class WipSheetSettings : IWipSheetSettings
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