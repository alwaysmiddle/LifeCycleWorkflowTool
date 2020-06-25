using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class WipReportsSettings
    {
        [JsonConstructor]
        public WipReportsSettings(string worksheetName, string dateAddress, string readingAddress)
        {
            WorksheetName = worksheetName;
            DateAddress = dateAddress;
            ReadingAddress = readingAddress;
        }

        public string WorksheetName { get; }
        public string DateAddress { get; }
        public string ReadingAddress { get; }
    }
}
