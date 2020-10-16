using System.Windows;


namespace LifeCycleWorkflowFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadFileButton.Click += LoadFileButton_Click;
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            FileLoaderWindow fileLoaderWindow = new FileLoaderWindow();
            fileLoaderWindow.Show();
            fileLoaderWindow.Activate();
        }
    }
}
