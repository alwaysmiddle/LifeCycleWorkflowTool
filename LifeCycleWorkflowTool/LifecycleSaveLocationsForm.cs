using System;
using System.Collections.Generic;
using LifeCycleWorkflowLibrary;
using System.Windows.Forms;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleSaveLocationsForm : Form
    {
        private List<TextBox> SaveLocationsColl{ get; set; }

        public LifecycleSaveLocationsForm()
        {
            InitializeComponent();
            InitalizeTextBoxCollection();
            ReadSavedLocations();
        }
        private void InitalizeTextBoxCollection()
        {
            SaveLocationsColl = new List<TextBox>();
            SaveLocationsColl.Add(TheBayOutputLocationWipValue);
            SaveLocationsColl.Add(TheBayOutputLocationFinalValue);
        }

        private void ReadSavedLocations()
        {
            TheBayOutputLocationWipValue.Text = StoredSettings.OutputDirectory.TheBay.WipOutputLocation;
            TheBayOutputLocationFinalValue.Text = StoredSettings.OutputDirectory.TheBay.FinalOutputLocation;
        }

        private void SaveLocationsWipFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(TheBayOutputLocationWipValue, 1);
        }

        private void SaveLocationFinalFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(TheBayOutputLocationFinalValue, 1);
        }

        /// <summary>
        /// Save Locations for the automated workflow output. The file is saved to local computer, it will be loaded between Sessions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveLocationsButtonSave_Click(object sender, EventArgs e)
        {
            bool allValid = true;

            //save to the locations

            foreach (var tBox in SaveLocationsColl)
            {
                TextBoxFileValidation validateTBox = new TextBoxFileValidation(tBox);
                if(tBox.Text == Properties.Settings.Default.DefaultSaveLocation)
                {
                    LifecycleSaveLocationsErrorProvider.Clear();
                }
                else if (validateTBox.isFolderValid())
                {
                    LifecycleSaveLocationsErrorProvider.Clear();
                }
                else
                {
                    LifecycleSaveLocationsErrorProvider.SetError(tBox, validateTBox.ErrorMessage);
                    allValid = false;
                }
            }

            if (allValid)
            {
                Properties.Settings.Default.SaveLocationTheBayWIP = TheBayOutputLocationWipValue.Text;
                Properties.Settings.Default.SaveLocationTheBayFinal = TheBayOutputLocationFinalValue.Text;
                Properties.Settings.Default.Save();
                this.Close();
            }
        }

        private void SaveLocationsButtonRestoreDefault_Click(object sender, EventArgs e)
        {
            foreach (var tBox in SaveLocationsColl)
            {
                tBox.Text = Properties.Settings.Default.DefaultSaveLocation;
            }
        }
    }
}
