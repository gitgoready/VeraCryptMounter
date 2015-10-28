using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCrypt_Mounter
{
    class Password_helper
    {
        private readonly Config _config = new Config();

        public Password_helper (string password)
        {
            _config = Singleton<ConfigManager>.Instance.Init(_config, password);
        }

        public bool Check_password()
        {
            if (_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordtest, "") == "Waldmann") return true;
            return false;
        }
        public void First_init()
        {
            
        }

    }
}
