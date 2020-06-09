using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;



namespace LifeCycleDevEnvironmentConsole
{
    public static class ExcelUtilities
    {
        /// <summary>
        /// Read excelfile using oledb into datatable. Capable of reading excel file format xls, xlsx, xlsm, xlsb, csv.
        /// </summary>
        /// <param name="filePath">Accepts .xls, .xlsx, .csv</param>
        /// <param name="worksheetNumber">Worksheet index starts at 1.</param>
        /// <returns></returns>
        public static System.Data.DataTable OledbExcelFileAsTable(string filePath, int worksheetNumber = 1, string rangeAddress = "")
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            string excelConnString = "Provider=Microsoft.{0}.OLEDB.{1};Data Source={2};Extended Properties=\"Excel {3};HDR=YES;IMEX=1\"";
            FileInfo fInfo = new FileInfo(filePath);
            if (fInfo.Extension.Equals(".xls"))
            {
                excelConnString = string.Format(excelConnString, "Jet", "4.0", filePath, "8.0");
            }
            else if (fInfo.Extension.Equals(".csv"))
            {
                excelConnString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};" +
                "Extended Properties=\"Text;HDR=Yes;FORMAT=Delimited\"", Path.GetDirectoryName(filePath));
            }
            else
            {
                excelConnString = string.Format(excelConnString, "Ace", "12.0", filePath, "12.0");
            }


            #region Create Connection to Excel work book 
            using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
            {
                string sql;

                if (fInfo.Extension.Equals(".csv"))
                {
                    sql = string.Format(@"SELECT * FROM [{0}]", Path.GetFileName(filePath));
                }
                else
                {
                    excelConnection.Open();
                    var schemaTable = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (schemaTable.Rows.Count < worksheetNumber) throw new ArgumentException("The worksheet number provided cannot be found in the spreadsheet");
                    string worksheet = schemaTable.Rows[worksheetNumber - 1]["table_name"].ToString().Replace("'", "").Replace("$", "");
                    excelConnection.Close();

                    if (rangeAddress != "")
                    {
                        rangeAddress = rangeAddress.Replace("$", "");
                    }

                    sql = String.Format("select * from [{0}${1}]", worksheet, rangeAddress);
                }

                //Create OleDbCommand to fetch data from Excel 
                using (OleDbCommand cmd = new OleDbCommand(sql, excelConnection))
                {
                    try
                    {
                        System.Data.DataTable table = new System.Data.DataTable();
                        using (OleDbDataAdapter oledata = new OleDbDataAdapter(cmd))
                        {
                            oledata.Fill(table);
                        }
                        return table;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Read excelfile using oledb into datatable. Capable of reading excel file format xls, xlsx, xlsm, xlsb, csv.
        /// </summary>
        /// <param name="filePath">Accepts .xls, .xlsx .xlsb .csv</param>
        /// <param name="worksheetNumber">Worksheet index starts at 1.</param>
        /// <returns></returns>
        public static System.Data.DataTable OledbExcelFileAsTable(string filePath, string worksheetName = "Sheet1", string rangeAddress = "")
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            string excelConnString = "Provider=Microsoft.{0}.OLEDB.{1};Data Source={2};Extended Properties=\"Excel {3};HDR=YES;IMEX=1\"";
            FileInfo fInfo = new FileInfo(filePath);
            if (fInfo.Extension.Equals(".xls"))
            {
                excelConnString = String.Format(excelConnString, "Jet", "4.0", filePath, "8.0");
            }else if (fInfo.Extension.Equals(".csv"))
            {
                excelConnString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};" +
                "Extended Properties=\"Text;HDR=Yes;FORMAT=Delimited\"", Path.GetDirectoryName(filePath));
            }
            else
            {
                excelConnString = String.Format(excelConnString, "Ace", "12.0", filePath, "12.0");
            }

            #region Create Connection to Excel work book 
            using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
            {
                string sql;

                if (fInfo.Extension.Equals(".csv"))
                {
                    sql = string.Format(@"SELECT * FROM [{0}]", Path.GetFileName(filePath));
                }
                else
                {
                    excelConnection.Open();
                    var schemaTable = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    worksheetName = worksheetName.Replace("'", "");
                    bool sheetExists = schemaTable.AsEnumerable().Any(r => r.Field<string>("table_name").IndexOf(worksheetName, StringComparison.OrdinalIgnoreCase) >= 0);
                    if (!sheetExists) throw new ArgumentException("The worksheet name supplied cannot be found in the spreadsheet worksheets");

                    excelConnection.Close();

                    if (rangeAddress != "")
                    {
                        rangeAddress = rangeAddress.Replace("$", "");
                    }

                    sql = String.Format("select * from [{0}${1}]", worksheetName, rangeAddress);
                }

                //Create OleDbCommand to fetch data from Excel 
                using (OleDbCommand cmd = new OleDbCommand(sql, excelConnection))
                {
                    try
                    {
                        System.Data.DataTable table = new System.Data.DataTable();
                        using (OleDbDataAdapter oledata = new OleDbDataAdapter(cmd))
                        {
                            oledata.Fill(table);
                        }
                        return table;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
                
            }
            #endregion
        }

        /// <summary>
        /// Test if an object is a value.
        /// </summary>
        public static bool IsNumber(this object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }
}
