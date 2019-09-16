namespace LifeCycleWorkflowTool
{
    partial class LifecycleTemplateLocationForm
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
            this.TemplateLocationsTabControl = new System.Windows.Forms.TabControl();
            this.TemplateLocationsTabPageTheBay = new System.Windows.Forms.TabPage();
            this.TheBayTemplateLocationsLabelFinal = new System.Windows.Forms.Label();
            this.TheBayTemplateLocationsFinalValue = new System.Windows.Forms.TextBox();
            this.TheBayTemplateLocationsFinalFilePicker = new System.Windows.Forms.Button();
            this.TheBayTemplateLocationsLabelWip = new System.Windows.Forms.Label();
            this.TheBayTemplateLocationsWipValue = new System.Windows.Forms.TextBox();
            this.TheBayTemplateLocationsWipFilePicker = new System.Windows.Forms.Button();
            this.TemplateLocationsButtonSaveSettings = new System.Windows.Forms.Button();
            this.TemplateLocationsErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TemplateLocationsTabControl.SuspendLayout();
            this.TemplateLocationsTabPageTheBay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateLocationsErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TemplateLocationsTabControl
            // 
            this.TemplateLocationsTabControl.Controls.Add(this.TemplateLocationsTabPageTheBay);
            this.TemplateLocationsTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TemplateLocationsTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemplateLocationsTabControl.Location = new System.Drawing.Point(0, 0);
            this.TemplateLocationsTabControl.Name = "TemplateLocationsTabControl";
            this.TemplateLocationsTabControl.SelectedIndex = 0;
            this.TemplateLocationsTabControl.Size = new System.Drawing.Size(518, 204);
            this.TemplateLocationsTabControl.TabIndex = 8;
            // 
            // TemplateLocationsTabPageTheBay
            // 
            this.TemplateLocationsTabPageTheBay.BackColor = System.Drawing.Color.Gainsboro;
            this.TemplateLocationsTabPageTheBay.Controls.Add(this.TheBayTemplateLocationsLabelFinal);
            this.TemplateLocationsTabPageTheBay.Controls.Add(this.TheBayTemplateLocationsFinalValue);
            this.TemplateLocationsTabPageTheBay.Controls.Add(this.TheBayTemplateLocationsFinalFilePicker);
            this.TemplateLocationsTabPageTheBay.Controls.Add(this.TheBayTemplateLocationsLabelWip);
            this.TemplateLocationsTabPageTheBay.Controls.Add(this.TheBayTemplateLocationsWipValue);
            this.TemplateLocationsTabPageTheBay.Controls.Add(this.TheBayTemplateLocationsWipFilePicker);
            this.TemplateLocationsTabPageTheBay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemplateLocationsTabPageTheBay.Location = new System.Drawing.Point(4, 29);
            this.TemplateLocationsTabPageTheBay.Name = "TemplateLocationsTabPageTheBay";
            this.TemplateLocationsTabPageTheBay.Padding = new System.Windows.Forms.Padding(3);
            this.TemplateLocationsTabPageTheBay.Size = new System.Drawing.Size(510, 171);
            this.TemplateLocationsTabPageTheBay.TabIndex = 1;
            this.TemplateLocationsTabPageTheBay.Text = "TheBay";
            // 
            // TheBayTemplateLocationsLabelFinal
            // 
            this.TheBayTemplateLocationsLabelFinal.AutoSize = true;
            this.TheBayTemplateLocationsLabelFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBayTemplateLocationsLabelFinal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TheBayTemplateLocationsLabelFinal.Location = new System.Drawing.Point(3, 81);
            this.TheBayTemplateLocationsLabelFinal.Name = "TheBayTemplateLocationsLabelFinal";
            this.TheBayTemplateLocationsLabelFinal.Size = new System.Drawing.Size(172, 24);
            this.TheBayTemplateLocationsLabelFinal.TabIndex = 3;
            this.TheBayTemplateLocationsLabelFinal.Text = "Final File Save To: ";
            // 
            // TheBayTemplateLocationsFinalValue
            // 
            this.TheBayTemplateLocationsFinalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBayTemplateLocationsFinalValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TheBayTemplateLocationsFinalValue.Location = new System.Drawing.Point(8, 108);
            this.TheBayTemplateLocationsFinalValue.Name = "TheBayTemplateLocationsFinalValue";
            this.TheBayTemplateLocationsFinalValue.Size = new System.Drawing.Size(429, 26);
            this.TheBayTemplateLocationsFinalValue.TabIndex = 4;
            // 
            // TheBayTemplateLocationsFinalFilePicker
            // 
            this.TheBayTemplateLocationsFinalFilePicker.Location = new System.Drawing.Point(459, 108);
            this.TheBayTemplateLocationsFinalFilePicker.Name = "TheBayTemplateLocationsFinalFilePicker";
            this.TheBayTemplateLocationsFinalFilePicker.Size = new System.Drawing.Size(35, 27);
            this.TheBayTemplateLocationsFinalFilePicker.TabIndex = 5;
            this.TheBayTemplateLocationsFinalFilePicker.Text = "...";
            this.TheBayTemplateLocationsFinalFilePicker.UseVisualStyleBackColor = true;
            this.TheBayTemplateLocationsFinalFilePicker.Click += new System.EventHandler(this.TemplateLocationsFinalFilePicker_Click);
            // 
            // TheBayTemplateLocationsLabelWip
            // 
            this.TheBayTemplateLocationsLabelWip.AutoSize = true;
            this.TheBayTemplateLocationsLabelWip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBayTemplateLocationsLabelWip.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TheBayTemplateLocationsLabelWip.Location = new System.Drawing.Point(3, 14);
            this.TheBayTemplateLocationsLabelWip.Name = "TheBayTemplateLocationsLabelWip";
            this.TheBayTemplateLocationsLabelWip.Size = new System.Drawing.Size(275, 24);
            this.TheBayTemplateLocationsLabelWip.TabIndex = 0;
            this.TheBayTemplateLocationsLabelWip.Text = "Work in Progress File Save To: ";
            // 
            // TheBayTemplateLocationsWipValue
            // 
            this.TheBayTemplateLocationsWipValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheBayTemplateLocationsWipValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TheBayTemplateLocationsWipValue.Location = new System.Drawing.Point(8, 41);
            this.TheBayTemplateLocationsWipValue.Name = "TheBayTemplateLocationsWipValue";
            this.TheBayTemplateLocationsWipValue.Size = new System.Drawing.Size(429, 26);
            this.TheBayTemplateLocationsWipValue.TabIndex = 1;
            // 
            // TheBayTemplateLocationsWipFilePicker
            // 
            this.TheBayTemplateLocationsWipFilePicker.Location = new System.Drawing.Point(459, 41);
            this.TheBayTemplateLocationsWipFilePicker.Name = "TheBayTemplateLocationsWipFilePicker";
            this.TheBayTemplateLocationsWipFilePicker.Size = new System.Drawing.Size(35, 27);
            this.TheBayTemplateLocationsWipFilePicker.TabIndex = 2;
            this.TheBayTemplateLocationsWipFilePicker.Text = "...";
            this.TheBayTemplateLocationsWipFilePicker.UseVisualStyleBackColor = true;
            this.TheBayTemplateLocationsWipFilePicker.Click += new System.EventHandler(this.TemplateLocationsWipFilePicker_Click);
            // 
            // TemplateLocationsButtonSaveSettings
            // 
            this.TemplateLocationsButtonSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemplateLocationsButtonSaveSettings.ForeColor = System.Drawing.Color.MediumBlue;
            this.TemplateLocationsButtonSaveSettings.Location = new System.Drawing.Point(4, 210);
            this.TemplateLocationsButtonSaveSettings.Name = "TemplateLocationsButtonSaveSettings";
            this.TemplateLocationsButtonSaveSettings.Size = new System.Drawing.Size(126, 34);
            this.TemplateLocationsButtonSaveSettings.TabIndex = 6;
            this.TemplateLocationsButtonSaveSettings.Text = "Save";
            this.TemplateLocationsButtonSaveSettings.UseVisualStyleBackColor = true;
            this.TemplateLocationsButtonSaveSettings.Click += new System.EventHandler(this.TemplateLocationsButtonSaveSettings_Click);
            // 
            // TemplateLocationsErrorProvider
            // 
            this.TemplateLocationsErrorProvider.BlinkRate = 0;
            this.TemplateLocationsErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.TemplateLocationsErrorProvider.ContainerControl = this;
            // 
            // LifecycleTemplateLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 257);
            this.Controls.Add(this.TemplateLocationsTabControl);
            this.Controls.Add(this.TemplateLocationsButtonSaveSettings);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LifecycleTemplateLocationForm";
            this.Text = "Template Locations";
            this.TemplateLocationsTabControl.ResumeLayout(false);
            this.TemplateLocationsTabPageTheBay.ResumeLayout(false);
            this.TemplateLocationsTabPageTheBay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateLocationsErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TemplateLocationsTabControl;
        private System.Windows.Forms.TabPage TemplateLocationsTabPageTheBay;
        private System.Windows.Forms.Label TheBayTemplateLocationsLabelFinal;
        private System.Windows.Forms.TextBox TheBayTemplateLocationsFinalValue;
        private System.Windows.Forms.Button TheBayTemplateLocationsFinalFilePicker;
        private System.Windows.Forms.Label TheBayTemplateLocationsLabelWip;
        private System.Windows.Forms.TextBox TheBayTemplateLocationsWipValue;
        private System.Windows.Forms.Button TheBayTemplateLocationsWipFilePicker;
        private System.Windows.Forms.Button TemplateLocationsButtonSaveSettings;
        private System.Windows.Forms.ErrorProvider TemplateLocationsErrorProvider;
    }
}