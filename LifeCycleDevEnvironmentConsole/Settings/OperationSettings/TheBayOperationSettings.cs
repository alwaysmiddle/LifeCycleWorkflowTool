using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings
{
    public class TheBayOperationSettings : IBaseOperationSettings
    {
        [JsonProperty]
        public IBasicTypeOperation BitreportSettings { get; }
        [JsonProperty]
        public IBasicTypeOperation WorkflowSettings { get; }
        [JsonProperty]
        public IBasicTypeOperation InactiveUpcSettings { get; }
        [JsonProperty]
        public IBasicTypeOperation NosCombinedSettings { get; }

        

        [JsonConstructor]
        public TheBayOperationSettings(
            BasicTypeOperation bitreportSettings,
            DataSourceTypeOperation workflowSettings, 
            DataSourceTypeOperation inactiveUpcSettings, 
            DataSourceTypeOperation nosCombinedSettings)
        {
            BitreportSettings = bitreportSettings;
            WorkflowSettings = workflowSettings;
            InactiveUpcSettings = inactiveUpcSettings;
            NosCombinedSettings = nosCombinedSettings;
        }
    }
}
