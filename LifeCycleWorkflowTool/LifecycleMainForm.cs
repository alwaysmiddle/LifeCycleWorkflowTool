using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

            //TODO implement this as user settings

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
            string path = Properties.Settings.Default.TheBayWipTemplatePath;

            //Make new file name for Wip file
            string newWipFilename = "PIM_" + lifeCycleDateTimePicker.Value.ToString("M.d.yyyy")+"_Daily_Workflow_Report_BAY";
            string newPath = LifeCycleFileUtilities.CopyFile(path, Properties.Settings.Default.DefaultSaveLocation, newWipFilename);

            Globals.WipFileProcessSucessful = true;
            MainFormStateCheck();
        }

        private void ManualLoadButtonFinalFile_Click(object sender, EventArgs e)
        {
            //Loading Final work process

            Globals.FinalFilePrcoessSucessful = true;
            MainFormStateCheck();
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
            LifecycleWorksheetOptionsForm optionsForm = new LifecycleWorksheetOptionsForm();
            optionsForm.ShowDialog();
        }

        private void LifecycleWorkflowForm_Load(object sender, EventArgs e)
        {
            //Set the default save location in app settings, these are used to persist through different runs
            Properties.Settings.Default.DefaultSaveLocation = 
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LifecycleDailyWorkflow";

            //initialize the template locations, these are located on virtual network drive
            //TODO add file location validation, if network location is not avaialable, then terminate the program
            Properties.Settings.Default.TheBayWipTemplatePath = 
                @"C:\Users\Middle\source\repos\alwaysmiddle\LifeCycleWorkflowTool\ExcelTemplates\BAY_DailyWorkflow_Template.xlsm";
            Properties.Settings.Default.TheBayFinalTemplatePath = 
                @"C:\Users\Middle\source\repos\alwaysmiddle\LifeCycleWorkflowTool\ExcelTemplates\Workflow_Report_BAY.xlsx";

            //Set Generate WIP file button and Generate Final File to unavailable
            MainFormStateCheck();
        }

        private void LifecycleWorkflowForm_Activated(object sender, EventArgs e)
        {
            MainFormStateCheck();
        }
    }
}
