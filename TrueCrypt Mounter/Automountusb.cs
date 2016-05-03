using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Get the devices with "automount usb" from config and mount them if it is pluged in.
    /// </summary>
    public class Automountusb
    {
        private static Config _config = new Config();
        private const string LanguageRegion = "Main";
        private static string _language;

        /// <summary>
        /// Name in config for mounted drive
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// state if mount succeed.
        /// </summary>
        public bool State { get; set; }

        //TODO check for partition

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnpid"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Automountusb MountUsb(string pnpid)
        {
            if (string.IsNullOrEmpty(pnpid))
                throw new ArgumentNullException("pnpid");

            // Get Singelton for config
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            ValidateMount vm = new ValidateMount();
            pnpid = pnpid.Replace(@"\\", @"\");
            string[] stringindex = { "USBSTOR", "SCSI\\DISK" };
            MountVareables mvd;
            State = false;
            int start;

            foreach (string sindex in stringindex)
            {
                if (pnpid.Contains(sindex))
                {
                    try
                    {                     
                        start = pnpid.IndexOf(sindex);
                        pnpid = pnpid.Substring(start, pnpid.Length - start - 1);
                    }
                    catch (Exception)
                    {
                        pnpid = "";
                    }
                }
            }

                    

#if DEBUG
            MessageBox.Show(pnpid);
#endif
            string[] sections = _config.GetSectionNames();
            string configPnPid = "";

            foreach (string section in sections)
            {
                Name = section;
                string configtype = _config.GetValue(section, ConfigTrm.Drive.Type, "");

                if (configtype.Equals("Container"))    
                {
                    configPnPid = _config.GetValue(section, ConfigTrm.Container.Pnpid, "");
                    if (configPnPid.Equals(pnpid))
                    {
                        if (_config.GetValue(section, ConfigTrm.Container.Automountusb, false))
                        {
                            try
                            {
                                mvd = vm.ValidateMountContainer(section, _language);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return this;
                            }

                            int ret = Mount.MountContainer(mvd.path, mvd.driveletter, mvd.key, mvd.password, mvd.silent, mvd.beep, mvd.force, mvd.readOnly, mvd.removalbe, mvd.tc, mvd.pim, mvd.hash);

                            if (ret == 0)
                                State = true;
                            return this;

                        }
                    }
                }


                if (configtype.Equals("Drive"))
                {
                    configPnPid = _config.GetValue(section, ConfigTrm.Drive.Pnpdeviceid, "");

                    if (configPnPid.Equals(pnpid))
                    {                    
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
                                return this;
                            }

                            int res = Mount.MountDrive(mvd.partitionlist, mvd.driveletter, mvd.key, mvd.password, mvd.silent, mvd.beep, mvd.force, mvd.readOnly, mvd.removalbe, mvd.pim, mvd.hash, mvd.tc);

                            if (res == 0)
                                State = true;

                            return this;
                        }
                    }
                }
            }
            return this;
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

