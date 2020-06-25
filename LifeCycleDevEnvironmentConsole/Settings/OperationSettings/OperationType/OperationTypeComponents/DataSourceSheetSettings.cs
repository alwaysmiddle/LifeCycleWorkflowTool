using Newtonsoft.Json;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class DataSourceSheetSettings
    {
        public int HeaderRow { get; }
        public int WritingRow { get; }
        public string WorksheetName { get; }

        [JsonConstructor]
        public DataSourceSheetSettings(string sheetname, int headerRow, int writingRow)
        {
            HeaderRow = headerRow;
            WorksheetName = sheetname;
            WritingRow = writingRow;
        }
    }
}