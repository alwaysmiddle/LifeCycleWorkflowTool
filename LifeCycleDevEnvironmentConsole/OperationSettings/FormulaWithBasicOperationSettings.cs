using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings
{
    class FormulaWithBasicOperationSettings : IBasicTemplateRelationships, IAdjustableFormulaRows
    {
        public int WipFormulaRow { get; private set; }
        public int WipReferenceRow { get; private set; }
        public string DataSourceSheetName { get; private set; }
        public int DataSourceSheetHeaderRow { get; private set; }
        public string WipSheetName { get; private set; }
        public int WipHeaderRow { get; private set; }
        public string WipReadingAddress { get; private set; }
        public string FinalSheetName { get; private set; }
        public string FinalSheetWritingAddress { get; private set; }
    }
}
