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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Form for container config.
    /// </summary>
    public partial class NewContainer : Form
    {
        private readonly Config _config = new Config();
        private readonly List<string> _driveletters = new List<string>();
        private readonly List<string> _useddriveletters = new List<string>();
        private const string LanguageRegion = "NewContainer";
        private readonly string _language;
        private string _oldName;
        private object[] _hashes = { "", "sha512", "sha256", "whirlpool", "ripemd160" };
        private string _password;

        /// <summary>
        /// Password setter for the new container.
        /// </summary>
        public string Password
        {
            set { _password = value; }
        }

        /// <summary>
        /// Constructor for creating a new container.
        /// </summary>
        public NewContainer()
        {
            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            LanguageFill();
            NewKontainer();
        }

        /// <summary>
        /// Constructor for editing a container.
        /// </summary>
        /// <param name="description"></param>
        public NewContainer(string description)
        {
            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            LanguageFill();
            if (string.IsNullOrEmpty(description))
                Close();
            NewKontainerEdit(description);
        }

        /// <summary>
        /// Set the languagestrings for the controls.
        /// </summary>
        private void LanguageFill()
        {
            try
            {
                Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Form", _language);
                groupBoxDescription.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxDescription", _language);
                groupBoxPath.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxPath", _language);
                groupBoxKyfilename.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxKyfilename", _language);
                groupBoxDrive.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxDrive", _language);
                groupBoxDriveletter.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxDriveletter", _language);
                groupBoxMountoptions.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxMountoptions", _language);
                checkBoxNoKeyfile.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxNoKeyfile", _language);
                checkBoxNoDrive.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxNoDrive", _language);
                checkBoxRemovable.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxRemovable", _language);
                checkBoxReadonly.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxReadonly", _language);
                buttonOk.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOk", _language);
                buttonClose.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonClose", _language);
                buttonOpenContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOpenContainer", _language);
                comboBoxDrives.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "comboBoxDrives", _language);
                checkBoxAutomountUsb.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxAutomountUsb", _language);
                checkBoxAutomountStart.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxAutomountStart", _language);
                groupBoxHash.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxHash", _language);
                groupBoxSavePassword.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxSavePassword", _language);
                buttonSavePassword.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonSavePassword", _language);
                //.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "", _language);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        /// <summary>
        /// Fill all controls with information for creating a new container.
        /// </summary>
        private void NewKontainer()
        {
            foreach (string element in DrivelettersHelper.GetDriveletters())
                _driveletters.Add(element);
            foreach (string elemnt in DrivelettersHelper.GetUsedDriveletter())
                _useddriveletters.Add(elemnt);

            comboBoxHash.Items.AddRange(_hashes);

            comboBoxDriveletter.DataSource = _driveletters;

            comboBoxDrives.SelectedItem = _driveletters[0];

            string[] sectionNames = _config.GetSectionNames();
            comboBoxDrives.Items.Clear();
            if (sectionNames != null)
            {
                foreach (string drive in sectionNames)
                {
                    if (_config.HasEntry(drive, ConfigTrm.Drive.Type))
                    {
                        if (_config.GetValue(drive, ConfigTrm.Drive.Type, "") == ConfigTrm.Drive.Typename)
                            comboBoxDrives.Items.Add(drive);
                    }
                }
            }
        }

        /// <summary>
        /// Fill all controls for editing a container.
        /// </summary>
        /// <param name="description"></param>
        private void NewKontainerEdit(string description)
        {
            _oldName = description;
            textBoxDescription.Text = description;
            comboBoxHash.Items.AddRange(new object[] { "", "sha512", "sha256", "wirlpool", "ripemd160" });
            comboBoxHash.SelectedItem = _config.GetValue(description, ConfigTrm.Container.Hash, "");
            checkBoxNoKeyfile.Checked = _config.GetValue(description, ConfigTrm.Container.Nokeyfile, false);
            checkBoxNoDrive.Checked = _config.GetValue(description, ConfigTrm.Container.Nodrive, false);
            textBoxKontainer.Text = _config.GetValue(description, ConfigTrm.Container.Kontainerpath, "");
            textBoxKeyfile.Text = _config.GetValue(description, ConfigTrm.Container.Keyfile, "");
            checkBoxReadonly.Checked = _config.GetValue(description, ConfigTrm.Container.Readonly, false);
            checkBoxRemovable.Checked = _config.GetValue(description, ConfigTrm.Container.Removable, false);
            checkBoxAutomountStart.Checked = _config.GetValue(description, ConfigTrm.Container.Automountstart, false);
            checkBoxAutomountUsb.Checked = _config.GetValue(description, ConfigTrm.Container.Automountusb, false);
            checkBoxTrueCrypt.Checked = _config.GetValue(description, ConfigTrm.Container.Truecrypt, false);
            checkBoxPim.Checked = _config.GetValue(description, ConfigTrm.Container.Pim, false);

            foreach (string element in DrivelettersHelper.GetDriveletters())
                _driveletters.Add(element);
            foreach (string elemnt in DrivelettersHelper.GetUsedDriveletter())
                _useddriveletters.Add(elemnt);

            comboBoxDriveletter.DataSource = _driveletters;

            comboBoxDriveletter.SelectedItem = _config.GetValue(description, ConfigTrm.Container.Driveletter, "");

            string[] sectionNames = _config.GetSectionNames();
            comboBoxDrives.Items.Clear();
            if (sectionNames != null)
            {
                foreach (string drive in sectionNames)
                {
                    if (_config.HasEntry(drive, ConfigTrm.Drive.Type))
                    {
                        if (_config.GetValue(drive, ConfigTrm.Drive.Type, "") == ConfigTrm.Drive.Typename)
                            comboBoxDrives.Items.Add(drive);
                    }
                }
            }
            string drivename = _config.GetValue(description, ConfigTrm.Container.Drive, "");
            if (drivename != "")
            {
                comboBoxDrives.SelectedItem = drivename; 
            }
           
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialogKontainer.ShowDialog();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxNoKeyfile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNoKeyfile.Checked)
            {
                textBoxKeyfile.Enabled = false;
            }
            else
            {
                textBoxKeyfile.Enabled = true;
            }
        }

        private void checkBoxNoDrive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNoDrive.Checked)
            {
                comboBoxDrives.Enabled = false;
            }
            else
            {
                comboBoxDrives.Enabled = true;
            }
        }

        private void openFileDialogKontainerFileOK(object sender, CancelEventArgs e)
        {
            textBoxKontainer.Text = openFileDialogKontainer.FileName;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string description = textBoxDescription.Text;
            string keyfile = textBoxKeyfile.Text;
            string drive = comboBoxDrives.SelectedText;
            
            try
            {
                if (_oldName != null)
                    if (description != _oldName)
                        _config.RemoveSection(_oldName);

                string usedriveletter = DrivelettersHelper.IsDrivletterUsedByConfig(comboBoxDriveletter.SelectedItem.ToString());

                if (usedriveletter != null && usedriveletter != description)
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDrivletterIsUsed", _language) + usedriveletter);

                if (!checkBoxNoKeyfile.Checked)
                {
                    _config.SetValue(description, ConfigTrm.Container.Keyfile, keyfile);

                }

                if (!checkBoxNoDrive.Checked)
                {
                    _config.SetValue(description, ConfigTrm.Container.Drive, drive);

                }

                if (checkBoxAutomountUsb.Checked)
                {
                    
                }

                string hash = (comboBoxHash.SelectedItem == null) ? "" : comboBoxHash.SelectedItem.ToString();

                _config.SetValue(description, ConfigTrm.Container.Type, ConfigTrm.Container.Typename);
                _config.SetValue(description, ConfigTrm.Container.Kontainerpath, textBoxKontainer.Text);
                _config.SetValue(description, ConfigTrm.Container.Driveletter, comboBoxDriveletter.SelectedItem.ToString());
                _config.SetValue(description, ConfigTrm.Container.Readonly, checkBoxReadonly.Checked);
                _config.SetValue(description, ConfigTrm.Container.Removable, checkBoxRemovable.Checked); 
                _config.SetValue(description, ConfigTrm.Container.Nokeyfile, checkBoxNoKeyfile.Checked);
                _config.SetValue(description, ConfigTrm.Container.Nodrive, checkBoxNoDrive.Checked);
                _config.SetValue(description, ConfigTrm.Container.Automountstart, checkBoxAutomountStart.Checked);
                _config.SetValue(description, ConfigTrm.Container.Automountusb, checkBoxAutomountUsb.Checked);
                _config.SetValue(description, ConfigTrm.Container.Pim, checkBoxPim.Checked);
                _config.SetValue(description, ConfigTrm.Container.Truecrypt, checkBoxTrueCrypt.Checked);
                _config.SetValue(description, ConfigTrm.Container.Hash, hash);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            Close();
        }

        private void ComboBoxDriveletter_MeasureItem(object sender,
                                                     MeasureItemEventArgs e)
        {
            // ItemHeight shout be font size + 4 
            e.ItemHeight = 12;
            //e.ItemWidth = 120;
        }

        // You must handle the DrawItem event for owner-drawn combo boxes.  
        // This event handler changes the color, size and font of an 
        // item based on its position in the array.
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

        private void checkBoxTrueCrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTrueCrypt.Checked)
            {
                checkBoxPim.Enabled = false;
                checkBoxPim.Checked = false;
            }
            else
                checkBoxPim.Enabled = true;
        }

        private void comboBoxHash_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxHash.DroppedDown = true;
        }

        private void comboBoxDrives_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxDrives.DroppedDown = true;
        }

        private void buttonSavePassword_Click(object sender, EventArgs e)
        {
            //Passwordinput pw = new Passwordinput(this, ConfigTrm.Container.Typename, true);
        }

        private void comboBoxDriveletter_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxDriveletter.DroppedDown = true;
        }
    }
}