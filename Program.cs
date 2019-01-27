using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LamePowerz
{
    static class Program
    {
        public static LogTool Log = new LogTool();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.WriteLine("Program started");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
