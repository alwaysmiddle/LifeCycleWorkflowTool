using System;
using System.Collections.Generic;
using System.IO;
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

    static class LifeCycleFileUtilities
    {
        /// <summary>
        /// Performs FileCopy, create the path supplied. Provide option to Rename the file, this method will read the original file extension and rename the file to the same extension.
        /// Returns the new file's fullname.
        /// </summary>
        /// <param name="FileToCopy"></param>
        /// <param name="CopyToPath"></param>
        /// <param name="RenameTo"></param>
        /// <returns></returns>
        public static string CopyFile(string FileToCopy, string CopyToPath, string RenameTo = "")
        {
            Directory.CreateDirectory(CopyToPath);

            if (RenameTo == "")
            {
                string destPath = Path.Combine(CopyToPath, Path.GetFileName(FileToCopy));
                File.Copy(FileToCopy, destPath, true);

                return destPath;
            }
            else
            {
                string destPath = Path.Combine(CopyToPath, RenameTo + Path.GetExtension(FileToCopy));
                File.Copy(FileToCopy, destPath, true);

                return destPath;
            }
        }
    }
}
