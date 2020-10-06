using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType
{

    public class BasicTypeOperation 
    {
        [JsonProperty]
        public WipSheetSettings WipSettings { get; private set; }

        [JsonConstructor]
        public BasicTypeOperation(WipSheetSettings wipSettings)
        {
            WipSettings = wipSettings;
        }
    }
}
