using System;
using System.Collections.Generic;
using LifeCycleWorkflowLibrary;
using System.Windows.Forms;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleSaveLocationsForm : Form
    {
        private List<TextBox> OutputLocationsColl{ get; set; }

        public LifecycleSaveLocationsForm()
        {
            InitializeComponent();
            InitalizeTextBoxCollection();
            ReadSavedLocations();
        }
        private void InitalizeTextBoxCollection()
        {
            OutputLocationsColl = new List<TextBox>();
            OutputLocationsColl.Add(TheBayOutputLocationWipValue);
            OutputLocationsColl.Add(TheBayOutputLocationFinalValue);
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
            TextBoxValidation outputLocationValidation
                = new TextBoxValidation(OutputLocationsColl, LifecycleSaveLocationsErrorProvider, TextBoxValidation.ValidationType.Folder);

            allValid = outputLocationValidation.ValidateTextBox();

            if(allValid)
            {
                StoredSettings.OutputDirectory.TheBay.WipOutputLocation= TheBayOutputLocationWipValue.Text;
                StoredSettings.OutputDirectory.TheBay.FinalOutputLocation = TheBayOutputLocationFinalValue.Text;
                this.Close();
            }
        }

        private void SaveLocationsButtonRestoreDefault_Click(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultLocation = true;
            TheBayOutputLocationWipValue.Text = Globals.TheBay.PathHolder.DefaultWipOutputFolder;
            TheBayOutputLocationFinalValue.Text = Globals.TheBay.PathHolder.DefaultFinalOutputFolder;
        }
    }
}
