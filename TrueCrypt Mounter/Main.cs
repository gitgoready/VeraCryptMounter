/**
 * <TruecryptMounter. Programm to use Truecrypt drives and containers easier.>
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
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace TrueCrypt_Mounter
{
    ///<summary>
    /// The main class. Here is all control for the programm
    ///</summary>
    public partial class TrueCryptMounter : Form
    {
        #region Vareables

        private const string AppId = "TrueCryptMounter";
        //private const string ProgId = "TrueCryptMounter";
        private const string LanguageRegion = "Main";
        private const string LanguageToolTip = "MainToolTips";

        private readonly BindingManagerBase _bmbd;
        private readonly BindingManagerBase _bmbk;
        private readonly List<string> _cbdrive = new List<string>();
        private readonly List<string> _cbkontainer = new List<string>();
        private readonly Config _config = new Config();

        private readonly string _executablePath;
        private readonly List<string> _mounteddrives = new List<string>();
        private readonly List<string> _mountedkontainer = new List<string>();
        private bool _cached;
        private bool _cachedKontainer;

        private string _language;
        private string _passwordDrive;
        private string _passwordContainer;
        private string _pim;
        private string _lablefailed;
        private string _lablesuccseed;
        private TaskbarManager windowsTaskbar;

        #endregion

        #region Setter,Getter

        public string PasswordDrive
        {
            get { return null; }
            set { _passwordDrive = value; }
        }

        public string PasswordContainer
        {
            get { return null; }
            set { _passwordContainer = value; }
        }

        public string Pim
        {
            get { return null; }
            set { _pim = value; }
        }

        #endregion

        #region Delegates

        public delegate int MountKeyfilecontainerDelegate(string path, string driveletter, bool silent, bool beep, bool force,
                                                          bool readOnly, bool removable, string hash, bool pim);


        public delegate int MountDriveDelegate(string partition, string driveletter, string keyfile, string password, bool silent,
                                                bool beep, bool force, bool readOnly, bool removable, string pim, string hash, bool tc);

        public delegate int MountContainerDelegate(string path, string driveletter, string keyfile, string password, bool silent,
                                                   bool beep, bool force, bool readOnly, bool removable, bool tc, string pim,string hash);

        public delegate int DismountDelegate(string driveletter, bool silent, bool beep, bool force);

        public delegate void StopProgressbarDelegate();

        public delegate void SetLableNotificationDelegate(int result);

        public delegate void NormalDelegate();

        public delegate void SetCursorNormalDelegate();

        public delegate void RefreshComboboxesInvokeDelegate();

        #endregion

        #region Constructor, Destructor

        ///<summary>
        /// Constructor makes all settings for the programm for first running. 
        ///</summary>
        public TrueCryptMounter()
        {
            InitializeComponent();

            // For these release Disabled
            automountConfigToolStripMenuItem.Visible = false;
            
            // Get Singelton for config
            _config = Singleton<ConfigManager>.Instance.Init(_config);


            // Bind sources to comboboxes and get bindingmanager for manual reload
            comboBoxDrives.DataSource = _cbdrive;
            comboBoxContainer.DataSource = _cbkontainer;
            _bmbd = comboBoxDrives.BindingContext[_cbdrive];
            _bmbk = comboBoxContainer.BindingContext[_cbkontainer];

            bool nokeyfile = !_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Nokeyfile, false);

            ToolStripMenuItemNotifyKeyfilecontainer.Enabled = nokeyfile;
            groupBoxKeyfileContainer.Visible = nokeyfile;
                
            if (nokeyfile)
            {
                EnableKeyfilekontainer();
            }
            else
            {
                DisableKeyfilekontainer();
            }
            
            _cbdrive.Clear();
            _cbkontainer.Clear();
            _mounteddrives.Clear();
            _mountedkontainer.Clear();
            ToolStripMenuItemNotifyRestore.Enabled = false;
            string[] sectionNames = _config.GetSectionNames();
            if (sectionNames != null)
            {
                foreach (string drive in sectionNames)
                {
                    if (_config.HasEntry(drive, ConfigTrm.Drive.Type))
                    {
                        if (_config.GetValue(drive, ConfigTrm.Drive.Type, "") == ConfigTrm.Drive.Typename)
                        {
                            _cbdrive.Add(drive);
                            string dletter = _config.GetValue(drive, ConfigTrm.Drive.Driveletter, "");
                            if (!DrivelettersHelper.IsDriveletterFree(dletter))
                            {
                                _mounteddrives.Add(drive);
                            }
                        }
                        if (_config.GetValue(drive, ConfigTrm.Container.Type, "") == ConfigTrm.Container.Typename)
                        {
                            _cbkontainer.Add(drive);
                            string dletter = _config.GetValue(drive, ConfigTrm.Container.Driveletter, "");
                            if (!DrivelettersHelper.IsDriveletterFree(dletter))
                            {
                                _mountedkontainer.Add(drive);
                            }
                        }
                    }
                }
            }

            _bmbd.SuspendBinding();
            _bmbd.ResumeBinding();
            _bmbk.SuspendBinding();
            _bmbk.ResumeBinding();

            comboBoxContainer.SelectedItem = null;
            comboBoxDrives.SelectedItem = null;

            // Fill controls with selected language
            LanguageFill();

            ValidateTest();


            // Windows7 taskbar funktions
            if (TaskbarManager.IsPlatformSupported)
            {
                windowsTaskbar = TaskbarManager.Instance;

                // Set the application specific id
                windowsTaskbar.ApplicationId = AppId;

                // Save current folder and path of running executable
                _executablePath = Assembly.GetEntryAssembly().Location;
                Path.GetDirectoryName(_executablePath);
                
            }
        }

        ~TrueCryptMounter()
        {
            _passwordDrive = null;
            _passwordContainer = null;
        }

        #endregion

        #region Language settings

        /// <summary>
        /// Set all controllelements to the selected language if the language is changed.
        /// </summary>
        private void LanguageFill()
        {
            if (_language != _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, ""))
            {
                _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
                try
                {
                    // Fill the controls with text.
                    buttonDismount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonDismount",
                                                                               _language);
                    buttonDismountContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                        "buttonDismountContainer",
                                                                                        _language);
                    buttonKeyfileContainerDismount.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                               "buttonKeyfileContainerDismount",
                                                                                               _language);
                    buttonKeyfileContainerMount.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                            "buttonKeyfileContainerMount",
                                                                                            _language);
                    buttonMount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonMount", _language);
                    buttonMountContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                     "buttonMountContainer",
                                                                                     _language);
                    groupBoxDrive.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxDrive", _language);
                    groupBoxContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxContainer",
                                                                                  _language);
                    groupBoxKeyfileContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                         "groupBoxKeyfileContainer",
                                                                                         _language);
                    checkBoxClearPassword.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                      "checkBoxClearPassword",
                                                                                      _language);
                    checkBoxClearPasswordContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                               "checkBoxClearPasswordContainer",
                                                                                               _language);
                    ToolStripMenuItemFile.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                      "ToolStripMenuItemFile",
                                                                                      _language);
                    ToolStripMenuItemClose.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                       "ToolStripMenuItemClose",
                                                                                       _language);
                    ToolStripMenuItemEdit.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                      "ToolStripMenuItemEdit",
                                                                                      _language);
                    ToolStripMenuItemNewDrive.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                          "ToolStripMenuItemNewDrive",
                                                                                          _language);
                    ToolStripMenuItemEditDrive.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                           "ToolStripMenuItemEditDrive",
                                                                                           _language);
                    ToolStripMenuItemRemoveDrive.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                             "ToolStripMenuItemRemoveDrive",
                                                                                             _language);
                    ToolStripMenuItemNewContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                              "ToolStripMenuItemNewContainer",
                                                                                              _language);
                    ToolStripMenuItemEditContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                               "ToolStripMenuItemEditContainer",
                                                                                               _language);
                    ToolStripMenuItemRemoveContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                                 "ToolStripMenuItemRemoveContainer",
                                                                                                 _language);
                    toolStripMenuItemSettings.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                          "toolStripMenuItemSettings",
                                                                                          _language);
                    ToolStripMenuItemMainSettings.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                              "ToolStripMenuItemMainSettings",
                                                                                              _language);
                    ToolStripMenuItemHelp.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                      "ToolStripMenuItemHelp",
                                                                                      _language);
                    toolStripMenuVersion.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                     "toolStripMenuVersion",
                                                                                     _language);
                    ToolStripMenuItemNotifyKeyfilecontainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                                        "ToolStripMenuItemNotifyKeyfilecontainer",
                                                                                                        _language);
                    ToolStripMenuItemNotifyRestore.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                               "ToolStripMenuItemNotifyRestore",
                                                                                               _language);
                    ToolStripMenuItemNotifyClose.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                             "ToolStripMenuItemNotifyClose",
                                                                                             _language);
                    ToolStripMenuItemNotifyMount.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                             "ToolStripMenuItemNotifyMount",
                                                                                             _language);
                    ToolStripMenuItemNotifyDismount.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                                "ToolStripMenuItemNotifyDismount",
                                                                                                _language);
                    comboBoxDrives.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "comboBoxDrives",
                                                                               _language);
                    comboBoxContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "comboBoxContainer",
                                                                                  _language);
                    automountConfigToolStripMenuItem.Text = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                                                 "automountConfigToolStripMenuItem",
                                                                                                 _language);
                    //.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "", _language);

                    // Fill the tooltips with text.
                    toolTipMain.SetToolTip(comboBoxDrives, LanguagePool.GetInstance().GetString(LanguageToolTip, "ComboboxDriveTip", _language));
                    toolTipMain.SetToolTip(comboBoxContainer, LanguagePool.GetInstance().GetString(LanguageToolTip, "ComboboxContainerTip", _language));
                    //toolTipMain.SetToolTip(, LanguagePool.GetInstance().GetString(LanguageToolTip, "", _language));
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        #endregion

        #region Initialize and Refreshes


        private void TaskBarWindows7(string state)
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                switch (state)
                {
                    case "start":
                        windowsTaskbar.SetProgressState(TaskbarProgressBarState.Indeterminate);
                        break;

                    case "stop":
                        windowsTaskbar.SetProgressState(TaskbarProgressBarState.Normal);
                        windowsTaskbar.SetProgressValue(0,100);
                        break;
                }
            }

        }

        /// <summary>
        /// On load preform automount funktions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrueCryptMounter_Load(object sender, EventArgs e)
        {
            
            if (_config.GetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Usestartautomount, false))
            {
                try
                {
                    var start = new Automount("start");
                    start.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.Source);
                    return;
                }
                RefreshComboboxes();
                
            }
        }


        /// <summary>
        /// Method to validate the mainconfig. 
        /// If config is not set deactivate all buttons and give aut the massage.
        /// </summary>
        private void ValidateTest()
        {
            //Deactivate all button if no configuration is made
            if (!TrueCrypt_Mounter.Validate.ValidateConfig())
            {
                Busy();
                toolStripLabelNotification.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "ValidateMessage", _language);
                toolStripLabelNotification.ForeColor = Color.Red;
                toolStripLabelNotification.Visible = true;
            }
            else
            {
                Normal();
                toolStripLabelNotification.Visible = false;
            }
        }     

        /// <summary>
        /// Function to refresh the comboboxes.
        /// </summary>
        private void RefreshComboboxes()
        {
            // Clear list elements.
            _cbdrive.Clear();
            _cbkontainer.Clear();
            _mounteddrives.Clear();
            _mountedkontainer.Clear();

            // Fill list with drive and container elements.
            string[] sectionNames = _config.GetSectionNames();
            if (sectionNames != null)
            {
                foreach (string section in sectionNames)
                {
                    if (_config.HasEntry(section, ConfigTrm.Drive.Type))
                    {
                        if (_config.GetValue(section, ConfigTrm.Drive.Type, "") == ConfigTrm.Drive.Typename)
                        {
                            _cbdrive.Add(section);
                            string dletter = _config.GetValue(section, ConfigTrm.Drive.Driveletter, "");
                            if (!DrivelettersHelper.IsDriveletterFree(dletter))
                            {
                                _mounteddrives.Add(section);
                            }
                        }
                        if (_config.GetValue(section, ConfigTrm.Container.Type, "") == ConfigTrm.Container.Typename)
                        {
                            _cbkontainer.Add(section);
                            string dletter = _config.GetValue(section, ConfigTrm.Container.Driveletter, "");
                            if (!DrivelettersHelper.IsDriveletterFree(dletter))
                            {
                                _mountedkontainer.Add(section);
                            }
                        }
                    }
                }
            }


            // Force comboboxes to redraw.
            _bmbd.SuspendBinding();
            _bmbd.ResumeBinding();
            _bmbk.SuspendBinding();
            _bmbk.ResumeBinding();

            comboBoxDrives.SelectedItem = null;
            comboBoxContainer.SelectedItem = null;

            comboBoxDrives.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "comboBoxDrives", _language);
            comboBoxContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "comboBoxContainer", _language);
        }

        #endregion

        #region Buttons Drive

        private void ButtonMountDrive_Click(object sender, EventArgs e)
        {
            
            bool silent = _config.GetValue(ConfigTrm.Mainconfig.Section, "Silentmode", true);
            const bool beep = false;
            const bool force = false;

            toolStripLabelNotification.Visible = false;

            try
            {
                // Test if entry in driverbox is chosen. 
                if (comboBoxDrives.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "DriveSelectionFaild", _language));
                }
                //test if keyfilekontainer is mounted
                bool nokeyfile = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Nokeyfile, true);
                string keyfilepath;
                if (_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Nokeyfile, true))
                {
                    keyfilepath = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Keyfile, "");
                }
                else
                {
                    keyfilepath =
                    _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "") +
                    _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Keyfile, "");
                }

# if DEBUG
                MessageBox.Show(keyfilepath, "Path to Keyfile");
# endif
                if (!nokeyfile && !File.Exists(keyfilepath))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "NoKeyfileMessage", _language));
                }

                // Reset the cached passwort
                if (checkBoxClearPassword.Checked)
                {
                    _cached = false;
                    checkBoxClearPassword.CheckState = CheckState.Unchecked;
                    _passwordDrive = null;
                    _pim = null;
                }
                // If a password is cached, the paswordform isn´t show 
                if (_cached == false)
                {
                    try
                    {
                        ShowPassworteingabe(ConfigTrm.Drive.Typename, 
                            _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Pim, false));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
                /** test if password is emty**/
                if (string.IsNullOrEmpty(_passwordDrive) && _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Nokeyfile, true))
                {
                    throw new Exception("Leeres Passwort ist nicht erlaubt.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _cached = false;
                return;
            }

            _cached = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordcache, false);

            
            //Nummber of iteration to try. (nummber of letters)
            const int iterations = 26;
            //int interne = 1;


            string dletter = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Driveletter, "");

            // Switch nokeyfile. if it is set key = null else key = keyfile;
            string key = null;
            if (!_config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Nokeyfile, true))
            {
                key = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "") +
                         _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Keyfile);
            }

            string partition = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Partition, "");
            bool removable = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Removable, false);
            bool readOnly = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Readonly, false);
            string hash = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Hash, "");
            bool tc = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Truecrypt, false);

            //TODO CHECK DISKNUMBER IS CORRECK!!!!

            //string diskmodel = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Diskmodel, null);
            //string diskserial = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Diskserial, null);

            //string disknumber = partition.Substring(16, 1);

            toolStripProgressBar.Visible = true;

            MountDriveDelegate mountdrive = Mount.MountDrive;
            
            mountdrive.BeginInvoke(partition, dletter, key, _passwordDrive, silent, beep, force, readOnly, removable, _pim, hash, tc,
                                   CallbackHandlerMountDrive, mountdrive);
            toolStripProgressBar.MarqueeAnimationSpeed = 30;

            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationDriveSucceed",
                                                                                  _language);

            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationDriveFaild", _language);

            Busy();

            Cursor = Cursors.WaitCursor;
            return;
        }

        private void ButtonDismountDrive_Click(object sender, EventArgs e)
        {
            toolStripLabelNotification.Visible = false;
            try
            {
                // Test if entry in driverbox is chosen. 
                if (comboBoxDrives.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "DriveSelectionFaild", _language));
                }
                //Test if drive is mounted
                if (DrivelettersHelper.IsDriveletterFree(_config.GetValue(comboBoxDrives.Text, ConfigTrm.Drive.Driveletter, "")))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "DriveNotMounted", _language));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dletter = _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Mainconfig.Driveletter,
                                              "");

            DismountDelegate dismount = Mount.Dismount;

            dismount.BeginInvoke(dletter, true, false, false, CallbackHandlerDismount, dismount);

            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationDriveDismountSucceed",
                                                                 _language);
            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationDriveDismountFaild",
                                                               _language);
            toolStripProgressBar.Visible = true;
            toolStripProgressBar.MarqueeAnimationSpeed = 30;

            Busy();

            Cursor = Cursors.WaitCursor;
            return;
        }

        #endregion 

        #region Buttons Container

        private void ButtonMountContainer_Click(object sender, EventArgs e)
        {
            bool silent = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Silentmode, true);
            const bool beep = false;
            const bool force = false;
            string key = null;
            

            toolStripLabelNotification.Visible = false;

            try
            {
                // Test if entry in driverbox is chosen
                if (comboBoxContainer.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "ContainerSelectionFaild",
                                                                             _language));
                }

                //  Test if keyfilekontainer is mounted
                bool nokeyfile = _config.GetValue(comboBoxContainer.SelectedItem.ToString(),
                                                  ConfigTrm.Container.Nokeyfile, true);

                string keyfilepath;
                if (_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Nokeyfile, true))
                {
                    keyfilepath = _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Keyfile, "");
                }
                else
                {
                    keyfilepath =
                     _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Container.Driveletter, "") +
                     _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Keyfile, "");
                }

# if DEBUG
                MessageBox.Show(keyfilepath + " " + comboBoxContainer.SelectedItem.ToString(), "Path to Keyfile");
# endif
                if (!nokeyfile && !File.Exists(keyfilepath))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "NoKeyfileMessage", _language));
                }

                /**Reset the cached password **/
                if (checkBoxClearPasswordContainer.Checked)
                {
                    _cachedKontainer = false;
                    checkBoxClearPasswordContainer.CheckState = CheckState.Unchecked;
                    _passwordContainer = null;
                }
                /** If a password is cached, the paswordform isn´t show **/
                if (_cachedKontainer == false)
                {
                    try
                    {
                        ShowPassworteingabe(ConfigTrm.Container.Typename, 
                            _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Pim, false));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
                /** test if password is emty**/
                if (string.IsNullOrEmpty(_passwordContainer) && _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Nokeyfile, false))
                {
                    throw new Exception("Leeres Passwort ist nicht erlaubt.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _cached = false;
                return;
            }

            _cachedKontainer = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordcache, false);

            toolStripProgressBar.Visible = true;
            TaskBarWindows7("start");

            string dletter = _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Driveletter,
                                              "");
            if (!_config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Nokeyfile, false))
            {
                key = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "") +
                      _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Keyfile);
            }

            string path = '\u0022' + _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Kontainerpath, "") +
                          '\u0022';
            bool removable = _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Removable, false);
            bool readOnly = _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Readonly, false);
            bool tc = _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Truecrypt, false);
            string hash = _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Hash, "");

            //if pim isnt used set to null
            if (!_config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Pim, false))
                _pim = null;


            MountContainerDelegate mountcontainer = Mount.MountContainer;

            mountcontainer.BeginInvoke(path, dletter, key, _passwordContainer, silent, beep, force, readOnly, removable, tc, _pim, hash,
                                       CallbackHandlerMountContainer, mountcontainer);

            toolStripProgressBar.MarqueeAnimationSpeed = 30;

            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationContainerSucceed",
                                                                                  _language);

            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationContainerFaild", _language);

            Busy();

            Cursor = Cursors.WaitCursor;

            return;
        }

        private void ButtonDismountContainer_Click(object sender, EventArgs e)
        {
            toolStripLabelNotification.Visible = false;

            try
            {
                // Test if entry in driverbox is chosen
                if (comboBoxContainer.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "ContainerSelectionFaild",
                                                                             _language));
                }
                //Test if container is mounted
                if (
                    DrivelettersHelper.IsDriveletterFree(_config.GetValue(comboBoxContainer.Text, ConfigTrm.Container.Driveletter, "")))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "ContainerNotMounted", _language));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            toolStripProgressBar.Visible = true;

            string dletter = _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Driveletter,
                                              "");

            DismountDelegate dismount = Mount.Dismount;

            dismount.BeginInvoke(dletter, true, false, false, CallbackHandlerDismount, dismount);

            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationContainerDismountSucceed",
                                                                 _language);

            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationContainerDismountFaild",
                                                               _language);

            toolStripProgressBar.MarqueeAnimationSpeed = 30;
            Busy();
            Cursor = Cursors.WaitCursor;
            return;
        }

        #endregion

        #region Buttons Keyfilecontainer

        private void ButtonKeyfileContainerMount_Click(object sender, EventArgs e)
        {
            toolStripLabelNotification.Visible = false;
            try
            {
                //Test if Keyfilecontainer is mounted or driveletter is used.
                if (
                    !DrivelettersHelper.IsDriveletterFree(_config.GetValue(ConfigTrm.Mainconfig.Section,
                                                              ConfigTrm.Mainconfig.Driveletter, "")))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "KyfilecontainerUsed", _language));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            toolStripProgressBar.Visible = true;
            bool ro = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Readonly, true);
            bool rm = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Removable, false);

            string path = '\u0022' +
                          _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Kontainerpath, "") +
                          '\u0022';

            string dletter = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "");

            MountKeyfilecontainerDelegate mountmethode = Mount.MountKeyfileContainer;

            string hash = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Hash, "");
            bool pim = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Pim, false);

            mountmethode.BeginInvoke(path, dletter, false, false, false, ro, rm, hash, pim, CallbackHandlerMountKyfilecontainer, mountmethode);

            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationKeyfilecontainerSucceed",
                                                                 _language);
            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationKeyfilecontainerFaild",
                                                               _language);
            toolStripProgressBar.MarqueeAnimationSpeed = 30;

            Busy();

            Cursor = Cursors.WaitCursor;

            return;
        }

        private void ButtonKeyfileContainerDismount_Click(object sender, EventArgs e)
        {
            toolStripLabelNotification.Visible = false;
            try
            {
                //Test if Keyfilecontainer is mounted.
                if (
                    DrivelettersHelper.IsDriveletterFree(_config.GetValue(ConfigTrm.Mainconfig.Section,
                                                             ConfigTrm.Mainconfig.Driveletter, "")))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "KeyfilecontainerNotMounted",
                                                                             _language));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            toolStripProgressBar.Visible = true;

            string dletter = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "");

            DismountDelegate dismount = Mount.Dismount;

            dismount.BeginInvoke(dletter, true, false, false, CallbackHandlerDismount, dismount);

            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                                 "NotificationKeyfilecontainerDismountSucceed",
                                                                 _language);
            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion,
                                                               "NotificationKeyfilecontainerDismountFaild",
                                                               _language);
            toolStripProgressBar.MarqueeAnimationSpeed = 30;
            Busy();
            Cursor = Cursors.WaitCursor;

            return;
        }

        #endregion

        #region Tool strip menue

        private void ToolStripMenuMainconfig_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogBox = new Mainsettings();
                dialogBox.ShowDialog(); // Returns when dialog box has closed
                // Test if mainconfig is made
                ValidateTest();
                // Refill language if it is changed
                LanguageFill();
                ToolStripMenuItemNotifyKeyfilecontainer.Enabled =
                groupBoxKeyfileContainer.Visible =
                !_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Nokeyfile, false);
                if (groupBoxKeyfileContainer.Visible)
                {
                    EnableKeyfilekontainer();
                }
                else
                {
                    DisableKeyfilekontainer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripMenuDriveNew_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogBox = new NewDrive();
                dialogBox.ShowDialog(); // Returns when dialog box has closed
                RefreshComboboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        private void ToolStripMenuDriveEdit_Click(object sender, EventArgs e)
        {
            try
            {

                // Test if entry in driverbox is chosen.
                if (comboBoxDrives.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "DriveSelectionFaild",
                                                                             _language));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Test if Drive is mounted.
                if (!DrivelettersHelper.IsDriveletterFree(
                    _config.GetValue(comboBoxDrives.SelectedItem.ToString(), ConfigTrm.Drive.Driveletter, "")))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "DriveEditMounted",
                                                                             _language));
                }

            }
            catch (Exception ex)
            {

                DialogResult res = MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language), MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Cancel)
                {
                    return;
                }

            }

            var dialogBox = new NewDrive(comboBoxDrives.SelectedItem.ToString());
            dialogBox.ShowDialog(); // Returns when dialog box has closed
            RefreshComboboxes();
        }

        private void ToolStripMenuDriveDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Test if entry in driverbox is chosen
                if (comboBoxDrives.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "DriveSelectionFaild", _language));
                }
                string drivename = comboBoxDrives.SelectedItem.ToString();
                DialogResult result =
                    MessageBox.Show(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDriveDelete", _language),
                                    LanguagePool.GetInstance().GetString(LanguageRegion, "MessageWarning", _language), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _config.RemoveSection(drivename);
                    RefreshComboboxes();
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ToolStripMenuContainerNew_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogBox = new NewContainer();
                dialogBox.ShowDialog(); // Returns when dialog box has closed
                RefreshComboboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ToolStripMenuContainerEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Test if entry in driverbox is chosen
                if (comboBoxContainer.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "ContainerSelectionFaild",
                                                                             _language));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Test if Container is mounted.
                if (!DrivelettersHelper.IsDriveletterFree(
                    _config.GetValue(comboBoxContainer.SelectedItem.ToString(), ConfigTrm.Container.Driveletter, "")))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "ContainerEditMounted",
                                                                             _language));

                }
            }
            catch (Exception ex)
            {

                DialogResult res = MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                if (res == DialogResult.Cancel)
                {
                    return;
                }

            }
           
            var dialogBox = new NewContainer(comboBoxContainer.SelectedItem.ToString());
            dialogBox.ShowDialog(); // Returns when dialog box has closed
            RefreshComboboxes();
            
        }

        private void ToolStripMenuContainerDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                // Test if entry in driverbox is chosen
                if (comboBoxContainer.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "ContainerSelectionFaild",
                                                                             _language));
                }
                string containerName = comboBoxContainer.SelectedItem.ToString();
                DialogResult result = MessageBox.Show(
                    LanguagePool.GetInstance().GetString(LanguageRegion, "MessageContainerDelete", _language),
                    LanguagePool.GetInstance().GetString(LanguageRegion, "MessageWarning", _language), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _config.RemoveSection(containerName);
                    RefreshComboboxes();
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ToolStripMenuVersion_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogBox = new Version();
                dialogBox.ShowDialog(); // Returns when dialog box has closed
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripMenuClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripMenuAutomountConfig_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogBox = new AutomountConfig();
                dialogBox.ShowDialog(); // Returns when dialog box has closed
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion 

        #region NotifyIcon

        private void TrueCryptMounter_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                if (!TaskbarManager.IsPlatformSupported)
                    Hide();

                ToolStripMenuItemNotifyRestore.Enabled = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ToolStripMenuItemNotifyRestore.Enabled = false;
        }

        #endregion

        #region ContextMenu

        private void ContextMenuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ContextMenuRestore_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ToolStripMenuItemNotifyRestore.Enabled = false;
        }

        #endregion

        #region Passwordinput
        /// <summary>
        /// Window for password input and pim
        /// </summary>
        /// <param name="chosen">string for drive or container</param>
        /// <param name="pim">bool pim used or not</param>
        public void ShowPassworteingabe(string chosen, bool pim)
        {
            var passwortDialog = new Passwordinput(this, chosen, pim);

            // Call Passwordinput form.
            passwortDialog.ShowDialog();

            passwortDialog.Dispose();
        }

        #endregion

        #region Comboboxes Draw Events

        // If you set the Draw property to DrawMode.OwnerDrawVariable, 
        // you must handle the MeasureItem event. This event handler 
        // will set the height and width of each item before it is drawn. 
        private void ComboBox_Laufwerke_MeasureItem(object sender,
                                                    MeasureItemEventArgs e)
        {
            // ItemHeight shout be font size + 4 
            e.ItemHeight = 12;
            //e.ItemWidth = 120;
            
        }

        // You must handle the DrawItem event for owner-drawn combo boxes.  
        // This event handler changes the color, size and font of an 
        // item based on its position in the array.
        private void ComboBox_Laufwerke_DrawItem(object sender,
                                                 DrawItemEventArgs e)
        {
            Font myFont;

            float size = 8;
            const FontStyle fstyle = FontStyle.Regular;
            string fontname = comboBoxDrives.Font.Name;
            //FontFamily family = FontFamily.GenericSansSerif;
            Brush brush = Brushes.Black;

            if (_mounteddrives.Contains(_cbdrive[e.Index]))
                brush = Brushes.SeaGreen;

            // Draw the background of the item.
            e.DrawBackground();

            // Draw each string in the array, using a different size, color,
            // and font for each item.
            myFont = new Font(fontname, size, fstyle);
            e.Graphics.DrawString(_cbdrive[e.Index], myFont, brush, e.Bounds.X, e.Bounds.Y);

            // Draw the focus rectangle if the mouse hovers over an item.
            e.DrawFocusRectangle();
        }

        // If you set the Draw property to DrawMode.OwnerDrawVariable, 
        // you must handle the MeasureItem event. This event handler 
        // will set the height and width of each item before it is drawn. 
        private void ComboBoxKontainer_MeasureItem(object sender,
                                                   MeasureItemEventArgs e)
        {
            // ItemHeight shout be font size + 4 
            e.ItemHeight = 12;
            //e.ItemWidth = 120;
        }

        // You must handle the DrawItem event for owner-drawn combo boxes.  
        // This event handler changes the color, size and font of an 
        // item based on its position in the array.
        private void ComboBoxKontainerDrawItem(object sender,
                                                DrawItemEventArgs e)
        {
            Font myFont;

            const float size = 8;
            const FontStyle fstyle = FontStyle.Regular;
            string fontname = comboBoxContainer.Font.Name;
            //FontFamily family = FontFamily.GenericSansSerif;
            Brush brush = Brushes.Black;

            if (_mountedkontainer.Contains(_cbkontainer[e.Index]))
                brush = Brushes.SeaGreen;

            // Draw the background of the item.
            e.DrawBackground();

            // Draw each string in the array, using a different size, color,
            // and font for each item.
            myFont = new Font(fontname, size, fstyle);
            e.Graphics.DrawString(_cbkontainer[e.Index], myFont, brush, e.Bounds.X, e.Bounds.Y);

            // Draw the focus rectangle if the mouse hovers over an item.
            e.DrawFocusRectangle();
        }

        #endregion

        #region Invoke Methods

        /// <summary>
        /// Method to deaktivate all buttons.
        /// </summary>
        private void Busy()
        {
            buttonMount.Enabled = false;
            buttonDismount.Enabled = false;
            buttonKeyfileContainerDismount.Enabled = false;
            buttonDismountContainer.Enabled = false;
            buttonKeyfileContainerMount.Enabled = false;
            buttonMountContainer.Enabled = false;
        }

        /// <summary>
        /// Method to activate all buttons.
        /// </summary>
        private void Normal()
        {
            buttonMount.Enabled = true;
            buttonDismount.Enabled = true;
            buttonKeyfileContainerDismount.Enabled = true;
            buttonDismountContainer.Enabled = true;
            buttonKeyfileContainerMount.Enabled = true;
            buttonMountContainer.Enabled = true;
        }

        /// <summary>
        /// Method to stop the progressbar.
        /// </summary>
        private void StopProgressbar()
        {

            toolStripProgressBar.MarqueeAnimationSpeed = 0;
            toolStripProgressBar.Visible = false;
            TaskBarWindows7("stop");

        }

        /// <summary>
        /// Decided whitch label is set on the value of the result.
        /// </summary>
        /// <param name="result"></param>
        private void SetLableNotification(int result)
        {
            if (result == 0)
            {
                toolStripLabelNotification.ForeColor = Color.Green;
                toolStripLabelNotification.Text = _lablesuccseed;
                toolStripLabelNotification.Visible = true;

            }
            else
            {
                toolStripLabelNotification.ForeColor = Color.Red;
                toolStripLabelNotification.Text = _lablefailed;
                toolStripLabelNotification.Visible = true;
            }

        }

        private void SetCursorNormal()
        {
            Cursor = Cursors.Arrow;
        }

        private void RefreshComboboxesInvoke()
        {
            RefreshComboboxes();
        }

        #endregion

        #region Callbacks

        /// <summary>
        /// Calback for mountkeyfilecontainer
        /// </summary>
        /// <param name="result"></param>
        public void CallbackHandlerMountKyfilecontainer(IAsyncResult result)
        {

            // Get returned value form result
            var mountmethode = (MountKeyfilecontainerDelegate)result.AsyncState;
            // get the returned value
            int completion = mountmethode.EndInvoke(result);


            if (statusStrip1.InvokeRequired)
            {
                StopProgressbarDelegate stop = StopProgressbar;
                Invoke(stop);
            }
            else
            {
                StopProgressbar();
            }
            if (statusStrip1.InvokeRequired)
            {
                SetLableNotificationDelegate set = SetLableNotification;
                Invoke(set, new object[] { completion });
            }
            else
            {
                SetLableNotification(completion);
            }
            if (comboBoxDrives.InvokeRequired || comboBoxContainer.InvokeRequired)
            {
                RefreshComboboxesInvokeDelegate cbr = RefreshComboboxesInvoke;
                Invoke(cbr);
            }
            else
            {
                RefreshComboboxes();
            }
            SetCursorNormalDelegate curs = SetCursorNormal;
            Invoke(curs);
            NormalDelegate normal = Normal;
            Invoke(normal);
        }

        ///<summary>
        /// Callback for all dismounts.
        /// Set the form normal and gives the returncode to the SetLableNotification method. 
        ///</summary>
        ///<param name="result"></param>
        public void CallbackHandlerDismount(IAsyncResult result)
        {
            var dismount = (DismountDelegate)result.AsyncState;

            int completion = dismount.EndInvoke(result);

            if (statusStrip1.InvokeRequired)
            {
                StopProgressbarDelegate stop = StopProgressbar;
                Invoke(stop);
            }
            else
            {
                StopProgressbar();
            }
            if (statusStrip1.InvokeRequired)
            {
                SetLableNotificationDelegate set = SetLableNotification;
                Invoke(set, new object[] { completion });
            }
            else
            {
                SetLableNotification(completion);
            }
            if (comboBoxDrives.InvokeRequired || comboBoxContainer.InvokeRequired)
            {
                RefreshComboboxesInvokeDelegate cbr = RefreshComboboxesInvoke;
                Invoke(cbr);
            }
            else
            {
                RefreshComboboxes();
            }
            SetCursorNormalDelegate curs = SetCursorNormal;
            Invoke(curs);
            NormalDelegate normal = Normal;
            Invoke(normal);
        }

        ///<summary>
        /// Callback for the mountdrive method.
        /// Set the form normal and gives the returncode to the SetLableNotification method. 
        ///</summary>
        ///<param name="result"></param>
        public void CallbackHandlerMountDrive(IAsyncResult result)
        {
            var mountdrive = (MountDriveDelegate)result.AsyncState;

            int completion = mountdrive.EndInvoke(result);


            if (statusStrip1.InvokeRequired)
            {
                StopProgressbarDelegate stop = StopProgressbar;
                Invoke(stop);
            }
            else
            {
                StopProgressbar();
            }
            if (statusStrip1.InvokeRequired)
            {
                SetLableNotificationDelegate set = SetLableNotification;
                Invoke(set, new object[] { completion });
            }
            else
            {
                SetLableNotification(completion);
            }
            if (comboBoxDrives.InvokeRequired || comboBoxContainer.InvokeRequired)
            {
                RefreshComboboxesInvokeDelegate cbr = RefreshComboboxesInvoke;
                Invoke(cbr);
            }
            else
            {
                RefreshComboboxes();
            }
            SetCursorNormalDelegate curs = SetCursorNormal;
            Invoke(curs);
            NormalDelegate normal = Normal;
            Invoke(normal);
        }

        ///<summary>
        /// Callback for the mountcontainer method.
        /// Set the form normal and gives the returncode to the SetLableNotification method. 
        ///</summary>
        ///<param name="result"></param>
        public void CallbackHandlerMountContainer(IAsyncResult result)
        {
            var mountcontainer = (MountContainerDelegate)result.AsyncState;

            int completion = mountcontainer.EndInvoke(result);


            if (statusStrip1.InvokeRequired)
            {
                StopProgressbarDelegate stop = StopProgressbar;
                Invoke(stop);
            }
            else
            {
                StopProgressbar();
            }
            if (statusStrip1.InvokeRequired)
            {
                SetLableNotificationDelegate set = SetLableNotification;
                Invoke(set, new object[] { completion });
            }
            else
            {
                SetLableNotification(completion);
            }
            if (comboBoxDrives.InvokeRequired || comboBoxContainer.InvokeRequired)
            {
                RefreshComboboxesInvokeDelegate cbr = RefreshComboboxesInvoke;
                Invoke(cbr);
            }
            else
            {
                RefreshComboboxes();
            }
            SetCursorNormalDelegate curs = SetCursorNormal;
            Invoke(curs);
            NormalDelegate normal = Normal;
            Invoke(normal);
        }
        #endregion     
   
        void EnableKeyfilekontainer()
        {
            this.Size = new Size(410, 308);
        }

        void DisableKeyfilekontainer()
        {
            this.Size = new Size(410, 250);
            
        }
    }
}
