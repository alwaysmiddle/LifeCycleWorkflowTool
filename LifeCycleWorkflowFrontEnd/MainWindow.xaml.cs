using LifeCycleWorkflowBackend;
using LifeCycleWorkflowBackend.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace LifeCycleWorkflowFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        private IntPtr handle;

        public MainWindow()
        {
            InitializeComponent();

            LoadFileButton.Click += LoadFileButton_Click;
            ButtonRun.Click += ButtonRun_Click;
            ButtonSettings.Click += ButtonSettings_Click;
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxBanners.SelectedItem == null)
            {
                MessageBox.Show("Please Select a banner first.");
                return;
            }

            Banner banner = (Banner)ComboBoxBanners.SelectedItem;
            SettingsIO.CreateDefaultSettingsProfile(banner, false);
            string bannerFullFilename = SettingsIO.GetFullBannerSettingsFilename(banner);

            if (File.Exists(bannerFullFilename))
            {
                Process[] targetProcess = Process.GetProcessesByName("Notepad");

                if(targetProcess.Length > 0)
                foreach (Process item in targetProcess)
                {
                    if (item.MainWindowTitle.Contains(Path.GetFileNameWithoutExtension(bannerFullFilename)))
                    {
                        handle = item.MainWindowHandle;
                        SetForegroundWindow(handle);
                        break;
                    }
                    }
                else
                {
                    Process.Start("Notepad.exe", bannerFullFilename);
                }
            }
            else
            {
                MessageBox.Show("The file with path {0} is not found.", bannerFullFilename);
            }
        }

        private void ButtonRun_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxBanners.SelectedItem == null)
            {
                MessageBox.Show("Please Select a banner first.");
                return;
            }

            Banner banner = (Banner)ComboBoxBanners.SelectedItem;
            SettingsIO.CreateDefaultSettingsProfile(banner, false);

            BannerSettings settingsLoaded = SettingsIO.LoadBannerSettingsFromFile(banner);

            try
            {
                settingsLoaded.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            OperationExecuter.RunBannerOperation(banner, settingsLoaded);

            MessageBox.Show("Operation Completed!");
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            FileLoaderWindow fileLoaderWindow = new FileLoaderWindow();
            fileLoaderWindow.Show();
            fileLoaderWindow.Activate();
        }
    }
}
