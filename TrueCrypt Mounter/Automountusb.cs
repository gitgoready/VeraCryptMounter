using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Get the devices with "automount usb" from config and mount them if it is pluged in.
    /// </summary>
    public static class Automountusb
    {
        private static Config _config = new Config();
        private const string LanguageRegion = "Main";
        private static string _language;

        //TODO  Mount for Container and check for partition

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnpid"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void MountUsb(string pnpid)
        {
            if (string.IsNullOrEmpty(pnpid))
                throw new ArgumentNullException("pnpid");
            
            // Get Singelton for config
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            ValidateMount vm = new ValidateMount();
            MountVareables mvd;
            int start;

            try
            {
                pnpid = pnpid.Replace(@"\\", @"\");
                start = pnpid.IndexOf("USBSTOR");
                pnpid = pnpid.Substring(start, pnpid.Length - start - 1);
            }
            catch (Exception ex)
            {
                pnpid = "";
            }
            

#if DEBUG
            MessageBox.Show(pnpid);
#endif
            string[] sections = _config.GetSectionNames();

            foreach (string section in sections)
            {
                string configPnPid = _config.GetValue(section, ConfigTrm.Drive.Pnpdeviceid, "");
                string configtype = _config.GetValue(section, ConfigTrm.Mainconfig.Type, "");

                if (configtype.Equals("Drive") && configPnPid.Equals(pnpid))
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

