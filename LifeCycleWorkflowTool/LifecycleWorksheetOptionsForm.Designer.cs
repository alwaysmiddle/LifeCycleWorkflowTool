﻿using LifeCycleWorkflowLibrary;

namespace LifeCycleWorkflowTool
{
    partial class LifecycleWorksheetOptionsForm
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
            this.WorksheetOptionsTabControl = new System.Windows.Forms.TabControl();
            this.WorksheetOptionsTabPageDetailsProduct = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DetailsProductColHeaderRowLabel = new System.Windows.Forms.Label();
            this.DetailsProductColHeaderRowValue = new System.Windows.Forms.TextBox();
            this.DetailsProductFormulaRowLabel = new System.Windows.Forms.Label();
            this.DetailsProductFormulaRowValue = new System.Windows.Forms.TextBox();
            this.DetailsProductHeaderRowValue = new System.Windows.Forms.TextBox();
            this.DetailsProductHeaderRowLabel = new System.Windows.Forms.Label();
            this.WorksheetOptionsTabPageInactiveUpc = new System.Windows.Forms.TabPage();
            this.InactiveUpcColHeaderRowLabel = new System.Windows.Forms.Label();
            this.InactiveUpcColHeaderRowValue = new System.Windows.Forms.TextBox();
            this.InactiveUpcFormulaRowLabel = new System.Windows.Forms.Label();
            this.InactiveUpcFormulaRowValue = new System.Windows.Forms.TextBox();
            this.InactiveUpcHeaderRowValue = new System.Windows.Forms.TextBox();
            this.InactiveUpcHeaderRowLabel = new System.Windows.Forms.Label();
            this.WorksheetOptionsTabPageNosCombined = new System.Windows.Forms.TabPage();
            this.NosCombinedColHeaderRowLabel = new System.Windows.Forms.Label();
            this.NosCombinedColHeaderRowValue = new System.Windows.Forms.TextBox();
            this.NosCombinedFormulaRowLabel = new System.Windows.Forms.Label();
            this.NosCombinedFormulaRowValue = new System.Windows.Forms.TextBox();
            this.NosCombinedHeaderRowValue = new System.Windows.Forms.TextBox();
            this.NosCombinedHeaderRowLabel = new System.Windows.Forms.Label();
            this.WorksheetOptionsTabControl.SuspendLayout();
            this.WorksheetOptionsTabPageDetailsProduct.SuspendLayout();
            this.WorksheetOptionsTabPageInactiveUpc.SuspendLayout();
            this.WorksheetOptionsTabPageNosCombined.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorksheetOptionsTabControl
            // 
            this.WorksheetOptionsTabControl.Controls.Add(this.WorksheetOptionsTabPageDetailsProduct);
            this.WorksheetOptionsTabControl.Controls.Add(this.WorksheetOptionsTabPageInactiveUpc);
            this.WorksheetOptionsTabControl.Controls.Add(this.WorksheetOptionsTabPageNosCombined);
            this.WorksheetOptionsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorksheetOptionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.WorksheetOptionsTabControl.Name = "WorksheetOptionsTabControl";
            this.WorksheetOptionsTabControl.SelectedIndex = 0;
            this.WorksheetOptionsTabControl.Size = new System.Drawing.Size(362, 236);
            this.WorksheetOptionsTabControl.TabIndex = 0;
            // 
            // WorksheetOptionsTabPageDetailsProduct
            // 
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.button2);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.button1);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductColHeaderRowLabel);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductColHeaderRowValue);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductFormulaRowLabel);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductFormulaRowValue);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductHeaderRowValue);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductHeaderRowLabel);
            this.WorksheetOptionsTabPageDetailsProduct.Location = new System.Drawing.Point(4, 22);
            this.WorksheetOptionsTabPageDetailsProduct.Name = "WorksheetOptionsTabPageDetailsProduct";
            this.WorksheetOptionsTabPageDetailsProduct.Padding = new System.Windows.Forms.Padding(3);
            this.WorksheetOptionsTabPageDetailsProduct.Size = new System.Drawing.Size(354, 210);
            this.WorksheetOptionsTabPageDetailsProduct.TabIndex = 0;
            this.WorksheetOptionsTabPageDetailsProduct.Text = "Details_Product";
            this.WorksheetOptionsTabPageDetailsProduct.UseVisualStyleBackColor = true;
            this.WorksheetOptionsTabPageDetailsProduct.Click += new System.EventHandler(this.WorksheetOptionsTabPageDetailsProduct_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 150);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 39);
            this.button2.TabIndex = 7;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 150);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DetailsProductColHeaderRowLabel
            // 
            this.DetailsProductColHeaderRowLabel.AutoSize = true;
            this.DetailsProductColHeaderRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsProductColHeaderRowLabel.Location = new System.Drawing.Point(7, 79);
            this.DetailsProductColHeaderRowLabel.Name = "DetailsProductColHeaderRowLabel";
            this.DetailsProductColHeaderRowLabel.Size = new System.Drawing.Size(167, 20);
            this.DetailsProductColHeaderRowLabel.TabIndex = 5;
            this.DetailsProductColHeaderRowLabel.Text = "Column Heading Row:";
            // 
            // DetailsProductColHeaderRowValue
            // 
            this.DetailsProductColHeaderRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsProductColHeaderRowValue.Location = new System.Drawing.Point(207, 79);
            this.DetailsProductColHeaderRowValue.Name = "DetailsProductColHeaderRowValue";
            this.DetailsProductColHeaderRowValue.Size = new System.Drawing.Size(115, 26);
            this.DetailsProductColHeaderRowValue.TabIndex = 4;
            // 
            // DetailsProductFormulaRowLabel
            // 
            this.DetailsProductFormulaRowLabel.AutoSize = true;
            this.DetailsProductFormulaRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsProductFormulaRowLabel.Location = new System.Drawing.Point(7, 45);
            this.DetailsProductFormulaRowLabel.Name = "DetailsProductFormulaRowLabel";
            this.DetailsProductFormulaRowLabel.Size = new System.Drawing.Size(116, 20);
            this.DetailsProductFormulaRowLabel.TabIndex = 3;
            this.DetailsProductFormulaRowLabel.Text = "Formulae Row:";
            // 
            // DetailsProductFormulaRowValue
            // 
            this.DetailsProductFormulaRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsProductFormulaRowValue.Location = new System.Drawing.Point(207, 45);
            this.DetailsProductFormulaRowValue.Name = "DetailsProductFormulaRowValue";
            this.DetailsProductFormulaRowValue.Size = new System.Drawing.Size(115, 26);
            this.DetailsProductFormulaRowValue.TabIndex = 2;
            // 
            // DetailsProductHeaderRowValue
            // 
            this.DetailsProductHeaderRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsProductHeaderRowValue.Location = new System.Drawing.Point(207, 11);
            this.DetailsProductHeaderRowValue.Name = "DetailsProductHeaderRowValue";
            this.DetailsProductHeaderRowValue.Size = new System.Drawing.Size(115, 26);
            this.DetailsProductHeaderRowValue.TabIndex = 1;
            // 
            // DetailsProductHeaderRowLabel
            // 
            this.DetailsProductHeaderRowLabel.AutoSize = true;
            this.DetailsProductHeaderRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsProductHeaderRowLabel.Location = new System.Drawing.Point(7, 11);
            this.DetailsProductHeaderRowLabel.Name = "DetailsProductHeaderRowLabel";
            this.DetailsProductHeaderRowLabel.Size = new System.Drawing.Size(102, 20);
            this.DetailsProductHeaderRowLabel.TabIndex = 0;
            this.DetailsProductHeaderRowLabel.Text = "Header Row:";
            // 
            // WorksheetOptionsTabPageInactiveUpc
            // 
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcColHeaderRowLabel);
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcColHeaderRowValue);
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcFormulaRowLabel);
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcFormulaRowValue);
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcHeaderRowValue);
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcHeaderRowLabel);
            this.WorksheetOptionsTabPageInactiveUpc.Location = new System.Drawing.Point(4, 22);
            this.WorksheetOptionsTabPageInactiveUpc.Name = "WorksheetOptionsTabPageInactiveUpc";
            this.WorksheetOptionsTabPageInactiveUpc.Padding = new System.Windows.Forms.Padding(3);
            this.WorksheetOptionsTabPageInactiveUpc.Size = new System.Drawing.Size(354, 210);
            this.WorksheetOptionsTabPageInactiveUpc.TabIndex = 1;
            this.WorksheetOptionsTabPageInactiveUpc.Text = "Inactive_UPC";
            this.WorksheetOptionsTabPageInactiveUpc.UseVisualStyleBackColor = true;
            // 
            // InactiveUpcColHeaderRowLabel
            // 
            this.InactiveUpcColHeaderRowLabel.AutoSize = true;
            this.InactiveUpcColHeaderRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcColHeaderRowLabel.Location = new System.Drawing.Point(7, 79);
            this.InactiveUpcColHeaderRowLabel.Name = "InactiveUpcColHeaderRowLabel";
            this.InactiveUpcColHeaderRowLabel.Size = new System.Drawing.Size(167, 20);
            this.InactiveUpcColHeaderRowLabel.TabIndex = 11;
            this.InactiveUpcColHeaderRowLabel.Text = "Column Heading Row:";
            // 
            // InactiveUpcColHeaderRowValue
            // 
            this.InactiveUpcColHeaderRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcColHeaderRowValue.Location = new System.Drawing.Point(207, 79);
            this.InactiveUpcColHeaderRowValue.Name = "InactiveUpcColHeaderRowValue";
            this.InactiveUpcColHeaderRowValue.Size = new System.Drawing.Size(115, 26);
            this.InactiveUpcColHeaderRowValue.TabIndex = 10;
            // 
            // InactiveUpcFormulaRowLabel
            // 
            this.InactiveUpcFormulaRowLabel.AutoSize = true;
            this.InactiveUpcFormulaRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcFormulaRowLabel.Location = new System.Drawing.Point(7, 45);
            this.InactiveUpcFormulaRowLabel.Name = "InactiveUpcFormulaRowLabel";
            this.InactiveUpcFormulaRowLabel.Size = new System.Drawing.Size(116, 20);
            this.InactiveUpcFormulaRowLabel.TabIndex = 9;
            this.InactiveUpcFormulaRowLabel.Text = "Formulae Row:";
            // 
            // InactiveUpcFormulaRowValue
            // 
            this.InactiveUpcFormulaRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcFormulaRowValue.Location = new System.Drawing.Point(207, 45);
            this.InactiveUpcFormulaRowValue.Name = "InactiveUpcFormulaRowValue";
            this.InactiveUpcFormulaRowValue.Size = new System.Drawing.Size(115, 26);
            this.InactiveUpcFormulaRowValue.TabIndex = 8;
            // 
            // InactiveUpcHeaderRowValue
            // 
            this.InactiveUpcHeaderRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcHeaderRowValue.Location = new System.Drawing.Point(207, 11);
            this.InactiveUpcHeaderRowValue.Name = "InactiveUpcHeaderRowValue";
            this.InactiveUpcHeaderRowValue.Size = new System.Drawing.Size(115, 26);
            this.InactiveUpcHeaderRowValue.TabIndex = 7;
            // 
            // InactiveUpcHeaderRowLabel
            // 
            this.InactiveUpcHeaderRowLabel.AutoSize = true;
            this.InactiveUpcHeaderRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcHeaderRowLabel.Location = new System.Drawing.Point(7, 11);
            this.InactiveUpcHeaderRowLabel.Name = "InactiveUpcHeaderRowLabel";
            this.InactiveUpcHeaderRowLabel.Size = new System.Drawing.Size(102, 20);
            this.InactiveUpcHeaderRowLabel.TabIndex = 6;
            this.InactiveUpcHeaderRowLabel.Text = "Header Row:";
            // 
            // WorksheetOptionsTabPageNosCombined
            // 
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedColHeaderRowLabel);
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedColHeaderRowValue);
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedFormulaRowLabel);
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedFormulaRowValue);
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedHeaderRowValue);
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedHeaderRowLabel);
            this.WorksheetOptionsTabPageNosCombined.Location = new System.Drawing.Point(4, 22);
            this.WorksheetOptionsTabPageNosCombined.Margin = new System.Windows.Forms.Padding(2);
            this.WorksheetOptionsTabPageNosCombined.Name = "WorksheetOptionsTabPageNosCombined";
            this.WorksheetOptionsTabPageNosCombined.Padding = new System.Windows.Forms.Padding(2);
            this.WorksheetOptionsTabPageNosCombined.Size = new System.Drawing.Size(354, 210);
            this.WorksheetOptionsTabPageNosCombined.TabIndex = 2;
            this.WorksheetOptionsTabPageNosCombined.Text = "Nos_Color_Combined";
            this.WorksheetOptionsTabPageNosCombined.UseVisualStyleBackColor = true;
            // 
            // NosCombinedColHeaderRowLabel
            // 
            this.NosCombinedColHeaderRowLabel.AutoSize = true;
            this.NosCombinedColHeaderRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NosCombinedColHeaderRowLabel.Location = new System.Drawing.Point(7, 79);
            this.NosCombinedColHeaderRowLabel.Name = "NosCombinedColHeaderRowLabel";
            this.NosCombinedColHeaderRowLabel.Size = new System.Drawing.Size(167, 20);
            this.NosCombinedColHeaderRowLabel.TabIndex = 11;
            this.NosCombinedColHeaderRowLabel.Text = "Column Heading Row:";
            // 
            // NosCombinedColHeaderRowValue
            // 
            this.NosCombinedColHeaderRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NosCombinedColHeaderRowValue.Location = new System.Drawing.Point(207, 79);
            this.NosCombinedColHeaderRowValue.Name = "NosCombinedColHeaderRowValue";
            this.NosCombinedColHeaderRowValue.Size = new System.Drawing.Size(115, 26);
            this.NosCombinedColHeaderRowValue.TabIndex = 10;
            // 
            // NosCombinedFormulaRowLabel
            // 
            this.NosCombinedFormulaRowLabel.AutoSize = true;
            this.NosCombinedFormulaRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NosCombinedFormulaRowLabel.Location = new System.Drawing.Point(7, 45);
            this.NosCombinedFormulaRowLabel.Name = "NosCombinedFormulaRowLabel";
            this.NosCombinedFormulaRowLabel.Size = new System.Drawing.Size(116, 20);
            this.NosCombinedFormulaRowLabel.TabIndex = 9;
            this.NosCombinedFormulaRowLabel.Text = "Formulae Row:";
            // 
            // NosCombinedFormulaRowValue
            // 
            this.NosCombinedFormulaRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NosCombinedFormulaRowValue.Location = new System.Drawing.Point(207, 45);
            this.NosCombinedFormulaRowValue.Name = "NosCombinedFormulaRowValue";
            this.NosCombinedFormulaRowValue.Size = new System.Drawing.Size(115, 26);
            this.NosCombinedFormulaRowValue.TabIndex = 8;
            // 
            // NosCombinedHeaderRowValue
            // 
            this.NosCombinedHeaderRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NosCombinedHeaderRowValue.Location = new System.Drawing.Point(207, 11);
            this.NosCombinedHeaderRowValue.Name = "NosCombinedHeaderRowValue";
            this.NosCombinedHeaderRowValue.Size = new System.Drawing.Size(115, 26);
            this.NosCombinedHeaderRowValue.TabIndex = 7;
            // 
            // NosCombinedHeaderRowLabel
            // 
            this.NosCombinedHeaderRowLabel.AutoSize = true;
            this.NosCombinedHeaderRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NosCombinedHeaderRowLabel.Location = new System.Drawing.Point(7, 11);
            this.NosCombinedHeaderRowLabel.Name = "NosCombinedHeaderRowLabel";
            this.NosCombinedHeaderRowLabel.Size = new System.Drawing.Size(102, 20);
            this.NosCombinedHeaderRowLabel.TabIndex = 6;
            this.NosCombinedHeaderRowLabel.Text = "Header Row:";
            // 
            // LifecycleWorksheetOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 236);
            this.Controls.Add(this.WorksheetOptionsTabControl);
            this.Name = "LifecycleWorksheetOptionsForm";
            this.Text = "LifecycleWorksheetOptionsForm";
            this.WorksheetOptionsTabControl.ResumeLayout(false);
            this.WorksheetOptionsTabPageDetailsProduct.ResumeLayout(false);
            this.WorksheetOptionsTabPageDetailsProduct.PerformLayout();
            this.WorksheetOptionsTabPageInactiveUpc.ResumeLayout(false);
            this.WorksheetOptionsTabPageInactiveUpc.PerformLayout();
            this.WorksheetOptionsTabPageNosCombined.ResumeLayout(false);
            this.WorksheetOptionsTabPageNosCombined.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl WorksheetOptionsTabControl;
        private System.Windows.Forms.TabPage WorksheetOptionsTabPageDetailsProduct;
        private System.Windows.Forms.TabPage WorksheetOptionsTabPageInactiveUpc;
        private System.Windows.Forms.Label DetailsProductColHeaderRowLabel;
        private System.Windows.Forms.TextBox DetailsProductColHeaderRowValue;
        private System.Windows.Forms.Label DetailsProductFormulaRowLabel;
        private System.Windows.Forms.TextBox DetailsProductFormulaRowValue;
        private System.Windows.Forms.TextBox DetailsProductHeaderRowValue;
        private System.Windows.Forms.Label DetailsProductHeaderRowLabel;
        private System.Windows.Forms.Label InactiveUpcColHeaderRowLabel;
        private System.Windows.Forms.TextBox InactiveUpcColHeaderRowValue;
        private System.Windows.Forms.Label InactiveUpcFormulaRowLabel;
        private System.Windows.Forms.TextBox InactiveUpcFormulaRowValue;
        private System.Windows.Forms.TextBox InactiveUpcHeaderRowValue;
        private System.Windows.Forms.Label InactiveUpcHeaderRowLabel;
        private System.Windows.Forms.TabPage WorksheetOptionsTabPageNosCombined;
        private System.Windows.Forms.Label NosCombinedColHeaderRowLabel;
        private System.Windows.Forms.TextBox NosCombinedColHeaderRowValue;
        private System.Windows.Forms.Label NosCombinedFormulaRowLabel;
        private System.Windows.Forms.TextBox NosCombinedFormulaRowValue;
        private System.Windows.Forms.TextBox NosCombinedHeaderRowValue;
        private System.Windows.Forms.Label NosCombinedHeaderRowLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}