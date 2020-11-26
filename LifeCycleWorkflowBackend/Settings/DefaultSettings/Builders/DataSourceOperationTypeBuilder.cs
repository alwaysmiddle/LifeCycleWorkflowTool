using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType;
using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.Settings.DefaultSettings
{
    public class DataSourceTypeOperationBuilder
    {
        private DataSourceTypeOperation _typeOperation;
        private WipSheetWithDataSettings _wipSheet;
        private DataSourceSheetSettings _dataSource;
        private FinalSheetSettings _finalSheet;

        public DataSourceTypeOperationBuilder BuildReportSheetSetting(string sheetName,
            int headerRow, int writingRow, int formulaRow, int referenceRow,
            string readingAddress)
        {
            _wipSheet = new WipSheetWithDataSettings(
                worksheetName: sheetName,
                headerRow: headerRow,
                formulaRow: formulaRow,
                referenceRow: referenceRow,
                writingRow: writingRow,
                readingAddress: readingAddress
                );
            return this;
        }


        public DataSourceTypeOperationBuilder BuildWipSheetSetting(string sheetName,
            int headerRow, int writingRow, int formulaRow, int referenceRow, 
            string readingAddress)
        {
            _wipSheet = new WipSheetWithDataSettings(
                worksheetName: sheetName,
                headerRow: headerRow,
                formulaRow: formulaRow,
                referenceRow: referenceRow,
                writingRow: writingRow,
                readingAddress: readingAddress
                );
            return this;
        }

        public DataSourceTypeOperationBuilder BuildFinalSheetSettings(string sheetName,
            string writingAddress)
        {
            _finalSheet = new FinalSheetSettings(
                worksheetName: sheetName,
                writingAddress: writingAddress
                );
            return this;
        }

        public DataSourceTypeOperationBuilder BuildDataSheetSetting(string sheetName, 
            int headerRow, int writingRow)
        {
            _dataSource = new DataSourceSheetSettings
            (
                writingRow: writingRow,
                headerRow: headerRow,
                sheetname: sheetName
            );
            return this;
        }

        public DataSourceTypeOperation Build()
        {
            if (_wipSheet != null &&
                _finalSheet != null &&
                _dataSource != null)
            {
                _typeOperation = new DataSourceTypeOperation(
                    wipSettings: _wipSheet,
                    finalSettings: _finalSheet,
                    dataSourceSettings:  _dataSource
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
