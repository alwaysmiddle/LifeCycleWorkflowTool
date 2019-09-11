using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace LifeCycleWorkflowLibrary
{
    static class TheBayManualFileProcess
    {
        public static bool ProcessNosCombinedFile(string NosFileName)
        {
            if (Globals.TheBayOutputWipFile == "" || Globals.TheBayOutputWipFile == null)
            {
                //TODO Convert this to debug
                MessageBox.Show("The output file is not found, possibly due to copying error, or file permissions error");
                return false;
            }

            XLWorkbook template = new XLWorkbook(Globals.TheBayOutputWipFile);
            DataTable dtNos = DataTableImporter.ReadCsvFile(NosFileName);

            return false;
        }
    }
}
