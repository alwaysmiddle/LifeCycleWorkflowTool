using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary
{
    public class ShowFolderUtilities
    {
        public enum Banner
        {
            TheBay
        }

        public enum ProcessType
        {
            WorkInProgress,
            Final
        }

        private Banner _banner;
        private ProcessType _process;

        public ShowFolderUtilities(ProcessType process, Banner banner)
        {
            _banner = banner;
            _process = process;
        }

        public void DisplayFolder()
        {

        }
    }
}
