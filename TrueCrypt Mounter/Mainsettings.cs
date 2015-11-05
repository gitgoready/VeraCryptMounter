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
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    /// <summary>
    /// Form for the mainsettings.
    /// </summary>
    public partial class Mainsettings : Form
    {
        private readonly Config _config = new Config();
        private readonly List<string> _driveletters = new List<string>();
        private readonly List<string> _useddriveletters = new List<string>();
        private List<string[]> _languages;
        private const string LanguageRegion = "Mainsettings";
        private object[] _hashes = { "", "sha512", "sha256", "whirlpool", "ripemd160" };
        private string _language;

        /// <summary>
        /// Constructer for the form.
        /// Initiliced the config singelton and get the language.
        /// </summary>
        public Mainsettings()
        {
            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            LanguageFill();
        }

        /// <summary>
        /// Fill all controllements with selected language texts.
        /// </summary>
        private void LanguageFill()
        {
            Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Form", _language);
            checkBoxPim.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxPim", _language);
            labelHash.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "labelHash", _language);
            labelTruecryptPath.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "labelTruecryptPath", _language);
            buttonTruecryptPath.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonTruecryptPath", _language);
            buttonContainerPath.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonContainerPath", _language);
            groupBoxKeyfileContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxKeyfileContainer", _language);
            labelKeyfilecontainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "labelKeyfilecontainer", _language);
            labelDriveletter.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "labelDriveletter", _language);
            checkBoxReadonly.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxReadonly", _language);
            checkBoxRemovable.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxRemovable", _language);
            groupBoxUsesettings.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxUsesettings", _language);
            checkBoxPortable.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxPortable", _language);
            checkBoxNoKeyfilecontainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxNoKeyfilecontainer", _language);
            checkBoxPasswordcache.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxPasswordcache", _language);
            groupBoxLanguage.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxLanguage", _language);
            groupBoxDebug.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxDebug", _language);
            checkBoxSilentMode.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxSilentMode", _language);
            buttonOk.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOk", _language);
            buttonClose.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonClose", _language);
            checkBoxAutomount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxAutomount", _language);
            //.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "", _language);
        }

        /// <summary>
        /// Fill all controllelements with selections from configfile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainsettingsLoad(object sender, EventArgs e)
        {
            string defaultlanguage = "";
            string selectedlanguage = "";
            // Get languages from language.xml file.
            try
            {
                _languages = LanguagePool.GetInstance().GetLanguages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            // Fill combobox with available languages and get default language
            if (_languages != null)
            {
                foreach (var language in _languages)
                {
                    comboBoxLanguage.Items.Add(language[0]);
                    if (_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Defaultlanguage, "") == language[1])
                        defaultlanguage = language[0];
                    if (_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, defaultlanguage) == language[1])
                        selectedlanguage = language[0];
                }
            }

            // Select chosen Language in combobox. If nothing chosen use default language
            if (selectedlanguage == "")
                selectedlanguage = defaultlanguage;
            comboBoxLanguage.SelectedItem = selectedlanguage;

            select_truecrypt.InitialDirectory =
                textBoxTruecryptPath.Text = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Truecryptpath, "");
            select_konpath.InitialDirectory =
                textBoxContainerPath.Text = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Kontainerpath, "");
            checkBoxSilentMode.Checked = !_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Silentmode, true);
            checkBoxReadonly.Checked = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Readonly, false);
            checkBoxRemovable.Checked = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Removable, false);
            checkBoxPortable.Checked = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Potable, false);
            checkBoxNoKeyfilecontainer.Checked = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Nokeyfile, false);
            checkBoxPasswordcache.Checked = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordcache, false);
            checkBoxAutomount.Checked = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Automount, false);
            checkBoxPim.Checked = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Pim, false);

            // Fill lists for the comboboxdriveletter
            foreach (string element in DrivelettersHelper.GetDriveletters())
            {
                _driveletters.Add(element);
            }
            foreach (string elemnt in DrivelettersHelper.GetUsedDriveletter())
            {
                _useddriveletters.Add(elemnt);
            }

            comboBoxDriveletter.DataSource = _driveletters;
            comboBoxDriveletter.SelectedItem = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter, "");

            comboBoxHash.Items.AddRange(_hashes);
            comboBoxHash.SelectedItem = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Hash, "");
        }

        /// <summary>
        /// Fill Cotrollelments with data in case portable is checked or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxPortable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPortable.Checked)
            {
                buttonTruecryptPath.Enabled = false;
                textBoxTruecryptPath.Clear();
                textBoxTruecryptPath.Text = Application.StartupPath + "\\TrueCrypt\\TrueCrypt.exe";
            }
            else
            {
                buttonTruecryptPath.Enabled = true;
                textBoxTruecryptPath.Text = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Truecryptpath, "");
            }
        }

        /// <summary>
        /// Event for button ok. Save the chosen config to config xml file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (checkBoxPortable.Checked)
                {
                    if (!File.Exists(Application.StartupPath + "\\" + "TrueCrypt\\TrueCrypt.exe"))
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageTruecryptexeMissing", _language));
                    if (!File.Exists(Application.StartupPath + "\\" + "TrueCrypt\\truecrypt.sys"))
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageTruecryptsysMissing", _language));
                    if (!File.Exists(Application.StartupPath + "\\" + "TrueCrypt\\truecrypt-x64.sys"))
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageTruecryptx64Missing", _language));

                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Truecryptpath,
                                     Application.StartupPath + "\\TrueCrypt\\TrueCrypt.exe");
                }
                else
                {
                    if (!File.Exists(textBoxTruecryptPath.Text))
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePathNotCorrect", _language));

                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Truecryptpath, textBoxTruecryptPath.Text);
                }

                if (checkBoxNoKeyfilecontainer.Checked)
                {
                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Nokeyfile, true);
                    _config.RemoveEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Kontainerpath);
                    _config.RemoveEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Removable);
                    _config.RemoveEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Readonly);
                    _config.RemoveEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter);
                    _config.RemoveEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Hash);
                    _config.RemoveEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Pim);

                }
                else
                {
                    if (!File.Exists(textBoxContainerPath.Text))
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MesageSetPathContainer", _language));

                    if (comboBoxDriveletter.SelectedItem == null)
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageSelectDriveletter", _language));

                    string usedriveletter = DrivelettersHelper.IsDrivletterUsedByConfig(comboBoxDriveletter.SelectedItem.ToString());

                    if (usedriveletter != null && usedriveletter != ConfigTrm.Mainconfig.Section)
                        throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageDrivletterIsUsed", _language)+usedriveletter);

                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Pim, checkBoxPim.Checked);
                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Kontainerpath, textBoxContainerPath.Text);
                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Removable, checkBoxRemovable.Checked);
                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Readonly, checkBoxReadonly.Checked);
                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Driveletter,
                                     comboBoxDriveletter.SelectedItem.ToString());
                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Hash, comboBoxHash.SelectedItem.ToString());
                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Pim, checkBoxPim.Checked);
                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Nokeyfile, false);
                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Automount, checkBoxAutomount.Checked);
                }
                _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordcache, checkBoxPasswordcache.Checked);
                _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig. Silentmode, !checkBoxSilentMode.Checked);
                _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Potable, checkBoxPortable.Checked);

                // Get letter for selected language and write it to config.
                foreach (var language in _languages)
                {
                    if (comboBoxLanguage.SelectedItem.ToString() == language[0])
                        _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, language[1]);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error",_language), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        /// <summary>
        /// Open file select dialog for selection of truecrypt.exe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTruecryptPath_Click(object sender, EventArgs e)
        {
            select_truecrypt.ShowDialog();
        }

        private void buttonKontainerPath_Click(object sender, EventArgs e)
        {
            if (checkBoxPortable.Checked)
            {
                try
                {
                    var dialogBox = new ContainerselectionPortable();
                    DialogResult result = dialogBox.ShowDialog(); // Returns when dialog box has closed
                    if (result == DialogResult.OK)
                        textBoxContainerPath.Text = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Kontainerpath, "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                }
            }
            else
            {
                select_konpath.ShowDialog();
            }
        }

        private void select_truecrypt_FileOk(object sender, CancelEventArgs e)
        {
            textBoxTruecryptPath.Text = select_truecrypt.FileName;
        }

        private void select_konpath_FileOk(object sender, CancelEventArgs e)
        {
            textBoxContainerPath.Text = select_konpath.FileName;
        }

        private void checkBoxKeinKeyfilekontainer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNoKeyfilecontainer.Checked)
            {
                groupBoxKeyfileContainer.Enabled = false;
            }
            else
            {
                groupBoxKeyfileContainer.Enabled = true;
            }
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}