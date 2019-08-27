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
            this.SaveLocationsLabelWip = new System.Windows.Forms.Label();
            this.SaveLocationsWipValue = new System.Windows.Forms.TextBox();
            this.SaveLocationsWipFilePicker = new System.Windows.Forms.Button();
            this.SaveLocationsButtonSaveSettings = new System.Windows.Forms.Button();
            this.SaveLocationsButtonRestoreDefault = new System.Windows.Forms.Button();
            this.SaveLocationsTabControl = new System.Windows.Forms.TabControl();
            this.SaveLocationsTabPageTheBay = new System.Windows.Forms.TabPage();
            this.SaveLocationsLabelFinal = new System.Windows.Forms.Label();
            this.SaveLocationsFinalValue = new System.Windows.Forms.TextBox();
            this.SaveLocationsFinalFilePicker = new System.Windows.Forms.Button();
            this.LifecycleSaveLocationsErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SaveLocationsTabControl.SuspendLayout();
            this.SaveLocationsTabPageTheBay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LifecycleSaveLocationsErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveLocationsLabelWip
            // 
            this.SaveLocationsLabelWip.AutoSize = true;
            this.SaveLocationsLabelWip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsLabelWip.Location = new System.Drawing.Point(3, 14);
            this.SaveLocationsLabelWip.Name = "SaveLocationsLabelWip";
            this.SaveLocationsLabelWip.Size = new System.Drawing.Size(275, 24);
            this.SaveLocationsLabelWip.TabIndex = 0;
            this.SaveLocationsLabelWip.Text = "Work in Progress File Save To: ";
            // 
            // SaveLocationsWipValue
            // 
            this.SaveLocationsWipValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsWipValue.Location = new System.Drawing.Point(8, 41);
            this.SaveLocationsWipValue.Name = "SaveLocationsWipValue";
            this.SaveLocationsWipValue.Size = new System.Drawing.Size(429, 26);
            this.SaveLocationsWipValue.TabIndex = 1;
            // 
            // SaveLocationsWipFilePicker
            // 
            this.SaveLocationsWipFilePicker.Location = new System.Drawing.Point(459, 41);
            this.SaveLocationsWipFilePicker.Name = "SaveLocationsWipFilePicker";
            this.SaveLocationsWipFilePicker.Size = new System.Drawing.Size(35, 27);
            this.SaveLocationsWipFilePicker.TabIndex = 2;
            this.SaveLocationsWipFilePicker.Text = "...";
            this.SaveLocationsWipFilePicker.UseVisualStyleBackColor = true;
            this.SaveLocationsWipFilePicker.Click += new System.EventHandler(this.SaveLocationsWipFilePicker_Click);
            // 
            // SaveLocationsButtonSaveSettings
            // 
            this.SaveLocationsButtonSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsButtonSaveSettings.ForeColor = System.Drawing.Color.MediumBlue;
            this.SaveLocationsButtonSaveSettings.Location = new System.Drawing.Point(12, 251);
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
            this.SaveLocationsButtonRestoreDefault.Location = new System.Drawing.Point(144, 251);
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
            this.SaveLocationsTabControl.Location = new System.Drawing.Point(0, 0);
            this.SaveLocationsTabControl.Name = "SaveLocationsTabControl";
            this.SaveLocationsTabControl.SelectedIndex = 0;
            this.SaveLocationsTabControl.Size = new System.Drawing.Size(520, 245);
            this.SaveLocationsTabControl.TabIndex = 5;
            // 
            // SaveLocationsTabPageTheBay
            // 
            this.SaveLocationsTabPageTheBay.BackColor = System.Drawing.Color.Gainsboro;
            this.SaveLocationsTabPageTheBay.Controls.Add(this.SaveLocationsLabelFinal);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.SaveLocationsFinalValue);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.SaveLocationsFinalFilePicker);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.SaveLocationsLabelWip);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.SaveLocationsWipValue);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.SaveLocationsWipFilePicker);
            this.SaveLocationsTabPageTheBay.Location = new System.Drawing.Point(4, 22);
            this.SaveLocationsTabPageTheBay.Name = "SaveLocationsTabPageTheBay";
            this.SaveLocationsTabPageTheBay.Padding = new System.Windows.Forms.Padding(3);
            this.SaveLocationsTabPageTheBay.Size = new System.Drawing.Size(512, 219);
            this.SaveLocationsTabPageTheBay.TabIndex = 1;
            this.SaveLocationsTabPageTheBay.Text = "TheBay";
            // 
            // SaveLocationsLabelFinal
            // 
            this.SaveLocationsLabelFinal.AutoSize = true;
            this.SaveLocationsLabelFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsLabelFinal.Location = new System.Drawing.Point(3, 81);
            this.SaveLocationsLabelFinal.Name = "SaveLocationsLabelFinal";
            this.SaveLocationsLabelFinal.Size = new System.Drawing.Size(172, 24);
            this.SaveLocationsLabelFinal.TabIndex = 3;
            this.SaveLocationsLabelFinal.Text = "Final File Save To: ";
            // 
            // SaveLocationsFinalValue
            // 
            this.SaveLocationsFinalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsFinalValue.Location = new System.Drawing.Point(8, 108);
            this.SaveLocationsFinalValue.Name = "SaveLocationsFinalValue";
            this.SaveLocationsFinalValue.Size = new System.Drawing.Size(429, 26);
            this.SaveLocationsFinalValue.TabIndex = 4;
            // 
            // SaveLocationsFinalFilePicker
            // 
            this.SaveLocationsFinalFilePicker.Location = new System.Drawing.Point(459, 108);
            this.SaveLocationsFinalFilePicker.Name = "SaveLocationsFinalFilePicker";
            this.SaveLocationsFinalFilePicker.Size = new System.Drawing.Size(35, 27);
            this.SaveLocationsFinalFilePicker.TabIndex = 5;
            this.SaveLocationsFinalFilePicker.Text = "...";
            this.SaveLocationsFinalFilePicker.UseVisualStyleBackColor = true;
            this.SaveLocationsFinalFilePicker.Click += new System.EventHandler(this.SaveLocationFinalFilePicker_Click);
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
            this.ClientSize = new System.Drawing.Size(520, 300);
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

        private System.Windows.Forms.Label SaveLocationsLabelWip;
        private System.Windows.Forms.TextBox SaveLocationsWipValue;
        private System.Windows.Forms.Button SaveLocationsWipFilePicker;
        private System.Windows.Forms.Button SaveLocationsButtonSaveSettings;
        private System.Windows.Forms.Button SaveLocationsButtonRestoreDefault;
        private System.Windows.Forms.TabControl SaveLocationsTabControl;
        private System.Windows.Forms.TabPage SaveLocationsTabPageTheBay;
        private System.Windows.Forms.Label SaveLocationsLabelFinal;
        private System.Windows.Forms.TextBox SaveLocationsFinalValue;
        private System.Windows.Forms.Button SaveLocationsFinalFilePicker;
        private System.Windows.Forms.ErrorProvider LifecycleSaveLocationsErrorProvider;
    }
}