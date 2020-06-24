
using LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType.OperationTypeComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.Settings.OperationSettings.OperationType
{
    public interface IBasicTypeOperation
    {
        IWipSheetSettings WipSettings { get; }
    }
}
