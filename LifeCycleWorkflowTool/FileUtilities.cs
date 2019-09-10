using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeCycleWorkflowTool
{
     static class FileFolderPickerUtility
    {
        /// <summary>
        /// Popluate the textbox control with a choice of filepicker (value: 0) or folderpicker(value: 1)
        /// depending on pickertype value passed.
        /// </summary>
        /// <param name="tBox"></param>
        /// <param name="pickerType"></param>
        public static void PopulateTextBox(TextBox tBox, int pickerType = 0)
        {
            if (pickerType == 0)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Open Input Files";
                openFileDialog.Filter = "Data Files (.csv, .xlsx)|*.csv;*.xlsx|All Files (.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tBox.Text = openFileDialog.FileName;
                }
            }

            if(pickerType == 1)
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}
