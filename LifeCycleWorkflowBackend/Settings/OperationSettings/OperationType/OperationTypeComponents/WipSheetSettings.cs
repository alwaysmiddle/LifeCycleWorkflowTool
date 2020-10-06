using Newtonsoft.Json;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class WipSheetSettings
    {
        [JsonProperty]
        public string WorksheetName { get; private set; }
        [JsonProperty]
        public int HeaderRow { get; private set; }
        [JsonProperty]
        public int WritingRow { get; private set; }
        [JsonProperty]
        public string ReadingAddress { get; private set; }

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