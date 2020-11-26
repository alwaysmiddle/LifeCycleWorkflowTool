using LifeCycleWorkflowBackend.Settings.OperationSettings;
using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType;
using LifeCycleWorkflowBackend.Settings.OperationSettings.OperationType.OperationTypeComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend.Settings.DefaultSettings
{
    public class BasicTypeOperationBuilder
    {
        private BasicTypeOperation _typeOperation;
        private WipSheetSettings _wipSheet;

        public BasicTypeOperationBuilder BuildWipSheetSetting(string sheetName,
            int headerRow, int writingRow, string readingAddress)
        {
            _wipSheet = new WipSheetSettings(
                worksheetName: sheetName,
                headerRow: headerRow,
                writingRow: writingRow,
                readingAddress: readingAddress
                );
            return this;
        }

        public BasicTypeOperation Build()
        {
            if (_wipSheet != null)
            {
                _typeOperation = new BasicTypeOperation(
                    (WipSheetSettings)_wipSheet
                    );
                return _typeOperation;
            }
            else
            {
                throw new ArgumentException("Failed to build default Settings with BasicTypeBuilder");
            }
        }
    }
}
