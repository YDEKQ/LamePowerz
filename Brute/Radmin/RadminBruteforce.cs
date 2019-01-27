using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LamePowerz.Brute
{
    public class Radmin
    {
        public static string[] Tasks =
        {
            "brute \"cfg=FileName\" ",
            "brute \"ip=FileNameOrSingleIp\" *\"threads=5\" *\"timeout=5000\""
        };

        public static void Initialize()
        {

        }

        public static bool CheckCombination(IPAddress address, string UserName, string Password)
        {
            return false;
        }
    }
}
