using LifeCycleWorkflowLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleWorksheetOptionsForm : Form
    {
        private Dictionary<string, WorksheetCustomSettings> worksheetSettings { get; set; }
        public LifecycleWorksheetOptionsForm()
        {
            InitializeComponent();
            worksheetSettings = new Dictionary<string, WorksheetCustomSettings>();
            if (StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions)
            {
                worksheetSettings = WorksheetCustomSettingsHolder.Load(Globals.TheBay.PathHolder.WsOptionsDefaultFileName).SettingsCollection;
                LoadSettings();
            }
            else
            {
                worksheetSettings = WorksheetCustomSettingsHolder.Load().SettingsCollection;
                LoadSettings();
            }
        }


        private void WorksheetOptionsTabPageDetailsProduct_Click(object sender, EventArgs e)
        {
            WorksheetOptionsTabPageDetailsProduct.Text = Globals.TheBay.TemplateWorksheetNames.DetailsProduct;
            WorksheetOptionsTabPageInactiveUpc.Text = Globals.TheBay.TemplateWorksheetNames.InactiveUpc;
            WorksheetOptionsTabPageNosCombined.Text = Globals.TheBay.TemplateWorksheetNames.NosCombined;
        }
        
        //TODO build a better design to save, load worksheetoptions

        private void LifecycleWorksheetOptionsSaveButton_Click(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = false;

            WorksheetCustomSettingsHolder newSettings = new WorksheetCustomSettingsHolder();

            WorksheetCustomSettings detailsProductSetting = new WorksheetCustomSettings();
            detailsProductSetting.FormulaeRow = (int)DetailsProductFormulaRowValue.Value;
            detailsProductSetting.HeaderRow = (int)DetailsProductHeaderRowValue.Value;
            detailsProductSetting.ReferenceRow = (int)DetailsProductReferenceRowValue.Value;
            newSettings.SettingsCollection.Add(Globals.TheBay.TemplateWorksheetNames.DetailsProduct, detailsProductSetting);

            WorksheetCustomSettings inactiveUpcSetting = new WorksheetCustomSettings();
            inactiveUpcSetting.FormulaeRow = (int)InactiveUpcFormulaRowValue.Value;
            inactiveUpcSetting.HeaderRow = (int)InactiveUpcHeaderRowValue.Value;
            inactiveUpcSetting.ReferenceRow = (int)InactiveUpcReferenceRowValue.Value;
            newSettings.SettingsCollection.Add(Globals.TheBay.TemplateWorksheetNames.InactiveUpc, inactiveUpcSetting);

            WorksheetCustomSettings nosCombinedSetting = new WorksheetCustomSettings();
            nosCombinedSetting.FormulaeRow = (int)NosCombinedFormulaRowValue.Value;
            nosCombinedSetting.HeaderRow = (int)NosCombinedHeaderRowValue.Value;
            nosCombinedSetting.ReferenceRow = (int)NosCombinedReferenceRowValue.Value;
            newSettings.SettingsCollection.Add(Globals.TheBay.TemplateWorksheetNames.NosCombined, nosCombinedSetting);

            newSettings.Save();
            this.Close();
        }

        private void LifecycleWorksheetOptionsLoadButton_Click(object sender, EventArgs e)
        {
            worksheetSettings = WorksheetCustomSettingsHolder.Load().SettingsCollection;
            LoadSettings();
        }

        private void LifecycleWorksheetOptionsDefaultButton_Click(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = true;
            worksheetSettings = WorksheetCustomSettingsHolder.Load(Globals.TheBay.PathHolder.WsOptionsDefaultFileName).SettingsCollection;
            LoadSettings();
        } 

        private void LoadSettings()
        {
            DetailsProductHeaderRowValue.Value = worksheetSettings[Globals.TheBay.TemplateWorksheetNames.DetailsProduct].HeaderRow;
            DetailsProductFormulaRowValue.Value = worksheetSettings[Globals.TheBay.TemplateWorksheetNames.DetailsProduct].FormulaeRow;
            DetailsProductReferenceRowValue.Value = worksheetSettings[Globals.TheBay.TemplateWorksheetNames.DetailsProduct].ReferenceRow;

            InactiveUpcHeaderRowValue.Value = worksheetSettings[Globals.TheBay.TemplateWorksheetNames.InactiveUpc].HeaderRow;
            InactiveUpcFormulaRowValue.Value = worksheetSettings[Globals.TheBay.TemplateWorksheetNames.InactiveUpc].FormulaeRow;
            InactiveUpcReferenceRowValue.Value = worksheetSettings[Globals.TheBay.TemplateWorksheetNames.InactiveUpc].ReferenceRow;

            NosCombinedHeaderRowValue.Value = worksheetSettings[Globals.TheBay.TemplateWorksheetNames.NosCombined].HeaderRow;
            NosCombinedFormulaRowValue.Value = worksheetSettings[Globals.TheBay.TemplateWorksheetNames.NosCombined].FormulaeRow;
            NosCombinedReferenceRowValue.Value = worksheetSettings[Globals.TheBay.TemplateWorksheetNames.NosCombined].ReferenceRow;
        }

        private void NosCombinedHeaderRowValue_ValueChanged(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = false;
        }

        private void NosCombinedFormulaRowValue_ValueChanged(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = false;
        }

        private void DetailsProductReferenceRowValue_ValueChanged(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = false;
        }

        private void InactiveUpcHeaderRowValue_ValueChanged(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = false;
        }

        private void InactiveUpcFormulaRowValue_ValueChanged(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = false;
        }

        private void InactiveUpcReferenceRowValue_ValueChanged(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = false;
        }

        private void DetailsProductHeaderRowValue_ValueChanged(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = false;
        }

        private void DetailsProductFormulaRowValue_ValueChanged(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = false;
        }

        private void NosCombinedReferenceRowValue_ValueChanged(object sender, EventArgs e)
        {
            StoredSettings.UseDefaultOptions.TheBay.UseDefaultWorksheetOptions = false;
        }
    }
}
