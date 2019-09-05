using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCycleWorkflowLibrary
{
    /// <summary>
    /// This class is repsonsible to transform the data from bay microstrategy report (BIT) into datatable format.
    /// </summary>
    class MicrostrategyConnector
    {
        /// <summary>
        /// BIT report formatting is altered on server side, this class target a value to search for then convert rest of the report into single delimited csv format.
        /// Then parsing the single delimieted csv file into datatable.
        /// </summary>
        /// <param name="filePath">Excel file path that contains information from BIT report.</param>
        /// <param name="findThisOnSheet">Look for this value on first sheet of passed workbook.</param>
        /// <returns></returns>
        public static DataTable ReadBitReport(string filePath, string findThisOnSheet)
        {
            DataTable dt = new DataTable();


            return dt;
        }
    }
}
