namespace LifeCycleWorkflowTool
{
    partial class LifecycleWorkflowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LifecycleWorkflowForm));
            this.WorkflowTabSettings = new System.Windows.Forms.TabPage();
            this.SettingsButtonTemplateLocations = new System.Windows.Forms.Button();
            this.SettingsButtonWorksheetOptions = new System.Windows.Forms.Button();
            this.SettingsButtonSaveLocation = new System.Windows.Forms.Button();
            this.WorkflowTabManual = new System.Windows.Forms.TabPage();
            this.ManualLoadButtonFinalFileShowFolder = new System.Windows.Forms.Button();
            this.ManualLoadWipShowFolder = new System.Windows.Forms.Button();
            this.ManualLoadLabelDate = new System.Windows.Forms.Label();
            this.lifeCycleDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ManualLoadProgressBar = new System.Windows.Forms.ProgressBar();
            this.ManualLoadButtonFinalFile = new System.Windows.Forms.Button();
            this.ManualLoadButtonWip = new System.Windows.Forms.Button();
            this.ManualLoadButtonLoadData = new System.Windows.Forms.Button();
            this.ManualTextBoxBanner = new System.Windows.Forms.ComboBox();
            this.ManualTabLabelBanner = new System.Windows.Forms.Label();
            this.WorkflowTabControl = new System.Windows.Forms.TabControl();
            this.ManualLoadErorrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.WorkflowTabSettings.SuspendLayout();
            this.WorkflowTabManual.SuspendLayout();
            this.WorkflowTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManualLoadErorrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkflowTabSettings
            // 
            this.WorkflowTabSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.WorkflowTabSettings.Controls.Add(this.SettingsButtonTemplateLocations);
            this.WorkflowTabSettings.Controls.Add(this.SettingsButtonWorksheetOptions);
            this.WorkflowTabSettings.Controls.Add(this.SettingsButtonSaveLocation);
            this.WorkflowTabSettings.Location = new System.Drawing.Point(4, 26);
            this.WorkflowTabSettings.Name = "WorkflowTabSettings";
            this.WorkflowTabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.WorkflowTabSettings.Size = new System.Drawing.Size(514, 239);
            this.WorkflowTabSettings.TabIndex = 2;
            this.WorkflowTabSettings.Text = "Settings";
            // 
            // SettingsButtonTemplateLocations
            // 
            this.SettingsButtonTemplateLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButtonTemplateLocations.ForeColor = System.Drawing.Color.Black;
            this.SettingsButtonTemplateLocations.Location = new System.Drawing.Point(262, 20);
            this.SettingsButtonTemplateLocations.Name = "SettingsButtonTemplateLocations";
            this.SettingsButtonTemplateLocations.Size = new System.Drawing.Size(236, 34);
            this.SettingsButtonTemplateLocations.TabIndex = 5;
            this.SettingsButtonTemplateLocations.Text = "Template Locations";
            this.SettingsButtonTemplateLocations.UseVisualStyleBackColor = true;
            this.SettingsButtonTemplateLocations.Click += new System.EventHandler(this.SettingsButtonTemplateLocations_Click);
            // 
            // SettingsButtonWorksheetOptions
            // 
            this.SettingsButtonWorksheetOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButtonWorksheetOptions.ForeColor = System.Drawing.Color.Black;
            this.SettingsButtonWorksheetOptions.Location = new System.Drawing.Point(20, 60);
            this.SettingsButtonWorksheetOptions.Name = "SettingsButtonWorksheetOptions";
            this.SettingsButtonWorksheetOptions.Size = new System.Drawing.Size(236, 34);
            this.SettingsButtonWorksheetOptions.TabIndex = 4;
            this.SettingsButtonWorksheetOptions.Text = "Worksheet Options";
            this.SettingsButtonWorksheetOptions.UseVisualStyleBackColor = true;
            this.SettingsButtonWorksheetOptions.Click += new System.EventHandler(this.SettingsButtonWorksheetOptions_Click);
            // 
            // SettingsButtonSaveLocation
            // 
            this.SettingsButtonSaveLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButtonSaveLocation.ForeColor = System.Drawing.Color.Black;
            this.SettingsButtonSaveLocation.Location = new System.Drawing.Point(20, 20);
            this.SettingsButtonSaveLocation.Name = "SettingsButtonSaveLocation";
            this.SettingsButtonSaveLocation.Size = new System.Drawing.Size(236, 34);
            this.SettingsButtonSaveLocation.TabIndex = 3;
            this.SettingsButtonSaveLocation.Text = "Output File Locations";
            this.SettingsButtonSaveLocation.UseVisualStyleBackColor = true;
            this.SettingsButtonSaveLocation.Click += new System.EventHandler(this.SettingsButtonSaveLocation_Click);
            // 
            // WorkflowTabManual
            // 
            this.WorkflowTabManual.BackColor = System.Drawing.Color.Gainsboro;
            this.WorkflowTabManual.Controls.Add(this.ManualLoadButtonFinalFileShowFolder);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadWipShowFolder);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadLabelDate);
            this.WorkflowTabManual.Controls.Add(this.lifeCycleDateTimePicker);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadProgressBar);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadButtonFinalFile);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadButtonWip);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadButtonLoadData);
            this.WorkflowTabManual.Controls.Add(this.ManualTextBoxBanner);
            this.WorkflowTabManual.Controls.Add(this.ManualTabLabelBanner);
            this.WorkflowTabManual.Location = new System.Drawing.Point(4, 26);
            this.WorkflowTabManual.Name = "WorkflowTabManual";
            this.WorkflowTabManual.Padding = new System.Windows.Forms.Padding(3);
            this.WorkflowTabManual.Size = new System.Drawing.Size(514, 239);
            this.WorkflowTabManual.TabIndex = 0;
            this.WorkflowTabManual.Text = "Manual Load";
            // 
            // ManualLoadButtonFinalFileShowFolder
            // 
            this.ManualLoadButtonFinalFileShowFolder.Image = global::LifeCycleWorkflowTool.Properties.Resources.imageedit_2_7181984581;
            this.ManualLoadButtonFinalFileShowFolder.Location = new System.Drawing.Point(429, 162);
            this.ManualLoadButtonFinalFileShowFolder.Name = "ManualLoadButtonFinalFileShowFolder";
            this.ManualLoadButtonFinalFileShowFolder.Size = new System.Drawing.Size(45, 37);
            this.ManualLoadButtonFinalFileShowFolder.TabIndex = 10;
            this.ManualLoadButtonFinalFileShowFolder.UseVisualStyleBackColor = true;
            this.ManualLoadButtonFinalFileShowFolder.Click += new System.EventHandler(this.ManualLoadButtonFinalFileShowFolder_Click);
            // 
            // ManualLoadWipShowFolder
            // 
            this.ManualLoadWipShowFolder.Image = global::LifeCycleWorkflowTool.Properties.Resources.imageedit_2_7181984581;
            this.ManualLoadWipShowFolder.Location = new System.Drawing.Point(194, 162);
            this.ManualLoadWipShowFolder.Name = "ManualLoadWipShowFolder";
            this.ManualLoadWipShowFolder.Size = new System.Drawing.Size(45, 37);
            this.ManualLoadWipShowFolder.TabIndex = 9;
            this.ManualLoadWipShowFolder.UseVisualStyleBackColor = true;
            this.ManualLoadWipShowFolder.Click += new System.EventHandler(this.ManualLoadWipShowFolder_Click);
            // 
            // ManualLoadLabelDate
            // 
            this.ManualLoadLabelDate.AutoSize = true;
            this.ManualLoadLabelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadLabelDate.ForeColor = System.Drawing.Color.SteelBlue;
            this.ManualLoadLabelDate.Location = new System.Drawing.Point(29, 72);
            this.ManualLoadLabelDate.Name = "ManualLoadLabelDate";
            this.ManualLoadLabelDate.Size = new System.Drawing.Size(168, 18);
            this.ManualLoadLabelDate.TabIndex = 8;
            this.ManualLoadLabelDate.Text = "Generated File Date: ";
            // 
            // lifeCycleDateTimePicker
            // 
            this.lifeCycleDateTimePicker.Location = new System.Drawing.Point(203, 72);
            this.lifeCycleDateTimePicker.Name = "lifeCycleDateTimePicker";
            this.lifeCycleDateTimePicker.Size = new System.Drawing.Size(222, 23);
            this.lifeCycleDateTimePicker.TabIndex = 7;
            // 
            // ManualLoadProgressBar
            // 
            this.ManualLoadProgressBar.Location = new System.Drawing.Point(32, 205);
            this.ManualLoadProgressBar.Name = "ManualLoadProgressBar";
            this.ManualLoadProgressBar.Size = new System.Drawing.Size(442, 16);
            this.ManualLoadProgressBar.TabIndex = 6;
            // 
            // ManualLoadButtonFinalFile
            // 
            this.ManualLoadButtonFinalFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadButtonFinalFile.ForeColor = System.Drawing.Color.Black;
            this.ManualLoadButtonFinalFile.Location = new System.Drawing.Point(267, 162);
            this.ManualLoadButtonFinalFile.Name = "ManualLoadButtonFinalFile";
            this.ManualLoadButtonFinalFile.Size = new System.Drawing.Size(156, 37);
            this.ManualLoadButtonFinalFile.TabIndex = 4;
            this.ManualLoadButtonFinalFile.Text = "Generate Final File";
            this.ManualLoadButtonFinalFile.UseVisualStyleBackColor = true;
            this.ManualLoadButtonFinalFile.Click += new System.EventHandler(this.ManualLoadButtonFinalFile_Click);
            // 
            // ManualLoadButtonWip
            // 
            this.ManualLoadButtonWip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadButtonWip.ForeColor = System.Drawing.Color.Black;
            this.ManualLoadButtonWip.Location = new System.Drawing.Point(32, 162);
            this.ManualLoadButtonWip.Name = "ManualLoadButtonWip";
            this.ManualLoadButtonWip.Size = new System.Drawing.Size(156, 37);
            this.ManualLoadButtonWip.TabIndex = 3;
            this.ManualLoadButtonWip.Text = "Generate WIP File";
            this.ManualLoadButtonWip.UseVisualStyleBackColor = true;
            this.ManualLoadButtonWip.Click += new System.EventHandler(this.ManualLoadButtonWIP_Click);
            // 
            // ManualLoadButtonLoadData
            // 
            this.ManualLoadButtonLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadButtonLoadData.ForeColor = System.Drawing.Color.Black;
            this.ManualLoadButtonLoadData.Location = new System.Drawing.Point(32, 112);
            this.ManualLoadButtonLoadData.Name = "ManualLoadButtonLoadData";
            this.ManualLoadButtonLoadData.Size = new System.Drawing.Size(442, 44);
            this.ManualLoadButtonLoadData.TabIndex = 2;
            this.ManualLoadButtonLoadData.Text = "Load Data Files";
            this.ManualLoadButtonLoadData.UseVisualStyleBackColor = true;
            this.ManualLoadButtonLoadData.Click += new System.EventHandler(this.ManualLoadButtonLoadData_Click);
            // 
            // ManualTextBoxBanner
            // 
            this.ManualTextBoxBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualTextBoxBanner.ForeColor = System.Drawing.Color.SteelBlue;
            this.ManualTextBoxBanner.FormattingEnabled = true;
            this.ManualTextBoxBanner.IntegralHeight = false;
            this.ManualTextBoxBanner.Items.AddRange(new object[] {
            "TheBay"});
            this.ManualTextBoxBanner.Location = new System.Drawing.Point(141, 24);
            this.ManualTextBoxBanner.Name = "ManualTextBoxBanner";
            this.ManualTextBoxBanner.Size = new System.Drawing.Size(144, 33);
            this.ManualTextBoxBanner.TabIndex = 1;
            // 
            // ManualTabLabelBanner
            // 
            this.ManualTabLabelBanner.AutoSize = true;
            this.ManualTabLabelBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualTabLabelBanner.ForeColor = System.Drawing.Color.SteelBlue;
            this.ManualTabLabelBanner.Location = new System.Drawing.Point(26, 24);
            this.ManualTabLabelBanner.Name = "ManualTabLabelBanner";
            this.ManualTabLabelBanner.Size = new System.Drawing.Size(109, 31);
            this.ManualTabLabelBanner.TabIndex = 0;
            this.ManualTabLabelBanner.Text = "Banner:";
            // 
            // WorkflowTabControl
            // 
            this.WorkflowTabControl.Controls.Add(this.WorkflowTabManual);
            this.WorkflowTabControl.Controls.Add(this.WorkflowTabSettings);
            this.WorkflowTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkflowTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkflowTabControl.Location = new System.Drawing.Point(0, 0);
            this.WorkflowTabControl.Name = "WorkflowTabControl";
            this.WorkflowTabControl.SelectedIndex = 0;
            this.WorkflowTabControl.Size = new System.Drawing.Size(522, 269);
            this.WorkflowTabControl.TabIndex = 0;
            // 
            // ManualLoadErorrProvider
            // 
            this.ManualLoadErorrProvider.BlinkRate = 0;
            this.ManualLoadErorrProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ManualLoadErorrProvider.ContainerControl = this;
            // 
            // LifecycleWorkflowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 269);
            this.Controls.Add(this.WorkflowTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LifecycleWorkflowForm";
            this.Text = "Lifecycle Excel Workflow Generator";
            this.Activated += new System.EventHandler(this.LifecycleWorkflowForm_Activated);
            this.WorkflowTabSettings.ResumeLayout(false);
            this.WorkflowTabManual.ResumeLayout(false);
            this.WorkflowTabManual.PerformLayout();
            this.WorkflowTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ManualLoadErorrProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage WorkflowTabSettings;
        private System.Windows.Forms.Button SettingsButtonSaveLocation;
        private System.Windows.Forms.TabPage WorkflowTabManual;
        private System.Windows.Forms.DateTimePicker lifeCycleDateTimePicker;
        private System.Windows.Forms.ProgressBar ManualLoadProgressBar;
        private System.Windows.Forms.Button ManualLoadButtonFinalFile;
        private System.Windows.Forms.Button ManualLoadButtonWip;
        private System.Windows.Forms.Button ManualLoadButtonLoadData;
        private System.Windows.Forms.ComboBox ManualTextBoxBanner;
        private System.Windows.Forms.Label ManualTabLabelBanner;
        private System.Windows.Forms.TabControl WorkflowTabControl;
        private System.Windows.Forms.Label ManualLoadLabelDate;
        private System.Windows.Forms.ErrorProvider ManualLoadErorrProvider;
        private System.Windows.Forms.Button ManualLoadWipShowFolder;
        private System.Windows.Forms.Button ManualLoadButtonFinalFileShowFolder;
        private System.Windows.Forms.Button SettingsButtonWorksheetOptions;
        private System.Windows.Forms.Button SettingsButtonTemplateLocations;
    }
}

