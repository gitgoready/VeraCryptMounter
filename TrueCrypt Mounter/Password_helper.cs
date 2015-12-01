using System.IO;
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    static class Password_helper
    {
        private static  string _password;
        private static string _confDir;

        public static string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private static void CheckConfDir()
        {
            _confDir = string.Format("{0}\\TRM.config", Application.StartupPath);
            if (!File.Exists(string.Format(_confDir)))
                return;
            try
            {
                using (FileStream fs = File.Create(Path.Combine(Application.StartupPath, Path.GetRandomFileName()), 1, FileOptions.DeleteOnClose))
                { }
            }
            catch
            {
                _confDir = string.Format("{0}\\TRM.config", Application.LocalUserAppDataPath);
            }
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

        public static void ChangePassword(string newPassword)
        {

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
