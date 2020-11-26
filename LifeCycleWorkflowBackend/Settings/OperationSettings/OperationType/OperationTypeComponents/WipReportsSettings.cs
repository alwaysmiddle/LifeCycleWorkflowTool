using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class WipReportsSettings
    {
        [JsonProperty]
        public string WorksheetName { get; private set; }
        [JsonProperty]
        public string DateAddress { get; private set; }
        [JsonProperty]
        public string ReadingAddress { get; private set; }

        [JsonConstructor]
        public WipReportsSettings(string worksheetName, string dateAddress, string readingAddress)
        {
            WorksheetName = worksheetName;
            DateAddress = dateAddress;
            ReadingAddress = readingAddress;
        }
    }
}
