using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings
{
    interface IAdjustableFormulaRows
    {
        int WipFormulaRow { get; }
        int WipReferenceRow { get; }
        string DataSourceSheetName { get; }
        int DataSourceSheetHeaderRow { get; }
    }
}
