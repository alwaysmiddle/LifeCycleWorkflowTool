namespace LifeCycleWorkflowTool
{
    partial class LifecycleSaveLocationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LifecycleSaveLocationsForm));
            this.TheBayOutputLocationWipLabel = new System.Windows.Forms.Label();
            this.TheBayOutputLocationWipValue = new System.Windows.Forms.TextBox();
            this.TheBayOutputLocationWipFilePicker = new System.Windows.Forms.Button();
            this.SaveLocationsButtonSaveSettings = new System.Windows.Forms.Button();
            this.SaveLocationsButtonRestoreDefault = new System.Windows.Forms.Button();
            this.SaveLocationsTabControl = new System.Windows.Forms.TabControl();
            this.SaveLocationsTabPageTheBay = new System.Windows.Forms.TabPage();
            this.TheBayOutputLocationFinalLabel = new System.Windows.Forms.Label();
            this.TheBayOutputLocationFinalValue = new System.Windows.Forms.TextBox();
            this.TheBayOutputLocationFinalFilePicker = new System.Windows.Forms.Button();
            this.LifecycleSaveLocationsErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SaveLocationsTabControl.SuspendLayout();
            this.SaveLocationsTabPageTheBay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LifecycleSaveLocationsErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TheBayOutputLocationWipLabel
            // 
            this.TheBayOutputLocationWipLabel.AutoSize = true;
            this.TheBayOutputLocationWipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBayOutputLocationWipLabel.Location = new System.Drawing.Point(3, 14);
            this.TheBayOutputLocationWipLabel.Name = "TheBayOutputLocationWipLabel";
            this.TheBayOutputLocationWipLabel.Size = new System.Drawing.Size(275, 24);
            this.TheBayOutputLocationWipLabel.TabIndex = 0;
            this.TheBayOutputLocationWipLabel.Text = "Work in Progress File Save To: ";
            // 
            // TheBayOutputLocationWipValue
            // 
            this.TheBayOutputLocationWipValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBayOutputLocationWipValue.Location = new System.Drawing.Point(8, 41);
            this.TheBayOutputLocationWipValue.Name = "TheBayOutputLocationWipValue";
            this.TheBayOutputLocationWipValue.Size = new System.Drawing.Size(429, 26);
            this.TheBayOutputLocationWipValue.TabIndex = 1;
            // 
            // TheBayOutputLocationWipFilePicker
            // 
            this.TheBayOutputLocationWipFilePicker.Location = new System.Drawing.Point(459, 41);
            this.TheBayOutputLocationWipFilePicker.Name = "TheBayOutputLocationWipFilePicker";
            this.TheBayOutputLocationWipFilePicker.Size = new System.Drawing.Size(35, 27);
            this.TheBayOutputLocationWipFilePicker.TabIndex = 2;
            this.TheBayOutputLocationWipFilePicker.Text = "...";
            this.TheBayOutputLocationWipFilePicker.UseVisualStyleBackColor = true;
            this.TheBayOutputLocationWipFilePicker.Click += new System.EventHandler(this.SaveLocationsWipFilePicker_Click);
            // 
            // SaveLocationsButtonSaveSettings
            // 
            this.SaveLocationsButtonSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsButtonSaveSettings.ForeColor = System.Drawing.Color.MediumBlue;
            this.SaveLocationsButtonSaveSettings.Location = new System.Drawing.Point(3, 249);
            this.SaveLocationsButtonSaveSettings.Name = "SaveLocationsButtonSaveSettings";
            this.SaveLocationsButtonSaveSettings.Size = new System.Drawing.Size(126, 34);
            this.SaveLocationsButtonSaveSettings.TabIndex = 3;
            this.SaveLocationsButtonSaveSettings.Text = "Save";
            this.SaveLocationsButtonSaveSettings.UseVisualStyleBackColor = true;
            this.SaveLocationsButtonSaveSettings.Click += new System.EventHandler(this.SaveLocationsButtonSave_Click);
            // 
            // SaveLocationsButtonRestoreDefault
            // 
            this.SaveLocationsButtonRestoreDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsButtonRestoreDefault.ForeColor = System.Drawing.Color.MediumBlue;
            this.SaveLocationsButtonRestoreDefault.Location = new System.Drawing.Point(135, 249);
            this.SaveLocationsButtonRestoreDefault.Name = "SaveLocationsButtonRestoreDefault";
            this.SaveLocationsButtonRestoreDefault.Size = new System.Drawing.Size(126, 34);
            this.SaveLocationsButtonRestoreDefault.TabIndex = 4;
            this.SaveLocationsButtonRestoreDefault.Text = "Default";
            this.SaveLocationsButtonRestoreDefault.UseVisualStyleBackColor = true;
            this.SaveLocationsButtonRestoreDefault.Click += new System.EventHandler(this.SaveLocationsButtonRestoreDefault_Click);
            // 
            // SaveLocationsTabControl
            // 
            this.SaveLocationsTabControl.Controls.Add(this.SaveLocationsTabPageTheBay);
            this.SaveLocationsTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.SaveLocationsTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsTabControl.Location = new System.Drawing.Point(0, 0);
            this.SaveLocationsTabControl.Name = "SaveLocationsTabControl";
            this.SaveLocationsTabControl.SelectedIndex = 0;
            this.SaveLocationsTabControl.Size = new System.Drawing.Size(519, 245);
            this.SaveLocationsTabControl.TabIndex = 5;
            // 
            // SaveLocationsTabPageTheBay
            // 
            this.SaveLocationsTabPageTheBay.BackColor = System.Drawing.Color.Gainsboro;
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBayOutputLocationFinalLabel);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBayOutputLocationFinalValue);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBayOutputLocationFinalFilePicker);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBayOutputLocationWipLabel);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBayOutputLocationWipValue);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBayOutputLocationWipFilePicker);
            this.SaveLocationsTabPageTheBay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsTabPageTheBay.Location = new System.Drawing.Point(4, 29);
            this.SaveLocationsTabPageTheBay.Name = "SaveLocationsTabPageTheBay";
            this.SaveLocationsTabPageTheBay.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.SaveLocationsTabPageTheBay.Size = new System.Drawing.Size(511, 212);
            this.SaveLocationsTabPageTheBay.TabIndex = 1;
            this.SaveLocationsTabPageTheBay.Text = "TheBay";
            // 
            // TheBayOutputLocationFinalLabel
            // 
            this.TheBayOutputLocationFinalLabel.AutoSize = true;
            this.TheBayOutputLocationFinalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBayOutputLocationFinalLabel.Location = new System.Drawing.Point(3, 81);
            this.TheBayOutputLocationFinalLabel.Name = "TheBayOutputLocationFinalLabel";
            this.TheBayOutputLocationFinalLabel.Size = new System.Drawing.Size(172, 24);
            this.TheBayOutputLocationFinalLabel.TabIndex = 3;
            this.TheBayOutputLocationFinalLabel.Text = "Final File Save To: ";
            // 
            // TheBayOutputLocationFinalValue
            // 
            this.TheBayOutputLocationFinalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBayOutputLocationFinalValue.Location = new System.Drawing.Point(8, 108);
            this.TheBayOutputLocationFinalValue.Name = "TheBayOutputLocationFinalValue";
            this.TheBayOutputLocationFinalValue.Size = new System.Drawing.Size(429, 26);
            this.TheBayOutputLocationFinalValue.TabIndex = 4;
            // 
            // TheBayOutputLocationFinalFilePicker
            // 
            this.TheBayOutputLocationFinalFilePicker.Location = new System.Drawing.Point(459, 108);
            this.TheBayOutputLocationFinalFilePicker.Name = "TheBayOutputLocationFinalFilePicker";
            this.TheBayOutputLocationFinalFilePicker.Size = new System.Drawing.Size(35, 27);
            this.TheBayOutputLocationFinalFilePicker.TabIndex = 5;
            this.TheBayOutputLocationFinalFilePicker.Text = "...";
            this.TheBayOutputLocationFinalFilePicker.UseVisualStyleBackColor = true;
            this.TheBayOutputLocationFinalFilePicker.Click += new System.EventHandler(this.SaveLocationFinalFilePicker_Click);
            // 
            // LifecycleSaveLocationsErrorProvider
            // 
            this.LifecycleSaveLocationsErrorProvider.BlinkRate = 0;
            this.LifecycleSaveLocationsErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.LifecycleSaveLocationsErrorProvider.ContainerControl = this;
            // 
            // LifecycleSaveLocationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 292);
            this.Controls.Add(this.SaveLocationsTabControl);
            this.Controls.Add(this.SaveLocationsButtonRestoreDefault);
            this.Controls.Add(this.SaveLocationsButtonSaveSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LifecycleSaveLocationsForm";
            this.Text = "Save Locations";
            this.SaveLocationsTabControl.ResumeLayout(false);
            this.SaveLocationsTabPageTheBay.ResumeLayout(false);
            this.SaveLocationsTabPageTheBay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LifecycleSaveLocationsErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TheBayOutputLocationWipLabel;
        private System.Windows.Forms.TextBox TheBayOutputLocationWipValue;
        private System.Windows.Forms.Button TheBayOutputLocationWipFilePicker;
        private System.Windows.Forms.Button SaveLocationsButtonSaveSettings;
        private System.Windows.Forms.Button SaveLocationsButtonRestoreDefault;
        private System.Windows.Forms.TabControl SaveLocationsTabControl;
        private System.Windows.Forms.TabPage SaveLocationsTabPageTheBay;
        private System.Windows.Forms.Label TheBayOutputLocationFinalLabel;
        private System.Windows.Forms.TextBox TheBayOutputLocationFinalValue;
        private System.Windows.Forms.Button TheBayOutputLocationFinalFilePicker;
        private System.Windows.Forms.ErrorProvider LifecycleSaveLocationsErrorProvider;
    }
}