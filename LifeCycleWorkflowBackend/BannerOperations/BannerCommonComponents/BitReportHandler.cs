using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ProcessManagement;
using System.Diagnostics;
using LifeCycleWorkflowBackend.Utilities;

namespace LifeCycleWorkflowBackend.BannerOperations
{
    public class BitReportHandler
    {
        private System.Data.DataTable _dt = new System.Data.DataTable();
        private string _filename;

        /// <summary>
        /// Accepts all excel file formats, will eliminate any spacings between data columns.
        /// </summary>
        public BitReportHandler(string fileName)
        {
            try
            {
                if (Path.GetExtension(fileName) == ".csv")
                {
                    _filename = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".xlsx");
                    this.ConvertCsvToExcel(fileName, _filename);
                }
                else
                {
                    _filename = ExcelUtilities.CopyToTempFile(fileName);
                }

                this.TrimBitReport(_filename);
            }
            catch (Exception)
            {
                //TODO write expcetion to file
            }
        }

        public System.Data.DataTable GetReportAsDatatable()
        {
            return _dt;           
        }

        /// <summary>
        /// BIT report formatting is altered on server side with incorrect spacing.
        /// This method meant to eliminate spacing and look for table start with value "DMM" as top left most cell.
        /// </summary>
        private void TrimBitReport(string excelFileName)
        {
            Application excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);

            Workbook wb = excelApp.Workbooks.Open(excelFileName);
            Worksheet ws = wb.Worksheets[1];
            excelApp.DisplayAlerts = false;

            try
            {
                ws.UsedRange.UnMerge();
                Range topLeftCell = ws.FindCellBasedOnValue<string>("DMM", matchFullCell: XlLookAt.xlWhole);
                ws.ClearAllRowsAboveRow(topLeftCell.Row);

                Range totalCell = ws.FindCellBasedOnValue<string>("Total", matchFullCell: XlLookAt.xlWhole);
                totalCell.EntireRow.Delete(XlDeleteShiftDirection.xlShiftUp);
                ws.UsedRange.SpecialCells(XlCellType.xlCellTypeBlanks).Delete(XlDeleteShiftDirection.xlShiftToLeft);
                wb.Save();
            }
            catch (Exception ex)
            {
                //TODO write exceptions
            }
            finally
            {
                wb.Close();
                excelApp.DisplayAlerts = true;
                excelApp.Quit();
                
                if (ws != null) Marshal.ReleaseComObject(ws);
                if (wb != null) Marshal.ReleaseComObject(wb);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
                excelProcess.Dispose();
            }

            _dt = ExcelUtilities.ReadExcelDataFileAsTable(excelFileName, 1);

            Console.WriteLine(DumpDataTable(_dt));
        }

        /// <summary>
        /// Fills bit report datatable with another table, the table's data types are expected to be the same on each column.
        /// </summary>
        /// <returns>A datatable with result of left outer join.</returns>
        public System.Data.DataTable JoinWithDataTable(System.Data.DataTable table)
        {
            var rowsToDelete = from row in table.AsEnumerable()
                               where row["DMM"].ToString().IndexOf("Total", StringComparison.OrdinalIgnoreCase) >= 0
                               select row;

            //delete total row, first store it in array to only process data in tables.
            object[] totalRow = rowsToDelete.FirstOrDefault().ItemArray.ToArray();

            foreach (DataRow r in rowsToDelete.ToList())
            {
                table.Rows.Remove(r);
            }
            table.AcceptChanges();

            //cleanse both tables of null rows
            table.AsEnumerable().
                Where(row => row["DMM"] == DBNull.Value || String.IsNullOrEmpty(row["DMM"].ToString().Trim()))
                            .ToList()
                            .ForEach(row => row.Delete());
            table.AcceptChanges();

            _dt.AsEnumerable().
                Where(row => row["DMM"] == DBNull.Value || String.IsNullOrEmpty(row["DMM"].ToString().Trim()))
                            .ToList()
                            .ForEach(row => _dt.Rows.Remove(row));
            _dt.AcceptChanges();

            //Console.WriteLine(DumpDataTable(_dt));
            //Console.WriteLine(DumpDataTable(table));

            System.Data.DataTable tblJoined = new System.Data.DataTable();

            tblJoined = (from rowA in table.AsEnumerable()
                         join rowB in _dt.AsEnumerable()
                         on rowA.Field<object>("DMM").ToString() equals rowB.Field<object>("DMM").ToString() into temp
                         from row in temp.DefaultIfEmpty(rowA)
                         select row).CopyToDataTable();

            System.Data.DataTable dtCloned = tblJoined.Clone();
            dtCloned.Columns[0].DataType = typeof(string);
            dtCloned.Columns[1].DataType = typeof(string);
            for (int i = 2; i < dtCloned.Columns.Count; i++)
            {
                dtCloned.Columns[i].DataType = typeof(double);
            }

            foreach (DataRow row1 in tblJoined.Rows)
            {
                dtCloned.ImportRow(row1);
            }
            tblJoined = null;

            DataRow toInsert = dtCloned.NewRow();
            toInsert[0] = totalRow[0];

            for (int i = 1; i < Math.Min(totalRow.Length, dtCloned.Columns.Count); i++)
            {
                if (totalRow[i] != DBNull.Value)
                {
                    double sum = 0;

                    foreach (DataRow row in dtCloned.Rows)
                    {
                        if (row[i] != DBNull.Value)
                        {
                            sum += Convert.ToDouble(row[i]);
                        }
                    }

                    toInsert[i] = sum;
                }
            }

            
            dtCloned.Rows.InsertAt(toInsert, 0);
            
            return dtCloned;
        }

        private void ConvertCsvToExcel(string csvFilePath, string excelOutputFile)
        {
            if (!File.Exists(csvFilePath)) throw new FileNotFoundException(csvFilePath);

            Application excelApp = new Application();
            ExcelProcessControl excelProcess = new ExcelProcessControl(excelApp);

            Workbook wb = excelApp.Workbooks.Open(csvFilePath);
            Worksheet ws = wb.Worksheets[1];
            excelApp.DisplayAlerts = false;

            try
            {    
                ws.Select();
                wb.SaveAs(Filename: excelOutputFile, FileFormat: XlFileFormat.xlOpenXMLWorkbook, XlSaveAsAccessMode.xlExclusive,
                          ConflictResolution: XlSaveConflictResolution.xlLocalSessionChanges);
                
            }
            catch (Exception ex)
            {
                //TODO write exceptions
            }
            finally
            {
                wb.Close();
                excelApp.DisplayAlerts = true;
                excelApp.Quit();

                if (ws != null) Marshal.ReleaseComObject(ws);
                if (wb != null) Marshal.ReleaseComObject(wb);
                if(excelApp != null) Marshal.ReleaseComObject(excelApp);
                excelProcess.Dispose();
            }
        }

        public static string DumpDataTable(System.Data.DataTable table)
        {
            string data = string.Empty;
            StringBuilder sb = new StringBuilder();

            if (null != table && null != table.Rows)
            {
                foreach (DataRow dataRow in table.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        sb.Append(item);
                        sb.Append(',');
                    }
                    sb.AppendLine();
                }

                data = sb.ToString();
            }
            return data;
        }
    }
}
