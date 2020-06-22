using LifeCycleDevEnvironmentConsole.OperationSettings.OperationType.OperationTypeComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings.OperationType
{
    public interface IBasicTypeOperation
    {
        IFinalSheetSettings FinalSettings { get; }
        IWipSheetSettings WipSettings { get; }
    }
}
