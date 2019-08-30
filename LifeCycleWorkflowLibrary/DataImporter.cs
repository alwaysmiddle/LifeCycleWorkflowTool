using System;
using System.Data;
using GenericParsing;
using System.IO;
using System.Windows.Forms;

namespace LifeCycleWorkflowLibrary
{
    static class DataTableImporter
    {
        static DataTable ReadCsvFile(string filename, bool FirstRowAsHeaders = true)
        {
            DataTable wfData = new DataTable();

            try
            {
                using (GenericParserAdapter parser = new GenericParserAdapter())
                {
                    parser.SetDataSource(filename);

                    parser.ColumnDelimiter = ',';
                    parser.FirstRowHasHeader = FirstRowAsHeaders;
                    parser.MaxBufferSize = 4096;

                    wfData = parser.GetDataTable();
                }

                return wfData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }

        static DataTable ReadXlsxSheet(string filename, string worksheetName, string range)
        {
            DataTable wfData = new DataTable();

            return wfData;
        }
    }
}
