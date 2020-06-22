using Newtonsoft.Json;

namespace LifeCycleDevEnvironmentConsole.OperationSettings.OperationType.OperationTypeComponents
{
    public interface IFinalSheetSettings
    {
        string WorksheetName { get; }
        string WritingAddress { get; }
    }

    public class FinalSheetSettings : IFinalSheetSettings
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