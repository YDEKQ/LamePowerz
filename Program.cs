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
        private static string[] AvailableModules = { "radmin" };

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

        private static void PrintHelp(string mod = null, string task = null)
        {
            Log.WriteLine("LamePowerz v" + Version);
            Log.WriteLine("");
            Log.WriteLine("Usage: LamePowerz [module] [task] \"[paramX]=[valueX]\"");
            Log.WriteLine("");

            if (mod == null)
            {
                Log.Write("Available modules: ");
                foreach (var module in AvailableModules)
                    Log.Write(module + " ");
                Log.WriteLine("");

                Log.WriteLine("To get module help, use:");
                Log.WriteLine("LamePowerz [module] help");
                Log.WriteLine("");
                Log.WriteLine("Example: LamePowerz  radmin  help");
                Log.WriteLine("                     ^module ^task");
                Log.WriteLine("");
            }
            else
            {
                Log.WriteLine($"{mod} tasks:");
                Log.WriteLine("");
                if (mod.ToLower() == "radmin")
                {
                    foreach (var t in Brute.Radmin.Tasks)
                        Log.WriteLine(t);
                }

                Log.WriteLine("");
                Log.WriteLine("Arguments marked with * are optional.");
                Log.WriteLine("");
            }
        }
    }
}
