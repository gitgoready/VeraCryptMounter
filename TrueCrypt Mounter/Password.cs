using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    public partial class Password : Form
    {
        private readonly Config _config = new Config();
        /// <summary>
        /// Password input for encrypted xml config.
        /// </summary>
        public Password()
        {
            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);

            if (_config.HasEntry(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordtest))
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
                    _config.Password = textBoxPassword_first.Text;
                    _config.SetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordtest, "Waldmann");
                    this.DialogResult = DialogResult.OK;
                    Close();
                    
                }
            }
            else
            {
                bool res = passwordTest();
                if (res == true)
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private bool passwordTest()
        {
            _config.Password = textBoxPassword_first.Text;
            var storedValue = (string)_config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Passwordtest);

            if (storedValue == textBoxPassword_first.Text)
            {
                return true;
            }
            return false;
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
