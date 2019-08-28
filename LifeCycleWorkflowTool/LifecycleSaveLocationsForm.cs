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
            SaveLocationsColl.Add(SaveLocationsWipValue);
            SaveLocationsColl.Add(SaveLocationsFinalValue);
        }

        private void ReadSavedLocations()
        {
            SaveLocationsWipValue.Text = Properties.Settings.Default.SaveLocationTheBayWIP;
            SaveLocationsFinalValue.Text = Properties.Settings.Default.SaveLocationTheBayFinal;
        }

        private void SaveLocationsWipFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(SaveLocationsWipValue, 1);
        }

        private void SaveLocationFinalFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(SaveLocationsFinalValue, 1);
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
                Properties.Settings.Default.SaveLocationTheBayWIP = SaveLocationsWipValue.Text;
                Properties.Settings.Default.SaveLocationTheBayFinal = SaveLocationsFinalValue.Text;
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
