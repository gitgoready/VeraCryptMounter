using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;


namespace TrueCrypt_Mounter
{
    public class Automountstart
    {

        private static Config _config = new Config();
        private Automount _mystart;
        private string _password;
        private const string LanguageRegion = "Automountstart";
        private string _language;

        public Automountstart()
        {
            _config = Singleton<ConfigManager>.Instance.Init(_config);
        }

        public void StartMount(object start)
        {

            _mystart = (Automount) start;
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            List<string> containers;
            List<string> drives;


            if (_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Automount, false))
            {
                string driveletter = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "");
                _mystart.SetFirstText(LanguagePool.GetInstance().GetString(LanguageRegion, "KeyfilecontainerTryMount", _language), true);

                if (DrivelettersHelper.IsDriveletterFree(driveletter))
                {
                    bool ro = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Readonly, true);
                    bool rm = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Removable, false);

                    string path = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Kontainerpath, "");
                    if (File.Exists(path))
                    {
                        path = '\u0022' + path + '\u0022';

                        _mystart.SetFirstText(LanguagePool.GetInstance().GetString(LanguageRegion, "KeyfilecontainerState", _language), false);

                        int ret = Mount.MountKeyfileContainer(path, driveletter, false, false, false, ro, rm);

                        if (ret == 0)
                        {
                            _mystart.SetLastText(LanguagePool.GetInstance().GetString(LanguageRegion, "Succeed", _language), Color.Green);
                        }
                        else
                        {
                            _mystart.SetLastText(LanguagePool.GetInstance().GetString(LanguageRegion, "Faild", _language), Color.Red);
                        }
                    }
                    else
                    {
                        _mystart.SetFirstText(LanguagePool.GetInstance().GetString(LanguageRegion, "KeyfilecontainerNotExist", _language), true);
                    }
                }
                else
                {
                    _mystart.SetFirstText(LanguagePool.GetInstance().GetString(LanguageRegion, "KeyfilecontainerMounted", _language), true);
                }
            }

            if (_config.GetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Mountcontainerstart, false))
            {
                containers = GetAutoContainers();

                if (containers != null)
                    foreach (var container in containers)
                    {
                        string path = _config.GetValue(container, ConfigTrm.Container.Kontainerpath, "");

                        _mystart.SetFirstText(container + LanguagePool.GetInstance().GetString(LanguageRegion, "TryMount", _language), true);

                        if (File.Exists(path))
                        {
                            string driveletter = _config.GetValue(container, ConfigTrm.Container.Driveletter, "");

                            if (DrivelettersHelper.IsDriveletterFree(driveletter))
                            {
                                bool ro = _config.GetValue(container, ConfigTrm.Container.Readonly, false);
                                string keyfile = null;
                                bool rm = _config.GetValue(container, ConfigTrm.Container.Removable, false);
                                bool beep = false;
                                bool force = false;
                                bool silent = true;
                                path = '\u0022' + path + '\u0022';
                                if (!_config.GetValue(container, ConfigTrm.Container.Nokeyfile, false))
                                {
                                    keyfile =
                                        _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter,"") +
                                        _config.GetValue(container, ConfigTrm.Container.Keyfile);
                                }
                                _mystart.SetFirstText(LanguagePool.GetInstance().GetString(LanguageRegion, "Password", _language) + container, true);

                                _mystart.SetFocus();

                                try
                                {
                                    Monitor.Enter(this);
                                    if ((_mystart.Password == null) && (_mystart.PasswordCached == null))
                                    {
                                        Monitor.Wait(this);
                                    }
                                    if (_mystart.Password != null)
                                    {
                                        _password = _mystart.Password;
                                        _mystart.Password = null;
                                    }
                                    else
                                    {
                                        _password = _mystart.PasswordCached;
                                    }
                                }
                                finally 
                                {
                                    Monitor.Exit(this);
                                }

                                _mystart.SetFirstText(container + LanguagePool.GetInstance().GetString(LanguageRegion, "State", _language), false);


                                int ret = Mount.MountContainer(path, driveletter, keyfile, _password, silent, beep,
                                                               force, ro, rm, false, null);

                                if (ret == 0)
                                {
                                    _mystart.SetLastText(LanguagePool.GetInstance().GetString(LanguageRegion, "Succeed", _language), Color.Green);
                                }
                                else
                                {
                                    _mystart.SetLastText(LanguagePool.GetInstance().GetString(LanguageRegion, "Faild", _language), Color.Red);
                                }
                            }
                            else
                            {
                                _mystart.SetFirstText(container + LanguagePool.GetInstance().GetString(LanguageRegion, "ContainerMounted", _language), true);

                            }
                        }
                        else
                        {
                            _mystart.SetFirstText(container + LanguagePool.GetInstance().GetString(LanguageRegion, "ContainerNotExist", _language), true);
                        }
                }
            }

            if (_config.GetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Mountdrivesstart, false))
            {
                _mystart.Password = null;
                _mystart.PasswordCached = null;

                drives = GetAutoDrives();
                if (drives != null)
                    foreach (string drive in drives)
                    {
                        string keyfile = _config.GetValue(drive, ConfigTrm.Drive.Keyfile, "");
                        string driveletter = _config.GetValue(drive, ConfigTrm.Drive.Driveletter, "");

                        _mystart.SetFirstText(drive + LanguagePool.GetInstance().GetString(LanguageRegion, "TryMount", _language), true);

                        if (DrivelettersHelper.IsDriveletterFree(driveletter))
                        {
                            string partition = _config.GetValue(drive, ConfigTrm.Drive.Partition, "");
                            bool ro = _config.GetValue(drive, ConfigTrm.Drive.Readonly, false);
                            bool rm = _config.GetValue(drive, ConfigTrm.Drive.Removable, false);

                            _mystart.SetFirstText(LanguagePool.GetInstance().GetString(LanguageRegion, "Password", _language) + drive, true);

                            _mystart.SetFocus();

                            try
                            {
                                Monitor.Enter(this);
                                if ((_mystart.Password == null) && (_mystart.PasswordCached == null))
                                {
                                    Monitor.Wait(this);
                                }
                                if (_mystart.Password != null)
                                {
                                    _password = _mystart.Password;
                                    _mystart.Password = null;
                                }
                                else
                                {
                                    _password = _mystart.PasswordCached;
                                }
                            }
                            finally 
                            {
                                Monitor.Exit(this);
                            }

                            _mystart.SetFirstText(drive + LanguagePool.GetInstance().GetString(LanguageRegion, "State", _language), false);

                            int ret = Mount.MountDrive(partition, driveletter, keyfile, _password, true, false, false, ro, rm, 26);

                            if (ret == 0)
                            {
                                _mystart.SetLastText(LanguagePool.GetInstance().GetString(LanguageRegion, "Succeed", _language), Color.Green);
                            }
                            else
                            {
                                _mystart.SetLastText(LanguagePool.GetInstance().GetString(LanguageRegion, "Faild", _language), Color.Red);
                            }
                        }
                        else
                        {
                            _mystart.SetFirstText(drive + LanguagePool.GetInstance().GetString(LanguageRegion, "DriveMounted", _language), true);
                        }
                        
                    }
            }
            _mystart.ButtonVisible();
        }


        /// <summary>
        /// Get list of drives which have the automount label.
        /// </summary>
        /// <param name="automount">ConfigTrm.Drives.Automountstart</param>
        /// <returns>List of drives</returns>
        private static List<string> GetAutoDrives()
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
        /// <param name="automount">ConfigTrm.Containers.Automountstart</param>
        /// <returns>List of containers</returns>
        private static List<string> GetAutoContainers()
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
