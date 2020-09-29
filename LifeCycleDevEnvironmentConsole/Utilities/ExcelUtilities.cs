using ExcelDataReader;
using LifeCycleDevEnvironmentConsole.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LifeCycleDevEnvironmentConsole.Utilities
{
    public static class ExcelUtilities
    {
        /// <summary>
        /// Read excelfile using exceldatareader dependency into datatable. Capable of reading excel file format xls, xlsx, xlsm, xlsb, csv.
        /// </summary>
        public static System.Data.DataTable ReadExcelDataFileAsTable(string filePath, int worksheetNum = 1, string startRange = "")
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            DataSet result;

            FileInfo fInfo = new FileInfo(filePath);
            if (fInfo.Extension.Equals(".csv"))
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                    {
                        result = reader.AsDataSet();
                    }
                }
                result.Tables[0].RemoveEmptyColumns();
                result.Tables[0].AcceptChanges();

                return result.Tables[0];
            }
            else if (fInfo.Extension.Equals(".xls") || fInfo.Extension.Equals(".xlsx") || fInfo.Extension.Equals(".xlsb") || fInfo.Extension.Equals(".xlsm"))
            {
                //Config for ExcelDatareader
                ExcelDataSetConfiguration setConfig = new ExcelDataSetConfiguration();
                ExcelDataTableConfiguration tableConfig = new ExcelDataTableConfiguration();

                setConfig.UseColumnDataType = true;
                if (worksheetNum != 1)
                {
                    //filter on the specific worksheetname, expect 1 worksheetname per function call.
                    setConfig.FilterSheet = (tableReader, sheetIndex) => (sheetIndex == worksheetNum);
                }

                tableConfig.EmptyColumnNamePrefix = "EmptyColumn";
                tableConfig.UseHeaderRow = true;

                if (startRange != "")
                {
                    var match = Regex.Match(startRange, @"(?<col>[A-Z]+)(?<row>\d+)");
                    var colStr = match.Groups["col"].ToString();
                    var fromCol = colStr.Select((t, i) => (colStr[i] - 64) * Math.Pow(26, colStr.Length - i - 1)).Sum();
                    var fromRow = int.Parse(match.Groups["row"].ToString());

                    int j = 0;
                    tableConfig.FilterRow = rowReader => fromRow <= ++j - 1;
                    tableConfig.FilterColumn = (rowReader, colIndex) => fromCol <= colIndex;
                }

                setConfig.ConfigureDataTable = (tableReader) => tableConfig;


                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                    {
                        result = reader.AsDataSet(setConfig);
                    }
                }

                //This function never expects to return whole workbook as dataset.
                if (result.Tables.Count != 0)
                {
                    result.Tables[0].RemoveEmptyColumns();
                    result.Tables[0].AcceptChanges();

                    return result.Tables[0];
                }
                else
                {
                    throw new ArgumentException("The worksheet name supplied cannot be found in the spreadsheet worksheets");
                }
            }
            else
            {
                Console.WriteLine("Unsupported format for file {0}", filePath);
                return null;
            }
        }

        /// <summary>
        /// Read excelfile using exceldatareader dependency into datatable. Capable of reading excel file format xls, xlsx, xlsm, xlsb, csv.
        /// </summary>
        public static System.Data.DataTable ReadExcelDataFileAsTable(string filePath, string worksheetName = "", string startRange = "")
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            DataSet result;

            FileInfo fInfo = new FileInfo(filePath);
            if (fInfo.Extension.Equals(".csv"))
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                    {
                        result = reader.AsDataSet();
                    }
                }
                result.Tables[0].RemoveEmptyColumns();
                result.Tables[0].AcceptChanges();

                return result.Tables[0];
            }
            else if(fInfo.Extension.Equals(".xls") || fInfo.Extension.Equals(".xlsx") || fInfo.Extension.Equals(".xlsb") || fInfo.Extension.Equals(".xlsm"))
            {
                //Config for ExcelDatareader
                ExcelDataSetConfiguration setConfig = new ExcelDataSetConfiguration();
                ExcelDataTableConfiguration tableConfig = new ExcelDataTableConfiguration();

                setConfig.UseColumnDataType = true;
                if (worksheetName != "")
                {
                    //filter on the specific worksheetname, expect 1 worksheetname per function call.
                    setConfig.FilterSheet = (tableReader, sheetIndex) => (string.Equals(tableReader.Name, worksheetName, StringComparison.OrdinalIgnoreCase));
                }
                
                tableConfig.EmptyColumnNamePrefix = "EmptyColumn";
                tableConfig.UseHeaderRow = true;

                if(startRange != "")
                {
                    var match = Regex.Match(startRange, @"(?<col>[A-Z]+)(?<row>\d+)");
                    var colStr = match.Groups["col"].ToString();
                    var fromCol = colStr.Select((t, i) => (colStr[i] - 64) * Math.Pow(26, colStr.Length - i - 1)).Sum();
                    var fromRow = int.Parse(match.Groups["row"].ToString());

                    int j = 0;
                    tableConfig.FilterRow = rowReader => fromRow <= ++j - 1;
                    tableConfig.FilterColumn = (rowReader, colIndex) => fromCol <= colIndex;
                }

                setConfig.ConfigureDataTable = (tableReader) => tableConfig;


                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                    {
                        result = reader.AsDataSet(setConfig);
                    }
                }

                //This function never expects to return whole workbook as dataset.
                if (result.Tables.Count != 0)
                {
                    result.Tables[0].RemoveEmptyColumns();
                    result.Tables[0].AcceptChanges();

                    return result.Tables[0];
                }
                else
                {
                    throw new ArgumentException("The worksheet name supplied cannot be found in the spreadsheet worksheets");
                }
            }
            else
            {
                Console.WriteLine("Unsupported format for file {0}", filePath);
                return null;
            }
        }

        /// <summary>
        /// Test if an object is a value.
        /// </summary>
        public static bool IsNumber(object value)
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


        public static string CopyToTempFile(string filename)
        {
            string destName = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + Path.GetExtension(filename));

            File.Copy(filename, destName);

            return destName;
        }
        
    }
}
