using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CubePower
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var current = Process.GetCurrentProcess();
            var v = Process.GetProcessesByName(current.ProcessName);
            if (v.Length > 1)
            {
                foreach (Process proc in v)
                {
                    if (proc.Id == current.Id) continue;
                    //ShowWindow(proc.MainWindowHandle, 9 /* SW_RESTORE */);
                    SetForegroundWindow(proc.MainWindowHandle);
                    return;
                }
            }

            var setting = new UserSetting();
            setting.Load();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(setting));
            setting.Save();
        }

        [DllImport("User32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
