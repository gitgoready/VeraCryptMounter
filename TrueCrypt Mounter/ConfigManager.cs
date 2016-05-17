/***
* <VeraCryptMounter. Programm to use Truecrypt drives and containers easier.>
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
using System.IO;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Provides the singelton and checked if the config has the needed entries.
    /// </summary>
    public sealed class ConfigManager : Singleton<ConfigManager>
    {
        
        /// <summary>
        /// initialized the singelton.
        /// </summary>
        /// <param name="conf"></param>
        /// <returns></returns>
        public Config Init(Config conf)
        {
            string dirPath = string.Format(Application.StartupPath);
            conf.XmlPathName = string.Format("{0}\\TRM.config", Application.StartupPath);

            //if startuppath is not writable use localuserappdatapath
            if (!File.Exists(conf.XmlPathName))
            { 
                try
                {
                    using (FileStream fs = File.Create(Path.Combine(dirPath, Path.GetRandomFileName()), 1, FileOptions.DeleteOnClose))
                    { }
                }
                catch
                {
                    conf.XmlPathName = string.Format("{0}\\TRM.config", Application.LocalUserAppDataPath);
                }
            }

            conf.GroupName = null;

            if (!conf.HasEntry(ConfigTrm.Automount.Section, ConfigTrm.Automount.Type))
                conf.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Type, ConfigTrm.Automount.Typename);

            if (!conf.HasEntry(ConfigTrm.Automount.Section, ConfigTrm.Automount.Useusbautomount))
                conf.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Useusbautomount, false);

            if (!conf.HasEntry(ConfigTrm.Automount.Section, ConfigTrm.Automount.Usestartautomount))
                conf.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Usestartautomount, false);
            
            if (!conf.HasEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Type))
                conf.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Type, ConfigTrm.Mainconfig.Typename);

            if (!conf.HasEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordtest))
                conf.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordtest, "Waldmann");

            if (!conf.HasEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Defaultlanguage))
                conf.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Defaultlanguage, "E");

            if (!conf.HasEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language))
                conf.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language,
                              Application.StartupPath + "\\language.xml");

            if (conf.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Languagefile, "") !=
                Application.StartupPath + "\\language.xml")
            {
                conf.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Languagefile,
                              Application.StartupPath + "\\language.xml");
            }

            return conf;
        }

    }
    
    /// <summary>
    /// Singelton class
    /// </summary>
    /// <typeparam name="T">instance from singelton</typeparam>
    public class Singleton<T>
        where T : new()
    {
        /// <summary>
        /// instance for singelton
        /// </summary>
        public static readonly T Instance = new T();
    }
}   