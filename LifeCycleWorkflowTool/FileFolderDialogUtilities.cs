using System.Windows.Forms;

namespace LifeCycleWorkflowTool
{
    static class FileFolderPickerUtility
    {
        public enum PickerType
        {
            File,
            Folder
        }
        /// <summary>
        /// Popluate the textbox control with a choice of filepicker (value: 0) or folderpicker(value: 1)
        /// depending on pickertype value passed.
        /// </summary>
        /// <param name="tBox"></param>
        /// <param name="pickerType"></param>
        public static void PopulateTextBox(TextBox tBox, 
            PickerType pickerType = PickerType.File, string customFilter = "")
        {
            if (pickerType == PickerType.File)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Open Input Files";

                if (customFilter == "")
                {
                    openFileDialog.Filter = "Data Files (.csv, .xlsx)|*.csv;*.xlsx|All Files (.*)|*.*";
                }
                else
                {
                    openFileDialog.Filter = customFilter + "|All files (.*)|*.*";
                }
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tBox.Text = openFileDialog.FileName;
                }
            }

            if (pickerType == PickerType.Folder)
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
