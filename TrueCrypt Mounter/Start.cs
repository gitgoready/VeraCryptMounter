using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Text;

namespace VeraCrypt_Mounter
{
    ///<summary>
    /// Form for the Ineraktion on automount function.
    ///</summary>
    public partial class Automount : Form
    {
        

        #region Vareables

        private static FontFamily fontfam = new FontFamily(GenericFontFamilies.SansSerif);
        private static Font myfont = new Font(fontfam, 10, FontStyle.Regular);
        private readonly Config _config = new Config();
        private string _password;
        private string _passwordcached;
        private int _time = 10;
        private Automountstart ams = new Automountstart();
        private Automountusb amu = new Automountusb();
        private const string LanguageRegion = "Automountform";
        private string _language;
        private readonly string _state;

        #endregion

        #region Delegates

        private delegate void DelButtonVisible();

        private delegate void SetFirstTextDel(string text, bool lb);

        private delegate void SetLastTextDel(string text, Color color);

        private delegate void CloseFormDel();

        private delegate void SetFocusDel();

        private delegate void SetTextCloseButtonDel(string text);

        #endregion 

        #region Setter,Getter

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string PasswordCached
        {
            get { return _passwordcached; }
            set { _passwordcached = value; }
        }

        #endregion

        #region Constructor, Load

        public Automount(string state)
        {
            _state = state;
            InitializeComponent();
            // Get Singelton for config
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
        }

        private void Start_Shown(object sender, EventArgs e)
        {
            if (_state == "start")
            {
                Thread autostartThread = new Thread(ams.StartMount);
                autostartThread.IsBackground = true;
                autostartThread.Start(this);
            }
            if (_state == "usb")
            {
                Thread autousbThread = new Thread(amu.StartMount);
                autousbThread.IsBackground = true;
                autousbThread.Start(this);
            }
            FillLanguage();
        }

        private void FillLanguage()
        {
            try
            {
                Text = LanguagePool.GetInstance().GetString(LanguageRegion, "Form", _language);
                buttonOk.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOk", _language);
                buttonCacheOk.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonCacheOk", _language);
                buttonClose.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonClose", _language);
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        #endregion

        #region SetFirstText
        private void SetFirstTextInvoke(string text, bool linebreak)
        {
            richTextBoxView.Select(richTextBoxView.Text.Length, 0);
            richTextBoxView.SelectionFont = myfont;
            if (linebreak)
            {
                richTextBoxView.SelectedText = text + Environment.NewLine;
            }
            else
            {
                richTextBoxView.SelectedText = text;
            }
        }
        

        public void SetFirstText(string text, bool linebreak)
        {
            if (richTextBoxView.InvokeRequired)
            {
                SetFirstTextDel sftd = SetFirstTextInvoke;
                this.Invoke(sftd, new object[] {text, linebreak});
            }
            else
            {
                SetFirstTextInvoke(text, linebreak);
            }
        }
        #endregion

        #region SetLastText

        private void SetLastTextInvoke(string text, Color mycolor)
        {
            richTextBoxView.Select(richTextBoxView.Text.Length, 0);
            richTextBoxView.SelectionColor = mycolor;
            richTextBoxView.SelectedText = text + Environment.NewLine;
        }

        public void SetLastText(string text, Color mycolor)
        {
            if (richTextBoxView.InvokeRequired)
            {
                SetLastTextDel sltd = SetLastTextInvoke;
                this.Invoke(sltd , new object[] {text, mycolor});
            }
            else
            {
                SetLastTextInvoke(text, mycolor);   
            }
        }

        #endregion

        #region Buttons

        private void ButtonVisibleInvoke()
        {
            buttonClose.Visible = true;
            timer1.Start();
        }

        public void ButtonVisible()
        {
            if (buttonClose.InvokeRequired)
            {
                DelButtonVisible bv = ButtonVisibleInvoke;
                Invoke(bv);
            }
            else
            {
                ButtonVisibleInvoke();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _password = textBoxPassword.Text;
            textBoxPassword.Text = "";
            Monitor.Enter(ams);
            Monitor.Pulse(ams);
            Monitor.Exit(ams);
        }

        private void buttonCacheOk_Click(object sender, EventArgs e)
        {
            _passwordcached = textBoxPassword.Text;
            textBoxPassword.Text = "";
            Monitor.Enter(ams);
            Monitor.Pulse(ams);
            Monitor.Exit(ams);
        }

        private void SetFocusInvoke()
        {
            textBoxPassword.Focus();
        }
        
        public void SetFocus()
        {
            if (textBoxPassword.InvokeRequired)
            {
                SetFocusDel sfd = SetFocusInvoke;
                this.Invoke(sfd);
            }
            else
            {
                textBoxPassword.Focus();
            }
        }
        private void SetTextCloseButton(string text)
        {
            buttonClose.Text = text;
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonOk_Click(sender, e);
        }

        #endregion

        #region Timer

        private void CloseForm()
        {
            Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {           
            _time--;
            if (buttonCacheOk.InvokeRequired)
            {
                SetTextCloseButtonDel stdel = SetTextCloseButton;
                Invoke(stdel,
                       new object[]
                           {
                               LanguagePool.GetInstance().GetString(LanguageRegion, "buttonClose", _language) + "(" +
                               _time + ")"
                           });
            }
            else
            {
                
                buttonClose.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonClose", _language) + "(" + _time + ")";
            }
            
            if (_time == 0)
            {
                if (this.InvokeRequired)
                {
                    CloseFormDel cl = CloseForm;
                    this.Invoke(cl);
                }
                else
                {
                    Close();
                }
            }
                
        }

        #endregion 

        



   }
}
