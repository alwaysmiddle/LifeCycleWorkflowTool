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
    public partial class LifecycleTemplateLocationForm : Form
    {
        private List<TextBox> TemplateLocationsColl { get; set; }

        public LifecycleTemplateLocationForm()
        {
            InitializeComponent();
            InitalizeTextBoxCollection();
            ReadSavedLocations();
        }
        private void InitalizeTextBoxCollection()
        {
            TemplateLocationsColl = new List<TextBox>();
            TemplateLocationsColl.Add(TheBayTemplateLocationsWipValue);
            TemplateLocationsColl.Add(TheBayTemplateLocationsFinalValue);
        }

        private void ReadSavedLocations()
        {
            TheBayTemplateLocationsWipValue.Text = Properties.Settings.Default.TheBayWipTemplatePath;
            TheBayTemplateLocationsFinalValue.Text = Properties.Settings.Default.TheBayFinalTemplatePath;
        }

        private void TemplateLocationsWipFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(TheBayTemplateLocationsWipValue, 0, "Template files (.xlsm, .xlsx)|*.xlsm;*.xlsx)");
        }

        private void TemplateLocationsFinalFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(TheBayTemplateLocationsFinalValue, 0, "Template files (.xlsm, .xlsx)|*.xlsm;*.xlsx)");
        }

        private void TemplateLocationsButtonSaveSettings_Click(object sender, EventArgs e)
        {
            bool allValid = true;

            //save the templates to app settings locations

            foreach (var tBox in TemplateLocationsColl)
            {
                TextBoxFileValidation validateTBox = new TextBoxFileValidation(tBox);

                if (validateTBox.isFileValid())
                {
                    TemplateLocationsErrorProvider.Clear();
                }
                else
                {
                    validateTBox.ErrorMessage = "Please set valid files for templates.";
                    TemplateLocationsErrorProvider.SetError(tBox, validateTBox.ErrorMessage);
                    allValid = false;
                }
            }

            if (allValid)
            {
                Properties.Settings.Default.TheBayWipTemplatePath = TheBayTemplateLocationsWipValue.Text;
                Properties.Settings.Default.TheBayFinalTemplatePath = TheBayTemplateLocationsFinalValue.Text;
                Properties.Settings.Default.Save();
                this.Close();
            }
        }
    }
}
