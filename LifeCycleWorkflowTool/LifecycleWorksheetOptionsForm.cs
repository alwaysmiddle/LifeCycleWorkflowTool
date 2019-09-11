using LifeCycleWorkflowLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            WorksheetOptionsTabPageDetailsProduct.Text = Globals.TheBayTemplateWsNameDetailsProduct;
            WorksheetOptionsTabPageInactiveUpc.Text = Globals.TheBayTemplateWsNameInactiveUpc;
            WorksheetOptionsTabPageNosCombined.Text = Globals.TheBayTemplateWsNameNosCombined;
        }
    }
}
