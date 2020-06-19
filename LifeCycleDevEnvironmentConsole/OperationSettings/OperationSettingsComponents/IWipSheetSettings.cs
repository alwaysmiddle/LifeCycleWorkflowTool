namespace LifeCycleDevEnvironmentConsole.OperationSettings
{
    interface IWipSheetSettings
    {
        int HeaderRow { get; }
        string ReadingAddress { get; }
        string WorksheetName { get; }
        int WritingRow { get; }
    }
}