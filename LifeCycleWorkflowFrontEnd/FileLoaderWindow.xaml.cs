using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace LifeCycleWorkflowFrontEnd
{
    /// <summary>
    /// Interaction logic for FileLoaderWindow.xaml
    /// </summary>
    public partial class FileLoaderWindow : Window
    {
        public FileLoaderWindow()
        {
            InitializeComponent();

            ButtonCloseFileLoader.Click += ButtonCloseFileLoader_Click;
            ButtonBitReport.Click += ButtonBitReport_Click;
            ButtonWorkflow.Click += ButtonWorkflow_Click;
            ButtonNos.Click += ButtonNos_Click;
            ButtonUpc.Click += ButtonUpc_Click;
        }

        #region Button Clicks

        private void ButtonUpc_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlock(TextBlockUpc);

            if (!string.IsNullOrEmpty(filepath))
            {
                Properties.Settings.Default.InputFileInactiveUPC = filepath;
            }
            
        }

        private void ButtonNos_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlock(TextBlockNos);

            if (!string.IsNullOrEmpty(filepath))
            {
                Properties.Settings.Default.InputFileInactiveUPC = filepath;
            }
        }

        private void ButtonWorkflow_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlock(TextBlockWorkflow);

            if (!string.IsNullOrEmpty(filepath))
            {
                Properties.Settings.Default.InputFileInactiveUPC = filepath;
            }
        }

        private void ButtonBitReport_Click(object sender, RoutedEventArgs e)
        {
            string filepath = PopulateTextBlock(TextBlockBitReport);

            if (!string.IsNullOrEmpty(filepath))
            {
                Properties.Settings.Default.InputFileInactiveUPC = filepath;
            }
        }

        private void ButtonCloseFileLoader_Click(object sender, RoutedEventArgs e)
        {
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

            openFileDialog.Filter = "Data Files (.csv, .xlsx)|*.csv;*.xlsx|All Files (.*)|*.*";

            if ((bool)openFileDialog.ShowDialog())
            {
                FileInfo file = new FileInfo(openFileDialog.FileName);
                textblock.Text = file.Name;
                return file.FullName;
            }

            return string.Empty;
        }

        #endregion
    }
}
