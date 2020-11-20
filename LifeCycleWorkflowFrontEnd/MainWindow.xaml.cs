using LifeCycleWorkflowBackend;
using LifeCycleWorkflowBackend.Settings;
using Squirrel;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
            DatePickerUI.SelectedDateChanged += DatePickerUI_SelectedDateChanged;
            this.Loaded += Window_Loaded;
        }

        private void DatePickerUI_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ComboBoxBanners.SelectedItem == null)
            {
                MessageBox.Show("Please Select a banner first.");
                return;
            }

            Banner banner = (Banner)ComboBoxBanners.SelectedItem;
            SettingsIO.CreateDefaultSettingsProfile(banner, false);

            BannerSettings settingsLoaded = SettingsIO.LoadBannerSettingsFromFile(banner);
            settingsLoaded.OutputDate = (DateTime) DatePickerUI.SelectedDate;

            SettingsIO.SaveSettingsProfile(banner, settingsLoaded);
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                VersionLabel.Content = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                await GetUpdate();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }



        private async Task GetUpdate(bool forceUpdate = false)
        {
            string releasePath = @"\\t49-vol4\ECommerce\Merch Ops\Site Operations & Improvements\Saks Direct Site Operations\Work Flow\Master Templates\Workflow Automated Tool\Releases 2.0";
            using (var mgr = new UpdateManager(releasePath))
            {
                var updateInfo = await mgr.CheckForUpdate();

                if (updateInfo.ReleasesToApply.Any())
                {

                    int versionCount = updateInfo.ReleasesToApply.Count;

                    string versionWord = versionCount > 1 ? "versions" : "version";
                    string message = new StringBuilder().AppendLine($"App is {versionCount} {versionWord} behind.").
                                                      AppendLine("If you choose to update, changes wont take affect until App is restarted.").
                                                      AppendLine("Would you like to download and install them?").
                                                      ToString();

                    MessageBoxResult result = MessageBox.Show(message, "App Update", MessageBoxButton.YesNo);
                    if (result != MessageBoxResult.Yes)
                    {
                        return;
                    }

                    await mgr.UpdateApp();

                    MessageBox.Show("Update Finished! Please restart your program for the lastest changes to take effect.");
                }
                else if (!updateInfo.ReleasesToApply.Any() && forceUpdate)
                {
                    MessageBox.Show("No new updates are found!");
                }
            }
        }
    }
}
