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
using ClosedXML.Excel;
using LifeCycleWorkflowLibrary;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleWorkflowForm : Form
    {
        public LifecycleWorkflowForm()
        {
            InitializeComponent();
            Properties.Settings.Default.DefaultSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                                              @"\LifecycleDailyWorkflow";

            //construct defaut worksheetsettings for testing
            WorksheetCustomSettingsHolder worksheetSettings = new WorksheetCustomSettingsHolder();

            WorksheetCustomSettings detailsProductSetting = new WorksheetCustomSettings();
            detailsProductSetting.FormulaeRow = 3;
            detailsProductSetting.HeaderRow = 7;
            detailsProductSetting.ReferenceRow = 5;
            worksheetSettings.SettingsCollection.Add("Details_Products", detailsProductSetting);

            WorksheetCustomSettings inactiveUpcSetting = new WorksheetCustomSettings();
            inactiveUpcSetting.FormulaeRow = 2;
            inactiveUpcSetting.HeaderRow = 7;
            inactiveUpcSetting.ReferenceRow = 4;
            worksheetSettings.SettingsCollection.Add("Inactive UPC", inactiveUpcSetting);

            WorksheetCustomSettings nosCombinedSetting = new WorksheetCustomSettings();
            nosCombinedSetting.FormulaeRow = 1;
            nosCombinedSetting.HeaderRow = 2;
            worksheetSettings.SettingsCollection.Add("NOS_Colour_Combined", nosCombinedSetting);

            worksheetSettings.Save();

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

        private void SettingsButtonWorksheetOptions_Click(object sender, EventArgs e)
        {
            LifecycleWorksheetOptionsForm optionsForm = new LifecycleWorksheetOptionsForm();
            optionsForm.ShowDialog();
        }
    }
}
