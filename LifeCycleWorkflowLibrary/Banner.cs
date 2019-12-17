

namespace LifeCycleWorkflowLibrary
{
    public enum HbcBanner
    {
        TheBay,
        Saks,
        SaksO5,
        LordAndTaylor
    }
    class Banner
    {
        private string _banner;
        private string _wipTemplateLanDirectory;
        private string _finalTemplateLanDirectory;
        private string _wipOutputLanDirectory;
        private string _finalOutputLanDirectory;
        private string _temporaryStorageDirectory;

        public string GetBanner()
        {
            return _banner;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Banner"></param>
        /// <param name="settingDirectory"></param>
        public Banner(HbcBanner banner, string settingDirectory)
        {
            _banner = banner.ToString();
        }
    }
}
