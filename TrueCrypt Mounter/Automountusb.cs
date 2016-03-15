using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    public static class Automountusb
    {
        private static Config _config = new Config();

        public static void MountUsb(string device)
        {
            device = device.Replace(@"\\", @"\");
            
            // Get Singelton for config
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            string pnpid = device;
            var start = pnpid.IndexOf("USBSTOR");
            pnpid = pnpid.Substring(start, pnpid.Length - start -1);
            
            //TODO extract device info from string to get wmi info 
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
                    MessageBox.Show(dmodel);
#endif
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

