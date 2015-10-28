using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace TrueCrypt_Mounter
{
    public partial class Password : Form
    {
        //private readonly Config _config = new Config();
        /// <summary>
        /// Password input for encrypted xml config.
        /// </summary>
        public Password()
        {
            InitializeComponent();
            //_config = Singleton<ConfigManager>.Instance.Init(_config);
            
            if (File.Exists(string.Format("{0}\\TRM.config", Application.StartupPath)))
            {
                labelPassword_second.Visible = false;
                textBoxPassword_second.Visible = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxPassword_second.Visible == true)
            {
                if (textBoxPassword_first.Text == textBoxPassword_second.Text)
                {
                    //_config.Password = textBoxPassword_first.Text;
                    //_config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordtest, "Waldmann");
                    var init = new Password_helper(textBoxPassword_first.Text);
                    this.DialogResult = DialogResult.OK;
                    Close();
                    
                }
            }
            else
            {
                var init = new Password_helper(textBoxPassword_first.Text);
                //var storedValue = (string)_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordtest);
                if (init.Check_password())
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    labelState.Text = "Password Wrong";
                    labelState.ForeColor = Color.Red;
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

        }

        private void textBoxPassword_second_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword_first.Text == textBoxPassword_second.Text)
            {
                labelState.Text = "equel";
                labelState.ForeColor = Color.Green;
            }
            else
            {
                labelState.Text = "not equel";
                labelState.ForeColor = Color.Red;
            }
        }
    }
}
