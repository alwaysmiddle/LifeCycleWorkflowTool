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
            this.SettingsButtonSaveLocation = new System.Windows.Forms.Button();
            this.WorkflowTabManual = new System.Windows.Forms.TabPage();
            this.ManualLoadLabelDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ManualLoadProgressBar = new System.Windows.Forms.ProgressBar();
            this.ManualLoadButtonShowFolder = new System.Windows.Forms.Button();
            this.ManualLoadButtonFinalFile = new System.Windows.Forms.Button();
            this.ManualLoadButtonWIP = new System.Windows.Forms.Button();
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
            this.WorkflowTabSettings.Controls.Add(this.SettingsButtonSaveLocation);
            this.WorkflowTabSettings.Location = new System.Drawing.Point(4, 22);
            this.WorkflowTabSettings.Name = "WorkflowTabSettings";
            this.WorkflowTabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.WorkflowTabSettings.Size = new System.Drawing.Size(514, 243);
            this.WorkflowTabSettings.TabIndex = 2;
            this.WorkflowTabSettings.Text = "Settings";
            // 
            // SettingsButtonSaveLocation
            // 
            this.SettingsButtonSaveLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButtonSaveLocation.ForeColor = System.Drawing.Color.Black;
            this.SettingsButtonSaveLocation.Location = new System.Drawing.Point(26, 16);
            this.SettingsButtonSaveLocation.Name = "SettingsButtonSaveLocation";
            this.SettingsButtonSaveLocation.Size = new System.Drawing.Size(183, 34);
            this.SettingsButtonSaveLocation.TabIndex = 3;
            this.SettingsButtonSaveLocation.Text = "Save Locations";
            this.SettingsButtonSaveLocation.UseVisualStyleBackColor = true;
            this.SettingsButtonSaveLocation.Click += new System.EventHandler(this.SettingsButtonSaveLocation_Click);
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
            this.WorkflowTabManual.Size = new System.Drawing.Size(514, 243);
            this.WorkflowTabManual.TabIndex = 0;
            this.WorkflowTabManual.Text = "Manual Load";
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(203, 72);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(222, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // ManualLoadProgressBar
            // 
            this.ManualLoadProgressBar.Location = new System.Drawing.Point(32, 205);
            this.ManualLoadProgressBar.Name = "ManualLoadProgressBar";
            this.ManualLoadProgressBar.Size = new System.Drawing.Size(442, 16);
            this.ManualLoadProgressBar.TabIndex = 6;
            // 
            // ManualLoadButtonShowFolder
            // 
            this.ManualLoadButtonShowFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadButtonShowFolder.ForeColor = System.Drawing.Color.MediumBlue;
            this.ManualLoadButtonShowFolder.Location = new System.Drawing.Point(330, 162);
            this.ManualLoadButtonShowFolder.Name = "ManualLoadButtonShowFolder";
            this.ManualLoadButtonShowFolder.Size = new System.Drawing.Size(144, 37);
            this.ManualLoadButtonShowFolder.TabIndex = 5;
            this.ManualLoadButtonShowFolder.Text = "Show Saved Folder";
            this.ManualLoadButtonShowFolder.UseVisualStyleBackColor = true;
            this.ManualLoadButtonShowFolder.Click += new System.EventHandler(this.ManualLoadButtonShowFolder_Click);
            // 
            // ManualLoadButtonFinalFile
            // 
            this.ManualLoadButtonFinalFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadButtonFinalFile.ForeColor = System.Drawing.Color.Black;
            this.ManualLoadButtonFinalFile.Location = new System.Drawing.Point(180, 162);
            this.ManualLoadButtonFinalFile.Name = "ManualLoadButtonFinalFile";
            this.ManualLoadButtonFinalFile.Size = new System.Drawing.Size(144, 37);
            this.ManualLoadButtonFinalFile.TabIndex = 4;
            this.ManualLoadButtonFinalFile.Text = "Generate Final File";
            this.ManualLoadButtonFinalFile.UseVisualStyleBackColor = true;
            this.ManualLoadButtonFinalFile.Click += new System.EventHandler(this.ManualLoadButtonFinalFile_Click);
            // 
            // ManualLoadButtonWIP
            // 
            this.ManualLoadButtonWIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualLoadButtonWIP.ForeColor = System.Drawing.Color.Black;
            this.ManualLoadButtonWIP.Location = new System.Drawing.Point(32, 162);
            this.ManualLoadButtonWIP.Name = "ManualLoadButtonWIP";
            this.ManualLoadButtonWIP.Size = new System.Drawing.Size(142, 37);
            this.ManualLoadButtonWIP.TabIndex = 3;
            this.ManualLoadButtonWIP.Text = "Generate WIP File";
            this.ManualLoadButtonWIP.UseVisualStyleBackColor = true;
            this.ManualLoadButtonWIP.Click += new System.EventHandler(this.ManualLoadButtonWIP_Click);
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
        private System.Windows.Forms.ErrorProvider ManualLoadErorrProvider;
    }
}

