﻿using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType;

namespace LifeCycleWorkflowBackend.Settings.OperationSettings
{
    public class TheBayOperationSettings : IBaseOperationSettings
    {
        public ReportTypeOperation SummarySettings { get; private set; }
        public BasicTypeOperation BitreportSettings { get; private set; }
        public DataSourceTypeOperation WorkflowSettings { get; private set; }
        public DataSourceTypeOperation InactiveUpcSettings { get; private set; }
        public DataSourceTypeOperation NosCombinedSettings { get; private set; }
    }
}
