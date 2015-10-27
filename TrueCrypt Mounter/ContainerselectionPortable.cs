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
using System.IO;
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    /// <summary>
    /// Form for keyfilecontainer selection if programm runs in portable mode.
    /// </summary>
    public partial class ContainerselectionPortable : Form
    {
        private const string LanguageRegion = "ContainerselectionPortable";
        private readonly string _language;
        private readonly Config _config = new Config();

        /// <summary>
        /// Constructor for form ContainerselectionPortable.
        /// It set the form elemnets and initialized the config singolton and get the language.
        /// </summary>
        public ContainerselectionPortable()
        {
            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            LanguageFill();
        }

        /// <summary>
        /// Set the languagestrings for the controls.
        /// </summary>
        private void LanguageFill()
        {
            Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Form", _language);
            labelKeyfilecontainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "labelKeyfilecontainer", _language);
            buttonOk.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOk", _language);
            buttonClose.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonClose", _language);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void Kontainer_Portable_Load(object sender, EventArgs e)
        {
            var dir = new DirectoryInfo(Application.StartupPath + "\\Kontainer");

            foreach (FileInfo file in dir.GetFiles())
            {
                listBoxFiles.Items.Add(file.Name);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
# if DEBUG
            MessageBox.Show(Application.StartupPath + "\\Kontainer\\" + listBoxFiles.SelectedItem);
#endif
            try
            {
                if (listBoxFiles.SelectedItem == null)
                    throw new Exception(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageNoSelection", _language));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LanguagePool.GetInstance().GetString(LanguageRegion, "Error", _language), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Kontainerpath,
                             Application.StartupPath + "\\Kontainer\\" + listBoxFiles.SelectedItem);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}