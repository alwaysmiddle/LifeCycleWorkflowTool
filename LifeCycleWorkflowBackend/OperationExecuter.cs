using LifeCycleWorkflowBackend.BannerOperations;
using LifeCycleWorkflowBackend.Settings;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend
{
    public static class OperationExecuter
    {
        public async static Task RunBannerOperation(Banner banner)
        {
            BannerSettings settingsLoaded = SettingsIO.LoadBannerSettingsFromFile(banner);
            switch (banner)
            {
                case Banner.TheBay:
                    {
                        TheBayOperations theBayWorkflow = new TheBayOperations(settingsLoaded);
                        await Task.Run(() => theBayWorkflow.RunOperation());
                        break;
                    }

                case Banner.Saks:
                    {
                        SaksOperations saksWorkflow = new SaksOperations(settingsLoaded);
                        await Task.Run(() => saksWorkflow.RunOperation());
                        break;
                    }
                case Banner.O5:
                    {
                        O5Operations o5Workflow = new O5Operations(settingsLoaded);
                        await Task.Run(() => o5Workflow.RunOperation());
                        break;
                    }
                default:
                    {
                        throw new Exception("The passed banner is not a valid banner.");
                    }
            }

            return;
        }
    }
}
