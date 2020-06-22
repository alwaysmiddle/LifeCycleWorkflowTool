using LifeCycleDevEnvironmentConsole.OperationSettings.OperationType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings
{
    public class TheBayOperationSettings : IBaseOperationSettings
    {
        [JsonProperty]
        public IBasicTypeOperation BitReportSettings { get; }
        [JsonProperty]
        public IBasicTypeOperation WorkflowSettings { get; }
        [JsonProperty]
        public IBasicTypeOperation InactiveUpcSettings { get; }
        [JsonProperty]
        public IBasicTypeOperation NosCombinedSettings { get; }

        [JsonConstructor]
        public TheBayOperationSettings(BasicTypeOperation bitReportSettings, DataSourceTypeOperation workflowSettings, 
            DataSourceTypeOperation inactiveUpcSettings, DataSourceTypeOperation nosCombinedSettings)
        {
            BitReportSettings = bitReportSettings;
            WorkflowSettings = workflowSettings;
            InactiveUpcSettings = inactiveUpcSettings;
            NosCombinedSettings = nosCombinedSettings;
        }
    }
}
