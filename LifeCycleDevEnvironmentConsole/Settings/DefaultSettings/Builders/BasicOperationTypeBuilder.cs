using LifeCycleDevEnvironmentConsole.Settings.OperationSettings;
using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType;
using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.DefaultSettings
{
    public class BasicTypeOperationBuilder
    {
        private IBasicTypeOperation _typeOperation;
        private IWipSheetSettings _wipSheet;

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
                return (BasicTypeOperation)_typeOperation;
            }
            else
            {
                throw new ArgumentException("Failed to build default Settings with BasicTypeBuilder");
            }
        }
    }
}
