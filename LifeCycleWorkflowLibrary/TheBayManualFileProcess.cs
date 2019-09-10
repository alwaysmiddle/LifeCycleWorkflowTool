using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace LifeCycleWorkflowLibrary
{
    static class TheBayManualFileProcess
    {
        public static bool ProcessNosCombinedFile(string NosFileName, string templateWb)
        {
            XLWorkbook a = new XLWorkbook(templateWb);
            return false;
        }
    }
}
