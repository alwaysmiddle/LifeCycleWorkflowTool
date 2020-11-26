using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType
{
    public class ReportTypeOperation
    {
        [JsonConstructor]
        public ReportTypeOperation(WipReportsSettings reportSettings, FinalSheetSettings finalSettings)
        {
            ReportSettings = reportSettings;
            FinalSettings = finalSettings;
        }

        [JsonProperty]
        public WipReportsSettings ReportSettings { get; private set; }
        [JsonProperty]
        public FinalSheetSettings FinalSettings { get; private set; }
    }
}
