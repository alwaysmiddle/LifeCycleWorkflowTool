using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary.Settings
{
    interface IAppSettingsBase
    {
        void Load();
        void Save();
    }
}
