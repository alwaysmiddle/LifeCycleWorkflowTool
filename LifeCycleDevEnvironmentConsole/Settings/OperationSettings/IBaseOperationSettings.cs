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
        IBasicTypeOperation BitreportSettings { get; }
        IBasicTypeOperation WorkflowSettings { get; }
        IBasicTypeOperation InactiveUpcSettings { get; }
    }
    public class BaseOperationSettings: IBaseOperationSettings
    {
        [JsonProperty]
        public IBasicTypeOperation BitreportSettings { get; }
        [JsonProperty]
        public IBasicTypeOperation WorkflowSettings { get; }
        [JsonProperty]
        public IBasicTypeOperation InactiveUpcSettings { get; }

        [JsonConstructor]
        public BaseOperationSettings(BasicTypeOperation bitreportSettings ,DataSourceTypeOperation workflowSettings, DataSourceTypeOperation inactiveUpcSettings)
        {
            BitreportSettings = bitreportSettings;
            WorkflowSettings = workflowSettings;
            InactiveUpcSettings = inactiveUpcSettings;
        }
    }
}
