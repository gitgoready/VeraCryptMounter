using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    public struct MountVareablesdrive
    {
        public string[] partitionlist;
        public string driveletter;
        public string key;
        public string password;
        public bool silent;
        public bool beep;
        public bool force;
        public bool readOnly;
        public bool removalbe;
        public string pim;
        public string hash;
        public bool tc;

        //public MountVareablesdrive(string[] partitionlist, string driveletter, string key, string password,
        //    string silent, string beep, string force, string readOnly, string removalbe, string pim, string hash, string tc)
        //{
        //    partitionlist = null;
        //    driveletter = null;
        //    key = null;
        //    password = null;
        //    silent = null;
        //    beep = null;
        //    force = null;
        //    readOnly = null;
        //    removalbe = null;
        //    pim = null;
        //    hash = null;
        //    tc = null;
        //}
    }

    class ValidateMount
    {
        private readonly Config _config = new Config();
        private const string LanguageRegion = "Main";
        private string _password;
        private string _pim;

        public ValidateMount()
        {
            // Get Singelton for config
            _config = Singleton<ConfigManager>.Instance.Init(_config);
        }

        ~ValidateMount()
        {
            _password = null;
            _pim = null;
        }

        public MountVareablesdrive ValidateMountDrive(VeraCryptMounter main, string name, string language)
        {
            return ValidateMountDrive(name, language);
        }
        public MountVareablesdrive ValidateMountDrive(VeraCryptMounter main, string pnpid, string partindex, string language)
        {
            string name = null;
            return ValidateMountDrive(name, language);
        }
        private MountVareablesdrive ValidateMountDrive(string drivename, string _language)
        {

            List<string> parlist = new List<string>();
            WmiDriveInfo info = new WmiDriveInfo();
            MountVareablesdrive retstruct = new MountVareablesdrive();
            List<DriveInfo> list;
            string keyfilepath = null;
            const bool beep = false;
            const bool force = false;
            string key = null;
            
            // get vareables from config
            bool silent = _config.GetValue(ConfigTrm.Mainconfig.Section, "Silentmode", true);
            string dletter = _config.GetValue(drivename, ConfigTrm.Drive.Driveletter, "");
            _password = _config.GetValue(drivename, ConfigTrm.Drive.Password, null);
            _pim = _config.GetValue(drivename, ConfigTrm.Drive.Pim, null);
            bool removable = _config.GetValue(drivename, ConfigTrm.Drive.Removable, false);
            bool readOnly = _config.GetValue(drivename, ConfigTrm.Drive.Readonly, false);
            string hash = _config.GetValue(drivename, ConfigTrm.Drive.Hash, "");
            bool tc = _config.GetValue(drivename, ConfigTrm.Drive.Truecrypt, false);
            string diskmodel = _config.GetValue(drivename, ConfigTrm.Drive.Diskmodel, null);
            string diskserial = _config.GetValue(drivename, ConfigTrm.Drive.Diskserial, null);
            string disknumber = _config.GetValue(drivename, ConfigTrm.Drive.Disknumber, null);
            string partnumber = _config.GetValue(drivename, ConfigTrm.Drive.Partnumber, null);
            string pnpdeviceid = _config.GetValue(drivename, ConfigTrm.Drive.Pnpdeviceid, null);
            bool nokeyfile = _config.GetValue(drivename, ConfigTrm.Drive.Nokeyfile, true);

            // Test if disk is connected on machine
            if (!info.CheckDiskPresent(pnpdeviceid))
            {
                throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "DiskNotPresentMessage", _language) + "\"" + diskmodel + "\"");
            }

            //test if keyfilekontainer is mounted               
            if (_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Nokeyfile, true))
            {
                keyfilepath = _config.GetValue(drivename, ConfigTrm.Drive.Keyfile, "");
            }
            else
            {
                keyfilepath =
                _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "") +
                _config.GetValue(drivename, ConfigTrm.Drive.Keyfile, "");
            }

# if DEBUG
            MessageBox.Show(keyfilepath, "Path to Keyfile");
# endif

            if (!nokeyfile && !File.Exists(keyfilepath))
            {
                throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "NoKeyfileMessage", _language));
            }

            // If a password is cached, the paswordform isn´t show 
            if (string.IsNullOrEmpty(_password))
            {
                try
                {
                    ShowPassworteingabe(ConfigTrm.Drive.Typename, _config.GetValue(drivename, ConfigTrm.Drive.Pimuse, false));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }

            // test if password is empty
            if (string.IsNullOrEmpty(_password) && _config.GetValue(drivename, ConfigTrm.Drive.Nokeyfile, true))
            {
                throw new Exception("Leeres Passwort ist nicht erlaubt.");
            }

            // Switch nokeyfile. if it is set key = null else key = keyfile;

            if (!_config.GetValue(drivename, ConfigTrm.Drive.Nokeyfile, true))
            {
                key = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "") +
                         _config.GetValue(drivename, ConfigTrm.Drive.Keyfile);
            }

            list = info.GetDriveinfo(pnpdeviceid);

            if (list.Count >= 1)
            {
                parlist.Add("\\Device\\Harddisk" + list[0].Index + "\\Partition" + partnumber);
            }
            else
            {
                parlist.Add("\\Device\\Harddisk" + disknumber + "\\Partition" + partnumber);
            }

            retstruct.partitionlist = parlist.ToArray();
            retstruct.driveletter = dletter;
            retstruct.key = key;
            retstruct.password = _password;
            retstruct.silent = silent;
            retstruct.beep = beep;
            retstruct.force = force;
            retstruct.readOnly = readOnly;
            retstruct.removalbe = removable;
            retstruct.pim = _pim;
            retstruct.hash = hash;
            retstruct.tc = tc;

            return retstruct;
        }

        /// <summary>
        /// Window for password input and pim
        /// </summary>
        /// <param name="chosen">string for drive or container</param>
        /// <param name="pim">bool pim used or not</param>
        private bool ShowPassworteingabe(string chosen, bool pim)
        {
            var passwortDialog = new Passwordinput(chosen, pim);

            // Call Passwordinput form.
            DialogResult res = passwortDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                _password = passwortDialog._password;
                _pim = passwortDialog._pim;
                passwortDialog.Dispose();
                return true;
            }
            passwortDialog.Dispose();
            return false;
        }
    }
}
