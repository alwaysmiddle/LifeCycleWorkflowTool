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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LifecycleSaveLocationsForm));
            this.SaveLocationsLabelWip = new System.Windows.Forms.Label();
            this.SaveLocationsWipValue = new System.Windows.Forms.TextBox();
            this.SaveLocationsWipFilePicker = new System.Windows.Forms.Button();
            this.SaveLocationsButtonSaveSettings = new System.Windows.Forms.Button();
            this.SaveLocationsFolderPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveLocationsButtonRestoreDefault = new System.Windows.Forms.Button();
            this.SaveLocationsTabControl = new System.Windows.Forms.TabControl();
            this.SaveLocationsTabPageTheBay = new System.Windows.Forms.TabPage();
            this.SaveLocationsLabelFinal = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveLocationsTabControl.SuspendLayout();
            this.SaveLocationsTabPageTheBay.SuspendLayout();
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
            this.SaveLocationsWipValue.Size = new System.Drawing.Size(515, 26);
            this.SaveLocationsWipValue.TabIndex = 1;
            // 
            // SaveLocationsWipFilePicker
            // 
            this.SaveLocationsWipFilePicker.Location = new System.Drawing.Point(529, 40);
            this.SaveLocationsWipFilePicker.Name = "SaveLocationsWipFilePicker";
            this.SaveLocationsWipFilePicker.Size = new System.Drawing.Size(35, 27);
            this.SaveLocationsWipFilePicker.TabIndex = 2;
            this.SaveLocationsWipFilePicker.Text = "...";
            this.SaveLocationsWipFilePicker.UseVisualStyleBackColor = true;
            this.SaveLocationsWipFilePicker.Click += new System.EventHandler(this.SaveLocationsButtonTheBayFilePicker_Click);
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
            // 
            // SaveLocationsTabControl
            // 
            this.SaveLocationsTabControl.Controls.Add(this.SaveLocationsTabPageTheBay);
            this.SaveLocationsTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.SaveLocationsTabControl.Location = new System.Drawing.Point(0, 0);
            this.SaveLocationsTabControl.Name = "SaveLocationsTabControl";
            this.SaveLocationsTabControl.SelectedIndex = 0;
            this.SaveLocationsTabControl.Size = new System.Drawing.Size(581, 245);
            this.SaveLocationsTabControl.TabIndex = 5;
            // 
            // SaveLocationsTabPageTheBay
            // 
            this.SaveLocationsTabPageTheBay.BackColor = System.Drawing.Color.Gainsboro;
            this.SaveLocationsTabPageTheBay.Controls.Add(this.SaveLocationsLabelFinal);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.textBox1);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.button1);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.SaveLocationsLabelWip);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.SaveLocationsWipValue);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.SaveLocationsWipFilePicker);
            this.SaveLocationsTabPageTheBay.Location = new System.Drawing.Point(4, 22);
            this.SaveLocationsTabPageTheBay.Name = "SaveLocationsTabPageTheBay";
            this.SaveLocationsTabPageTheBay.Padding = new System.Windows.Forms.Padding(3);
            this.SaveLocationsTabPageTheBay.Size = new System.Drawing.Size(573, 219);
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(8, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(515, 26);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(529, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LifecycleSaveLocationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 298);
            this.Controls.Add(this.SaveLocationsTabControl);
            this.Controls.Add(this.SaveLocationsButtonRestoreDefault);
            this.Controls.Add(this.SaveLocationsButtonSaveSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LifecycleSaveLocationsForm";
            this.Text = "Save Locations";
            this.SaveLocationsTabControl.ResumeLayout(false);
            this.SaveLocationsTabPageTheBay.ResumeLayout(false);
            this.SaveLocationsTabPageTheBay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label SaveLocationsLabelWip;
        private System.Windows.Forms.TextBox SaveLocationsWipValue;
        private System.Windows.Forms.Button SaveLocationsWipFilePicker;
        private System.Windows.Forms.Button SaveLocationsButtonSaveSettings;
        private System.Windows.Forms.FolderBrowserDialog SaveLocationsFolderPicker;
        private System.Windows.Forms.Button SaveLocationsButtonRestoreDefault;
        private System.Windows.Forms.TabControl SaveLocationsTabControl;
        private System.Windows.Forms.TabPage SaveLocationsTabPageTheBay;
        private System.Windows.Forms.Label SaveLocationsLabelFinal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}