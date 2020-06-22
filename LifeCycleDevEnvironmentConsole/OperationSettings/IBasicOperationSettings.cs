using LifeCycleDevEnvironmentConsole.OperationSettings.OperationType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings
{
    public interface IBaseOperationSettings
    {
        IBasicTypeOperation BitReportSettings { get; }
        IBasicTypeOperation WorkflowSettings { get; }
        IBasicTypeOperation InactiveUpcSettings { get; }
    }
    public class BaseOperationSettings: IBaseOperationSettings
    {
        [JsonProperty]
        public IBasicTypeOperation BitReportSettings { get; }
        [JsonProperty]
        public IBasicTypeOperation WorkflowSettings { get; }
        [JsonProperty]
        public IBasicTypeOperation InactiveUpcSettings { get; }

        [JsonConstructor]
        public BaseOperationSettings(BasicTypeOperation bitReportSettings, DataSourceTypeOperation workflowSettings, DataSourceTypeOperation inactiveUpcSettings)
        {
            BitReportSettings = bitReportSettings;
            WorkflowSettings = workflowSettings;
            InactiveUpcSettings = inactiveUpcSettings;
        }
    }
}
