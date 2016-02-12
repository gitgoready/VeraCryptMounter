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
using System.Windows.Forms;

namespace VeraCrypt_Mounter
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
        private bool _pimchosen;

        /// <summary>
        /// The entered password.
        /// </summary>
        public string _password { get; set; }

        /// <summary>
        /// The enterd pim.
        /// </summary>
        public string _pim { get; set; }


        public Passwordinput(string chosen, bool pimuse, string password, string pim)
        {
            if (string.IsNullOrEmpty(chosen))
                throw new NullReferenceException("Chosen not set");
            if (string.IsNullOrEmpty(password))
                throw new NullReferenceException("password not set");
            if (string.IsNullOrEmpty(pim))
                throw new NullReferenceException("pim not set");

            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            LanguageFill();
            textBoxPassword.Text = _password = password;
            if (pimuse)
            {
                labelPim.Visible = true;
                textBoxPim.Visible = true;
                textBoxPim.Text = _pim = pim;
            }          
            textBoxPassword.UseSystemPasswordChar = textBoxPim.UseSystemPasswordChar = false;
            
        }
        /// <summary>
        /// Constructor for the passwordform.
        /// Initialize the form and the config also the language string.
        /// </summary>
        public Passwordinput(string chosen, bool pimuse)
        {
            if (string.IsNullOrEmpty(chosen))
                throw new NullReferenceException("Chosen not set");

            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            LanguageFill();
            _chosen = chosen;
            _pimchosen = pimuse;
            if (pimuse)
            {
                labelPim.Visible = true;
                textBoxPim.Visible = true;
            }

        }

        /// <summary>
        /// Fill the secelcted language into form.
        /// </summary>
        private void LanguageFill()
        {
            Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Form", _language);
            labelPassword.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "labelPassword", _language);
            buttonOk.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOk", _language);
            labelPim.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "labelPim", _language);
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            _password = textBoxPassword.Text;
            _pim = textBoxPim.Text;

            var t = 0;
            try
            {
                if (string.IsNullOrEmpty(_password))
                    throw new ArgumentException(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePasswordEmty", _language));

                if (_pimchosen)
                {
                    if (!int.TryParse(_pim, out t))
                    {
                        throw new FormatException(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePimWrongValue", _language));
                    }
                    if (_password.Length < 20 && t < 485)
                    {
                        throw new FormatException(LanguagePool.GetInstance().GetString(LanguageRegion, "MessagePimWrongValue", _language));
                    }
                }          
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _password = null;
                _pim = null;
                return;
            }          
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PasswortEingabe_KexDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_ok_Click(sender, e);
        }

        private void textBoxPim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_ok_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.UseSystemPasswordChar)
                textBoxPassword.UseSystemPasswordChar = textBoxPim.UseSystemPasswordChar = false;
            else
                textBoxPassword.UseSystemPasswordChar = textBoxPim.UseSystemPasswordChar = true;
        }
    }
}