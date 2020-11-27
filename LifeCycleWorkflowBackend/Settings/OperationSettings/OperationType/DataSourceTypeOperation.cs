using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents;


namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType
{
    public class DataSourceTypeOperation
    {
        public WipSheetWithDataSettings WipSettings { get; set; }
        public FinalSheetSettings FinalSettings { get; set; }
        public DataSourceSheetSettings DataSourceSettings { get; set; }
    }
}
