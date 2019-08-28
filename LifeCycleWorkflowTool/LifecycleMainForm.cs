using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            Properties.Settings.Default.DefaultSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                                              @"\LifecycleDailyWorkflow";
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

        private void ManualLoadWipShowFolder_Click(object sender, EventArgs e)
        {
            string saveLocation = Properties.Settings.Default.SaveLocationTheBayWIP;

            if (saveLocation == "")
            {
                Directory.CreateDirectory(Properties.Settings.Default.DefaultSaveLocation);
                Process.Start(Properties.Settings.Default.DefaultSaveLocation);
            }
            else
            {
                Directory.CreateDirectory(saveLocation);
                Process.Start(saveLocation);
            }
        }

        private void ManualLoadButtonFinalFileShowFolder_Click(object sender, EventArgs e)
        {
            string saveLocation = Properties.Settings.Default.SaveLocationTheBayFinal;

            if (saveLocation == "")
            {
                Directory.CreateDirectory(Properties.Settings.Default.DefaultSaveLocation);
                Process.Start(Properties.Settings.Default.DefaultSaveLocation);
            }
            Directory.CreateDirectory(saveLocation);
            Process.Start(saveLocation);
        }
    }
}
