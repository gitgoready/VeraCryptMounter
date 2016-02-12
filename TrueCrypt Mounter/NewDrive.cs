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
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    ///<summary>
    /// Class NewDrive shows the form for creating a new drive entry in the config.
    ///</summary>
    public partial class NewDrive : Form
    {
        private readonly Config _config = new Config();
        private readonly List<string> _driveletters = new List<string>();
        private readonly List<string> _useddriveletters = new List<string>();
        private static object[] _hashes = { "", "sha512", "sha256", "whirlpool", "ripemd160" };
        private bool _edit;
        private readonly string _language; 
        private const string LanguageRegion = "NewDrive";
        private string _oldName = null;
        private string _disknummber;
        private string _partnummber;
        private string _diskmodel;
        private string _diskserial;
        private string _pnpdeviceid;
        private string _password = null;
        private string _pim = null;

        /// <summary>
        /// Set the pnpdeviceid for the drive
        /// </summary>
        public string PNPDeviceID
        {
            set { _pnpdeviceid = value; }
        }
        /// <summary>
        /// Set the disknumber for the drive
        /// </summary>
        public string Disknummber
        {
            set { _disknummber = value; }
        }
        /// <summary>
        /// Set the partition number on the drive
        /// </summary>
        public string Partnummber
        {
            set { _partnummber = value; }
        }
        /// <summary>
        /// Set the name of the drive
        /// </summary>
        public string Diskmodel
        {
            set { _diskmodel = value; }
        }
        /// <summary>
        /// set the serial of the drive
        /// </summary>
        public string Diskserial
        {
            set { _diskserial = value; }
        }
        ///<summary>
        /// Constructor for new drive element.
        ///</summary>
        public NewDrive()
        {
            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);         
            _language =  _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "E");
            LanguageFill();
            NewDriveCreate();
        }
         /// <summary>
         /// Constructor for editing an existing drive.
         /// </summary>
        /// <param name="driveName">The name of the drive in the config file</param>
        public NewDrive(string driveName)
        {
            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "E");
            LanguageFill();
            if (string.IsNullOrEmpty(driveName))
               Close();
            NewDriveEdit(driveName);
        }

        /// <summary>
        /// Set the languagestrings for the controls.
        /// </summary>
        private void LanguageFill()
        {
            try
            {
                lableDescription.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "lableDescription", _language);
                lablePartition.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "lablePartition", _language);
                lableKeyfile.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "lableKeyfile", _language);
                checkBoxNoKeyfile.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxNoKeyfile", _language);
                groupBoxMountoptions.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxMountoptions", _language);
                checkBoxRemovable.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxRemovable", _language);
                checkBoxReadonly.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxReadonly", _language);
                groupBoxDriveletter.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "lableDriveletter", _language);
                buttonOk.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOk", _language);
                buttonCancel.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonCancel", _language);
                checkBoxAutomountUsb.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxAutomountUsb", _language);
                checkBoxAutomountStart.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxAutomountStart", _language);
                checkBoxTruecrypt.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxTruecrypt", _language);
                checkBoxPim.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxPim", _language);
                groupBox_PNPDeviceID.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxPNPDeviceID", _language);
                buttonShowPassword.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonShowPassword", _language);
                checkBoxPassword.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxPassword", _language);
                buttonSavePassword.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonSavePassword", _language);
                groupBoxSavePassword.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxSavePassword", _language);
                //.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "", _language);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        /// <summary>
        /// Fills the controls with the needed information for creating a drive.
        /// </summary>
        private void NewDriveCreate()
        {
            Text = LanguagePool.GetInstance().GetString(LanguageRegion, "NewDrive", _language);
            // Set _edit to false.
            _edit = false;
            // Get the driveletters and the used driveletters and stor them in the lists.
            foreach (string element in DrivelettersHelper.GetDriveletters())
                _driveletters.Add(element);
            foreach (string elemnt in DrivelettersHelper.GetUsedDriveletter())
                _useddriveletters.Add(elemnt);
            // Set the datasource for the drivelettercobobox and select the first. 
            comboBoxDriveletter.DataSource = _driveletters;
            comboBoxDriveletter.SelectedItem = _driveletters[0];
            comboBoxHash.Items.AddRange(_hashes);

            buttonShowPassword.Enabled = false;
        }

        /// <summary>
        /// Fill the controls with the information that needed to edit the drive.
        /// </summary>
        /// <param name="driveName"></param>
        private void NewDriveEdit(string driveName)
        {
            Text = LanguagePool.GetInstance().GetString(LanguageRegion, "DriveEdit", _language);
            _edit = true;
            _oldName = driveName;
            foreach (string element in DrivelettersHelper.GetDriveletters())
                _driveletters.Add(element);
            foreach (string elemnt in DrivelettersHelper.GetUsedDriveletter())
                _useddriveletters.Add(elemnt);
            comboBoxDriveletter.DataSource = _driveletters;
            comboBoxHash.Items.AddRange(_hashes);

            textBoxDescription.Text = driveName;
            textBoxPartition.Text = _config.GetValue(driveName, ConfigTrm.Drive.Partition, "\\Device\\Harddisk\\Partition");
            textBoxKeyfile.Text = _config.GetValue(driveName, ConfigTrm.Drive.Keyfile, "");
            checkBoxNoKeyfile.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Nokeyfile, false);
            checkBoxReadonly.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Readonly, false);
            checkBoxRemovable.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Removable, false);
            checkBoxAutomountStart.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Automountstart, false);
            checkBoxAutomountUsb.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Automountusb, false);
            checkBoxPim.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Pimuse, false);
            checkBoxTruecrypt.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Truecrypt, false);
            comboBoxHash.SelectedItem = _config.GetValue(driveName, ConfigTrm.Drive.Hash, "");
            _disknummber = _config.GetValue(driveName, ConfigTrm.Drive.Disknumber, "");
            _partnummber = _config.GetValue(driveName, ConfigTrm.Drive.Partnumber, "");
            _pnpdeviceid = _config.GetValue(driveName, ConfigTrm.Drive.Pnpdeviceid, "");
            _password = _config.GetValue(driveName, ConfigTrm.Drive.Password, "");
            _pim = _config.GetValue(driveName, ConfigTrm.Drive.Pim, "");

            textBox_PNPDeviceID.Text = _pnpdeviceid;

            comboBoxDriveletter.SelectedItem = _config.GetValue(driveName, ConfigTrm.Drive.Driveletter, "");

            if (string.IsNullOrEmpty(_password))
                buttonShowPassword.Enabled = false;
        }

        /// <summary>
        /// Event that close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abbruch_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event from buttonOK. Write the information for the drive in the config.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void erstellen_Click(object sender, EventArgs e)
        {
            string part;
            string key;
            string dletter;
            string beschr;
            string hash;
            string usedriveletter = DrivelettersHelper.IsDrivletterUsedByConfig(comboBoxDriveletter.SelectedItem.ToString());
            // Load information from controls into variables
            beschr = textBoxDescription.Text;
            part = textBoxPartition.Text;
            key = textBoxKeyfile.Text;
            dletter = comboBoxDriveletter.SelectedItem.ToString();

            try
            {
                if (checkBoxPim.Checked)
                {
                    if (string.IsNullOrEmpty(_pim) && !string.IsNullOrEmpty(_password))
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePimNotSet", _language));
                }
            }
            catch (Exception ex)
            {
                DialogResult res = MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonSavePassword_Click(this, e);
            }

            //if driveletter is used ask if it shoud ignor or select a new one
            try
            {
                if (usedriveletter != null && usedriveletter != textBoxDescription.Text)
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDrivletterIsUsed", _language) + usedriveletter);
            }
            catch (Exception ex)
            {
                DialogResult res = MessageBox.Show(ex.Message, "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                if (res == DialogResult.Abort)
                {
                    return;
                }
                if (res == DialogResult.Retry)
                {
                    erstellen_Click(sender, e);
                    return;
                }

            }
            // Validate userinput
            try
            {
                if (_oldName != null)
                    if (beschr != _oldName)
                        _config.RemoveSection(_oldName);

                

                //check if hash is selected
                hash = (comboBoxHash.SelectedItem == null) ? "" : comboBoxHash.SelectedItem.ToString();



                // Check if driveconfig exist
                if (!_edit)
                {
                    string[] names = _config.GetSectionNames();
                    foreach (string name in names)
                    {
                        if (name == beschr)
                        {
                            throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDriveExist", _language));
                        }
                    }
                    
                }
                // Check if drivename is set.
                if (string.IsNullOrEmpty(beschr))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDesciptionEmpty", _language));
                }

                // Check if description begins with a letter.
                char[] firstLetter = textBoxDescription.Text.ToCharArray();
                if (!char.IsLetter(firstLetter[0]))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDescriptionLetter", _language));
                }

                // Check if description has not a valid name.
                if (textBoxDescription.Text == ConfigTrm.Mainconfig.Section || textBoxDescription.Text == "configSections")
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDescriptNoValidName", _language));
                }

                // Check if partitionname is set.
                if (string.IsNullOrEmpty(part))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePartitionIsEmpty", _language));
                }

                // Check if keyfile is empty when nokeyfile is not checked. 
                if (!checkBoxNoKeyfile.Checked)
                {
                    if (string.IsNullOrEmpty(key))
                    {
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageKeyfileEmpty", _language));
                    }
                }

                string pat = @"\\Device\\Harddisk\d+\\Partition\d+$";
                Regex r = new Regex(pat);
                            
                // Check if partiton has the right format.
                if (!r.IsMatch(part))
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePartitionWrongFormat", _language));
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Write data into config file.
            try
            {
                
                _config.SetValue(beschr, ConfigTrm.Drive.Partition, part);
                _config.SetValue(beschr, ConfigTrm.Drive.Keyfile, key);
                _config.SetValue(beschr, ConfigTrm.Drive.Driveletter, dletter);
                _config.SetValue(beschr, ConfigTrm.Drive.Type, ConfigTrm.Drive.Typename);
                _config.SetValue(beschr, ConfigTrm.Drive.Nokeyfile, checkBoxNoKeyfile.Checked);
                _config.SetValue(beschr, ConfigTrm.Drive.Removable, checkBoxRemovable.Checked);
                _config.SetValue(beschr, ConfigTrm.Drive.Readonly, checkBoxReadonly.Checked);
                _config.SetValue(beschr, ConfigTrm.Drive.Automountusb, checkBoxAutomountUsb.Checked);
                _config.SetValue(beschr, ConfigTrm.Drive.Automountstart, checkBoxAutomountStart.Checked);
                _config.SetValue(beschr, ConfigTrm.Drive.Diskmodel, _diskmodel);
                _config.SetValue(beschr, ConfigTrm.Drive.Diskserial, _diskserial);
                _config.SetValue(beschr, ConfigTrm.Drive.Pimuse, checkBoxPim.Checked);
                _config.SetValue(beschr, ConfigTrm.Drive.Truecrypt, checkBoxTruecrypt.Checked);
                _config.SetValue(beschr, ConfigTrm.Drive.Hash, hash);
                _config.SetValue(beschr, ConfigTrm.Drive.Disknumber, _disknummber);
                _config.SetValue(beschr, ConfigTrm.Drive.Partnumber, _partnummber);
                _config.SetValue(beschr, ConfigTrm.Drive.Pnpdeviceid, _pnpdeviceid);
                _config.SetValue(beschr, ConfigTrm.Drive.Pimuse, checkBoxPim.Checked);

                if (!string.IsNullOrEmpty(_password))
                {
                    _config.SetValue(beschr, ConfigTrm.Drive.Password, _password);
                    _config.SetValue(beschr, ConfigTrm.Drive.Pim, _pim);
                }

                if (checkBoxPassword.Checked)
                {
                    _config.SetValue(beschr, ConfigTrm.Drive.Password, "");
                    _config.SetValue(beschr, ConfigTrm.Drive.Pim, "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error writing config");
                _config.RemoveSection(beschr);
            }
            // Close the form.
            Close();
        }

        /// <summary>
        /// Handle the event for the nokeyfile checkbox.
        /// Clears the textbox for keyfiel and make it readonly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckboxNoKeyfileCheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxNoKeyfile.Checked)
            {
                textBoxKeyfile.Clear();
                textBoxKeyfile.ReadOnly = true;
            }
            else
            {
                textBoxKeyfile.ReadOnly = false;
            }
        }

        /// <summary>
        /// You must handle the MeasureItem event for owner-drawn combo boxes.
        /// This event handler changes the dimension of the drawbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxDriveletter_MeasureItem(object sender,
                                                     MeasureItemEventArgs e)
        {
            // ItemHeight shout be font size + 4 
            e.ItemHeight = 12;
        }

        /// <summary>
        /// You must handle the DrawItem event for owner-drawn combo boxes.  
        /// This event handler changes the color, size and font of an item based on its position in the array.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxDriveletter_DrawItem(object sender,
                                                  DrawItemEventArgs e)
        {
            Font myFont;

            float size = 8;
            const FontStyle fstyle = FontStyle.Regular;
            string fontname = comboBoxDriveletter.Font.Name;
            //FontFamily family = FontFamily.GenericSansSerif;
            Brush brush = Brushes.Black;

            if (_useddriveletters.Contains(_driveletters[e.Index]))
                brush = Brushes.Red;

            // Draw the background of the item.
            e.DrawBackground();

            // Draw each string in the array, using a different size, color,
            // and font for each item.
            myFont = new Font(fontname, size, fstyle);
            e.Graphics.DrawString(_driveletters[e.Index], myFont, brush, e.Bounds.X, e.Bounds.Y);

            // Draw the focus rectangle if the mouse hovers over an item.
            e.DrawFocusRectangle();
        }

        private void buttonChosePartition_Click(object sender, EventArgs e)
        {
            var sp = new SelectPartition();
            DialogResult res = sp.ShowDialog();
            _partnummber = sp._partnummber;
            _diskmodel = sp._diskmodel;
            _disknummber = sp._disknummber;
            _diskserial = sp._diskserial;
            _pnpdeviceid = sp._pNPDeviceID;

            if (res == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(_partnummber))
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePartnumberEmpty", _language));
                if (string.IsNullOrEmpty(_disknummber))
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDisknumberEmpty", _language));
                if (string.IsNullOrEmpty(_pnpdeviceid))
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePNPDeviceIDEmpty", _language));

                textBoxPartition.Text = "\\Device\\Harddisk" + _disknummber + "\\Partition" + _partnummber;
                textBox_PNPDeviceID.Text = _pnpdeviceid;
            }
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassword.Checked)
            {
                buttonSavePassword.Enabled = buttonShowPassword.Enabled = false;
            }
            else
            {
                buttonSavePassword.Enabled = true;

                if (!string.IsNullOrEmpty(_password))
                    buttonShowPassword.Enabled = true;
            }
        }

        private void buttonSavePassword_Click(object sender, EventArgs e)
        {
            Passwordinput pw = new Passwordinput(ConfigTrm.Container.Typename, checkBoxPim.Checked);
            DialogResult res = pw.ShowDialog();
            if (res == DialogResult.OK)
            {
                _password = pw._password;
                _pim = pw._pim;
                buttonShowPassword.Enabled = true;
            }
            pw._password = null;
            pw._pim = null;
            pw.Dispose();
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}