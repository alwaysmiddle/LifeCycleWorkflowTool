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
            if (!IsValidExcelCellAddress(startRange)) throw new ArgumentException(String.Format("{0} is not a valid single cell address", startRange));

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
            if (!IsValidExcelCellAddress(startRange)) throw new ArgumentException(String.Format("{0} is not a valid single cell address", startRange));

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

            // Loading columns into datatable
            for (int i = 1; i <= data.GetLength(1); i++)
            {
                var Column = new DataColumn();
                Column.DataType = System.Type.GetType("System.Object");
                if (data[1, i] == null || data[1, i] == DBNull.Value)
                {
                    Column.ColumnName = "Empty_Column" + i.ToString();
                }
                else
                {
                    Column.ColumnName = data[1, i].ToString();
                }
                dt.Columns.Add(Column);
            }

            // Filling in Data

            for (int rCnt = 2; rCnt <= data.GetLength(0); rCnt++)
            {
                DataRow row = dt.NewRow();

                for (int cCnt = 1; cCnt <= data.GetLength(1); cCnt++)
                {
                    row[cCnt - 1] = data[rCnt, cCnt];
                }

                dt.Rows.Add(row);
            }

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
