using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LifeCycleWorkflowTool
{
    class TextBoxValidation
    {
        public enum ValidationType
        {
            File,
            Folder,
            PostiveInteger
        }

        private List<TextBox> _tBoxColl { get; set; }
        private ErrorProvider _erorrProvider { get; set; }
        private string _errorMessage { get; set; }
        private ValidationType _type { get; set; }

        public TextBoxValidation(TextBox tBox, ErrorProvider errorProvider, ValidationType type)
        {
            _tBoxColl.Add(tBox);
            _erorrProvider = errorProvider;
            _type = type;
        }

        public TextBoxValidation(List<TextBox> tColl, ErrorProvider errorProvider, ValidationType type)
        {
            _tBoxColl = tColl;
            _erorrProvider = errorProvider;
            _type = type;
        }

        public bool ValidateTextBox()
        {
            bool allValid = true;
            foreach (var tBox in _tBoxColl)
            {
                if (!isValid(tBox))
                {
                    allValid = false;
                }
            }

            if (allValid)
            {
                _erorrProvider.Clear();
            }
            return allValid;
        }

        private bool isValid(TextBox tBox)
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(tBox.Text))
            {
                _errorMessage = "Error: Can not leave this field blank!";
                _erorrProvider.SetError(tBox, _errorMessage);
                valid = false;
            }else if (_type == ValidationType.File && !File.Exists(tBox.Text))
            {
                _errorMessage = "Error: File path is not valid, please make sure you have valid filename selected.";
                _erorrProvider.SetError(tBox, _errorMessage);
                valid = false;
            }
            else if (_type == ValidationType.Folder && !Directory.Exists(tBox.Text))
            {
                _errorMessage = "Error: Folder path is not valid, please make sure you have valid folder path selected.";
                _erorrProvider.SetError(tBox, _errorMessage);
                valid = false;
            }
            else
            {
                _erorrProvider.SetError(tBox, "");
                valid = true;
            }

            return valid;
        }
    }
}
