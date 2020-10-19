using LifeCycleWorkflowBackend.BannerOperations;
using LifeCycleWorkflowBackend.Settings;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LifeCycleWorkflowBackend
{
    public static class OperationExecuter
    {
        public static void RunBannerOperation(Banner banner, BannerSettings settingsLoaded)
        {
            
            switch (banner)
            {
                case Banner.TheBay:
                    {
                        TheBayOperations theBayWorkflow = new TheBayOperations(settingsLoaded);
                        theBayWorkflow.RunOperation();
                        break;
                    }

                case Banner.Saks:
                    {
                        SaksOperations saksWorkflow = new SaksOperations(settingsLoaded);
                        saksWorkflow.RunOperation();
                        break;
                    }
                case Banner.O5:
                    {
                        O5Operations o5Workflow = new O5Operations(settingsLoaded);
                        o5Workflow.RunOperation();
                        break;
                    }
                default:
                    {
                        throw new Exception("The passed banner is not a valid banner.");
                    }
            }
        }
    }
}
