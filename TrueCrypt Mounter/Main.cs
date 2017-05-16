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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    ///<summary>
    /// The main class. Here is all control for the programm
    ///</summary>
    public partial class VeraCryptMounter : Form
    {
        #region Vareables

        private const string AppId = "VeraCryptMounter";
        private const string LanguageRegion = "Main";
        private const string LanguageToolTip = "MainToolTips";

        private readonly BindingManagerBase _bmbd;
        private readonly BindingManagerBase _bmbk;
        private readonly List<string> _cbdrive = new List<string>();
        private readonly List<string> _cbkontainer = new List<string>();
        private readonly Config _config = new Config();

        private readonly List<string> _mounteddrives = new List<string>();
        private readonly List<string> _mountedkontainer = new List<string>();

        private static ManagementScope scope = new ManagementScope("root\\CIMV2");
        private ManagementEventWatcher w = null;

        private string _language;
        private string _lablefailed;
        private string _lablesuccseed;
       

        #endregion

        #region Delegates
        /// <summary>
        /// Delegate for mountkeyfilekontainer
        /// </summary>
        /// <param name="path">string</param>
        /// <param name="driveletter">string</param>
        /// <param name="silent">bool</param>
        /// <param name="beep">bool</param>
        /// <param name="force">bool</param>
        /// <param name="readOnly">bool</param>
        /// <param name="removable">bool</param>
        /// <param name="hash">string</param>
        /// <param name="pim">string</param>
        /// <returns></returns>
        public delegate int MountKeyfilecontainerDelegate(string path, string driveletter, bool silent, bool beep, bool force,
                                                          bool readOnly, bool removable, string hash, bool pim);

        /// <summary>
        /// Delegate for Mounting a Drive
        /// </summary>
        /// <param name="partition">string[]</param>
        /// <param name="driveletter">string</param>
        /// <param name="keyfile">string</param>
        /// <param name="password">string</param>
        /// <param name="silent">bool</param>
        /// <param name="beep">bool</param>
        /// <param name="force">bool</param>
        /// <param name="readOnly">bool</param>
        /// <param name="removable">bool</param>
        /// <param name="pim">string</param>
        /// <param name="hash">string</param>
        /// <param name="tc">bool</param>
        /// <returns></returns>
        public delegate int MountDriveDelegate(string[] partition, string driveletter, string keyfile, string password, bool silent,
                                                bool beep, bool force, bool readOnly, bool removable, string pim, string hash, bool tc);

        /// <summary>
        /// delegate for mounting a container
        /// </summary>
        /// <param name="path"></param>
        /// <param name="driveletter"></param>
        /// <param name="keyfile"></param>
        /// <param name="password"></param>
        /// <param name="silent"></param>
        /// <param name="beep"></param>
        /// <param name="force"></param>
        /// <param name="readOnly"></param>
        /// <param name="removable"></param>
        /// <param name="tc"></param>
        /// <param name="pim"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public delegate int MountContainerDelegate(string path, string driveletter, string keyfile, string password, bool silent,
                                                   bool beep, bool force, bool readOnly, bool removable, bool tc, string pim,string hash);

        /// <summary>
        /// delegate for dismounting a drive or container
        /// </summary>
        /// <param name="driveletter"></param>
        /// <param name="silent"></param>
        /// <param name="beep"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public delegate int DismountDelegate(string driveletter, bool silent, bool beep, bool force);


        /// <summary>
        /// Stop the progressbar from other task
        /// </summary>
        public delegate void StopProgressbarDelegate();

        /// <summary>
        /// set label notification base on result
        /// </summary>
        /// <param name="result">0 for ok, 1 for fail</param>
        public delegate void SetLableNotificationDelegate(int result);

        /// <summary>
        /// sets main ui on normal state
        /// </summary>
        public delegate void NormalDelegate();

        /// <summary>
        /// sets main ui on busy state 
        /// </summary>
        public delegate void BusyDelegate();

        /// <summary>
        /// set cursor on normal state
        /// </summary>
        public delegate void SetCursorNormalDelegate();

        /// <summary>
        /// refresh comboboxes 
        /// </summary>
        public delegate void RefreshComboboxesInvokeDelegate();

        /// <summary>
        /// start automount from usb 
        /// </summary>
        /// <param name="e">eventparameter</param>
        /// <returns></returns>
        private delegate Automountusb UsbAnalysisDelegate(EventArrivedEventArgs e);


        #endregion

        #region USBEvent

        /// <summary>
        /// Event method if a usbdevice is pluged in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UsbEventArrived(object sender, EventArrivedEventArgs e)
        {
            UsbAnalysisDelegate aus = UsbEventAnalysing;
            BusyDelegate bu = Busy;
            Invoke(bu);
            aus.BeginInvoke(e, UsbCallback, aus);
        }


        /// <summary>
        /// Analyse if the usbdevice is a sorrage device.
        /// </summary>
        /// <param name="e"></param>
        /// <returns>true if it is a storage device</returns>
        private static Automountusb UsbEventAnalysing(EventArrivedEventArgs e)
        {
            Automountusb autousb = new Automountusb();
            Automountusb res = null;
            // Get the Event Object.
            foreach (PropertyData pd in e.NewEvent.Properties)
            {
                ManagementBaseObject mbo = null;
                if ((mbo = pd.Value as ManagementBaseObject) != null)
                {
                    foreach (PropertyData prop in mbo.Properties)
                    {
                        string test = (string)prop.Value;
                        if (test != null)
                        {
                            if (test.Contains("USBSTOR") || test.Contains("SCSI\\\\DISK"))
                            {
                                res = autousb.MountUsb(test);
                                return res;
                            }
                        }
                    }
                }
            }
            return null;
        }
        
        /// <summary>
        /// Changed notification if automunt has tried to mount anything.
        /// </summary>
        /// <param name="result"></param>
        private void UsbCallback(IAsyncResult result)
        {
            var ausresult = (UsbAnalysisDelegate)result.AsyncState;
            Automountusb res = ausresult.EndInvoke(result);
            int completion = 1;
            if (res != null)
            {
                if (res.State)
                    completion = 0;

                _lablesuccseed = res.Name + LanguagePool.GetInstance().GetString(LanguageRegion, "Automountusbsucceed", _language);
                _lablefailed = res.Name + LanguagePool.GetInstance().GetString(LanguageRegion, "Automountusbfailed", _language);

                if (statusStrip1.InvokeRequired)
                {
                    SetLableNotificationDelegate set = SetLableNotification;
                    Invoke(set, new object[] { completion });
                }
                else
                    SetLableNotification(completion);

                if (this.InvokeRequired)
                {
                    NormalDelegate nor = Normal;
                    Invoke(nor);
                }
                else
                    Normal();


            }
        }

        /// <summary>
        /// Set Eventwatcher for usb event. called if any usb event is signaled.
        /// </summary>
        private void UsbEventWatcher()
        {            
            WqlEventQuery q = new WqlEventQuery();
            scope.Options.EnablePrivileges = true; //sets required privilege
            try
            {
                q.EventClassName = "__InstanceCreationEvent";

                q.WithinInterval = new TimeSpan(0, 0, 15);

                q.Condition = @"TargetInstance ISA 'Win32_USBControllerDevice' ";
                w = new ManagementEventWatcher(scope, q);

                w.EventArrived += UsbEventArrived;
                w.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Constructor, Destructor
        ///<summary>
        /// Constructor makes all settings for the programm for first running. 
        ///</summary>
        public VeraCryptMounter()
        {
            InitializeComponent();
            UsbEventWatcher();


            comboBoxDrives.ContextMenuStrip = contextMenuStripDrive;
            comboBoxContainer.ContextMenuStrip =contextMenuStripContainer ;
            
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
        }
        /// <summary>
        /// Destructor set passwords and PIM to null.
        /// </summary>
        ~VeraCryptMounter()
        {
        }

        #endregion

        private void AutomountAtStart()
        { 
            Automountstart ams = new Automountstart();
            //TODO seems working Test is on
            ams.StartMount();           
        }

        #region Language settings

        /// <summary>
        /// Set all controllelements to the selected language if the language is changed.
        /// </summary>
        private void LanguageFill()
        {
            if (_language != _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, ""))
            {
                _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");               
                Properties.Settings.Default.language = _language;
                Properties.Settings.Default.Save();
                try
                {
                    // Fill the controls with text.
                    buttonDismount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonDismount", _language);
                    buttonDismountContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonDismountContainer", _language);
                    buttonKeyfileContainerDismount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonKeyfileContainerDismount", _language);
                    buttonKeyfileContainerMount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonKeyfileContainerMount", _language);
                    buttonMount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonMount", _language);
                    buttonMountContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonMountContainer", _language);
                    groupBoxDrive.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxDrive", _language);
                    groupBoxContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxContainer", _language);
                    groupBoxKeyfileContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxKeyfileContainer", _language);
                    ToolStripMenuItemFile.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "ToolStripMenuItemFile", _language);
                    ToolStripMenuItemClose.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "ToolStripMenuItemClose", _language);
                    ToolStripMenuItemEdit.Text = LanguagePool.GetInstance().GetString(LanguageRegion,"ToolStripMenuItemEdit", _language);
                    containerToolStripMenuItem.Text = LanguagePool.GetInstance().GetString(LanguageRegion,"ContainerToolStripMenuItem", _language);
                    ToolStripMenuItemNew.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "ToolStripMenuItemNew", _language);
                    ToolStripMenuItemEditEntry.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "ToolStripMenuItemEditEntry",_language);
                    ToolStripMenuItemRemove.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "ToolStripMenuItemRemove",_language);
                    driveToolStripMenuItem.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "DriveToolStripMenuItem",_language);
                    toolStripMenuItemSettings.Text = LanguagePool.GetInstance().GetString(LanguageRegion,"toolStripMenuItemSettings",_language);
                    ToolStripMenuItemMainSettings.Text = LanguagePool.GetInstance().GetString(LanguageRegion,"ToolStripMenuItemMainSettings", _language);
                    ToolStripMenuItemHelp.Text = LanguagePool.GetInstance().GetString(LanguageRegion,"ToolStripMenuItemHelp",_language);
                    toolStripMenuVersion.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "toolStripMenuVersion",_language);
                    ToolStripMenuItemNotifyKeyfilecontainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion,"ToolStripMenuItemNotifyKeyfilecontainer",_language);
                    ToolStripMenuItemNotifyRestore.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "ToolStripMenuItemNotifyRestore", _language);
                    ToolStripMenuItemNotifyClose.Text = LanguagePool.GetInstance().GetString(LanguageRegion,"ToolStripMenuItemNotifyClose",_language);
                    ToolStripMenuItemNotifyMount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "ToolStripMenuItemNotifyMount",_language);
                    ToolStripMenuItemNotifyDismount.Text = LanguagePool.GetInstance().GetString(LanguageRegion,"ToolStripMenuItemNotifyDismount", _language);
                    comboBoxDrives.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "comboBoxDrives",_language);
                    comboBoxContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "comboBoxContainer",_language);
                    toolStripMenuItem_Drive_new.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "toolStripMenuItem_Drive_new", _language);
                    toolStripMenuItem_Drive_edit.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "toolStripMenuItem_Drive_edit", _language);
                    deleteToolStripMenuItem.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "deleteToolStripMenuItem", _language);
                    toolStripMenuItem_Container_new.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "toolStripMenuItem_Container_new", _language);
                    editToolStripMenuItem_Container_edit.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "editToolStripMenuItem_Container_edit", _language);
                    deleteToolStripMenuItem1.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "deleteToolStripMenuItem1", _language);
                    automountToolStripMenuItem.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "automountToolStripMenuItem", _language);
                    automountToolStripMenuItem1.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "automountToolStripMenuItem", _language);
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

        /// <summary>
        /// Method to validate the mainconfig. 
        /// If config is not set deactivate all buttons and give aut the massage.
        /// </summary>
        private void ValidateTest()
        {
            //Deactivate all button if no configuration is made
            if (!VeraCrypt_Mounter.Validate.ValidateConfig())
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
        public void RefreshComboboxes()
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
            ValidateMount vm = new ValidateMount();
            MountDriveDelegate mountdrive = Mount.MountDrive;
            MountVareables mvd;
            string name;

            // test if combobox drive select is done.
            try
            {
                // Test if entry in driverbox is chosen. 
                if (comboBoxDrives.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "DriveSelectionFaild", _language));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            name = comboBoxDrives.SelectedItem.ToString();
            //change elements to mount state
            toolStripLabelNotification.Visible = false;
            toolStripProgressBar.Visible = true;
            
            try
            {
                mvd = vm.ValidateMountDrive(name, _language);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // mount drive 
            mountdrive.BeginInvoke(mvd.partitionlist, mvd.driveletter, mvd.key, mvd.password, mvd.silent, mvd.beep, mvd.force, mvd.readOnly, mvd.removalbe, mvd.pim, 
                                    mvd.hash, mvd.tc, CallbackHandlerMountDrive, mountdrive);
            
            //change to mount state 
            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationDriveSucceed", _language);
            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationDriveFaild", _language);
            toolStripProgressBar.MarqueeAnimationSpeed = 30;
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

            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationDriveDismountSucceed",_language);
            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationDriveDismountFaild",_language);
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
            MountVareables mvd;
            ValidateMount vm = new ValidateMount();
            string name;
            // first check if anything is chosen
            try
            {
                // Test if entry in driverbox is chosen
                if (comboBoxContainer.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "SelectionFaild",
                                                                             _language));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            name = comboBoxContainer.SelectedItem.ToString();

            toolStripLabelNotification.Visible = false;
            
            try
            {
                
                mvd = vm.ValidateMountContainer(name, _language);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            toolStripProgressBar.Visible = true;

            MountContainerDelegate mountcontainer = Mount.MountContainer;

            mountcontainer.BeginInvoke(mvd.path, mvd.driveletter, mvd.key, mvd.password, mvd.silent, mvd.beep, mvd.force, mvd.readOnly, mvd.removalbe,
                                        mvd.tc, mvd.pim, mvd.hash, CallbackHandlerMountContainer, mountcontainer);

            toolStripProgressBar.MarqueeAnimationSpeed = 30;
            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationContainerSucceed", _language);
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

            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationContainerDismountSucceed", _language);

            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationContainerDismountFaild", _language);

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

            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationKeyfilecontainerSucceed", _language);
            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationKeyfilecontainerFaild",_language);
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

            _lablesuccseed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationKeyfilecontainerDismountSucceed",_language);
            _lablefailed = LanguagePool.GetInstance().GetString(LanguageRegion, "NotificationKeyfilecontainerDismountFaild",_language);
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
                if (comboBoxDrives.Items.Count > 0)
                    comboBoxDrives.SelectedIndex = comboBoxDrives.Items.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        private void ToolStripMenuEditEntry_Click(object sender, EventArgs e)
        {
            string selection = "container";
            string letter = null;
            try
            {

                // Test if entry in driverbox is chosen.
                if (comboBoxDrives.SelectedItem == null && comboBoxContainer.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "SelectionFaild",
                                                                             _language));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxContainer.SelectedItem == null) selection = "drive";
            Form dialogBox = new Form();

            switch (selection)
            {
                case "drive":
                    letter = comboBoxDrives.SelectedItem.ToString();
                    dialogBox = new NewDrive(letter);
                    break;
                case "container":
                    letter = comboBoxContainer.SelectedItem.ToString();
                    dialogBox = new NewContainer(letter);
                    break;
            }
               

            try
            {
                // Test if Drive is mounted.
                if (!DrivelettersHelper.IsDriveletterFree(
                    _config.GetValue(letter, ConfigTrm.Drive.Driveletter, "")))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "EditMounted",
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


            dialogBox.ShowDialog(); // Returns when dialog box has closed
            RefreshComboboxes();
        }

        private void ToolStripMenuDelete_Click(object sender, EventArgs e)
        {
            string selection = "container";
            string name = "";
            DialogResult result =  DialogResult.Cancel;

            try
            {

                //TODO Fehler wenn beide ausgewählt sind 
                if (comboBoxDrives.SelectedItem == null && comboBoxContainer.SelectedItem == null)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "SelectionFaild", _language));
                }

                if (comboBoxContainer.SelectedItem == null) selection = "drive";

                switch (selection)
                {
                    case "drive":
                        name = comboBoxDrives.SelectedItem.ToString();
                        result = MessageBox.Show(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDriveDelete", _language),
                                    LanguagePool.GetInstance().GetString(LanguageRegion, "MessageWarning", _language), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        break;
                    case "container":
                        name = comboBoxContainer.SelectedItem.ToString();
                        result = MessageBox.Show(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageContainerDelete", _language),
                                    LanguagePool.GetInstance().GetString(LanguageRegion, "MessageWarning", _language), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        break;
                }

                
                if (result == DialogResult.Yes)
                {
                    _config.RemoveSection(name);
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

        private void ToolStripMenuDriveDelete_Click(object sender, EventArgs e)
        {
            ToolStripMenuDelete_Click(sender, e);
        }

        private void ToolStripMenuContainerDelete_Click(object sender, EventArgs e)
        {
            ToolStripMenuDelete_Click(sender, e);
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

        

        #endregion 

        #region NotifyIcon

        private void VeraCryptMounter_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
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

        #region Comboboxes Draw Events

        // If you set the Draw property to DrawMode.OwnerDrawVariable, 
        // you must handle the MeasureItem event. This event handler 
        // will set the height and width of each item before it is drawn. 
        private void ComboBox_Laufwerke_MeasureItem(object sender,
                                                    MeasureItemEventArgs e)
        {
            // ItemHeight shout be font size + 4 
            e.ItemHeight = 14;
            //e.ItemWidth = 120;
            
        }

        // You must handle the DrawItem event for owner-drawn combo boxes.  
        // This event handler changes the color, size and font of an 
        // item based on its position in the array.
        private void ComboBox_Laufwerke_DrawItem(object sender,
                                                 DrawItemEventArgs e)
        {
            Font myFont;

            float size = 9;
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
            e.ItemHeight = 14;
            //e.ItemWidth = 120;
        }

        // You must handle the DrawItem event for owner-drawn combo boxes.  
        // This event handler changes the color, size and font of an 
        // item based on its position in the array.
        private void ComboBoxKontainerDrawItem(object sender,
                                                DrawItemEventArgs e)
        {
            Font myFont;

            const float size = 9;
            const FontStyle fstyle = FontStyle.Regular;
            //string fontname = comboBoxContainer.Font.Name;
            FontFamily family = FontFamily.GenericSansSerif;
            Brush brush = Brushes.Black;

            if (_mountedkontainer.Contains(_cbkontainer[e.Index]))
                brush = Brushes.SeaGreen;

            // Draw the background of the item.
            e.DrawBackground();

            // Draw each string in the array, using a different size, color,
            // and font for each item.
            myFont = new Font(family, size, fstyle);
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
        /// <summary>
        /// refresh the comboboxes
        /// </summary>
        public void RefreshComboboxesInvoke()
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

        #region Workflow and resizing

        void EnableKeyfilekontainer()
        {
            this.Size = new Size(410, 308);
        }

        void DisableKeyfilekontainer()
        {
            this.Size = new Size(410, 250);
            
        }

        private void comboBoxDrives_MouseClick(object sender, MouseEventArgs e)
        {          
            comboBoxDrives.DroppedDown = true;
        }

        private void comboBoxContainer_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxContainer.DroppedDown = true;
        }

        private void comboBoxDrives_DropDown(object sender, EventArgs e)
        {
            RefreshComboboxes();
        }

        private void comboBoxContainer_DropDown(object sender, EventArgs e)
        {
            RefreshComboboxes();
        }
        private void VeraCryptMounter_FormClosing(object sender, FormClosingEventArgs e)
        {
            //stop usb event watcher on close
            w.Stop();
        }

        private void automountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busy();
            toolStripLabelNotification.ForeColor = Color.Green;
            toolStripLabelNotification.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Automount", _language);
            toolStripLabelNotification.Visible = true;
            AutomountAtStart();
            Normal();
            toolStripLabelNotification.Visible = false;
        }

        private void VeraCryptMounter_Shown(object sender, EventArgs e)
        {
            Busy();
            toolStripLabelNotification.ForeColor = Color.Green;
            toolStripLabelNotification.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Automount", _language);
            toolStripLabelNotification.Visible = true;
            AutomountAtStart();
            Normal();
            toolStripLabelNotification.Visible = false;
        }

        private void automountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Busy();
            toolStripLabelNotification.ForeColor = Color.Green;
            toolStripLabelNotification.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Automount", _language);
            toolStripLabelNotification.Visible = true;
            AutomountAtStart();
            Normal();
            toolStripLabelNotification.Visible = false;
        }

        #endregion
    }
}
