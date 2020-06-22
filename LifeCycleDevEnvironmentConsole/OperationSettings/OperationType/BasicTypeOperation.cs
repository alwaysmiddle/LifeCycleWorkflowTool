using LifeCycleDevEnvironmentConsole.OperationSettings.OperationType.OperationTypeComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings.OperationType
{

    public class BasicTypeOperation : IBasicTypeOperation
    {
        [JsonProperty]
        public IWipSheetSettings WipSettings { get; }
        [JsonProperty]
        public IFinalSheetSettings FinalSettings { get; }

        [JsonConstructor]
        public BasicTypeOperation(WipSheetSettings wipSettings, FinalSheetSettings finalSettings)
        {
            WipSettings = wipSettings;
            FinalSettings = finalSettings;
        }
    }
}
