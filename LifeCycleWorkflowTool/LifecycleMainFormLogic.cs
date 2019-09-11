using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeCycleWorkflowLibrary;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleWorkflowForm 
    {
        /// <summary>
        /// Responsible to set controls to correct state.
        /// </summary>
        private void MainFormStateCheck()
        {
            if (Globals.ManualInputFilesLoadedCheck && !Globals.WipFileProcessing && !Globals.WipFileProcessSucessful)
            {
                ManualLoadButtonWip.Enabled = true;
            }
            else
            {
                ManualLoadButtonWip.Enabled = false;
            }

            if (Globals.WipFileProcessSucessful && !Globals.FinalFileProcesing && !Globals.FinalFilePrcoessSucessful)
            {
                ManualLoadButtonFinalFile.Enabled = true;
            }
            else
            {
                ManualLoadButtonFinalFile.Enabled = false;
            }
        }
    }
}
