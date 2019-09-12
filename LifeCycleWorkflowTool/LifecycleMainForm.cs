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
            worksheetSettings.SettingsCollection.Add(Globals.TheBayTemplateWsNameDetailsProduct, detailsProductSetting);

            WorksheetCustomSettings inactiveUpcSetting = new WorksheetCustomSettings();
            inactiveUpcSetting.FormulaeRow = 3;
            inactiveUpcSetting.HeaderRow = 7;
            inactiveUpcSetting.ReferenceRow = 4;
            worksheetSettings.SettingsCollection.Add(Globals.TheBayTemplateWsNameInactiveUpc, inactiveUpcSetting);

            WorksheetCustomSettings nosCombinedSetting = new WorksheetCustomSettings();
            nosCombinedSetting.FormulaeRow = 1;
            nosCombinedSetting.HeaderRow = 2;
            worksheetSettings.SettingsCollection.Add(Globals.TheBayTemplateWsNameNosCombined, nosCombinedSetting);

            worksheetSettings.Save();

        }

        /// <summary>
        /// Responsible to set controls to correct state.
        /// </summary>
        private void MainFormStateCheck()
        {
            if (Globals.ManualInputFilesLoadedCheck && !Globals.WipFileProcessing && !Globals.WipFileProcessSucessful)
            {
                ManualLoadButtonWip.Enabled = true;
            }
            else
            {
                ManualLoadButtonWip.Enabled = false;
            }

            if (Globals.WipFileProcessSucessful && !Globals.FinalFileProcesing && !Globals.FinalFilePrcoessSucessful)
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
            //Loading Work in progress tempalte location saved in AppSetting
            string path = Properties.Settings.Default.TheBayWipTemplatePath;

            //Copy the template to the desired outPut folder
            //TODO Process the file locally first, then do the copy function afterwards
            string newWipFilename = "PIM_" + lifeCycleDateTimePicker.Value.ToString("M.d.yyyy")+"_Daily_Workflow_Report_BAY";
            string newWipFullFileName = LifeCycleFileUtilities.CopyFile(path, Properties.Settings.Default.SaveLocationTheBayWIP, newWipFilename);
            Globals.TheBayOutputWipFile = newWipFullFileName;

            //Running Main Processes
            TheBayManualFileProcess.ProcessNosCombinedFile(Properties.Settings.Default.TheBayManualDataLoadNosCombinedFile);
            //TheBayManualFileProcess.ProcessInactiveUPC(Properties.Settings.Default.TheBayManualDataLoadInactiveUpcFile);
            //TheBayManualFileProcess.ProcessProductDetails(Properties.Settings.Default.TheBayManualDataLoadNosFile);

            Globals.WipFileProcessSucessful = true;
            MainFormStateCheck();
        }

        /// <summary>
        /// Final File main script sequence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualLoadButtonFinalFile_Click(object sender, EventArgs e)
        {
            //Loading Final tempalte location saved in AppSetting
            string path = Properties.Settings.Default.TheBayFinalTemplatePath;

            //Copy the template to the desired outPut folder
            //TODO Process the file locally first, then do the copy function afterwards
            string newFinalFilename = lifeCycleDateTimePicker.Value.ToString("MM.dd.yyyy") + "_Daily_Workflow_Report_BAY";
            string newFinalFullFilename = LifeCycleFileUtilities.CopyFile(path, Properties.Settings.Default.SaveLocationTheBayFinal, newFinalFilename);
            Globals.TheBayOutputFinalFile = newFinalFullFilename;

            Globals.FinalFilePrcoessSucessful = true;
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
            }
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
            else
            {
                Directory.CreateDirectory(saveLocation);
                Process.Start(saveLocation);
            }
        }

        private void SettingsButtonWorksheetOptions_Click(object sender, EventArgs e)
        {
            using (LifecycleWorksheetOptionsForm optionsForm = new LifecycleWorksheetOptionsForm())
            {
                optionsForm.ShowDialog();
            }
        }

        private void LifecycleWorkflowForm_Load(object sender, EventArgs e)
        {
            //Set the default save location in app settings, these are used to persist through different runs
            Properties.Settings.Default.DefaultSaveLocation = 
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LifecycleDailyWorkflow";

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
            }
        }
    }
}
