using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary.Settings
{
    interface IBannerSettings
    {

        string Banner { get; }
        string WipTemplateDirectory { get; }
        string FinalTemplateDirectory { get; }
        string WipOutputDirectory { get; }
        string FinalOutputDirectory { get; }
    }
}
