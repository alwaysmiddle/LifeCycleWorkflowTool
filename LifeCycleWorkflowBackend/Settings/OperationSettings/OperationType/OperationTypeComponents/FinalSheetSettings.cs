using Newtonsoft.Json;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class FinalSheetSettings
    {
        [JsonProperty]
        public string WorksheetName { get; private set; }
        [JsonProperty]
        public string WritingAddress { get; private set; }

        [JsonConstructor]
        public FinalSheetSettings(string worksheetName, string writingAddress)
        {
            WorksheetName = worksheetName;
            WritingAddress = writingAddress;
        }
    }
}