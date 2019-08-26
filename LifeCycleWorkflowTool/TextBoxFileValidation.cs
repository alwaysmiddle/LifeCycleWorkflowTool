using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LifeCycleWorkflowTool
{
    internal class TextBoxFileValidation
    {
        public string ErrorMessage { get; set; }
        private TextBox _tBox { get; set; }

        public TextBoxFileValidation(TextBox tBox)
        {
            ErrorMessage = "";
            _tBox = tBox;
        }

        public TextBoxFileValidation(TextBox tBox, string errorMsg)
        {
            ErrorMessage = errorMsg;
            _tBox = tBox;
        }


        public bool isValid()
        {
            bool valid = true;

            ///validate if file exists
            if (_tBox.Text != "" && !File.Exists(_tBox.Text))
            {
                ErrorMessage = "Error: File path are not valid files, please make sure you have valid file path selected.";
                valid = false;
            }
            else if(_tBox.Text == "")
            {
                ErrorMessage = "Error: Can not leave this file unselected!";
                valid = false;
            }

            return valid;

        }

    }
}
