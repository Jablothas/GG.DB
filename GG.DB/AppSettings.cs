using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GoodGameDB
{
    internal class AppSettings
    {
        public static void Read()
        {
            using (StreamReader sr = new StreamReader("settings.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("DarkMode=false"))
                    {
                        Main.DarkMode = false;
                    }
                    if (line.Contains("DarkMode=true"))
                    {
                        Main.DarkMode = true;
                    }
                    if (line.Contains("ShowReplays=false"))
                    {
                        Database.ShowReplays = false;
                    }
                    if (line.Contains("ShowReplays=true"))
                    {
                        Database.ShowReplays = true;
                    }
                }
            }
        }
    }
}
