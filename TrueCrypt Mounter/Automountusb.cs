using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    public static class Automountusb
    {
        private static Config _config = new Config();
        private const string LanguageRegion = "AutomountUsb";

        private static string _language;
        private static string _password;
        private static string _pim;

        public static void MountUsb(string device)
        {
            device = device.Replace(@"\\", @"\");
            
            // Get Singelton for config
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            string pnpid = device;
            var start = pnpid.IndexOf("USBSTOR");
            pnpid = pnpid.Substring(start, pnpid.Length - start -1);

#if DEBUG
            MessageBox.Show(pnpid);
#endif
            string[] sections = _config.GetSectionNames();

            foreach (string section in sections)
            {
                var configPnPid = _config.GetValue(section, ConfigTrm.Drive.Pnpdeviceid, "");
                var configtype = _config.GetValue(section, ConfigTrm.Mainconfig.Type, "");

                if (configtype == "Drive" && configPnPid == pnpid)
                {
                    var dmodel = _config.GetValue(section, ConfigTrm.Drive.Diskmodel, "");
#if DEBUG
                    MessageBox.Show(section);
#endif
                    if (_config.GetValue(section, ConfigTrm.Drive.Automountusb, false)) MountDrive(section);
                }
            }

        }

        /// <summary>
        /// Get list of drives which have the automount label.
        /// </summary>
        /// <returns>List of drives</returns>
        private static List<string> GetAutoDrives()
        {
            List<string> drives = new List<string>();

            string[] sections = _config.GetSectionNames();

            foreach (string section in sections)
            {
                if (_config.GetValue(section, ConfigTrm.Mainconfig.Type, "") == "Drive")
                {
                    if (_config.GetValue(section, ConfigTrm.Container.Automountusb, false))
                    {
                        drives.Add(section);
                    }
                }
            }
            return drives;
        }

        /// <summary>
        /// Get list of containers which have the automount label.
        /// </summary>
        /// <returns>List of containers</returns>
        private static List<string> GetAutoContainers()
        {
            List<string> containers = new List<string>();

            string[] sections = _config.GetSectionNames();

            foreach (string section in sections)
            {
                if (_config.GetValue(section, ConfigTrm.Mainconfig.Type, "") == "Container")
                {
                    if (_config.GetValue(section, ConfigTrm.Drive.Automountusb, false))
                    {
                        containers.Add(section);
                    }
                }
            }
            return containers;
        }
        

        private static void MountDrive(string name)
        {
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");

            bool silent = _config.GetValue(ConfigTrm.Mainconfig.Section, "Silentmode", true);
            const bool beep = false;
            const bool force = false;
            string key = null;
            List<string> parlist = new List<string>();

            string dletter = _config.GetValue(name, ConfigTrm.Drive.Driveletter, "");
            _password = _config.GetValue(name, ConfigTrm.Drive.Password, null);
            _pim = _config.GetValue(name, ConfigTrm.Drive.Pim, null);

            //string partition = _config.GetValue(name, ConfigTrm.Drive.Partition, "");
            bool removable = _config.GetValue(name, ConfigTrm.Drive.Removable, false);
            bool readOnly = _config.GetValue(name, ConfigTrm.Drive.Readonly, false);
            string hash = _config.GetValue(name, ConfigTrm.Drive.Hash, "");
            bool tc = _config.GetValue(name, ConfigTrm.Drive.Truecrypt, false);

            // check if disknumber has changed. If it has correct it
            string diskmodel = _config.GetValue(name, ConfigTrm.Drive.Diskmodel, null);
            string diskserial = _config.GetValue(name, ConfigTrm.Drive.Diskserial, null);
            string disknumber = _config.GetValue(name, ConfigTrm.Drive.Disknumber, null);
            string partnumber = _config.GetValue(name, ConfigTrm.Drive.Partnumber, null);
            string pnpdeviceid = _config.GetValue(name, ConfigTrm.Drive.Pnpdeviceid, null);

            WmiDriveInfo info = new WmiDriveInfo();

            try
            {
                // Test if disk is connected on machine
                if (!info.CheckDiskPresent(pnpdeviceid))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "DiskNotPresentMessage", _language) + "\"" + diskmodel + "\"");
                }

                //test if keyfilekontainer is mounted
                bool nokeyfile = _config.GetValue(name, ConfigTrm.Drive.Nokeyfile, true);
                string keyfilepath;
                if (_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Nokeyfile, true))
                {
                    keyfilepath = _config.GetValue(name, ConfigTrm.Drive.Keyfile, "");
                }
                else
                {
                    keyfilepath =
                    _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "") +
                    _config.GetValue(name, ConfigTrm.Drive.Keyfile, "");
                }

# if DEBUG
                MessageBox.Show(keyfilepath, "Path to Keyfile");
# endif
                if (!nokeyfile && !File.Exists(keyfilepath))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "NoKeyfileMessage", _language));
                }

                // If a password is cached, the paswordform isn´t show 
                if (string.IsNullOrEmpty(_password))
                {
                    try
                    {
                        ShowPassworteingabe(ConfigTrm.Drive.Typename, _config.GetValue(name, ConfigTrm.Drive.Pimuse, false));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
                /** test if password is empty**/
                if (string.IsNullOrEmpty(_password) && _config.GetValue(name, ConfigTrm.Drive.Nokeyfile, true))
                {
                    throw new Exception("Leeres Passwort ist nicht erlaubt.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Switch nokeyfile. if it is set key = null else key = keyfile;

            if (!_config.GetValue(name, ConfigTrm.Drive.Nokeyfile, true))
            {
                key = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "") +
                         _config.GetValue(name, ConfigTrm.Drive.Keyfile);
            }
            // get disknumber from PNPdeviceid if ther is not one use saved disknumber BAD

            List<DriveInfo> list = info.GetDriveinfo(pnpdeviceid);

            if (list.Count >= 1)
            {
                parlist.Add("\\Device\\Harddisk" + list[0].Index + "\\Partition" + partnumber);
            }
            else
            {
                parlist.Add("\\Device\\Harddisk" + disknumber + "\\Partition" + partnumber);
            }

            int ret = Mount.MountDrive(parlist.ToArray(), dletter, key, _password, silent, beep, force, readOnly, removable, _pim, hash, tc);

            if (ret != 0)
            {
                var retmes = MessageBox.Show(LanguagePool.GetInstance().GetString(LanguageRegion, "Mountfail", _language),"hallo",MessageBoxButtons.RetryCancel,MessageBoxIcon.Question);
                if (retmes == DialogResult.Retry)
                {
                    _password = null;
                    _pim = null;
                    MountDrive(name);
                }
            }
            return;
        }

        /// <summary>
        /// Window for password input and pim
        /// </summary>
        /// <param name="chosen">string for drive or container</param>
        /// <param name="pim">bool pim used or not</param>
        public static bool ShowPassworteingabe(string chosen, bool pim)
        {
            var passwortDialog = new Passwordinput(chosen, pim);

            // Call Passwordinput form.
            DialogResult res = passwortDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                _password = passwortDialog._password;
                _pim = passwortDialog._pim;
                passwortDialog.Dispose();
                return true;
            }
            passwortDialog.Dispose();
            return false;
        }

    }
}

