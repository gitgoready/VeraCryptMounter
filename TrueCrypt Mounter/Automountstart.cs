using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Class for mounting all config whitch have automountstart set.
    /// </summary>
    public class Automountstart
    {

        private static Config _config = new Config();
        private const string LanguageRegion = "Automountstart";
        /// <summary>
        /// Name in config for mounted drive
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// state if mount succeed.
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// Class for mount containers and drives at start
        /// </summary>
        public Automountstart()
        {
            _config = Singleton<ConfigManager>.Instance.Init(_config);
        }

        /// <summary>
        /// Mount all containers and drives witch automountstart flag
        /// </summary>
        public void StartMount()
        {
            string _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            ValidateMount vm = new ValidateMount();
            MountVareables mvd = new MountVareables();
            List<string> containers;
            List<string> drives;
            containers = GetAutoContainers();
            drives = GetAutoDrives();
            
            foreach (string name in containers)
            {
                try
                {
                    mvd = vm.ValidateMountContainer(name, _language);
                    int ret = Mount.MountContainer(mvd.path, mvd.driveletter, mvd.key, mvd.password, mvd.silent, mvd.beep, mvd.force, mvd.readOnly, mvd.removalbe, mvd.tc, mvd.pim, mvd.hash);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
            foreach (string name in drives)
            {
                try
                {
                    mvd = vm.ValidateMountDrive(name, _language);
                    int res = Mount.MountDrive(mvd.partitionlist, mvd.driveletter, mvd.key, mvd.password, mvd.silent, mvd.beep, mvd.force, mvd.readOnly, mvd.removalbe, mvd.pim, mvd.hash, mvd.tc);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }

        /// <summary>
        /// Get list of drives which have the automount label.
        /// </summary>
        /// <returns>List of drives</returns>
        private List<string> GetAutoDrives()
        {
            List<string> drives = new List<string>();

            string[] sections = _config.GetSectionNames();

            foreach (string section in sections)
            {
                if (_config.GetValue(section, ConfigTrm.Mainconfig.Type, "") == "Drive")
                {
                    if (_config.GetValue(section, ConfigTrm.Container.Automountstart, false))
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
        private List<string> GetAutoContainers()
        {
            List<string> containers = new List<string>();

            string[] sections = _config.GetSectionNames();

            foreach (string section in sections)
            {
                if (_config.GetValue(section, ConfigTrm.Mainconfig.Type, "") == "Container")
                {
                    if (_config.GetValue(section, ConfigTrm.Drive.Automountstart, false))
                    {
                        containers.Add(section);
                    }
                }
            }
            return containers;
        }

    }
}
