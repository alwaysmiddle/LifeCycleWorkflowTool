using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary
{
    interface IAppSettingsBase
    {
        void Load();
        void Save();
    }
}
