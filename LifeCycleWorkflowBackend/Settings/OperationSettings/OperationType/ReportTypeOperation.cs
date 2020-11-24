using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType
{
    public class ReportTypeOperation
    {
        public WipReportsSettings ReportSettings { get; set; }
        public FinalSheetSettings FinalSettings { get; set; }
    }
}
