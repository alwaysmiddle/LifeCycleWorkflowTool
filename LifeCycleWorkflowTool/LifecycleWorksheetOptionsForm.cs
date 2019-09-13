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
            WorksheetOptionsTabPageDetailsProduct.Text = Globals.TheBay.TemplateWorksheetNames.TheBayTemplateWsNameDetailsProduct;
            WorksheetOptionsTabPageInactiveUpc.Text = Globals.TheBay.TemplateWorksheetNames.TheBayTemplateWsNameInactiveUpc;
            WorksheetOptionsTabPageNosCombined.Text = Globals.TheBay.TemplateWorksheetNames.TheBayTemplateWsNameNosCombined;
        }
    }
}
