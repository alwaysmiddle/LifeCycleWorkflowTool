using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType
{
    public class DataSourceTypeOperation : IBasicTypeOperation
    {
        [JsonProperty]
        public IWipSheetSettings WipSettings { get; }
        [JsonProperty]
        public IFinalSheetSettings FinalSettings { get; }
        [JsonProperty]
        public IDataSourceSheetSettings DataSourceSettings { get; }
        
        [JsonConstructor]
        public DataSourceTypeOperation(WipSheetWithDataSettings wipSettings, FinalSheetSettings finalSettings, DataSourceSheetSettings dataSourceSettings)
        {
            WipSettings = wipSettings;
            FinalSettings = finalSettings;
            DataSourceSettings = dataSourceSettings;
        }
    }
}
