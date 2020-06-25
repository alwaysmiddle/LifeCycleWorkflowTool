using Newtonsoft.Json;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class FinalSheetSettings
    {
        public string WorksheetName { get; }
        public string WritingAddress { get; }

        [JsonConstructor]
        public FinalSheetSettings(string worksheetName, string writingAddress)
        {
            WorksheetName = worksheetName;
            WritingAddress = writingAddress;
        }
    }
}