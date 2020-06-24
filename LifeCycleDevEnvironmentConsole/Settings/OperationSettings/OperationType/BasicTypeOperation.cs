using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType
{

    public class BasicTypeOperation : IBasicTypeOperation
    {
        [JsonProperty]
        public IWipSheetSettings WipSettings { get; }

        [JsonConstructor]
        public BasicTypeOperation(WipSheetSettings wipSettings)
        {
            WipSettings = wipSettings;
        }
    }
}
