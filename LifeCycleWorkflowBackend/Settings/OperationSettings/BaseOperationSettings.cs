﻿using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings
{
    public class BaseOperationSettings : IBaseOperationSettings
    {
        public ReportTypeOperation SummarySettings { get; set; }
        public BasicTypeOperation BitreportSettings { get; set; }
        public DataSourceTypeOperation WorkflowSettings { get; set; }
        public DataSourceTypeOperation InactiveUpcSettings { get; set; }
    }
}
