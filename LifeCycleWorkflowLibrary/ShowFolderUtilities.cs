using System.Diagnostics;
using System.IO;

namespace LifeCycleWorkflowLibrary
{
    public class ShowFolderUtilities
    {
        private Globals.Banner _banner;
        private Globals.ProcessType _process;

        public ShowFolderUtilities(Globals.ProcessType process, Globals.Banner banner)
        {
            _banner = banner;
            _process = process;
        }

        public void DisplayFolder()
        {
            if(_banner == Globals.Banner.TheBay)
            {
                if(_process == Globals.ProcessType.WorkInProgress)
                {
                    CreateSecondPathIfEmpty(StoredSettings.OutputDirectory.TheBay.WipOutputLocation, Globals.TheBay.PathHolder.DefaultWipOutputFolder);
                }
                else if(_process == Globals.ProcessType.Final)
                {
                    CreateSecondPathIfEmpty(StoredSettings.OutputDirectory.TheBay.FinalOutputLocation, Globals.TheBay.PathHolder.DefaultFinalOutputFolder);
                }
            }
        }

        private void CreateSecondPathIfEmpty(string firstPath, string secondPath)
        {
            if (firstPath == "" || firstPath == null)
            {
                Directory.CreateDirectory(secondPath);
                Process.Start(secondPath);
            }
            else
            {
                Directory.CreateDirectory(firstPath);
                Process.Start(firstPath);
            }
        }
    }
}
