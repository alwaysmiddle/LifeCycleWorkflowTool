using System.Windows;


namespace LifeCycleWorkflowFrontEnd
{
    /// <summary>
    /// Interaction logic for WorkflowTypeOptionWindow.xaml
    /// </summary>
    public partial class WorkflowTypeOptionWindow : Window
    {
        private WorkflowType _chosenType;

        public WorkflowType Chosentype 
        {
            get { return _chosenType; }
        }

        public WorkflowTypeOptionWindow()
        {
            InitializeComponent();
            WipButton.Click += WipButton_Click;
            FinalButton.Click += FinalButton_Click;
        }

        private void FinalButton_Click(object sender, RoutedEventArgs e)
        {
            _chosenType = WorkflowType.Final;
            this.Hide();
        }

        private void WipButton_Click(object sender, RoutedEventArgs e)
        {
            _chosenType = WorkflowType.Wip;
            this.Hide();
        }
    }
}
