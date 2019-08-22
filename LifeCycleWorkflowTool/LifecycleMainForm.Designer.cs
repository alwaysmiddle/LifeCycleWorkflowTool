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
            this.WorkflowTabSettings = new System.Windows.Forms.TabPage();
            this.WorkflowTabManual = new System.Windows.Forms.TabPage();
            this.ManualTabLabelBanner = new System.Windows.Forms.Label();
            this.ManualTextBoxBanner = new System.Windows.Forms.ComboBox();
            this.ManualLoadButtonLoadData = new System.Windows.Forms.Button();
            this.ManualLoadButtonWIP = new System.Windows.Forms.Button();
            this.ManualLoadButtonFinalFile = new System.Windows.Forms.Button();
            this.WorkflowTabControl = new System.Windows.Forms.TabControl();
            this.ManualLoadButtonShowFolder = new System.Windows.Forms.Button();
            this.ManualLoadProgressBar = new System.Windows.Forms.ProgressBar();
            this.SettingsButtonSaveLocation = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ManualLoadLabelDate = new System.Windows.Forms.Label();
            this.WorkflowTabSettings.SuspendLayout();
            this.WorkflowTabManual.SuspendLayout();
            this.WorkflowTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkflowTabSettings
            // 
            this.WorkflowTabSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.WorkflowTabSettings.Controls.Add(this.SettingsButtonSaveLocation);
            this.WorkflowTabSettings.Location = new System.Drawing.Point(4, 22);
            this.WorkflowTabSettings.Name = "WorkflowTabSettings";
            this.WorkflowTabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.WorkflowTabSettings.Size = new System.Drawing.Size(503, 238);
            this.WorkflowTabSettings.TabIndex = 2;
            this.WorkflowTabSettings.Text = "Settings";
            // 
            // WorkflowTabManual
            // 
            this.WorkflowTabManual.BackColor = System.Drawing.Color.Gainsboro;
            this.WorkflowTabManual.Controls.Add(this.ManualLoadLabelDate);
            this.WorkflowTabManual.Controls.Add(this.dateTimePicker1);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadProgressBar);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadButtonShowFolder);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadButtonFinalFile);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadButtonWIP);
            this.WorkflowTabManual.Controls.Add(this.ManualLoadButtonLoadData);
            this.WorkflowTabManual.Controls.Add(this.ManualTextBoxBanner);
            this.WorkflowTabManual.Controls.Add(this.ManualTabLabelBanner);
            this.WorkflowTabManual.Location = new System.Drawing.Point(4, 22);
            this.WorkflowTabManual.Name = "WorkflowTabManual";
            this.WorkflowTabManual.Padding = new System.Windows.Forms.Padding(3);
            this.WorkflowTabManual.Size = new System.Drawing.Size(510, 260);
            this.WorkflowTabManual.TabIndex = 0;
            this.WorkflowTabManual.Text = "Manual Load";
            // 
            // ManualTabLabelBanner
            // 
            this.ManualTabLabelBanner.AutoSize = true;
            this.ManualTabLabelBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualTabLabelBanner.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ManualTabLabelBanner.Location = new System.Drawing.Point(25, 21);
            this.ManualTabLabelBanner.Name = "ManualTabLabelBanner";
            this.ManualTabLabelBanner.Size = new System.Drawing.Size(149, 42);
            this.ManualTabLabelBanner.TabIndex = 0;
            this.ManualTabLabelBanner.Text = "Banner:";
            // 
            // ManualTextBoxBanner
            // 
            this.ManualTextBoxBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualTextBoxBanner.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ManualTextBoxBanner.FormattingEnabled = true;
            this.ManualTextBoxBanner.IntegralHeight = false;
            this.ManualTextBoxBanner.Items.AddRange(new object[] {
            "TheBay"});
            this.ManualTextBoxBanner.Location = new System.Drawing.Point(180, 24);
            this.ManualTextBoxBanner.Name = "ManualTextBoxBanner";
            this.ManualTextBoxBanner.Size = new System.Drawing.Size(144, 39);
            this.ManualTextBoxBanner.TabIndex = 1;
            // 
            // ManualLoadButtonLoadData
            // 
            this.ManualLoadButtonLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadButtonLoadData.ForeColor = System.Drawing.Color.Black;
            this.ManualLoadButtonLoadData.Location = new System.Drawing.Point(32, 87);
            this.ManualLoadButtonLoadData.Name = "ManualLoadButtonLoadData";
            this.ManualLoadButtonLoadData.Size = new System.Drawing.Size(442, 44);
            this.ManualLoadButtonLoadData.TabIndex = 2;
            this.ManualLoadButtonLoadData.Text = "Load Data Files";
            this.ManualLoadButtonLoadData.UseVisualStyleBackColor = true;
            // 
            // ManualLoadButtonWIP
            // 
            this.ManualLoadButtonWIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadButtonWIP.ForeColor = System.Drawing.Color.Black;
            this.ManualLoadButtonWIP.Location = new System.Drawing.Point(32, 179);
            this.ManualLoadButtonWIP.Name = "ManualLoadButtonWIP";
            this.ManualLoadButtonWIP.Size = new System.Drawing.Size(142, 37);
            this.ManualLoadButtonWIP.TabIndex = 3;
            this.ManualLoadButtonWIP.Text = "Generate WIP File";
            this.ManualLoadButtonWIP.UseVisualStyleBackColor = true;
            // 
            // ManualLoadButtonFinalFile
            // 
            this.ManualLoadButtonFinalFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadButtonFinalFile.ForeColor = System.Drawing.Color.Black;
            this.ManualLoadButtonFinalFile.Location = new System.Drawing.Point(180, 179);
            this.ManualLoadButtonFinalFile.Name = "ManualLoadButtonFinalFile";
            this.ManualLoadButtonFinalFile.Size = new System.Drawing.Size(144, 37);
            this.ManualLoadButtonFinalFile.TabIndex = 4;
            this.ManualLoadButtonFinalFile.Text = "Generate Final File";
            this.ManualLoadButtonFinalFile.UseVisualStyleBackColor = true;
            // 
            // WorkflowTabControl
            // 
            this.WorkflowTabControl.Controls.Add(this.WorkflowTabManual);
            this.WorkflowTabControl.Controls.Add(this.WorkflowTabSettings);
            this.WorkflowTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkflowTabControl.Location = new System.Drawing.Point(0, 0);
            this.WorkflowTabControl.Name = "WorkflowTabControl";
            this.WorkflowTabControl.SelectedIndex = 0;
            this.WorkflowTabControl.Size = new System.Drawing.Size(518, 286);
            this.WorkflowTabControl.TabIndex = 0;
            // 
            // ManualLoadButtonShowFolder
            // 
            this.ManualLoadButtonShowFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadButtonShowFolder.ForeColor = System.Drawing.Color.MediumBlue;
            this.ManualLoadButtonShowFolder.Location = new System.Drawing.Point(330, 179);
            this.ManualLoadButtonShowFolder.Name = "ManualLoadButtonShowFolder";
            this.ManualLoadButtonShowFolder.Size = new System.Drawing.Size(144, 37);
            this.ManualLoadButtonShowFolder.TabIndex = 5;
            this.ManualLoadButtonShowFolder.Text = "Show Saved Folder";
            this.ManualLoadButtonShowFolder.UseVisualStyleBackColor = true;
            // 
            // ManualLoadProgressBar
            // 
            this.ManualLoadProgressBar.Location = new System.Drawing.Point(32, 222);
            this.ManualLoadProgressBar.Name = "ManualLoadProgressBar";
            this.ManualLoadProgressBar.Size = new System.Drawing.Size(442, 16);
            this.ManualLoadProgressBar.TabIndex = 6;
            // 
            // SettingsButtonSaveLocation
            // 
            this.SettingsButtonSaveLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButtonSaveLocation.ForeColor = System.Drawing.Color.Black;
            this.SettingsButtonSaveLocation.Location = new System.Drawing.Point(17, 17);
            this.SettingsButtonSaveLocation.Name = "SettingsButtonSaveLocation";
            this.SettingsButtonSaveLocation.Size = new System.Drawing.Size(232, 36);
            this.SettingsButtonSaveLocation.TabIndex = 3;
            this.SettingsButtonSaveLocation.Text = "Save Locations";
            this.SettingsButtonSaveLocation.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(203, 141);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(235, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // ManualLoadLabelDate
            // 
            this.ManualLoadLabelDate.AutoSize = true;
            this.ManualLoadLabelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadLabelDate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ManualLoadLabelDate.Location = new System.Drawing.Point(29, 141);
            this.ManualLoadLabelDate.Name = "ManualLoadLabelDate";
            this.ManualLoadLabelDate.Size = new System.Drawing.Size(168, 18);
            this.ManualLoadLabelDate.TabIndex = 8;
            this.ManualLoadLabelDate.Text = "Generated File Date: ";
            // 
            // LifecycleWorkflowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 286);
            this.Controls.Add(this.WorkflowTabControl);
            this.Name = "LifecycleWorkflowForm";
            this.Text = "Lifecycle Excel Workflow Generator";
            this.WorkflowTabSettings.ResumeLayout(false);
            this.WorkflowTabManual.ResumeLayout(false);
            this.WorkflowTabManual.PerformLayout();
            this.WorkflowTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage WorkflowTabSettings;
        private System.Windows.Forms.Button SettingsButtonSaveLocation;
        private System.Windows.Forms.TabPage WorkflowTabManual;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ProgressBar ManualLoadProgressBar;
        private System.Windows.Forms.Button ManualLoadButtonShowFolder;
        private System.Windows.Forms.Button ManualLoadButtonFinalFile;
        private System.Windows.Forms.Button ManualLoadButtonWIP;
        private System.Windows.Forms.Button ManualLoadButtonLoadData;
        private System.Windows.Forms.ComboBox ManualTextBoxBanner;
        private System.Windows.Forms.Label ManualTabLabelBanner;
        private System.Windows.Forms.TabControl WorkflowTabControl;
        private System.Windows.Forms.Label ManualLoadLabelDate;
    }
}

