﻿/* 
   LamePowerz (C) Dz3n 2019
   GitHub: https://github.com/feel-the-dz3n/lamepowerz
   
   File: Log.cs
   Why:  Log stuff for modules
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LamePowerz
{
    public class LogTool : IDisposable
    {
        public enum Modules
        {
            LamePowerz,
            BruteRadmin
        }

        public Modules Module = Modules.LamePowerz;
        private StreamWriter writer = null;
        
        public LogTool(Modules module = Modules.LamePowerz, string betterName = null)
        {
            Module = module;

            if(betterName == null)
                writer = new StreamWriter($"{module.ToString()}_{DateTime.Now.ToString().Replace(":", ".")}.log");
            else
                writer = new StreamWriter($"{betterName}_{DateTime.Now.ToString().Replace(":", ".")}.log");

            writer.AutoFlush = true;
        }

        public void Write(object data, ConsoleColor color = ConsoleColor.Black)
        {
            writer.Write(data);
        }

        public void WriteLine(object data, ConsoleColor color = ConsoleColor.Black)
        {
            writer.WriteLine(data);
        }

        public void Dispose()
        {
            writer.Flush();
            writer.Dispose();
        }
    }
}
