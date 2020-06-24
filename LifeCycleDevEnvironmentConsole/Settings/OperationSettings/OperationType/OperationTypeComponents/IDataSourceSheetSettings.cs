using Newtonsoft.Json;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public interface IDataSourceSheetSettings
    {
        int HeaderRow { get; }
        string WorksheetName { get; }
    }

    public class DataSourceSheetSettings : IDataSourceSheetSettings
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