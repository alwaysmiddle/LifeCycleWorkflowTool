using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings
{
    public interface IBaseOperationSettings
    {
        ReportTypeOperation SummarySettings { get; }
        BasicTypeOperation BitreportSettings { get; }
        DataSourceTypeOperation WorkflowSettings { get; }
        DataSourceTypeOperation InactiveUpcSettings { get; }
    }
    public class BaseOperationSettings: IBaseOperationSettings
    {
        [JsonProperty]
        public ReportTypeOperation SummarySettings { get; }
        [JsonProperty]
        public BasicTypeOperation BitreportSettings { get; }
        [JsonProperty]
        public DataSourceTypeOperation WorkflowSettings { get; }
        [JsonProperty]
        public DataSourceTypeOperation InactiveUpcSettings { get; }
        
        [JsonConstructor]
        public BaseOperationSettings(ReportTypeOperation summarySettings, BasicTypeOperation bitreportSettings, 
            DataSourceTypeOperation workflowSettings, DataSourceTypeOperation inactiveUpcSettings)
        {
            SummarySettings = summarySettings;
            BitreportSettings = bitreportSettings;
            WorkflowSettings = workflowSettings;
            InactiveUpcSettings = inactiveUpcSettings;
        }
    }
}
