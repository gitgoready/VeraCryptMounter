using System;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Form for the settings of the automount function.
    /// </summary>
    public partial class AutomountConfig : Form
    {
        private readonly Config _config = new Config();
        private const string LanguageRegion = "Automount";
        private readonly string _language;
        
        /// <summary>
        /// Initialize the form and the config singelton.
        /// </summary>
        public AutomountConfig()
        {
            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            LanguageFill();
        }

        /// <summary>
        /// Load the selected language for the form.
        /// </summary>
        private void LanguageFill()
        {
            Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Form", _language);
            checkBoxUseAutomount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxUseAutomount", _language);
            checkBoxDrives.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxDrives", _language);
            checkBoxContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxContainer", _language);
            buttonOK.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOK", _language);
            buttonCancel.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonCancel", _language);
            groupBoxUsbAutomount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxUsbAutomount", _language);
            tabPageUsbAutomount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "tabPageUsbAutomount", _language);
            tabPageStartAutomount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "tabPageStartAutomount", _language);
            checkBoxUseStartAutomount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxUseStartAutomount", _language);
            checkBoxStartDrives.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxStartDrives", _language);
            checkBoxSartContainer.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "checkBoxSartContainer", _language);
            groupBoxStartAutomount.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "groupBoxStartAutomount", _language);
            
            //.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "", _language);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Save the setting in the config file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (checkBoxUseAutomount.Checked)
            {
                _config.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Mountcontainersusb, checkBoxContainer.Checked);
                _config.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Mountdrivesusb, checkBoxDrives.Checked);
                _config.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Useusbautomount, checkBoxUseAutomount.Checked);
            }
            else
            {
                _config.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Useusbautomount, checkBoxUseAutomount.Checked);

            }

            if (checkBoxUseStartAutomount.Checked)
            {
                _config.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Mountcontainerstart,checkBoxSartContainer.Checked);
                _config.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Mountdrivesstart, checkBoxStartDrives.Checked);
                _config.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Usestartautomount, checkBoxUseStartAutomount.Checked);
            }
            else
            {
                _config.SetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Usestartautomount, checkBoxUseStartAutomount.Checked);
            }

            Close();
        }
        /// <summary>
        /// Load the controls with the values from the config.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutomountConfig_Load(object sender, EventArgs e)
        {
            checkBoxUseAutomount.Checked = _config.GetValue(ConfigTrm.Automount.Section,
                                                            ConfigTrm.Automount.Useusbautomount, false);

            checkBoxContainer.Checked = _config.GetValue(ConfigTrm.Automount.Section,
                                                         ConfigTrm.Automount.Mountcontainersusb, false);

            checkBoxDrives.Checked = _config.GetValue(ConfigTrm.Automount.Section, ConfigTrm.Automount.Mountdrivesusb,
                                                      false);

            checkBoxUseStartAutomount.Checked = _config.GetValue(ConfigTrm.Automount.Section,
                                                                 ConfigTrm.Automount.Usestartautomount, false);

            checkBoxSartContainer.Checked = _config.GetValue(ConfigTrm.Automount.Section,
                                                             ConfigTrm.Automount.Mountcontainerstart, false);

            checkBoxStartDrives.Checked = _config.GetValue(ConfigTrm.Automount.Section,
                                                           ConfigTrm.Automount.Mountdrivesstart, false);

            checkBoxUseAutomount_CheckedChanged(sender, e);
            checkBoxUseStartAutomount_CheckedChanged(sender, e);
        }

        /// <summary>
        /// Togle groupbox enabled if the checkboxUseAutomount is set or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxUseAutomount_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxUseAutomount.Checked)
            {
                groupBoxUsbAutomount.Enabled = false;
            }
            else
            {
                groupBoxUsbAutomount.Enabled = true;
            }

        }

        private void checkBoxUseStartAutomount_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxUseStartAutomount.Checked)
            {
                groupBoxStartAutomount.Enabled = false;
            }
            else
            {
                groupBoxStartAutomount.Enabled = true;
            }
        }
    }
}
