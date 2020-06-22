using Newtonsoft.Json;

namespace LifeCycleDevEnvironmentConsole.OperationSettings.OperationType.OperationTypeComponents
{
    public interface IDataSourceSheetSettings
    {
        int HeaderRow { get; }
        string Name { get; }
    }

    public class DataSourceSheetSettings : IDataSourceSheetSettings
    {
        public int HeaderRow { get; }
        public string Name { get; }

        [JsonConstructor]
        public DataSourceSheetSettings(int headerRow, string name)
        {
            HeaderRow = headerRow;
            Name = name;
        }
    }
}