using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType;
using Newtonsoft.Json;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings
{
    public interface IBaseOperationSettings
    {
        ReportTypeOperation SummarySettings { get; }
        BasicTypeOperation BitreportSettings { get; }
        DataSourceTypeOperation WorkflowSettings { get; }
        DataSourceTypeOperation InactiveUpcSettings { get; }
    }

    public class BaseOperationSettings: IBaseOperationSettings
    { 
        public ReportTypeOperation SummarySettings { get; set; }
        public BasicTypeOperation BitreportSettings { get; set; }
        public DataSourceTypeOperation WorkflowSettings { get; set; }
        public DataSourceTypeOperation InactiveUpcSettings { get; set; }  
    }
}
