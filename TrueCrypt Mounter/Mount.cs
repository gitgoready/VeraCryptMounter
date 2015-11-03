/**
 * <TruecryptMounter. Programm to use Truecrypt drives and containers easier.>
 * Copyright (C) <2009>  <Rafael Grothmann>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * **/
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    internal static class Mount
    {
        private const char Quote = '\u0022';
        //private const string Wipechache = " /w ";
        //private const string Cache = " /c ";
        //private const string Explore = " /e ";
        private const string Beep = " /b ";
        private const string DismountString = " /d ";
        private const string Force = " /f ";
        private const string Keyfile = " /k ";
        private const string Letter = " /l ";
        private const string Mountoption = " /m ";
        private const string MountoptionReadonly = "ro";
        private const string MountoptionRemovable = "rm";
        private const string Password = " /p ";
        private const string Quit = " /q ";
        private const string Silent = " /s ";
        private const string Volume = " /v ";
        private const string Pim = " /pim ";
        private const string Truecrypt = " /tc ";
        private const string Hash = " /hash ";
        private static readonly Config _config = new Config();
        private static readonly ProcessStartInfo Tc = new ProcessStartInfo();
        private static readonly Process Tcprocess = new Process();

        static Mount()
        {
            _config = Singleton<ConfigManager>.Instance.Init(_config);
        }


        internal static int MountDrive(string partition, string driveletter, string keyfile, string password, bool silent,
                                          bool beep, bool force, bool readOnly, bool removable, int iterations)
        {
            int output;
            Tc.FileName = _config.GetValue("Grundeinstellungen", "Truecryptpath", "");

            Tc.RedirectStandardOutput = true;
            Tc.UseShellExecute = false;
            const string status = "Die Vareable ist null oder leer:";
            try
            {
                if (string.IsNullOrEmpty(partition))
                {
                    throw new Exception(status + "(partition)");
                }
                if (string.IsNullOrEmpty(driveletter))
                {
                    throw new Exception(status + "(driveletter)");
                }

                if (string.IsNullOrEmpty(keyfile))
                {
                    throw new Exception(status + "(keyfile)");
                }

                //if (string.IsNullOrEmpty(password))
                //{
                //    throw new Exception(status + "(password)");
                //}
                if (!DrivelettersHelper.IsDriveletterFree(driveletter))
                {
                    throw new Exception("Laufwerksbuchstabe ist belegt");
                }
                if (!string.IsNullOrEmpty(keyfile))
                {
                    if (!File.Exists(keyfile))
                    {
                        throw new Exception("Keyfile nicht vorhanden");
                    }
                }
                if (!File.Exists(Tc.FileName))
                {
                    throw new Exception("TrueCrypt.exe nicht vorhanden");
                }
            }
            catch (Exception e)
            {
                string text = "";
#if DEBUG
                text = "Mount Class";
#endif
#if RELEASE
                text = "Fehler";
#endif
                MessageBox.Show(e.Message, text);
                return 2;
            }
            //
            

            string argumentstring = Letter + driveletter + Password + password +
                                    Quit;

            if (!string.IsNullOrEmpty(keyfile))
                argumentstring += Keyfile + Quote + keyfile + Quote;
            if (silent)
                argumentstring += Silent;
            if (beep)
                argumentstring += Beep;
            if (force)
                argumentstring += Force;
            if (removable)
                argumentstring += Mountoption + MountoptionRemovable;
            if (readOnly)
                argumentstring += Mountoption + MountoptionReadonly;

            
            for(int i = 0 ;iterations >= i; i++)
            {
                string path = Volume + "\\Device\\Harddisk" + i + "\\" + partition;
                Tc.Arguments = path + argumentstring;
# if DEBUG
                DialogResult result = MessageBox.Show(Tc.Arguments, "Mountstring", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Cancel)
                    return 2;
                //Clipboard.SetDataObject(argumentstring, true);
#endif
                try
                {
                    Tcprocess.StartInfo = Tc;
                    Tcprocess.Start();
                    Tcprocess.WaitForExit();
                    output = Tcprocess.ExitCode;
                    Tcprocess.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return 1;
                }
                if (output == 0)
                    return 0;
            }

            return 1;
        }

        public static int MountKeyfileContainer(string path, string driveletter, bool silent, bool beep, bool force,
                                                bool readOnly, bool removable, string hash, bool pim)
        {
            int output;

            Tc.FileName = _config.GetValue("Grundeinstellungen", "Truecryptpath", "");

            Tc.RedirectStandardOutput = true;
            Tc.UseShellExecute = false;
            const string status = "Die Vareable ist null oder leer:";
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception(status + "(path)");
                }

                if (string.IsNullOrEmpty(driveletter))
                {
                    throw new Exception(status + "(driveletter)");
                }
                if (!DrivelettersHelper.IsDriveletterFree(driveletter))
                {
                    throw new Exception("Laufwerksbuchstabe ist belegt");
                }
                if (!File.Exists(Tc.FileName))
                {
                    throw new Exception("TrueCrypt.exe nicht vorhanden");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 2;
            }

            string argumentstring = Volume + path + Letter + driveletter + Quit;

            if (!string.IsNullOrEmpty(hash))
                argumentstring += Hash + Quote + hash + Quote;
            if (pim)
                argumentstring += Pim + Quote + "0" + Quote; 
            if (silent)
                argumentstring += Silent;
            if (beep)
                argumentstring += Beep;
            if (force)
                argumentstring += Force;
            if (readOnly)
                argumentstring += Mountoption + MountoptionReadonly;
            if (removable)
                argumentstring += Mountoption + MountoptionRemovable;
# if DEBUG
            DialogResult result = MessageBox.Show(argumentstring, "Mountstring", MessageBoxButtons.RetryCancel);
            if (result == DialogResult.Cancel)
                return 2;
#endif
            Tc.Arguments = argumentstring;
            try
            {
                Tcprocess.StartInfo = Tc;
                Tcprocess.Start();
                Tcprocess.WaitForExit();
                output = Tcprocess.ExitCode;
                Tcprocess.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }
            return output;
        }

        public static int Dismount(string driveletter, bool silent, bool beep, bool force)
        {
            int output;

            Tc.FileName = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Truecryptpath, "");

            Tc.RedirectStandardOutput = true;
            Tc.UseShellExecute = false;

            const string status = "Die Vareable ist null oder leer:";
            try
            {
                if (string.IsNullOrEmpty(driveletter))
                {
                    throw new Exception(status + "(driveletter)");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }

            string argumentstring = DismountString + driveletter + Quit;

            if (silent)
                argumentstring += Silent;
            if (beep)
                argumentstring += Beep;
            if (force)
                argumentstring += Force;
# if DEBUG
            DialogResult result = MessageBox.Show(argumentstring, "Mountstring", MessageBoxButtons.RetryCancel);
            if (result == DialogResult.Cancel)
                return 2;
#endif
            Tc.Arguments = argumentstring;
            try
            {
                Tcprocess.StartInfo = Tc;
                Tcprocess.Start();
                Tcprocess.WaitForExit();
                output = Tcprocess.ExitCode;
                Tcprocess.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }
            return output;
        }

        public static int MountContainer(string path, string driveletter, string keyfile, string password, bool silent,
                                         bool beep, bool force, bool readOnly, bool removable, bool tc, string pim, string hash)
        {
            int output = 2;

            Tc.FileName = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Truecryptpath, "");

            Tc.RedirectStandardOutput = true;
            Tc.UseShellExecute = false;
            const string status = "Die Vareable ist null oder leer:";
            try
            {

                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception(status + "(path)");
                }

                if (string.IsNullOrEmpty(driveletter))
                {
                    throw new Exception(status + "(driveletter)");
                }

                //if (string.IsNullOrEmpty(password))
                //{
                //    throw new Exception(status + "(password)");
                //}
                if (!DrivelettersHelper.IsDriveletterFree(driveletter))
                {
                    throw new Exception("Laufwerksbuchstabe ist belegt");
                }
                if (!File.Exists(Tc.FileName))
                {
                    throw new Exception("TrueCrypt.exe nicht vorhanden");
                }
            }
            catch (Exception e)
            {
                string text = "";
#if DEBUG
                text = "Mount Class";
#endif
#if RELEASE
                text = "Fehler";
#endif
                MessageBox.Show(e.Message, text);
                return 2;
            }
            string argumentstring = Volume + path + Letter + driveletter + Password + password + Quit;

            if (!string.IsNullOrEmpty(keyfile))
                argumentstring += Keyfile + Quote + keyfile + Quote;
            if (!string.IsNullOrEmpty(pim))
                argumentstring += Pim + Quote + pim + Quote;
            if (!string.IsNullOrEmpty(hash))
                argumentstring += Hash + Quote + hash + Quote;
            if (silent)
                argumentstring += Silent;
            if (beep)
                argumentstring += Beep;
            if (force)
                argumentstring += Force;
            if (readOnly)
                argumentstring += Mountoption + MountoptionReadonly;
            if (removable)
                argumentstring += Mountoption + MountoptionRemovable;
            if (tc)
                argumentstring += Truecrypt;

# if DEBUG
            DialogResult result = MessageBox.Show(argumentstring, "Mountstring", MessageBoxButtons.RetryCancel);
            if (result == DialogResult.Cancel)
                return 2;
            //Clipboard.SetDataObject(argumentstring, true);
#endif
            Tc.Arguments = argumentstring;
            try
            {
                Tcprocess.StartInfo = Tc;
                Tcprocess.Start();
                Tcprocess.WaitForExit();
                output = Tcprocess.ExitCode;
                Tcprocess.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }
            return output;
        }
    }
}