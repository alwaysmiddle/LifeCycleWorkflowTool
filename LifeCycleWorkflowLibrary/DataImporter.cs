using System;
using System.Data;
using GenericParsing;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace LifeCycleWorkflowLibrary
{
    static class DataTableImporter
    {
        public static DataTable ReadCsvFile(string filename, bool FirstRowAsHeaders = true)
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

        public static DataTable ReadXlsxSheet(string filePath, string sheetName)
        {
            // Reference to Stackoverflow article: 
            //https://stackoverflow.com/questions/48756449/read-excel-worksheet-into-datatable-using-closedxml

            // Open the Excel file using ClosedXML.
            // Keep in mind the Excel file cannot be open when trying to read it
            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.
                DataTable dt = new DataTable();

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;

                        foreach (IXLCell cell in row.Cells(row.FirstCellUsed().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                }

                return dt;
            }
        }
    }
}
