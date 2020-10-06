using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LifeCycleWorkflowBackend.Utilities
{
    public static class ExcelUtilities
    {
        /// <summary>
        /// Read excelfile using exceldatareader dependency into datatable. Capable of reading excel file format xls, xlsx, xlsm, xlsb, csv.
        /// </summary>
        public static System.Data.DataTable ReadExcelDataFileAsTable(string filePath, int worksheetNum = 1, string startRange = "")
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
            if (startRange != "") {
                if(!IsValidExcelCellAddress(startRange)) throw new ArgumentException(String.Format("{0} is not a valid single cell address", startRange));
            }

            DataSet result;
            const string EMPTY_COLUMN_PREFIX = "Empty_Column";

            FileInfo fInfo = new FileInfo(filePath);
            if (fInfo.Extension.Equals(".csv"))
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                    {
                        result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            UseColumnDataType = true,
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {
                                EmptyColumnNamePrefix = EMPTY_COLUMN_PREFIX,
                                UseHeaderRow = true
                            }
                        });
                    }
                }

                result.Tables[0].RemoveColumnsWithPrefix(EMPTY_COLUMN_PREFIX);
                
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

                tableConfig.EmptyColumnNamePrefix = EMPTY_COLUMN_PREFIX;
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
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        result = reader.AsDataSet(setConfig);
                    }
                }

                //This function never expects to return whole workbook as dataset.
                if (result.Tables.Count != 0)
                {
                    result.Tables[0].RemoveColumnsWithPrefix(EMPTY_COLUMN_PREFIX);

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
            if (startRange != "")
            {
                if (!IsValidExcelCellAddress(startRange)) throw new ArgumentException(String.Format("{0} is not a valid single cell address", startRange));
            }

            DataSet result;
            const string EMPTY_COLUMN_PREFIX = "Empty_Column";

            FileInfo fInfo = new FileInfo(filePath);
            if (fInfo.Extension.Equals(".csv"))
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                    {
                        result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            UseColumnDataType = true,
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {
                                EmptyColumnNamePrefix = EMPTY_COLUMN_PREFIX,
                                UseHeaderRow = true
                            }
                        });
                    }
                }

                result.Tables[0].RemoveColumnsWithPrefix(EMPTY_COLUMN_PREFIX);

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
                
                tableConfig.EmptyColumnNamePrefix = EMPTY_COLUMN_PREFIX;
                tableConfig.UseHeaderRow = true;

                if(startRange != "")
                {
                    startRange = startRange.Split(':')[0];
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
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        result = reader.AsDataSet(setConfig);
                    }
                }

                //This function never expects to return whole workbook as dataset.
                if (result.Tables.Count != 0)
                {
                    result.Tables[0].RemoveColumnsWithPrefix(EMPTY_COLUMN_PREFIX);

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
        /// Read worksheet range as datatable.
        /// </summary>
        public static System.Data.DataTable ReadWorksheetRangeAsTable(Worksheet ws, string readingRange)
        {
            if (!IsValidExcelRangeAddress(readingRange))
            {
                //TODO error reading address from invalid range
                return null;
            }

            System.Data.DataTable dt = new System.Data.DataTable();

            Range sheetRange = ws.Range[readingRange];

            object[,] data = sheetRange.Value2;

            dt = ArraytoDatatable(data, useFirstRowAsHeader: true, useOneBasedIndex: true);

            return dt;
        }


        /// <summary>
        /// Complete column like address with top row and last row. There is optional start row
        /// </summary>
        public static string AutoCompleteExcelColumnRange(Worksheet ws, string excelAddress, int startRow = -1)
        {
            if (!IsValidExcelRangeAddress(excelAddress)) throw new ArgumentException(String.Format("{0} is not a valid excel range address", excelAddress));

            string pattern = @"(\$?[A-Za-z]{1,3})\:(\$?[A-Za-z]{1,3})";

            bool match = Regex.IsMatch(excelAddress, pattern);

            if (match)
            {
                if (startRow == -1)
                {
                    startRow = ws.UsedRange.Cells[1, 1].Row;
                }

                string[] arr = excelAddress.Split(':');

                int lastRow = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;

                if (startRow < lastRow)
                {
                    excelAddress = arr[0] + startRow + ":" + arr[1] + lastRow;
                }
                else
                {
                    excelAddress = arr[0] + startRow + ":" + arr[1] + (++startRow);
                }
            }

            return excelAddress;
        }

        /// <summary>
        /// Expects excel range address in format like "AA1:BBB1000000", or "A:FD".
        /// </summary>
        public static bool IsValidExcelRangeAddress(string excelAddress)
        {
            string pattern = @"(\$?[A-Za-z]{1,3})(\$?[0-9]{1,7})\:(\$?[A-Za-z]{1,3})(\$?[0-9]{1,7})";
            bool match = Regex.IsMatch(excelAddress, pattern);

            //check for case where single cell address is written in range format, example: "E200:E200"
            if (match)
            {
                string[] arr = excelAddress.Split(':');
                if (string.Equals(arr[0], arr[1], comparisonType: StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            else
            {
                pattern = @"(\$?[A-Za-z]{1,3})\:(\$?[A-Za-z]{1,3})";

                match = Regex.IsMatch(excelAddress, pattern);
            }

            return match;
        }

        /// <summary>
        /// Expects single cell address in format like "AA150", or "A1:A1".
        /// </summary>
        public static bool IsValidExcelCellAddress(string excelAddress)
        {
            string pattern = @"(\$?[A-Za-z]{1,3})(\$?[0-9]{0,7})\:(\$?[A-Za-z]{1,3})(\$?[0-9]{0,7})";
            bool match = Regex.IsMatch(excelAddress, pattern);

            //check for case where single cell address is written in range format, example: "E200:E200"
            if (match)
            {
                string[] arr = excelAddress.Split(':');
                if (string.Equals(arr[0], arr[1], comparisonType: StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            pattern = @"(\$?[A-Za-z]{1,3})(\$?[0-9]{1,6})";
            match = Regex.IsMatch(excelAddress, pattern);

            return match;
        }

        public static System.Data.DataTable ArraytoDatatable(Object[,] data, bool useFirstRowAsHeader = true, bool useOneBasedIndex = false)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            int newI;

            if (useFirstRowAsHeader)
            {
                string columnName;
                newI = 1;

                // Loading columns into datatable
                for (int k = 0; k < data.GetLength(1); k++)
                {
                    int rowNum;
                    int newK;
                    if (useOneBasedIndex)
                    {
                        rowNum = 1;
                        newK = k + 1;
                    }
                    else
                    {
                        rowNum = 0;
                        newK = k;
                    }

                    if (data[rowNum, newK] == null || data[rowNum, newK] == DBNull.Value)
                    {
                        columnName = "Empty_Column" + (k + 1).ToString();
                    }
                    else
                    {
                        columnName = data[rowNum, newK].ToString();
                    }

                    dt.Columns.Add(columnName, System.Type.GetType("System.Object"));
                }
            }
            else
            {
                newI = 0;
                for (int i = 0; i < data.GetLength(1); i++)
                {
                    dt.Columns.Add("Column" + (i + 1), System.Type.GetType("System.Object"));
                }
            }


            // Filling in Data
            for (var i = newI; i < data.GetLength(0); ++i)
            {
                DataRow row = dt.NewRow();
                for (var j = 0; j < data.GetLength(1); ++j)
                {
                    if (useOneBasedIndex)
                    {
                        row[j] = data[(i + 1), (j + 1)];
                    }
                    else
                    {
                        row[j] = data[i, j];
                    }

                }
                dt.Rows.Add(row);
            }

            return dt;
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
