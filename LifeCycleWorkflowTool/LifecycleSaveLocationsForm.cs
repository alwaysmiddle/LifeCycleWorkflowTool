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
        }
        private void InitalizeTextBoxCollection()
        {
            SaveLocationsColl = new List<TextBox>();
            SaveLocationsColl.Add(SaveLocationsWipValue);
            SaveLocationsColl.Add(SaveLocationsFinalValue);
        }

        private void SaveLocationsButtonTheBayFilePicker_Click(object sender, EventArgs e)
        {
            SaveLocationsFolderPicker.ShowDialog();
            string folderPicker = SaveLocationsFolderPicker.SelectedPath;
            SaveLocationsWipValue.Text = folderPicker;
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
                if (validateTBox.isValid())
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
                //close the form, then marks the files are ready for loaded
            }
        }

        private void SaveLocationFinalFilePicker_Click(object sender, EventArgs e)
        {
            SaveLocationsFolderPicker.ShowDialog();
            string folderPicker = SaveLocationsFolderPicker.SelectedPath;
            SaveLocationsFinalValue.Text = folderPicker;
        }

        private void SaveLocationsButtonRestoreDefault_Click(object sender, EventArgs e)
        {

        }
    }
}
