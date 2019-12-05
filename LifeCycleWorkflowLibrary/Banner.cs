using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary
{
    class Banner
    {
        private string _banner;
        public string GetBanner()
        {
            return _banner;
        }

        public Banner(string Banner)
        {
            _banner = Banner;
        }

        
    }
}
