﻿using System;
using System.Collections.Generic;
using LifeCycleWorkflowLibrary;
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
            TheBayTemplateLocationsWipValue.Text = StoredSettings.OutputDirectory.TheBay.WipOutputLocation;
            TheBayTemplateLocationsFinalValue.Text = StoredSettings.OutputDirectory.TheBay.WipOutputLocation;
        }

        private void TemplateLocationsWipFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(TheBayTemplateLocationsWipValue, 0, "Template files (.xlsm, .xlsx)|*.xlsm;*.xlsx");
        }

        private void TemplateLocationsFinalFilePicker_Click(object sender, EventArgs e)
        {
            FileFolderPickerUtility.PopulateTextBox(TheBayTemplateLocationsFinalValue, 0, "Template files (.xlsm, .xlsx)|*.xlsm;*.xlsx");
        }

        private void TemplateLocationsButtonSaveSettings_Click(object sender, EventArgs e)
        {
            bool allValid = true;
            
            TextBoxFileValidation templateLocationValidation
            = new TextBoxFileValidation(TemplateLocationsColl, TemplateLocationsErrorProvider, TextBoxFileValidation.ValidationType.File);

            allValid = templateLocationValidation.ValidateTextBox();

            if (allValid)
            {
                StoredSettings.TemplateLocations.TheBay.WipTempalteLocation = TheBayTemplateLocationsWipValue.Text;
                StoredSettings.TemplateLocations.TheBay.FinalTemplateLocation = TheBayTemplateLocationsFinalValue.Text;
                this.Close();
            }
        }
    }
}
