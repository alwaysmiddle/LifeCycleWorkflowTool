using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LifeCycleWorkflowLibrary;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleManualLoadTheBayForm : Form
    {
        private List<TextBox> TextBoxColl { get; set; }

        public LifecycleManualLoadTheBayForm()
        {
            InitializeComponent();
            InitalizeTextBoxCollection();
        }

        private void InitalizeTextBoxCollection()
        {
            TextBoxColl = new List<TextBox>();
            TextBoxColl.Add(ManualDataLoadInventoryAmountValue);
            TextBoxColl.Add(ManualDataLoadNosValue);
            TextBoxColl.Add(ManualDataLoadNosCombinedValue);
            TextBoxColl.Add(ManualDataLoadInactiveUpcValue);
        }

        private void ManualDataLoadInventoryAmountFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(ManualDataLoadInventoryAmountValue);
        }

        private void ManualDataLoadNosFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(ManualDataLoadNosValue);
        }

        private void ManualDataLoadNosCombinedFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(ManualDataLoadNosCombinedValue);
        }

        private void ManualDataLoadInactiveUpcFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(ManualDataLoadInactiveUpcValue);
        }

        private void ManualDataLoadConfirmButton_Click(object sender, EventArgs e)
        {
            bool allValid = true;
            TextBoxValidation manualLoadValidation 
                = new TextBoxValidation(TextBoxColl, ManualDataLoadTheBayErrorProvider, TextBoxValidation.ValidationType.File);

            allValid = manualLoadValidation.ValidateTextBox();

            if (allValid)
            {
                StoredSettings.ManualInputFileNames.TheBay.InventoryAmountFile = ManualDataLoadInventoryAmountValue.Text;
                StoredSettings.ManualInputFileNames.TheBay.NotOnSiteFile = ManualDataLoadNosValue.Text;
                StoredSettings.ManualInputFileNames.TheBay.NosCombinedFile = ManualDataLoadNosCombinedValue.Text;
                StoredSettings.ManualInputFileNames.TheBay.InactiveUpcFile = ManualDataLoadInactiveUpcValue.Text;

                //Release the control on Wip lock
                Globals.General.StateControl.ManualInputFilesLoadedCheck = true;
                //close the form, then marks the files are ready for loaded
                this.Close();
            }

        }

        private void ManualDataLoadRestoreRecentButton_Click(object sender, EventArgs e)
        {
            ManualDataLoadInventoryAmountValue.Text = StoredSettings.ManualInputFileNames.TheBay.InventoryAmountFile;
            ManualDataLoadNosValue.Text = StoredSettings.ManualInputFileNames.TheBay.NotOnSiteFile;
            ManualDataLoadNosCombinedValue.Text = StoredSettings.ManualInputFileNames.TheBay.NosCombinedFile;
            ManualDataLoadInactiveUpcValue.Text = StoredSettings.ManualInputFileNames.TheBay.InactiveUpcFile;
        }
    }
}
