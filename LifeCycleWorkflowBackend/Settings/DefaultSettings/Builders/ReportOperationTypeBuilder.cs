using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType;
using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents;
using System;

namespace LifeCycleWorkflowBackend.Settings.DefaultSettings
{
    class ReportOperationTypeBuilder
    {
        private ReportTypeOperation _typeOperation = new ReportTypeOperation();
        private WipReportsSettings _reportsheet = new WipReportsSettings();
        private FinalSheetSettings _finalSheet = new FinalSheetSettings();

        public ReportOperationTypeBuilder BuildReportSheetSetting(string sheetName,
            string dateAddress, string readingAddress)
        {
            _reportsheet.WorksheetName = sheetName;
            _reportsheet.DateAddress = dateAddress;
            _reportsheet.ReadingAddress = readingAddress;
            
            return this;
        }

        public ReportOperationTypeBuilder BuildFinalSheetSettings(string sheetName,
            string writingAddress)
        {
            _finalSheet.WorksheetName = sheetName;
            _finalSheet.WritingAddress = writingAddress;
            
            return this;
        }

        public ReportTypeOperation Build()
        {
            if (_reportsheet == null)
            {
                throw new ArgumentException("Failed to build ReportSettings due to null value in DataSourceTypeBuilder");
            }
            if(_finalSheet != null)
            {
                throw new ArgumentException("Failed to build FinalSettings due to null value in DataSourceTypeBuilder");
            }
            else
            {
                _typeOperation.ReportSettings = _reportsheet;
                _typeOperation.FinalSettings = _finalSheet;
                return _typeOperation;
            }
        }
    }
}
