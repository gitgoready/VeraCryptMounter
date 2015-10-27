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
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    /// <summary>
    /// Form for passwordinput.
    /// </summary>
    public partial class Passwordinput : Form
    {
        private const string LanguageRegion = "Passwordinput";
        private readonly string _language;
        private readonly Config _config = new Config();
        private string _chosen;
        private TrueCryptMounter _main;

        /// <summary>
        /// Constructor for the passwordform.
        /// Initialize the form and the config also the language string.
        /// </summary>
        public Passwordinput(TrueCryptMounter main, string chosen)
        {
            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            LanguageFill();
            _chosen = chosen;
            _main = main;
        }

        /// <summary>
        /// Fill the secelcted language into form.
        /// </summary>
        private void LanguageFill()
        {
            Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Form", _language);
            labelPassword.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "labelPassword", _language);
            buttonOk.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOk", _language);
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (_chosen == ConfigTrm.Container.Typename)
                _main.PasswordContainer = textBoxPassword.Text;

            if (_chosen == ConfigTrm.Drive.Typename)
                _main.PasswordDrive = textBoxPassword.Text;

            Close();
        }

        private void PasswortEingabe_KexDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_ok_Click(sender, e);
        }
    }
}