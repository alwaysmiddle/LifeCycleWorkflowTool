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
        public ReportTypeOperation SummarySettings { get; }
        [JsonProperty]
        public BasicTypeOperation BitreportSettings { get; }
        [JsonProperty]
        public DataSourceTypeOperation WorkflowSettings { get; }
        [JsonProperty]
        public DataSourceTypeOperation InactiveUpcSettings { get; }
        [JsonProperty]
        public DataSourceTypeOperation NosCombinedSettings { get; }

        [JsonConstructor]
        public TheBayOperationSettings(
            ReportTypeOperation summarySettings,
            BasicTypeOperation bitreportSettings,
            DataSourceTypeOperation workflowSettings, 
            DataSourceTypeOperation inactiveUpcSettings, 
            DataSourceTypeOperation nosCombinedSettings)
        {
            SummarySettings = summarySettings;
            BitreportSettings = bitreportSettings;
            WorkflowSettings = workflowSettings;
            InactiveUpcSettings = inactiveUpcSettings;
            NosCombinedSettings = nosCombinedSettings;
        }
    }
}
