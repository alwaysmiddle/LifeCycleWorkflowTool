using LifeCycleWorkflowLibrary;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LifecycleWorksheetOptionsForm));
            this.WorksheetOptionsTabControl = new System.Windows.Forms.TabControl();
            this.WorksheetOptionsTabPageDetailsProduct = new System.Windows.Forms.TabPage();
            this.LifecycleWorksheetOptionsLoadButton = new System.Windows.Forms.Button();
            this.LifecycleWorksheetOptionsSaveButton = new System.Windows.Forms.Button();
            this.DetailsProductReferenceRowLabel = new System.Windows.Forms.Label();
            this.DetailsProductReferenceRowValue = new System.Windows.Forms.TextBox();
            this.DetailsProductFormulaRowLabel = new System.Windows.Forms.Label();
            this.DetailsProductFormulaRowValue = new System.Windows.Forms.TextBox();
            this.DetailsProductHeaderRowValue = new System.Windows.Forms.TextBox();
            this.DetailsProductHeaderRowLabel = new System.Windows.Forms.Label();
            this.WorksheetOptionsTabPageInactiveUpc = new System.Windows.Forms.TabPage();
            this.InactiveUpcReferenceRowLabel = new System.Windows.Forms.Label();
            this.InactiveUpcReferenceRowValue = new System.Windows.Forms.TextBox();
            this.InactiveUpcFormulaRowLabel = new System.Windows.Forms.Label();
            this.InactiveUpcFormulaRowValue = new System.Windows.Forms.TextBox();
            this.InactiveUpcHeaderRowValue = new System.Windows.Forms.TextBox();
            this.InactiveUpcHeaderRowLabel = new System.Windows.Forms.Label();
            this.WorksheetOptionsTabPageNosCombined = new System.Windows.Forms.TabPage();
            this.NosCombinedReferenceRowLabel = new System.Windows.Forms.Label();
            this.NosCombinedReferenceRowValue = new System.Windows.Forms.TextBox();
            this.NosCombinedFormulaRowLabel = new System.Windows.Forms.Label();
            this.NosCombinedFormulaRowValue = new System.Windows.Forms.TextBox();
            this.NosCombinedHeaderRowValue = new System.Windows.Forms.TextBox();
            this.NosCombinedHeaderRowLabel = new System.Windows.Forms.Label();
            this.WorkSheetOptionsSplitter = new System.Windows.Forms.Splitter();
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
            this.WorksheetOptionsTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.WorksheetOptionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.WorksheetOptionsTabControl.Name = "WorksheetOptionsTabControl";
            this.WorksheetOptionsTabControl.SelectedIndex = 0;
            this.WorksheetOptionsTabControl.Size = new System.Drawing.Size(358, 151);
            this.WorksheetOptionsTabControl.TabIndex = 0;
            // 
            // WorksheetOptionsTabPageDetailsProduct
            // 
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductReferenceRowLabel);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductReferenceRowValue);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductFormulaRowLabel);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductFormulaRowValue);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductHeaderRowValue);
            this.WorksheetOptionsTabPageDetailsProduct.Controls.Add(this.DetailsProductHeaderRowLabel);
            this.WorksheetOptionsTabPageDetailsProduct.Location = new System.Drawing.Point(4, 22);
            this.WorksheetOptionsTabPageDetailsProduct.Name = "WorksheetOptionsTabPageDetailsProduct";
            this.WorksheetOptionsTabPageDetailsProduct.Padding = new System.Windows.Forms.Padding(3);
            this.WorksheetOptionsTabPageDetailsProduct.Size = new System.Drawing.Size(350, 125);
            this.WorksheetOptionsTabPageDetailsProduct.TabIndex = 0;
            this.WorksheetOptionsTabPageDetailsProduct.Text = "Details_Product";
            this.WorksheetOptionsTabPageDetailsProduct.UseVisualStyleBackColor = true;
            this.WorksheetOptionsTabPageDetailsProduct.Click += new System.EventHandler(this.WorksheetOptionsTabPageDetailsProduct_Click);
            // 
            // LifecycleWorksheetOptionsLoadButton
            // 
            this.LifecycleWorksheetOptionsLoadButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LifecycleWorksheetOptionsLoadButton.Location = new System.Drawing.Point(109, 166);
            this.LifecycleWorksheetOptionsLoadButton.Margin = new System.Windows.Forms.Padding(2);
            this.LifecycleWorksheetOptionsLoadButton.Name = "LifecycleWorksheetOptionsLoadButton";
            this.LifecycleWorksheetOptionsLoadButton.Size = new System.Drawing.Size(101, 39);
            this.LifecycleWorksheetOptionsLoadButton.TabIndex = 5;
            this.LifecycleWorksheetOptionsLoadButton.Text = "Load";
            this.LifecycleWorksheetOptionsLoadButton.UseVisualStyleBackColor = true;
            this.LifecycleWorksheetOptionsLoadButton.Click += new System.EventHandler(this.LifecycleWorksheetOptionsLoadButton_Click);
            // 
            // LifecycleWorksheetOptionsSaveButton
            // 
            this.LifecycleWorksheetOptionsSaveButton.Location = new System.Drawing.Point(4, 166);
            this.LifecycleWorksheetOptionsSaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.LifecycleWorksheetOptionsSaveButton.Name = "LifecycleWorksheetOptionsSaveButton";
            this.LifecycleWorksheetOptionsSaveButton.Size = new System.Drawing.Size(101, 39);
            this.LifecycleWorksheetOptionsSaveButton.TabIndex = 4;
            this.LifecycleWorksheetOptionsSaveButton.Text = "Save";
            this.LifecycleWorksheetOptionsSaveButton.UseVisualStyleBackColor = true;
            this.LifecycleWorksheetOptionsSaveButton.Click += new System.EventHandler(this.LifecycleWorksheetOptionsSaveButton_Click);
            // 
            // DetailsProductReferenceRowLabel
            // 
            this.DetailsProductReferenceRowLabel.AutoSize = true;
            this.DetailsProductReferenceRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsProductReferenceRowLabel.Location = new System.Drawing.Point(7, 79);
            this.DetailsProductReferenceRowLabel.Name = "DetailsProductReferenceRowLabel";
            this.DetailsProductReferenceRowLabel.Size = new System.Drawing.Size(124, 20);
            this.DetailsProductReferenceRowLabel.TabIndex = 0;
            this.DetailsProductReferenceRowLabel.Text = "Reference Row:";
            // 
            // DetailsProductReferenceRowValue
            // 
            this.DetailsProductReferenceRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsProductReferenceRowValue.Location = new System.Drawing.Point(207, 79);
            this.DetailsProductReferenceRowValue.Name = "DetailsProductReferenceRowValue";
            this.DetailsProductReferenceRowValue.Size = new System.Drawing.Size(115, 26);
            this.DetailsProductReferenceRowValue.TabIndex = 3;
            // 
            // DetailsProductFormulaRowLabel
            // 
            this.DetailsProductFormulaRowLabel.AutoSize = true;
            this.DetailsProductFormulaRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsProductFormulaRowLabel.Location = new System.Drawing.Point(7, 45);
            this.DetailsProductFormulaRowLabel.Name = "DetailsProductFormulaRowLabel";
            this.DetailsProductFormulaRowLabel.Size = new System.Drawing.Size(116, 20);
            this.DetailsProductFormulaRowLabel.TabIndex = 0;
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
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcReferenceRowLabel);
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcReferenceRowValue);
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcFormulaRowLabel);
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcFormulaRowValue);
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcHeaderRowValue);
            this.WorksheetOptionsTabPageInactiveUpc.Controls.Add(this.InactiveUpcHeaderRowLabel);
            this.WorksheetOptionsTabPageInactiveUpc.Location = new System.Drawing.Point(4, 22);
            this.WorksheetOptionsTabPageInactiveUpc.Name = "WorksheetOptionsTabPageInactiveUpc";
            this.WorksheetOptionsTabPageInactiveUpc.Padding = new System.Windows.Forms.Padding(3);
            this.WorksheetOptionsTabPageInactiveUpc.Size = new System.Drawing.Size(358, 148);
            this.WorksheetOptionsTabPageInactiveUpc.TabIndex = 1;
            this.WorksheetOptionsTabPageInactiveUpc.Text = "Inactive_UPC";
            this.WorksheetOptionsTabPageInactiveUpc.UseVisualStyleBackColor = true;
            // 
            // InactiveUpcReferenceRowLabel
            // 
            this.InactiveUpcReferenceRowLabel.AutoSize = true;
            this.InactiveUpcReferenceRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcReferenceRowLabel.Location = new System.Drawing.Point(7, 79);
            this.InactiveUpcReferenceRowLabel.Name = "InactiveUpcReferenceRowLabel";
            this.InactiveUpcReferenceRowLabel.Size = new System.Drawing.Size(124, 20);
            this.InactiveUpcReferenceRowLabel.TabIndex = 0;
            this.InactiveUpcReferenceRowLabel.Text = "Reference Row:";
            // 
            // InactiveUpcReferenceRowValue
            // 
            this.InactiveUpcReferenceRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcReferenceRowValue.Location = new System.Drawing.Point(207, 79);
            this.InactiveUpcReferenceRowValue.Name = "InactiveUpcReferenceRowValue";
            this.InactiveUpcReferenceRowValue.Size = new System.Drawing.Size(115, 26);
            this.InactiveUpcReferenceRowValue.TabIndex = 3;
            // 
            // InactiveUpcFormulaRowLabel
            // 
            this.InactiveUpcFormulaRowLabel.AutoSize = true;
            this.InactiveUpcFormulaRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcFormulaRowLabel.Location = new System.Drawing.Point(7, 45);
            this.InactiveUpcFormulaRowLabel.Name = "InactiveUpcFormulaRowLabel";
            this.InactiveUpcFormulaRowLabel.Size = new System.Drawing.Size(116, 20);
            this.InactiveUpcFormulaRowLabel.TabIndex = 0;
            this.InactiveUpcFormulaRowLabel.Text = "Formulae Row:";
            // 
            // InactiveUpcFormulaRowValue
            // 
            this.InactiveUpcFormulaRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcFormulaRowValue.Location = new System.Drawing.Point(207, 45);
            this.InactiveUpcFormulaRowValue.Name = "InactiveUpcFormulaRowValue";
            this.InactiveUpcFormulaRowValue.Size = new System.Drawing.Size(115, 26);
            this.InactiveUpcFormulaRowValue.TabIndex = 2;
            // 
            // InactiveUpcHeaderRowValue
            // 
            this.InactiveUpcHeaderRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcHeaderRowValue.Location = new System.Drawing.Point(207, 11);
            this.InactiveUpcHeaderRowValue.Name = "InactiveUpcHeaderRowValue";
            this.InactiveUpcHeaderRowValue.Size = new System.Drawing.Size(115, 26);
            this.InactiveUpcHeaderRowValue.TabIndex = 1;
            // 
            // InactiveUpcHeaderRowLabel
            // 
            this.InactiveUpcHeaderRowLabel.AutoSize = true;
            this.InactiveUpcHeaderRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveUpcHeaderRowLabel.Location = new System.Drawing.Point(7, 11);
            this.InactiveUpcHeaderRowLabel.Name = "InactiveUpcHeaderRowLabel";
            this.InactiveUpcHeaderRowLabel.Size = new System.Drawing.Size(102, 20);
            this.InactiveUpcHeaderRowLabel.TabIndex = 0;
            this.InactiveUpcHeaderRowLabel.Text = "Header Row:";
            // 
            // WorksheetOptionsTabPageNosCombined
            // 
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedReferenceRowLabel);
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedReferenceRowValue);
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedFormulaRowLabel);
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedFormulaRowValue);
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedHeaderRowValue);
            this.WorksheetOptionsTabPageNosCombined.Controls.Add(this.NosCombinedHeaderRowLabel);
            this.WorksheetOptionsTabPageNosCombined.Location = new System.Drawing.Point(4, 22);
            this.WorksheetOptionsTabPageNosCombined.Margin = new System.Windows.Forms.Padding(2);
            this.WorksheetOptionsTabPageNosCombined.Name = "WorksheetOptionsTabPageNosCombined";
            this.WorksheetOptionsTabPageNosCombined.Padding = new System.Windows.Forms.Padding(2);
            this.WorksheetOptionsTabPageNosCombined.Size = new System.Drawing.Size(350, 125);
            this.WorksheetOptionsTabPageNosCombined.TabIndex = 2;
            this.WorksheetOptionsTabPageNosCombined.Text = "Nos_Color_Combined";
            this.WorksheetOptionsTabPageNosCombined.UseVisualStyleBackColor = true;
            // 
            // NosCombinedReferenceRowLabel
            // 
            this.NosCombinedReferenceRowLabel.AutoSize = true;
            this.NosCombinedReferenceRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NosCombinedReferenceRowLabel.Location = new System.Drawing.Point(7, 79);
            this.NosCombinedReferenceRowLabel.Name = "NosCombinedReferenceRowLabel";
            this.NosCombinedReferenceRowLabel.Size = new System.Drawing.Size(124, 20);
            this.NosCombinedReferenceRowLabel.TabIndex = 11;
            this.NosCombinedReferenceRowLabel.Text = "Reference Row:";
            // 
            // NosCombinedReferenceRowValue
            // 
            this.NosCombinedReferenceRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NosCombinedReferenceRowValue.Location = new System.Drawing.Point(207, 79);
            this.NosCombinedReferenceRowValue.Name = "NosCombinedReferenceRowValue";
            this.NosCombinedReferenceRowValue.Size = new System.Drawing.Size(115, 26);
            this.NosCombinedReferenceRowValue.TabIndex = 3;
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
            this.NosCombinedFormulaRowValue.TabIndex = 2;
            // 
            // NosCombinedHeaderRowValue
            // 
            this.NosCombinedHeaderRowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NosCombinedHeaderRowValue.Location = new System.Drawing.Point(207, 11);
            this.NosCombinedHeaderRowValue.Name = "NosCombinedHeaderRowValue";
            this.NosCombinedHeaderRowValue.Size = new System.Drawing.Size(115, 26);
            this.NosCombinedHeaderRowValue.TabIndex = 1;
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
            // WorkSheetOptionsSplitter
            // 
            this.WorkSheetOptionsSplitter.BackColor = System.Drawing.SystemColors.Control;
            this.WorkSheetOptionsSplitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.WorkSheetOptionsSplitter.Enabled = false;
            this.WorkSheetOptionsSplitter.Location = new System.Drawing.Point(0, 151);
            this.WorkSheetOptionsSplitter.Name = "WorkSheetOptionsSplitter";
            this.WorkSheetOptionsSplitter.Size = new System.Drawing.Size(358, 10);
            this.WorkSheetOptionsSplitter.TabIndex = 1;
            this.WorkSheetOptionsSplitter.TabStop = false;
            // 
            // LifecycleWorksheetOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(358, 217);
            this.Controls.Add(this.LifecycleWorksheetOptionsLoadButton);
            this.Controls.Add(this.WorkSheetOptionsSplitter);
            this.Controls.Add(this.LifecycleWorksheetOptionsSaveButton);
            this.Controls.Add(this.WorksheetOptionsTabControl);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label DetailsProductReferenceRowLabel;
        private System.Windows.Forms.TextBox DetailsProductReferenceRowValue;
        private System.Windows.Forms.Label DetailsProductFormulaRowLabel;
        private System.Windows.Forms.TextBox DetailsProductFormulaRowValue;
        private System.Windows.Forms.TextBox DetailsProductHeaderRowValue;
        private System.Windows.Forms.Label DetailsProductHeaderRowLabel;
        private System.Windows.Forms.Label InactiveUpcReferenceRowLabel;
        private System.Windows.Forms.TextBox InactiveUpcReferenceRowValue;
        private System.Windows.Forms.Label InactiveUpcFormulaRowLabel;
        private System.Windows.Forms.TextBox InactiveUpcFormulaRowValue;
        private System.Windows.Forms.TextBox InactiveUpcHeaderRowValue;
        private System.Windows.Forms.Label InactiveUpcHeaderRowLabel;
        private System.Windows.Forms.TabPage WorksheetOptionsTabPageNosCombined;
        private System.Windows.Forms.Label NosCombinedReferenceRowLabel;
        private System.Windows.Forms.TextBox NosCombinedReferenceRowValue;
        private System.Windows.Forms.Label NosCombinedFormulaRowLabel;
        private System.Windows.Forms.TextBox NosCombinedFormulaRowValue;
        private System.Windows.Forms.TextBox NosCombinedHeaderRowValue;
        private System.Windows.Forms.Label NosCombinedHeaderRowLabel;
        private System.Windows.Forms.Button LifecycleWorksheetOptionsLoadButton;
        private System.Windows.Forms.Button LifecycleWorksheetOptionsSaveButton;
        private System.Windows.Forms.Splitter WorkSheetOptionsSplitter;
    }
}