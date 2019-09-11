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
            this.TheBaySaveLocationsLabelWip = new System.Windows.Forms.Label();
            this.TheBaySaveLocationsWipValue = new System.Windows.Forms.TextBox();
            this.TheBaySaveLocationsWipFilePicker = new System.Windows.Forms.Button();
            this.SaveLocationsButtonSaveSettings = new System.Windows.Forms.Button();
            this.SaveLocationsButtonRestoreDefault = new System.Windows.Forms.Button();
            this.SaveLocationsTabControl = new System.Windows.Forms.TabControl();
            this.SaveLocationsTabPageTheBay = new System.Windows.Forms.TabPage();
            this.TheBaySaveLocationsLabelFinal = new System.Windows.Forms.Label();
            this.TheBaySaveLocationsFinalValue = new System.Windows.Forms.TextBox();
            this.TheBaySaveLocationsFinalFilePicker = new System.Windows.Forms.Button();
            this.LifecycleSaveLocationsErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SaveLocationsTabControl.SuspendLayout();
            this.SaveLocationsTabPageTheBay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LifecycleSaveLocationsErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TheBaySaveLocationsLabelWip
            // 
            this.TheBaySaveLocationsLabelWip.AutoSize = true;
            this.TheBaySaveLocationsLabelWip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBaySaveLocationsLabelWip.Location = new System.Drawing.Point(4, 17);
            this.TheBaySaveLocationsLabelWip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TheBaySaveLocationsLabelWip.Name = "TheBaySaveLocationsLabelWip";
            this.TheBaySaveLocationsLabelWip.Size = new System.Drawing.Size(353, 29);
            this.TheBaySaveLocationsLabelWip.TabIndex = 0;
            this.TheBaySaveLocationsLabelWip.Text = "Work in Progress File Save To: ";
            // 
            // TheBaySaveLocationsWipValue
            // 
            this.TheBaySaveLocationsWipValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBaySaveLocationsWipValue.Location = new System.Drawing.Point(11, 50);
            this.TheBaySaveLocationsWipValue.Margin = new System.Windows.Forms.Padding(4);
            this.TheBaySaveLocationsWipValue.Name = "TheBaySaveLocationsWipValue";
            this.TheBaySaveLocationsWipValue.Size = new System.Drawing.Size(571, 30);
            this.TheBaySaveLocationsWipValue.TabIndex = 1;
            // 
            // TheBaySaveLocationsWipFilePicker
            // 
            this.TheBaySaveLocationsWipFilePicker.Location = new System.Drawing.Point(612, 50);
            this.TheBaySaveLocationsWipFilePicker.Margin = new System.Windows.Forms.Padding(4);
            this.TheBaySaveLocationsWipFilePicker.Name = "TheBaySaveLocationsWipFilePicker";
            this.TheBaySaveLocationsWipFilePicker.Size = new System.Drawing.Size(47, 33);
            this.TheBaySaveLocationsWipFilePicker.TabIndex = 2;
            this.TheBaySaveLocationsWipFilePicker.Text = "...";
            this.TheBaySaveLocationsWipFilePicker.UseVisualStyleBackColor = true;
            this.TheBaySaveLocationsWipFilePicker.Click += new System.EventHandler(this.SaveLocationsWipFilePicker_Click);
            // 
            // SaveLocationsButtonSaveSettings
            // 
            this.SaveLocationsButtonSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsButtonSaveSettings.ForeColor = System.Drawing.Color.MediumBlue;
            this.SaveLocationsButtonSaveSettings.Location = new System.Drawing.Point(4, 306);
            this.SaveLocationsButtonSaveSettings.Margin = new System.Windows.Forms.Padding(4);
            this.SaveLocationsButtonSaveSettings.Name = "SaveLocationsButtonSaveSettings";
            this.SaveLocationsButtonSaveSettings.Size = new System.Drawing.Size(168, 42);
            this.SaveLocationsButtonSaveSettings.TabIndex = 3;
            this.SaveLocationsButtonSaveSettings.Text = "Save";
            this.SaveLocationsButtonSaveSettings.UseVisualStyleBackColor = true;
            this.SaveLocationsButtonSaveSettings.Click += new System.EventHandler(this.SaveLocationsButtonSave_Click);
            // 
            // SaveLocationsButtonRestoreDefault
            // 
            this.SaveLocationsButtonRestoreDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsButtonRestoreDefault.ForeColor = System.Drawing.Color.MediumBlue;
            this.SaveLocationsButtonRestoreDefault.Location = new System.Drawing.Point(180, 306);
            this.SaveLocationsButtonRestoreDefault.Margin = new System.Windows.Forms.Padding(4);
            this.SaveLocationsButtonRestoreDefault.Name = "SaveLocationsButtonRestoreDefault";
            this.SaveLocationsButtonRestoreDefault.Size = new System.Drawing.Size(168, 42);
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
            this.SaveLocationsTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.SaveLocationsTabControl.Name = "SaveLocationsTabControl";
            this.SaveLocationsTabControl.SelectedIndex = 0;
            this.SaveLocationsTabControl.Size = new System.Drawing.Size(692, 302);
            this.SaveLocationsTabControl.TabIndex = 5;
            // 
            // SaveLocationsTabPageTheBay
            // 
            this.SaveLocationsTabPageTheBay.BackColor = System.Drawing.Color.Gainsboro;
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBaySaveLocationsLabelFinal);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBaySaveLocationsFinalValue);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBaySaveLocationsFinalFilePicker);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBaySaveLocationsLabelWip);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBaySaveLocationsWipValue);
            this.SaveLocationsTabPageTheBay.Controls.Add(this.TheBaySaveLocationsWipFilePicker);
            this.SaveLocationsTabPageTheBay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsTabPageTheBay.Location = new System.Drawing.Point(4, 34);
            this.SaveLocationsTabPageTheBay.Margin = new System.Windows.Forms.Padding(4);
            this.SaveLocationsTabPageTheBay.Name = "SaveLocationsTabPageTheBay";
            this.SaveLocationsTabPageTheBay.Padding = new System.Windows.Forms.Padding(4);
            this.SaveLocationsTabPageTheBay.Size = new System.Drawing.Size(684, 264);
            this.SaveLocationsTabPageTheBay.TabIndex = 1;
            this.SaveLocationsTabPageTheBay.Text = "TheBay";
            // 
            // TheBaySaveLocationsLabelFinal
            // 
            this.TheBaySaveLocationsLabelFinal.AutoSize = true;
            this.TheBaySaveLocationsLabelFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBaySaveLocationsLabelFinal.Location = new System.Drawing.Point(4, 100);
            this.TheBaySaveLocationsLabelFinal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TheBaySaveLocationsLabelFinal.Name = "TheBaySaveLocationsLabelFinal";
            this.TheBaySaveLocationsLabelFinal.Size = new System.Drawing.Size(221, 29);
            this.TheBaySaveLocationsLabelFinal.TabIndex = 3;
            this.TheBaySaveLocationsLabelFinal.Text = "Final File Save To: ";
            // 
            // TheBaySaveLocationsFinalValue
            // 
            this.TheBaySaveLocationsFinalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBaySaveLocationsFinalValue.Location = new System.Drawing.Point(11, 133);
            this.TheBaySaveLocationsFinalValue.Margin = new System.Windows.Forms.Padding(4);
            this.TheBaySaveLocationsFinalValue.Name = "TheBaySaveLocationsFinalValue";
            this.TheBaySaveLocationsFinalValue.Size = new System.Drawing.Size(571, 30);
            this.TheBaySaveLocationsFinalValue.TabIndex = 4;
            // 
            // TheBaySaveLocationsFinalFilePicker
            // 
            this.TheBaySaveLocationsFinalFilePicker.Location = new System.Drawing.Point(612, 133);
            this.TheBaySaveLocationsFinalFilePicker.Margin = new System.Windows.Forms.Padding(4);
            this.TheBaySaveLocationsFinalFilePicker.Name = "TheBaySaveLocationsFinalFilePicker";
            this.TheBaySaveLocationsFinalFilePicker.Size = new System.Drawing.Size(47, 33);
            this.TheBaySaveLocationsFinalFilePicker.TabIndex = 5;
            this.TheBaySaveLocationsFinalFilePicker.Text = "...";
            this.TheBaySaveLocationsFinalFilePicker.UseVisualStyleBackColor = true;
            this.TheBaySaveLocationsFinalFilePicker.Click += new System.EventHandler(this.SaveLocationFinalFilePicker_Click);
            // 
            // LifecycleSaveLocationsErrorProvider
            // 
            this.LifecycleSaveLocationsErrorProvider.BlinkRate = 0;
            this.LifecycleSaveLocationsErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.LifecycleSaveLocationsErrorProvider.ContainerControl = this;
            // 
            // LifecycleSaveLocationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 359);
            this.Controls.Add(this.SaveLocationsTabControl);
            this.Controls.Add(this.SaveLocationsButtonRestoreDefault);
            this.Controls.Add(this.SaveLocationsButtonSaveSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LifecycleSaveLocationsForm";
            this.Text = "Save Locations";
            this.SaveLocationsTabControl.ResumeLayout(false);
            this.SaveLocationsTabPageTheBay.ResumeLayout(false);
            this.SaveLocationsTabPageTheBay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LifecycleSaveLocationsErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TheBaySaveLocationsLabelWip;
        private System.Windows.Forms.TextBox TheBaySaveLocationsWipValue;
        private System.Windows.Forms.Button TheBaySaveLocationsWipFilePicker;
        private System.Windows.Forms.Button SaveLocationsButtonSaveSettings;
        private System.Windows.Forms.Button SaveLocationsButtonRestoreDefault;
        private System.Windows.Forms.TabControl SaveLocationsTabControl;
        private System.Windows.Forms.TabPage SaveLocationsTabPageTheBay;
        private System.Windows.Forms.Label TheBaySaveLocationsLabelFinal;
        private System.Windows.Forms.TextBox TheBaySaveLocationsFinalValue;
        private System.Windows.Forms.Button TheBaySaveLocationsFinalFilePicker;
        private System.Windows.Forms.ErrorProvider LifecycleSaveLocationsErrorProvider;
    }
}