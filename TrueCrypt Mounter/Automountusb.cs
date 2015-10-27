using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrueCrypt_Mounter
{
    class Automountusb
    {
        private static Config _config = new Config();
        private Automount _mystart;
        private string _password;
        private const string LanguageRegion = "Automountusb";
        private string _language;

        
        public void StartMount(object start)
        {
            _mystart = (Automount)start;
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            List<string> containers = GetAutoContainers();
            List<string> drives = GetAutoDrives();

            //if ()
            //_mystart.ButtonVisible();
        }

        //private string GetNewDriveletter()
        //{
        //    string ret = null;
        //    string[] drivletters = Program.Drivelist;
        //    string[] newdrivletters = DrivelettersHelper.GetUsedDriveletter();

        //    foreach(string letter in newdrivletters)
        //    {
        //       if (!drivletters.Contains(letter))
        //           ret = letter;
        //    }
        //    return ret;
        //}

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

