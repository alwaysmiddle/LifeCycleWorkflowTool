using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType;
using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.DefaultSettings
{
    class ReportOperationTypeBuilder
    {
        private ReportTypeOperation _typeOperation;
        private WipReportsSettings _reportsheet;
        private FinalSheetSettings _finalSheet;

        public ReportOperationTypeBuilder BuildReportSheetSetting(string sheetName,
            string dateAddress, string readingAddress)
        {
            _reportsheet = new WipReportsSettings(
                worksheetName: sheetName,
                dateAddress: dateAddress,
                readingAddress: readingAddress
                );
            return this;
        }

        public ReportOperationTypeBuilder BuildFinalSheetSettings(string sheetName,
            string writingAddress)
        {
            _finalSheet = new FinalSheetSettings(
                worksheetName: sheetName,
                writingAddress: writingAddress
                );
            return this;
        }

        public ReportTypeOperation Build()
        {
            if (_reportsheet != null &&
                _finalSheet != null)
            {
                _typeOperation = new ReportTypeOperation(
                    reportSettings: _reportsheet,
                    finalSettings: _finalSheet
                    );
                return _typeOperation;
            }
            else
            {
                throw new ArgumentException("Failed to build default Settings with DataSourceTypeBuilder");
            }
        }
    }
}
