

namespace LifeCycleWorkflowTool
{
    public static class ManualInputFileNames
    {
        public static class TheBay
        {
            public static string NosCombinedFile
            {
                get {
                    return Properties.Settings.Default.TheBayManualDataLoadNosCombinedFile;
                }
            }

            public static string NotOnSiteFile
            {
                get
                {
                    return Properties.Settings.Default.TheBayManualDataLoadNosCombinedFile;
                }
            }

            public static string InventoryAmountFile
            {
                get
                {
                    return Properties.Settings.Default.TheBayManualDataLoadInventoryAmountFile;
                }
            }

            public static string  InactiveUpcFile
            {
                get
                {
                    return Properties.Settings.Default.TheBayManualDataLoadInactiveUpcFile;
                }
            }

        }
    }
}
