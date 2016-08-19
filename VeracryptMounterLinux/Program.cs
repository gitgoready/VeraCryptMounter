using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeracryptMounterLinux
{
    class Program 
    {
        private static string password;


        static void Main(string[] args)
        {
            string description = Properties.Settings.Default.Description;
            if (args.Length <= 0)
            {
                Console.WriteLine(description);
                password = PasswordInput();
                Console.WriteLine(password);
                Password_helper.Password = password;
                bool check = Password_helper.Check_password();
                Console.WriteLine(check);
                Console.ReadKey();
                Environment.Exit(0);
            }

            switch (args[0])
            {
                case "-l":
                    Console.WriteLine(description);
                    Console.WriteLine("-l gedrückt");
                    password = PasswordInput();
                    Console.WriteLine();

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
