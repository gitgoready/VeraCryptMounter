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
            // Get Singelton for config
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            ValidateMount vm = new ValidateMount();
            MountVareables mvd;
            string pnpid = device;
            int start;

            device = device.Replace(@"\\", @"\");            
            start = pnpid.IndexOf("USBSTOR");
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
                    if (_config.GetValue(section, ConfigTrm.Drive.Automountusb, false))
                    {
                        try
                        {
                            mvd = vm.ValidateMountDrive(section, _language);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        Mount.MountDrive(mvd.partitionlist, mvd.driveletter, mvd.key, mvd.password, mvd.silent, mvd.beep, mvd.force, mvd.readOnly, mvd.removalbe, mvd.pim, mvd.hash, mvd.tc);
                        
                    }
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
    }
}

