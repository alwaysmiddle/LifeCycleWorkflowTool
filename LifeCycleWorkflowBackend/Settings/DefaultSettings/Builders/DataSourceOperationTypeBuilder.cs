using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType;
using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents;
using System;

namespace LifeCycleWorkflowBackend.Settings.DefaultSettings
{
    public class DataSourceTypeOperationBuilder
    {
        private DataSourceTypeOperation _typeOperation = new DataSourceTypeOperation();
        private WipSheetWithDataSettings _wipSheet = new WipSheetWithDataSettings();
        private DataSourceSheetSettings _dataSource = new DataSourceSheetSettings();
        private FinalSheetSettings _finalSheet = new FinalSheetSettings();

        public DataSourceTypeOperationBuilder BuildWipSheetSetting(string sheetName,
            int headerRow, int writingRow, int formulaRow, int referenceRow, 
            string readingAddress)
        {
            _wipSheet.WorksheetName = sheetName;
            _wipSheet.HeaderRow = headerRow;
            _wipSheet.FormulaRow = formulaRow;
            _wipSheet.ReferenceRow = referenceRow;
            _wipSheet.WritingRow = writingRow;
            _wipSheet.ReadingAddress = readingAddress;

            return this;
        }

        public DataSourceTypeOperationBuilder BuildFinalSheetSettings(string sheetName,
            string writingAddress)
        {
            _finalSheet.WorksheetName = sheetName;
            _finalSheet.WritingAddress = writingAddress;
            
            return this;
        }

        public DataSourceTypeOperationBuilder BuildDataSheetSetting(string sheetName, 
            int headerRow, int writingRow)
        {
            _dataSource.WorksheetName = sheetName;
            _dataSource.HeaderRow = headerRow;
            _dataSource.WritingRow = writingRow;
            
            return this;
        }

        public DataSourceTypeOperation Build()
        {
            if (_wipSheet == null)
            {
                throw new ArgumentException("Failed to build WipSettings due to null value in DataSourceTypeBuilder");
            }
            else if(_finalSheet == null)
            {
                throw new ArgumentException("Failed to build FinalSettings due to null value in with DataSourceTypeBuilder");
            }
            else if(_dataSource == null)
            {
                throw new ArgumentException("Failed to DataSourceSettings due to null value in with DataSourceTypeBuilder");
            }else
            {
                _typeOperation.WipSettings = _wipSheet;
                _typeOperation.FinalSettings = _finalSheet;
                _typeOperation.DataSourceSettings = _dataSource;

                return _typeOperation;
            }
        }
    }
}
