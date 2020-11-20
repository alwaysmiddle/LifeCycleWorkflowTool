using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using LifeCycleWorkflowBackend;
using LifeCycleWorkflowBackend.Settings;

namespace LifeCycleWorkflowFrontEnd
{
    /// <summary>
    /// Interaction logic for FileLoaderWindow.xaml
    /// </summary>
    public partial class FileLoaderWindow : Window
    {
        private BannerSettings _theBayBannerSettingsLoaded;
        public FileLoaderWindow()
        {
            InitializeComponent();

            SettingsIO.CreateDefaultSettingsProfile(Banner.TheBay, false);

            _theBayBannerSettingsLoaded = SettingsIO.LoadBannerSettingsFromFile(Banner.TheBay);
            TextBlockBitReport.Text = _theBayBannerSettingsLoaded.InputFilenameBitReport;
            TextBlockNos.Text = _theBayBannerSettingsLoaded.InputFilenameNosCombined;
            TextBlockWorkflow.Text = _theBayBannerSettingsLoaded.InputFilenameWorkflow;
            TextBlockUpc.Text = _theBayBannerSettingsLoaded.InputFilenameInactiveUpc;
            TextBlockTemplateWip.Text = _theBayBannerSettingsLoaded.TemplateFullnameWip;
            TextBlockTemplateFinal.Text = _theBayBannerSettingsLoaded.TemplateFullnameFinal;
            TextBlockOutputWip.Text = _theBayBannerSettingsLoaded.OutputFolderWip;
            TextBlockOutputFinal.Text = _theBayBannerSettingsLoaded.OutputFolderFinal;

            ButtonCloseFileLoader.Click += ButtonCloseFileLoader_Click;
            ButtonBitReport.Click += ButtonBitReport_Click;
            ButtonWorkflow.Click += ButtonWorkflow_Click;
            ButtonNos.Click += ButtonNos_Click;
            ButtonUpc.Click += ButtonUpc_Click;
            ButtonTemplateWip.Click += ButtonTemplateWip_Click;
            ButtonTemplateFinal.Click += ButtonTemplateFinal_Click;
            ButtonOutputFolderWip.Click += ButtonOutputFolderWip_Click;
            ButtonOutputFolderFinal.Click += ButtonOutputFolderFinal_Click;
        }

        private void ButtonOutputFolderFinal_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlockFolder(TextBlockOutputFinal);

            if (!string.IsNullOrEmpty(filepath))
            {
                _theBayBannerSettingsLoaded.OutputFolderFinal = filepath;
            }
            this.Activate();
        }

        private void ButtonOutputFolderWip_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlockFolder(TextBlockOutputWip);

            if (!string.IsNullOrEmpty(filepath))
            {
                _theBayBannerSettingsLoaded.OutputFolderFinal = filepath;
            }
            this.Activate();
        }

        private void ButtonTemplateFinal_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlock(TextBlockTemplateFinal);

            if (!string.IsNullOrEmpty(filepath))
            {
                _theBayBannerSettingsLoaded.TemplateFullnameFinal = filepath;
            }
            this.Activate();
        }

        private void ButtonTemplateWip_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlock(TextBlockTemplateWip);

            if (!string.IsNullOrEmpty(filepath))
            {
                _theBayBannerSettingsLoaded.TemplateFullnameWip = filepath;
            }
            this.Activate();
        }

        #region Button Clicks

        private void ButtonUpc_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlock(TextBlockUpc);

            if (!string.IsNullOrEmpty(filepath))
            {
                _theBayBannerSettingsLoaded.InputFilenameInactiveUpc = filepath;
            }
            this.Activate();
        }

        private void ButtonNos_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlock(TextBlockNos);

            if (!string.IsNullOrEmpty(filepath))
            {
                _theBayBannerSettingsLoaded.InputFilenameNosCombined = filepath;
            }
            this.Activate();
        }

        private void ButtonWorkflow_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlock(TextBlockWorkflow);

            if (!string.IsNullOrEmpty(filepath))
            {
                _theBayBannerSettingsLoaded.InputFilenameWorkflow = filepath;
            }
            this.Activate();
        }

        private void ButtonBitReport_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlock(TextBlockBitReport);

            if (!string.IsNullOrEmpty(filepath))
            {
                _theBayBannerSettingsLoaded.InputFilenameBitReport = filepath;
            }
            this.Activate();
        }

        private void ButtonCloseFileLoader_Click(object sender, RoutedEventArgs e)
        {
            SettingsIO.SaveSettingsProfile(Banner.TheBay, _theBayBannerSettingsLoaded);
            this.Close();
        }

        #endregion


        #region Helper Function
        /// <summary>
        /// Helper function for temporary form
        /// </summary>
        public static string PopulateTextBlock(TextBlock textblock)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Input Files";

            openFileDialog.Filter = "Data Files (.csv, .xlsx, .xlsm)|*.csv;*.xlsx;*xlsm|All Files (.*)|*.*";

            if ((bool)openFileDialog.ShowDialog())
            {
                FileInfo file = new FileInfo(openFileDialog.FileName);
                textblock.Text = file.Name;
                return file.FullName;
            }

            return string.Empty;
        }

        public static string PopulateTextBlockFolder(TextBlock textblock)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "Select Folders";

            if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
            {
                return string.Empty;
            }

            textblock.Text = dialog.FileName;

            return dialog.FileName;
        }

        #endregion
    }
}
