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

            bool allTextBoxValid = true;

            foreach (var tBox in textBoxColl)
            {
                tBox.ForeColor = Color.Black;
                TheBayErrorLabel.Text = "";
                //MessageBox.Show(tBox.Text + " File is not a valid file! Please select or choose a correct file.");

                if (tBox.Text != ""){
                    if (!File.Exists(tBox.Text))
                    {
                        TheBayErrorLabel.Text = "Error: File path are not valid files, please make sure you have valid file path selected.";
                        tBox.ForeColor = Color.Red;
                        allTextBoxValid = false;
                    }
                }
                else
                {
                    TheBayErrorLabel.Text = "Error: Can not leave any files unselected";
                    allTextBoxValid = false;
                }
            }

            if (allTextBoxValid)
            {
                MessageBox.Show("All are valid");
            }

        }
    }
}
