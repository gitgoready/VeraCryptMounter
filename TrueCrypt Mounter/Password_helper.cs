using System.IO;
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    static class Password_helper
    {
        private static  string _password;

        public static string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public static bool Check_password()
        {
            if (!File.Exists(string.Format("{0}\\TRM.config", Application.StartupPath)))
                return false;

            var conf = new Config();
            conf.XmlPathName = string.Format("{0}\\TRM.config", Application.StartupPath);
            conf.GroupName = null;
            if (conf.HasEntry(ConfigTrm.Mainconfig.Section,ConfigTrm.Mainconfig.Passwordtest))
            {
                if (conf.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordtest, "").Equals("Waldmann"))
                    return true;
            }
            return false;
        }

    }
}
