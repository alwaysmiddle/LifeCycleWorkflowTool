using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType
{
    public class DataSourceTypeOperation
    {
        [JsonProperty]
        public WipSheetWithDataSettings WipSettings { get; private set; }
        [JsonProperty]
        public FinalSheetSettings FinalSettings { get; private set; }
        [JsonProperty]
        public DataSourceSheetSettings DataSourceSettings { get; private set; }
        
        [JsonConstructor]
        public DataSourceTypeOperation(WipSheetWithDataSettings wipSettings, FinalSheetSettings finalSettings, DataSourceSheetSettings dataSourceSettings)
        {
            WipSettings = wipSettings;
            FinalSettings = finalSettings;
            DataSourceSettings = dataSourceSettings;
        }
    }
}
