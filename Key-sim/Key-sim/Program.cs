using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Key_sim
{
    class Program
    {
        const Int32 SW_MINIMIZE = 6;

        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow([In] IntPtr hWnd, [In] Int32 nCmdShow);

        private static void MinimizeConsoleWindow()
        {
            IntPtr hWndConsole = GetConsoleWindow();
            ShowWindow(hWndConsole, SW_MINIMIZE);
        } 

        static void Main(string[] args)
        {
            MinimizeConsoleWindow();
            System.Windows.Forms.SendKeys.SendWait(" ");
        }
    }
}
