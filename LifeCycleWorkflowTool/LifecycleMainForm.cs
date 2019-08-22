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
    public partial class LifecycleWorkflowForm : Form
    {
        public LifecycleWorkflowForm()
        {
            InitializeComponent();
        }

        private void SettingsButtonSaveLocation_Click(object sender, EventArgs e)
        {
            LifecycleSaveLocationsForm saveLocations = new LifecycleSaveLocationsForm();

            saveLocations.Show();
        }

        private void ManualLoadButtonLoadData_Click(object sender, EventArgs e)
        {
            LifecycleManualLoadTheBayForm manualLoad = new LifecycleManualLoadTheBayForm();

            manualLoad.Show();
        }
    }
}
