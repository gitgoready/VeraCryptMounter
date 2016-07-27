using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeracryptMounterLinux
{
    class Program 
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Environment.Exit(0);
            }

            switch (args[0])
            {
                case "-t":
                    Console.WriteLine("-t gedrückt");
                    break;
                case "-f":
                    Console.WriteLine("-f gedrückt");
                    break;
            }
        }
    }
}
