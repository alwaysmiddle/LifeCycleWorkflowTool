namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents
{
    public class WipSheetWithDataSettings
    {
        public int HeaderRow { get; set; }
        public int FormulaRow { get; set; }
        public int ReferenceRow { get; set; }
        public int WritingRow { get; set; }

        public string WorksheetName { get; set; }
        public string ReadingAddress { get; set; }
    }
}
