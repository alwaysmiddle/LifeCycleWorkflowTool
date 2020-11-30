using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType;
using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents;
using System;


namespace LifeCycleWorkflowBackend.Settings.DefaultSettings
{
    public class BasicTypeOperationBuilder
    {
        private BasicTypeOperation _typeOperation = new BasicTypeOperation();
        private WipSheetSettings _wipSheet = new WipSheetSettings();

        public BasicTypeOperationBuilder BuildWipSheetSetting(string sheetName,
            int headerRow, int writingRow, string readingAddress)
        {
            _wipSheet.WorksheetName = sheetName;
            _wipSheet.HeaderRow = headerRow;
            _wipSheet.WritingRow = writingRow;
            _wipSheet.ReadingAddress = readingAddress;
                
            return this;
        }

        public BasicTypeOperation Build()
        {
            if (string.IsNullOrEmpty(_wipSheet.WorksheetName) ||
                string.IsNullOrEmpty(_wipSheet.ReadingAddress) ||
                _wipSheet.HeaderRow < 1 ||
                _wipSheet.WritingRow < 1
                )
            {
                throw new ArgumentException("Invalid Settings Values with BasicTypeBuilder");
            }
            else
            {
                _typeOperation.WipSettings = _wipSheet;
                return _typeOperation;
            }
        }
    }
}
