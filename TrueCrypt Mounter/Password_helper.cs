using System;
using System.IO;
using System.Windows.Forms;
using SecurityDriven.Inferno.Hash;
using System.Security;
using System.Security.Permissions;

namespace VeraCrypt_Mounter
{
    static class Password_helper
    {
        private static string _password;
        private static string _confDir;

        public static string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// Check if Startuppath is writeable. if it isnt use Applocal path for config.
        /// </summary>
        /// <returns>string: Path to config file</returns>
        public static string CheckConfDir()
        {
            _confDir = string.Format("{0}\\TRM.config", Application.StartupPath);

            if (File.Exists(string.Format(_confDir)))
                return _confDir;
            try
            {
                using (FileStream fs = File.Create(Path.Combine(Application.StartupPath, Path.GetRandomFileName()), 1, FileOptions.DeleteOnClose))
                { }
            }
            catch
            {
                _confDir = string.Format("{0}\\TRM.config", Application.LocalUserAppDataPath);
                return _confDir;
            }
            return _confDir;
        }


        public static bool Check_password()
        {

            CheckConfDir();
      
            var conf = new Config();
            conf.XmlPathName = string.Format(_confDir);
            conf.GroupName = null;
            if (conf.HasEntry(ConfigTrm.Mainconfig.Section,ConfigTrm.Mainconfig.Passwordtest))
            {
                if (conf.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordtest, "").Equals("Waldmann"))
                    return true;
            }
            return false;
        }

        public static bool Check_password(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (password.Equals(_password))
            {
                password = null;
                return true;
            }
            password = null;
            return false;
        }

        /// <summary>
        /// Change the master password for the encryption of the config
        /// </summary>
        /// <param name="newPassword"></param>
        /// <exception cref="ArgumentNullException">Throws if passwort is null or empty</exception>
        public static void ChangePassword(string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
                throw new ArgumentNullException("new password is null or empty");

            CheckConfDir();

            var conf = new Config();
            conf.XmlPathName = string.Format(_confDir);
            conf.GroupName = null;

            string[] sections = conf.GetSectionNames();

            foreach (string section in sections)
            {
                if (!string.Equals(section, "configSections"))
                {
                    string[] entrys = conf.GetEntryNames(section);
                    foreach (string entry in entrys)
                    {
                        var vars = conf.GetValue(section, entry);
                        var oldpw = _password;
                        _password = newPassword;
                        conf.SetValue(section, entry, vars);
                        _password = oldpw;
                    }
                }
                    
                
            }

        }

    }
}
