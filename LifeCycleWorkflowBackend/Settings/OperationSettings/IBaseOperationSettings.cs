using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType;


namespace LifeCycleWorkflowBackend.Settings.OperationSettings
{
    public interface IBaseOperationSettings
    {
        ReportTypeOperation SummarySettings { get; }
        BasicTypeOperation BitreportSettings { get; }
        DataSourceTypeOperation WorkflowSettings { get; }
        DataSourceTypeOperation InactiveUpcSettings { get; }
    }
}
