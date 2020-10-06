using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManagement
{
    class ExcelProcessControl : Job
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private uint _pid = 0;

        public ExcelProcessControl(Application excelApp)
        {
            int hWnd = excelApp.Hwnd;
            
            GetWindowThreadProcessId(new IntPtr(hWnd), out _pid);
            base.AddProcess(Process.GetProcessById((int)_pid).Handle);
        }
    }
}
