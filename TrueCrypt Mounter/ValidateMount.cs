/**
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// kontains all neede vareables for mounting
    /// </summary>
    public struct MountVareables
    {
        public string[] partitionlist;
        public string path;
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

        /// <summary>
        /// Validate vareables for on drive in config. Makes corrections.
        /// Returns all vareables for mounting in struct from type MountVareablesdrive. 
        /// </summary>
        /// <param name="name">Name of the Drive stored in config</param>
        /// <param name="language">selected language for gui</param>
        /// <returns>struct MountVareablesdrive</returns>
        /// <exception cref="ArgumentNullException"> thrown if parameter is null or empty</exception>
        /// <exception cref="Exception">thrown for user information</exception>
        public MountVareables ValidateMountDrive(string name, string language)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(language))
                throw new ArgumentNullException("language");
            return ValidateMountDrive(name, language);
        }

        ///// <summary>
        ///// Validate vareables for on container in config. Get name from config with pnpid and partindex. 
        ///// Returns all vareables for mounting in struct from type MountVareablesdrive. 
        ///// </summary>
        ///// <param name="pnpid">pnpid stored in config</param>
        ///// <param name="partitionindex">partition index stored in config</param>
        ///// <param name="language">selected language for gui</param>
        ///// <returns></returns>
        ///// <exception cref="ArgumentNullException"> thrown if parameter is null or empty</exception>
        ///// <exception cref="Exception">thrown for user information</exception>
        //public MountVareablesdrive ValidateMountDrive(string pnpid, string partitionindex, string language)
        //{
        //    string[] sections;

        //    if (string.IsNullOrEmpty(pnpid))
        //        throw new ArgumentNullException("pnpid");
        //    if (string.IsNullOrEmpty(language))
        //        throw new ArgumentNullException("language");
        //    if (string.IsNullOrEmpty(partitionindex))
        //        throw new ArgumentNullException("partindex");

        //    sections = _config.GetSectionNames();

        //    foreach (string sectionname in sections)
        //    {
        //        if (pnpid.Equals(_config.GetValue(sectionname, ConfigTrm.Drive.Pnpdeviceid)) && )
        //        {

        //        }
        //    }

        //    string name = null;
        //    return ValidateDrive(name, language);
        //}

        #region MountDrive

        private MountVareables ValidateDrive(string drivename, string _language)
        {

            List<string> parlist = new List<string>();
            WmiDriveInfo info = new WmiDriveInfo();
            MountVareables retstruct = new MountVareables();
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

            // Switch nokeyfile. if it is set key = null else key = keyfile;

            if (!_config.GetValue(drivename, ConfigTrm.Drive.Nokeyfile, true))
            {
                key = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "") +
                         _config.GetValue(drivename, ConfigTrm.Drive.Keyfile);

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
        #endregion

        public MountVareables ValidateMountContainer(string name, string language)
        {
            return ValidateContainer(name, language);
        }

        private MountVareables ValidateContainer(string name, string _language)
        {
            WmiDriveInfo winfo = new WmiDriveInfo();
            MountVareables mvd = new MountVareables();

            bool silent = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Silentmode, true);
            const bool beep = false;
            string driveletterFromPath = null;
            const bool force = false;
            string key = null;
            string keyfilepath;
            _password = _config.GetValue(name, ConfigTrm.Container.Password, null);
            _pim = _config.GetValue(name, ConfigTrm.Container.Pim, null);
            string pnpid = _config.GetValue(name, ConfigTrm.Container.Pim, null);
            string path = _config.GetValue(name, ConfigTrm.Container.Kontainerpath, "");
            bool removable = _config.GetValue(name, ConfigTrm.Container.Removable, false);
            bool readOnly = _config.GetValue(name, ConfigTrm.Container.Readonly, false);
            bool tc = _config.GetValue(name, ConfigTrm.Container.Truecrypt, false);
            string hash = _config.GetValue(name, ConfigTrm.Container.Hash, "");
            string dletter = _config.GetValue(name, ConfigTrm.Container.Driveletter, "");
            string partnumber = _config.GetValue(name, ConfigTrm.Container.Partnummber, "");
            bool nokeyfile = _config.GetValue(name, ConfigTrm.Container.Nokeyfile, true);

            try
            {
                driveletterFromPath = Path.GetPathRoot(@path);
                driveletterFromPath = driveletterFromPath.Replace(@"\", "");
            }
            catch (Exception)
            {
                //Do nothing.
            }

            var driveltterFromPNPID = (!string.IsNullOrEmpty(pnpid)) ? winfo.GetDriveLetter(pnpid, partnumber) : null;


            // check if pnpid is set and drive is connected
            if (!string.IsNullOrEmpty(driveltterFromPNPID))
            {
                if (winfo.CheckDiskPresent(pnpid))
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "DiskNotPresentContainerMessage", _language));
            }

            //  Test if keyfilekontainer is mounted

            if (_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Nokeyfile, true))
            {
                keyfilepath = _config.GetValue(name, ConfigTrm.Container.Keyfile, "");
            }
            else
            {
                keyfilepath =
                    _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Container.Driveletter, "") +
                    _config.GetValue(name, ConfigTrm.Container.Keyfile, "");
            }

# if DEBUG
            MessageBox.Show(keyfilepath + " " + name, "Path to Keyfile");
# endif
            if (!nokeyfile && !File.Exists(keyfilepath))
            {
                throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "NoKeyfileMessage", _language));
            }

            /** If a password is cached, the paswordform isn´t show **/
            if (string.IsNullOrEmpty(_password))
            {
                try
                {
                    bool dres = ShowPassworteingabe(ConfigTrm.Container.Typename, _config.GetValue(name, ConfigTrm.Container.Pimuse, false));
                    //if (!dres)
                    //    throw new Exception();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }

            if (!_config.GetValue(name, ConfigTrm.Container.Nokeyfile, false))
            {
                key = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "") +
                      _config.GetValue(name, ConfigTrm.Container.Keyfile);
            }

            //
            if (!string.IsNullOrEmpty(driveletterFromPath) && !string.IsNullOrEmpty(driveltterFromPNPID))
            {
                if (!driveltterFromPNPID.Equals(driveletterFromPath))
                {
                    path = path.Substring(1, path.Length);
                    path = driveltterFromPNPID + path;
                }
            }

            //if pim isnt used set to null
            if (!_config.GetValue(name, ConfigTrm.Container.Pimuse, false))
                _pim = null;

            // set quotes to path
            path = '\u0022' + path + '\u0022';

            mvd.path = path;
            mvd.driveletter = dletter;
            mvd.key = key;
            mvd.password = _password;
            mvd.silent = silent;
            mvd.beep = beep;
            mvd.force = force;
            mvd.readOnly = readOnly;
            mvd.removalbe = removable;
            mvd.tc = tc;
            mvd.pim = _pim;
            mvd.hash = hash;     

            return mvd;
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
