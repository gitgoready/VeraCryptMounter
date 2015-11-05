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
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    ///<summary>
    /// Class NewDrive shows the form for creating a new drive entry in the config.
    ///</summary>
    public partial class NewDrive : Form
    {
        private readonly Config _config = new Config();
        private readonly List<string> _driveletters = new List<string>();
        private readonly List<string> _useddriveletters = new List<string>();
        private bool _edit;
        private readonly string _language; 
        private const string LanguageRegion = "NewDrive";
        private string _oldName;

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
            if (driveName != null) NewDriveEdit(driveName);
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
                lableDriveletter.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "lableDriveletter", _language);
                buttonOk.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOk", _language);
                buttonCancel.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonCancel", _language);
                checkBoxAutomountUsb.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxAutomountUsb", _language);
                checkBoxAutomountStart.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxAutomountStart", _language);
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

            textBoxDescription.Text = driveName;
            textBoxPartition.Text = _config.GetValue(driveName, ConfigTrm.Drive.Partition, "Partition");
            textBoxKeyfile.Text = _config.GetValue(driveName, ConfigTrm.Drive.Keyfile, "");
            checkBoxNoKeyfile.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Nokeyfile, false);
            checkBoxReadonly.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Readonly, false);
            checkBoxRemovable.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Removable, false);
            checkBoxAutomountStart.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Automountstart, false);
            checkBoxAutomountUsb.Checked = _config.GetValue(driveName, ConfigTrm.Drive.Automountusb, false);

            comboBoxDriveletter.SelectedItem = _config.GetValue(driveName, ConfigTrm.Drive.Driveletter, "");
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

            // Validate userinput
            try
            {
                // Load information from controls into variables
                beschr = textBoxDescription.Text;
                part = textBoxPartition.Text;
                key = textBoxKeyfile.Text;
                dletter = comboBoxDriveletter.SelectedItem.ToString();

                if (_oldName != null)
                    if (beschr != _oldName)
                        _config.RemoveSection(_oldName);

                string usedriveletter = DrivelettersHelper.IsDrivletterUsedByConfig(comboBoxDriveletter.SelectedItem.ToString());

  
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
                    if (usedriveletter != null && usedriveletter != textBoxDescription.Text)
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDrivletterIsUsed", _language) + usedriveletter);
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
                //if (string.IsNullOrEmpty(dletter))
                //{
                //    throw new Exception("Laufwerkbuchstabe darf nicht leer sein");
                //}

                // Check if partiton has the right format.
                if (part.Length < 10)
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePartitionWrongFormat", _language));
                }
                if (part.Substring(0, 9) != "Partition")
                {
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePartitionWrongFormat", _language));
                }
                char[] partChar = part.Substring(9, part.Length - 9).ToCharArray();
                foreach (char c in partChar)
                {
                    if (!char.IsNumber(c))
                    {
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePartitonEndsWithLetter", _language));
                    }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error writing config");
                throw;
            }
            // Close the form.
            Close();
        }

        /// <summary>
        /// Handle the event for the nkkeyfile checkbox.
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
            //e.ItemWidth = 120;
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
            var dialogBox = new SelectPartition(this);
            dialogBox.ShowDialog();
        }
    }
}