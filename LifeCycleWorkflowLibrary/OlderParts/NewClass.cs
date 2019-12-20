using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary
{
    class WipButtonClicked
    {
        public IBannerOperation operation { get; set; }

        public WipButtonClicked(IBannerOperation bannerOperation)
        {
            this.operation = bannerOperation;
        }
    }

    interface IBannerOperation
    {
        void RunOperations(Banner banner);
    }

    class TheBayOperation : IBannerOperation
    {
        public void RunOperations(Banner banner)
        {
            throw new NotImplementedException();
        }
    }

    class SaksOperation : IBannerOperation
    {
        public void RunOperations(Banner banner)
        {
            throw new NotImplementedException();
        }
    }
}
