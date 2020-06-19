using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleDevEnvironmentConsole.OperationSettings
{
    class DataSourceSheetSettings : IDataSourceSheetSettings
    {
        public int HeaderRow { get; }
        public string Name { get; }
    }
}
