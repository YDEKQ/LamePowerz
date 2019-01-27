using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LamePowerz
{
    static class Program
    {
        public static List<Form> AllForms = new List<Form>();
        public static LogTool Log = new LogTool();
        public static string[] Arguments = { };
        public static Version Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Log.WriteLine("Program started");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args != null)
                Arguments = args;

            for(int i = 0; i < Arguments.Length; i++)
            {
                string arg = Arguments[i];

                if (arg.ToLower() == "radmin")
                {

                }
                else
                {
                    PrintHelp();
                    Environment.Exit(1);
                }
            }
            
            Application.Run(new MainMenu());
        }

        private static void PrintHelp()
        {
            Log.WriteLine("LamePowerz v" + Version);
            Log.WriteLine("");
        }
    }
}
