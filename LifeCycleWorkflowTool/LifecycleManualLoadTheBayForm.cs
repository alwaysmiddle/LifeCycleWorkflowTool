using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleManualLoadTheBayForm : Form
    {
        public LifecycleManualLoadTheBayForm()
        {
            InitializeComponent();
        }

        private void ManualDataLoadInventoryAmountFilePicker_Click(object sender, EventArgs e)
        {
            ManualDataLoadInventoryAmountValue.Text = "";
            ManualDataLoadOpenFileDialog.ShowDialog();
            string selectedFile = ManualDataLoadOpenFileDialog.FileName;
            ManualDataLoadInventoryAmountValue.Text = selectedFile;
        }

        private void ManualDataLoadNosFilePicker_Click(object sender, EventArgs e)
        {
            ManualDataLoadNosValue.Text = "";
            ManualDataLoadOpenFileDialog.ShowDialog();
            string selectedFile = ManualDataLoadOpenFileDialog.FileName;
            ManualDataLoadNosValue.Text = selectedFile;
        }

        private void ManualDataLoadNosCombinedFilePicker_Click(object sender, EventArgs e)
        {
            ManualDataLoadNosCombinedValue.Text = "";
            ManualDataLoadOpenFileDialog.ShowDialog();
            string selectedFile = ManualDataLoadOpenFileDialog.FileName;
            ManualDataLoadNosCombinedValue.Text = selectedFile;
        }

        private void ManualDataLoadInactiveUpcFilePicker_Click(object sender, EventArgs e)
        {
            ManualDataLoadInactiveUpcValue.Text = "";
            ManualDataLoadOpenFileDialog.ShowDialog();
            string selectedFile = ManualDataLoadOpenFileDialog.FileName;
            ManualDataLoadInactiveUpcValue.Text = selectedFile;
        }

        private void ManualDataLoadConfirmButton_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxColl = new List<TextBox>();
            textBoxColl.Add(ManualDataLoadInventoryAmountValue);
            textBoxColl.Add(ManualDataLoadNosValue);
            textBoxColl.Add(ManualDataLoadNosCombinedValue);
            textBoxColl.Add(ManualDataLoadInactiveUpcValue);

            ToolTip errorTooltip = new ToolTip();
            bool allValid = true;

            foreach (var tBox in textBoxColl)
            {
                TextBoxFileValidation validateTBox = new TextBoxFileValidation(tBox);
                //MessageBox.Show(tBox.Text + " File is not a valid file! Please select or choose a correct file.");
                if (validateTBox.isValid())
                {
                    ManualDataLoadTheBayErrorProvider.Clear();
                }
                else
                {
                    ManualDataLoadTheBayErrorProvider.SetError(tBox, validateTBox.ErrorMessage);
                    allValid = false;
                }
            }

            if (allValid)
            {
                //close the form, then marks the files are ready for loaded
            }

        }
    }
}
