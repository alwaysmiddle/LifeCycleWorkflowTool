using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary
{
    /// <summary>
    /// This class is responsible to define all the custom settings of a worksheet within this project.
    /// </summary>

    public class WorksheetCustomSettings
    {    
        public int HeaderRow { get; set;}
        public int ReferenceRow { get; set; }
        public int FormulaeRow { get; set; }
    }

    public class WorksheetCustomSettingsHolder: AppSettings<WorksheetCustomSettings>
    {
        public Dictionary<string, WorksheetCustomSettings> SettingsCollection { get; set; }
    }
}
