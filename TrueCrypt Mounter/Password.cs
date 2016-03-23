﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace VeraCrypt_Mounter
{
    public partial class Password : Form
    {

        private string _confDir;
        private const string LanguageRegion = "Password";
        private string _language = Properties.Settings.Default.language;

        //private readonly Config _config = new Config();
        /// <summary>
        /// Password input for encrypted xml config.
        /// </summary>
        public Password()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "";
#if DEBUG
            toolStripStatusLabel1.Text = _language;
#endif
            checkConfigPath();
            FillLanguage();

            if (File.Exists(_confDir))
            {
                labelPassword_second.Visible = false;
                textBoxPassword_second.Visible = false;
                labelOldPassword.Visible = false;
                textBoxOldPassword.Visible = false;
            }
            else
            {
                labelOldPassword.Visible = false;
                textBoxOldPassword.Visible = false;
            }
        }
        private void FillLanguage()
        {
            this.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Caption", _language);
            buttonCancel.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonCancel", _language);
            buttonChangePassword.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonChangePassword", _language);
            buttonOK.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOK", _language);
            buttonReset.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonReset", _language);

            //LanguagePool.GetInstance().GetString(LanguageRegion, "", _language);
        }
        private void checkConfigPath()
        {
            _confDir = string.Format("{0}\\TRM.config", Application.StartupPath);
            if (!File.Exists(string.Format(_confDir)))
                return;
            try
            {
                using (FileStream fs = File.Create(Path.Combine(Application.StartupPath, Path.GetRandomFileName()), 1, FileOptions.DeleteOnClose))
                { }
            }
            catch
            {
                _confDir = string.Format("{0}\\TRM.config", Application.LocalUserAppDataPath);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxOldPassword.Visible)
            {
                Password_helper.Password = textBoxOldPassword.Text;
                if (!Password_helper.Check_password())
                    return;

                if (!string.Equals(textBoxPassword_first.Text, textBoxPassword_second.Text))
                    return;

                Password_helper.ChangePassword(textBoxPassword_first.Text);
            }

            if (textBoxPassword_second.Visible)
            {
                if (textBoxPassword_first.Text == textBoxPassword_second.Text)
                {
                    Password_helper.Password = textBoxPassword_first.Text;
                    this.DialogResult = DialogResult.OK;
                    Close();                  
                }
                return;
            }
            else
            {
                Password_helper.Password = textBoxPassword_first.Text;
                if (Password_helper.Check_password())
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    set_wrong();
                    return;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(LanguagePool.GetInstance().GetString(LanguageRegion, "resetMessage", _language), "Delete Config", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel)
                return;

            if (File.Exists(_confDir))
            {
                File.Delete(_confDir);
            }
            Application.Restart();
        }

        private void textBoxPassword_second_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword_first.Text == textBoxPassword_second.Text)
            {
                toolStripStatusLabel1.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "equel", _language);
                toolStripStatusLabel1.ForeColor = Color.Green;
            }
            else
            {
                toolStripStatusLabel1.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "not equel", _language);
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
        }

        private void set_wrong()
        {
            toolStripStatusLabel1.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "password wrong", _language);
            toolStripStatusLabel1.ForeColor = Color.Red;
            return;
        }

        private void textBoxPassword_first_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonOK_Click(sender, new EventArgs());
            }
        }

        private void textBoxPassword_second_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonOK_Click(sender, new EventArgs());
            }
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            labelOldPassword.Visible = true;
            textBoxOldPassword.Visible = true;
            labelPassword_second.Visible = true;
            textBoxPassword_second.Visible = true;
        }
    }
}
