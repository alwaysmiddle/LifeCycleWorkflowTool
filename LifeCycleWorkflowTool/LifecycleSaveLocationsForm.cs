using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeCycleWorkflowTool
{
    public partial class LifecycleSaveLocationsForm : Form
    {
        public LifecycleSaveLocationsForm()
        {
            InitializeComponent();
        }

        private void SaveLocationsButtonTheBayFilePicker_Click(object sender, EventArgs e)
        {
            SaveLocationsFolderPicker.ShowDialog();
            string folderPicker = SaveLocationsFolderPicker.SelectedPath;
            SaveLocationsWipValue.Text = folderPicker;
        }

        private void SaveLocationsButtonSave_Click(object sender, EventArgs e)
        {
            if (SaveLocationsWipValue.Text != "")
            {
                //save to the locations
            }
            else
            {
                //else save to the default save locations, which is user's desktop
            }
        }

    }
}
