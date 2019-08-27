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
        
        /// <summary>
        /// Manually loading files into TheBay workflow. If the Banner Textbox is not empty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualLoadButtonLoadData_Click(object sender, EventArgs e)
        {
            if (ManualTextBoxBanner.Text != "")
            {
                ManualLoadErorrProvider.Clear();
                LifecycleManualLoadTheBayForm manualLoad = new LifecycleManualLoadTheBayForm();
                manualLoad.ShowDialog();
            }
            else
            {
                ManualLoadErorrProvider.SetError(ManualTextBoxBanner, "Please select a banner before loading the files!");
            }
        }

        private void ManualLoadButtonWIP_Click(object sender, EventArgs e)
        {
            //Loading WIP work process
        }

        private void ManualLoadButtonFinalFile_Click(object sender, EventArgs e)
        {
            //Loading Final work process
        }

        private void ManualLoadButtonShowFolder_Click(object sender, EventArgs e)
        {

        }
    }
}
