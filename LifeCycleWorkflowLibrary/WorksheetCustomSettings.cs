using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeCycleWorkflowLibrary
{
    /// <summary>
    /// This class is responsible to define all the custom settings of a worksheet within this project.
    /// </summary>

    public class WorksheetCustomSettings
    {
        public int HeaderRow { get; set; } = 0;
        public int ReferenceRow { get; set; } = 0;
        public int FormulaeRow { get; set; } = 0;
    }

    public class WorksheetCustomSettingsHolder: AppSettings<WorksheetCustomSettingsHolder>
    {
        public Dictionary<string, WorksheetCustomSettings> SettingsCollection { get; set; }

        public WorksheetCustomSettingsHolder()
        {
            SettingsCollection = new Dictionary<string, WorksheetCustomSettings>();
        }
    }
}
