using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using LifeCycleWorkflowLibrary;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleWorkflowForm : Form
    {
        public LifecycleWorkflowForm()
        {
            InitializeComponent();

            //TODO implement this as user settings

            //construct defaut worksheetsettings for testing
            WorksheetCustomSettingsHolder worksheetSettings = new WorksheetCustomSettingsHolder();

            WorksheetCustomSettings detailsProductSetting = new WorksheetCustomSettings();
            detailsProductSetting.FormulaeRow = 3;
            detailsProductSetting.HeaderRow = 7;
            detailsProductSetting.ReferenceRow = 5;
            worksheetSettings.SettingsCollection.Add(Globals.TheBay.TemplateWorksheetNames.DetailsProduct, detailsProductSetting);

            WorksheetCustomSettings inactiveUpcSetting = new WorksheetCustomSettings();
            inactiveUpcSetting.FormulaeRow = 3;
            inactiveUpcSetting.HeaderRow = 7;
            inactiveUpcSetting.ReferenceRow = 4;
            worksheetSettings.SettingsCollection.Add(Globals.TheBay.TemplateWorksheetNames.InactiveUpc, inactiveUpcSetting);

            WorksheetCustomSettings nosCombinedSetting = new WorksheetCustomSettings();
            nosCombinedSetting.FormulaeRow = 1;
            nosCombinedSetting.HeaderRow = 2;
            worksheetSettings.SettingsCollection.Add(Globals.TheBay.TemplateWorksheetNames.NosCombined, nosCombinedSetting);

            worksheetSettings.Save();
        }

        /// <summary>
        /// Responsible to set controls to correct state.
        /// </summary>
        private void MainFormStateCheck()
        {
            bool releaseWipControl = Globals.General.StateControl.ManualInputFilesLoadedCheck &&
                                    !Globals.General.StateControl.WipFileProcessing &&
                                    !Globals.General.StateControl.WipFileProcessSucessful;

            bool releaseFinalControl = Globals.General.StateControl.WipFileProcessSucessful &&
                                    !Globals.General.StateControl.FinalFileProcesing &&
                                    !Globals.General.StateControl.FinalFilePrcoessSucessful;

            if (releaseWipControl)
            {
                ManualLoadButtonWip.Enabled = true;
            }
            else
            {
                ManualLoadButtonWip.Enabled = false;
            }

            if (releaseFinalControl)
            {
                ManualLoadButtonFinalFile.Enabled = true;
            }
            else
            {
                ManualLoadButtonFinalFile.Enabled = false;
            }
        }

        //=========Main Functionality==============

        /// <summary>
        /// Work in progress main script sequence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ManualLoadButtonWIP_Click(object sender, EventArgs e)
        {
            
            MainFormStateCheck();
        }

        /// <summary>
        /// Final File main script sequence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualLoadButtonFinalFile_Click(object sender, EventArgs e)
        {
            MainFormStateCheck();
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
                using (LifecycleManualLoadTheBayForm manualLoad = new LifecycleManualLoadTheBayForm())
                {
                    manualLoad.ShowDialog();
                }
            }
            else
            {
                ManualLoadErorrProvider.SetError(ManualTextBoxBanner, "Please select a banner before loading the files!");
            }
        }

        //===============Events=================

        private void SettingsButtonSaveLocation_Click(object sender, EventArgs e)
        {
            using(LifecycleSaveLocationsForm saveLocations = new LifecycleSaveLocationsForm())
            {
                saveLocations.ShowDialog();
                saveLocations.Dispose();
            }
        }

        private void ManualLoadWipShowFolder_Click(object sender, EventArgs e)
        {
            ShowFolderUtilities folderDialog = new ShowFolderUtilities(Globals.ProcessType.WorkInProgress, Globals.Banner.TheBay);
            folderDialog.DisplayFolder();
        }

        private void ManualLoadButtonFinalFileShowFolder_Click(object sender, EventArgs e)
        {
            ShowFolderUtilities folderDialog = new ShowFolderUtilities(Globals.ProcessType.Final, Globals.Banner.TheBay);
            folderDialog.DisplayFolder();
        }

        private void SettingsButtonWorksheetOptions_Click(object sender, EventArgs e)
        {
            using (LifecycleWorksheetOptionsForm optionsForm = new LifecycleWorksheetOptionsForm())
            {
                optionsForm.ShowDialog();
                optionsForm.Dispose();
            }
        }

        private void LifecycleWorkflowForm_Load(object sender, EventArgs e)
        {
            //Set the default save location in app settings, these are used to persist through different runs
            if (StoredSettings.OutputDirectory.TheBay.UseDefaultLocation)
            {
                StoredSettings.OutputDirectory.TheBay.WipOutputLocation =
                    Globals.TheBay.PathHolder.OutputWipFile;
                StoredSettings.OutputDirectory.TheBay.FinalOutputLocation =
                    Globals.TheBay.PathHolder.OutputFinalFile;
            }

            //TODO add file location validation, if network location is not avaialable, then terminate the program
            //TODO check user settings on startup, give warning if some critical values are not set

            //Set Generate WIP file button and Generate Final File to unavailable
            MainFormStateCheck();
        }

        private void LifecycleWorkflowForm_Activated(object sender, EventArgs e)
        {
            MainFormStateCheck();
        }

        private void SettingsButtonTemplateLocations_Click(object sender, EventArgs e)
        {
            using (LifecycleTemplateLocationForm templateForm = new LifecycleTemplateLocationForm())
            {
                templateForm.ShowDialog();
                templateForm.Dispose();
            }
        }

        private void LifeCycleDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //Ensure Dynamic date reading
            Globals.General.OutputFileDate = lifeCycleDateTimePicker.Value;
        }
    }
}