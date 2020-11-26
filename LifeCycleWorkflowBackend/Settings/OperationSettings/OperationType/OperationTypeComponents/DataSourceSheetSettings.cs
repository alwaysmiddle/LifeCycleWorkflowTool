using Newtonsoft.Json;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class DataSourceSheetSettings
    {
        [JsonProperty]
        public int HeaderRow { get; private set; }
        [JsonProperty]
        public int WritingRow { get; private set; }
        [JsonProperty]
        public string WorksheetName { get; private set; }

        [JsonConstructor]
        public DataSourceSheetSettings(string sheetname, int headerRow, int writingRow)
        {
            HeaderRow = headerRow;
            WorksheetName = sheetname;
            WritingRow = writingRow;
        }
    }
}