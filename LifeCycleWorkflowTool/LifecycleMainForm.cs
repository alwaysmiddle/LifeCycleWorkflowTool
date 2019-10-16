using LifeCycleWorkflowLibrary;
using System;
using System.Windows.Forms;
using Squirrel;
using System.Threading.Tasks;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleWorkflowForm : Form
    {
        public LifecycleWorkflowForm()
        {
            InitializeComponent();
            GetUpdate();
            VersionNumberLabel.Text = "Version: " + Application.ProductVersion;

            //Set the default save location in app settings, these are used to persist through different runs
            if (StoredSettings.UseDefaultOptions.TheBay.UseDefaultLocation)
            {
                StoredSettings.OutputDirectory.DefaultOutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LifecycleDailyWorkflow";
                StoredSettings.OutputDirectory.TheBay.WipOutputLocation = StoredSettings.OutputDirectory.DefaultOutputFolder + @"\TheBay";
                StoredSettings.OutputDirectory.TheBay.FinalOutputLocation = StoredSettings.OutputDirectory.DefaultOutputFolder + @"\TheBay";
            }

            if (StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions)
            {
                InitializeTheBayWsOptionsCustomSettings();
            }

            //TODO add file location validation, if network location is not avaialable, then terminate the program
            //TODO check user settings on startup, give warning if some critical values are not set

            //Set Generate WIP file button and Generate Final File to unavailable
            MainFormStateCheck();
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
            if (ValidateState())
            {
                Globals.General.OutputFileDate = lifeCycleDateTimePicker.Value;
                TheBayManualFileProcess.ProcessWipFiles();
                MainFormStateCheck();
            }
        }

        /// <summary>
        /// Final File main script sequence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualLoadButtonFinalFile_Click(object sender, EventArgs e)
        {
            if (ValidateState())
            {
                Globals.General.OutputFileDate = lifeCycleDateTimePicker.Value;
                TheBayManualFileProcess.ProcessFinalFiles();
                MainFormStateCheck();
            }
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
            using (LifecycleSaveLocationsForm saveLocations = new LifecycleSaveLocationsForm())
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

        private void SettingsButtonTemplateLocations_Click(object sender, EventArgs e)
        {
            using (LifecycleTemplateLocationForm templateForm = new LifecycleTemplateLocationForm())
            {
                templateForm.ShowDialog();
                templateForm.Dispose();
            }
        }


        //Settings initializations

        private void InitializeTheBayWsOptionsCustomSettings()
        {
            //construct defaut worksheetsettings for testing
            WorksheetCustomSettingsHolder worksheetSettings = new WorksheetCustomSettingsHolder();

            WorksheetCustomSettings detailsProductSetting = new WorksheetCustomSettings();
            detailsProductSetting.FormulaeRow = 3;
            detailsProductSetting.HeaderRow = 7;
            detailsProductSetting.ReferenceRow = 4;
            worksheetSettings.SettingsCollection.Add(Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.DetailsProduct, detailsProductSetting);

            WorksheetCustomSettings inactiveUpcSetting = new WorksheetCustomSettings();
            inactiveUpcSetting.FormulaeRow = 3;
            inactiveUpcSetting.HeaderRow = 7;
            inactiveUpcSetting.ReferenceRow = 4;
            worksheetSettings.SettingsCollection.Add(Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.InactiveUpc, inactiveUpcSetting);

            WorksheetCustomSettings nosCombinedSetting = new WorksheetCustomSettings();
            nosCombinedSetting.FormulaeRow = 1;
            nosCombinedSetting.HeaderRow = 2;
            worksheetSettings.SettingsCollection.Add(Globals.TheBay.TemplateWorksheetNames.WipTemplateNames.NosCombined, nosCombinedSetting);

            worksheetSettings.Save(Globals.TheBay.PathHolder.WsOptionsDefaultFileName);
        }

        private void LifecycleWorkflowForm_Activated(object sender, EventArgs e)
        {
            MainFormStateCheck();
        }


        private bool ValidateState()
        {
            if(StoredSettings.TemplateLocations.TheBay.WipTempalteLocation == "" 
                || StoredSettings.TemplateLocations.TheBay.FinalTemplateLocation == "")
            {
                MessageBox.Show("The template path are empty, please set the template path!");
                return false;
            }

            return true;
        }

        private void GetUpdateButton_Click(object sender, EventArgs e)
        {
            GetUpdate(true);
        }

        private async Task GetUpdate(bool forceUpdate = false)
        {
            string releasePath = @"\\t49-vol4\ECommerce\Merch Ops\Site Operations & Improvements\Saks Direct Site Operations\Work Flow\Master Templates\Workflow Automated Tool\Releases";
            using (var mgr = new UpdateManager(releasePath))
            {
                await mgr.UpdateApp();
                if (forceUpdate)
                {
                    MessageBox.Show("Update Finished! Please restart your program for the lastest changes to take effect.");
                }
            }
        }
    }
}