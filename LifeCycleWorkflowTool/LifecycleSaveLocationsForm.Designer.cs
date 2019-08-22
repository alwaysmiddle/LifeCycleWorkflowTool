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
            this.SaveLocationsLabelTheBay = new System.Windows.Forms.Label();
            this.SaveLocationsTheBayValue = new System.Windows.Forms.TextBox();
            this.SaveLocationsButtonTheBayFilePicker = new System.Windows.Forms.Button();
            this.SaveLocationsButtonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveLocationsLabelTheBay
            // 
            this.SaveLocationsLabelTheBay.AutoSize = true;
            this.SaveLocationsLabelTheBay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsLabelTheBay.Location = new System.Drawing.Point(12, 9);
            this.SaveLocationsLabelTheBay.Name = "SaveLocationsLabelTheBay";
            this.SaveLocationsLabelTheBay.Size = new System.Drawing.Size(92, 25);
            this.SaveLocationsLabelTheBay.TabIndex = 0;
            this.SaveLocationsLabelTheBay.Text = "TheBay:";
            // 
            // SaveLocationsTheBayValue
            // 
            this.SaveLocationsTheBayValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsTheBayValue.Location = new System.Drawing.Point(110, 9);
            this.SaveLocationsTheBayValue.Name = "SaveLocationsTheBayValue";
            this.SaveLocationsTheBayValue.Size = new System.Drawing.Size(332, 29);
            this.SaveLocationsTheBayValue.TabIndex = 1;
            // 
            // SaveLocationsButtonTheBayFilePicker
            // 
            this.SaveLocationsButtonTheBayFilePicker.Location = new System.Drawing.Point(448, 9);
            this.SaveLocationsButtonTheBayFilePicker.Name = "SaveLocationsButtonTheBayFilePicker";
            this.SaveLocationsButtonTheBayFilePicker.Size = new System.Drawing.Size(39, 29);
            this.SaveLocationsButtonTheBayFilePicker.TabIndex = 2;
            this.SaveLocationsButtonTheBayFilePicker.Text = "...";
            this.SaveLocationsButtonTheBayFilePicker.UseVisualStyleBackColor = true;
            // 
            // SaveLocationsButtonSave
            // 
            this.SaveLocationsButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationsButtonSave.ForeColor = System.Drawing.Color.MediumBlue;
            this.SaveLocationsButtonSave.Location = new System.Drawing.Point(17, 56);
            this.SaveLocationsButtonSave.Name = "SaveLocationsButtonSave";
            this.SaveLocationsButtonSave.Size = new System.Drawing.Size(126, 34);
            this.SaveLocationsButtonSave.TabIndex = 3;
            this.SaveLocationsButtonSave.Text = "Save";
            this.SaveLocationsButtonSave.UseVisualStyleBackColor = true;
            // 
            // LifecycleSaveLocationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 110);
            this.Controls.Add(this.SaveLocationsButtonSave);
            this.Controls.Add(this.SaveLocationsButtonTheBayFilePicker);
            this.Controls.Add(this.SaveLocationsTheBayValue);
            this.Controls.Add(this.SaveLocationsLabelTheBay);
            this.Name = "LifecycleSaveLocationsForm";
            this.Text = "Save Locations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SaveLocationsLabelTheBay;
        private System.Windows.Forms.TextBox SaveLocationsTheBayValue;
        private System.Windows.Forms.Button SaveLocationsButtonTheBayFilePicker;
        private System.Windows.Forms.Button SaveLocationsButtonSave;
    }
}