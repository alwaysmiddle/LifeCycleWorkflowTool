using LifeCycleWorkflowLibrary;
using System;
using System.Windows.Forms;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleWorksheetOptionsForm : Form
    {
        public LifecycleWorksheetOptionsForm()
        {
            InitializeComponent();
        }

        private void WorksheetOptionsTabPageDetailsProduct_Click(object sender, EventArgs e)
        {
            WorksheetOptionsTabPageDetailsProduct.Text = Globals.TheBay.TemplateWorksheetNames.DetailsProduct;
            WorksheetOptionsTabPageInactiveUpc.Text = Globals.TheBay.TemplateWorksheetNames.InactiveUpc;
            WorksheetOptionsTabPageNosCombined.Text = Globals.TheBay.TemplateWorksheetNames.NosCombined;
        }

        private void LifecycleWorksheetOptionsLoadButton_Click(object sender, EventArgs e)
        {

        }

        private void LifecycleWorksheetOptionsSaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
