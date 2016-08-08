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
            string description = Properties.Settings.Default.Description;
            if (args.Length <= 0)
            {
                Console.WriteLine(description);
                Environment.Exit(0);
            }

            switch (args[0])
            {
                case "-l":
                    Console.WriteLine(description);
                    Console.WriteLine("-l gedrückt");
                    Console.WriteLine(PasswordInput());
                    break;
                case "-f":
                    Console.WriteLine(description);
                    Console.WriteLine("-f gedrückt");
                    break;
            }
        }

        private static string PasswordInput()
        {
            Console.WriteLine(Properties.Settings.Default.Stringpasswordinput);
            string passwort = "";
            ConsoleKeyInfo Key;

            do
            {
                Key = Console.ReadKey();

                if (Key.Key == ConsoleKey.Backspace)
                {
                    if (passwort.Length != 0)
                    {
                        Console.Write(' ');
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        passwort = passwort.Substring(0, passwort.Length - 1);
                    }
                }
                else if (Key.Key != ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);

                    if (Convert.ToInt32(Key.KeyChar) != 0)
                    {
                        Console.Write('*');
                        passwort += Key.KeyChar;
                    }
                }
            }

            while (Key.Key != ConsoleKey.Enter && passwort.Length < 33);

            return passwort;
        }
    }
}
