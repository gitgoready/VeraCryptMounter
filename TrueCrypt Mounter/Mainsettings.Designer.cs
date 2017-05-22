namespace VeraCrypt_Mounter
{
    partial class Mainsettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainsettings));
            this.select_truecrypt = new System.Windows.Forms.OpenFileDialog();
            this.textBoxTruecryptPath = new System.Windows.Forms.TextBox();
            this.buttonTruecryptPath = new System.Windows.Forms.Button();
            this.textBoxContainerPath = new System.Windows.Forms.TextBox();
            this.buttonContainerPath = new System.Windows.Forms.Button();
            this.labelTruecryptPath = new System.Windows.Forms.Label();
            this.labelKeyfilecontainer = new System.Windows.Forms.Label();
            this.select_konpath = new System.Windows.Forms.OpenFileDialog();
            this.labelDriveletter = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxDebug = new System.Windows.Forms.GroupBox();
            this.checkBoxSilentMode = new System.Windows.Forms.CheckBox();
            this.groupBoxKeyfileContainer = new System.Windows.Forms.GroupBox();
            this.labelHash = new System.Windows.Forms.Label();
            this.comboBoxHash = new System.Windows.Forms.ComboBox();
            this.checkBoxPim = new System.Windows.Forms.CheckBox();
            this.checkBoxAutomount = new System.Windows.Forms.CheckBox();
            this.comboBoxDriveletter = new System.Windows.Forms.ComboBox();
            this.checkBoxRemovable = new System.Windows.Forms.CheckBox();
            this.checkBoxReadonly = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxTruecryptPath = new System.Windows.Forms.GroupBox();
            this.groupBoxUsesettings = new System.Windows.Forms.GroupBox();
            this.checkBox_startwithwin = new System.Windows.Forms.CheckBox();
            this.checkBoxNoKeyfilecontainer = new System.Windows.Forms.CheckBox();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.groupBoxConfigPath = new System.Windows.Forms.GroupBox();
            this.buttonShowConfig = new System.Windows.Forms.Button();
            this.textBoxConfigPath = new System.Windows.Forms.TextBox();
            this.groupBoxDebug.SuspendLayout();
            this.groupBoxKeyfileContainer.SuspendLayout();
            this.groupBoxTruecryptPath.SuspendLayout();
            this.groupBoxUsesettings.SuspendLayout();
            this.groupBoxLanguage.SuspendLayout();
            this.groupBoxConfigPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // select_truecrypt
            // 
            this.select_truecrypt.DefaultExt = "exe";
            this.select_truecrypt.FileName = "VeraCrypt.exe";
            this.select_truecrypt.Filter = "truecrypt.exe|veracrypt.exe";
            this.select_truecrypt.InitialDirectory = "C:\\Program Files\\VeraCrypt";
            this.select_truecrypt.FileOk += new System.ComponentModel.CancelEventHandler(this.select_truecrypt_FileOk);
            // 
            // textBoxTruecryptPath
            // 
            this.textBoxTruecryptPath.Location = new System.Drawing.Point(12, 24);
            this.textBoxTruecryptPath.Name = "textBoxTruecryptPath";
            this.textBoxTruecryptPath.ReadOnly = true;
            this.textBoxTruecryptPath.Size = new System.Drawing.Size(324, 21);
            this.textBoxTruecryptPath.TabIndex = 0;
            // 
            // buttonTruecryptPath
            // 
            this.buttonTruecryptPath.Location = new System.Drawing.Point(366, 21);
            this.buttonTruecryptPath.Name = "buttonTruecryptPath";
            this.buttonTruecryptPath.Size = new System.Drawing.Size(75, 21);
            this.buttonTruecryptPath.TabIndex = 3;
            this.buttonTruecryptPath.Text = "Auswählen";
            this.buttonTruecryptPath.UseVisualStyleBackColor = true;
            this.buttonTruecryptPath.Click += new System.EventHandler(this.buttonTruecryptPath_Click);
            // 
            // textBoxContainerPath
            // 
            this.textBoxContainerPath.Location = new System.Drawing.Point(9, 29);
            this.textBoxContainerPath.Name = "textBoxContainerPath";
            this.textBoxContainerPath.ReadOnly = true;
            this.textBoxContainerPath.Size = new System.Drawing.Size(324, 21);
            this.textBoxContainerPath.TabIndex = 0;
            // 
            // buttonContainerPath
            // 
            this.buttonContainerPath.Location = new System.Drawing.Point(366, 27);
            this.buttonContainerPath.Name = "buttonContainerPath";
            this.buttonContainerPath.Size = new System.Drawing.Size(75, 21);
            this.buttonContainerPath.TabIndex = 5;
            this.buttonContainerPath.Text = "Auswählen";
            this.buttonContainerPath.UseVisualStyleBackColor = true;
            this.buttonContainerPath.Click += new System.EventHandler(this.buttonKontainerPath_Click);
            // 
            // labelTruecryptPath
            // 
            this.labelTruecryptPath.AutoSize = true;
            this.labelTruecryptPath.Location = new System.Drawing.Point(9, 9);
            this.labelTruecryptPath.Name = "labelTruecryptPath";
            this.labelTruecryptPath.Size = new System.Drawing.Size(107, 12);
            this.labelTruecryptPath.TabIndex = 20;
            this.labelTruecryptPath.Text = "Pfad zu VeraCrypt";
            // 
            // labelKeyfilecontainer
            // 
            this.labelKeyfilecontainer.AutoSize = true;
            this.labelKeyfilecontainer.Location = new System.Drawing.Point(6, 15);
            this.labelKeyfilecontainer.Name = "labelKeyfilecontainer";
            this.labelKeyfilecontainer.Size = new System.Drawing.Size(113, 12);
            this.labelKeyfilecontainer.TabIndex = 9;
            this.labelKeyfilecontainer.Text = "Pfad zum Kontainer";
            // 
            // select_konpath
            // 
            this.select_konpath.FileName = "openFileDialog1";
            this.select_konpath.FileOk += new System.ComponentModel.CancelEventHandler(this.select_konpath_FileOk);
            // 
            // labelDriveletter
            // 
            this.labelDriveletter.AutoSize = true;
            this.labelDriveletter.Location = new System.Drawing.Point(6, 52);
            this.labelDriveletter.Name = "labelDriveletter";
            this.labelDriveletter.Size = new System.Drawing.Size(119, 12);
            this.labelDriveletter.TabIndex = 13;
            this.labelDriveletter.Text = "Laufwerksbuchstaben";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(383, 266);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 21);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Schließen";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBoxDebug
            // 
            this.groupBoxDebug.Controls.Add(this.checkBoxSilentMode);
            this.groupBoxDebug.Location = new System.Drawing.Point(153, 302);
            this.groupBoxDebug.Name = "groupBoxDebug";
            this.groupBoxDebug.Size = new System.Drawing.Size(146, 40);
            this.groupBoxDebug.TabIndex = 15;
            this.groupBoxDebug.TabStop = false;
            this.groupBoxDebug.Text = "Debug Optionen";
            // 
            // checkBoxSilentMode
            // 
            this.checkBoxSilentMode.AutoSize = true;
            this.checkBoxSilentMode.Location = new System.Drawing.Point(6, 14);
            this.checkBoxSilentMode.Name = "checkBoxSilentMode";
            this.checkBoxSilentMode.Size = new System.Drawing.Size(156, 16);
            this.checkBoxSilentMode.TabIndex = 16;
            this.checkBoxSilentMode.Text = "Silent-Mode abschalten";
            this.checkBoxSilentMode.UseVisualStyleBackColor = true;
            // 
            // groupBoxKeyfileContainer
            // 
            this.groupBoxKeyfileContainer.Controls.Add(this.labelHash);
            this.groupBoxKeyfileContainer.Controls.Add(this.comboBoxHash);
            this.groupBoxKeyfileContainer.Controls.Add(this.checkBoxPim);
            this.groupBoxKeyfileContainer.Controls.Add(this.checkBoxAutomount);
            this.groupBoxKeyfileContainer.Controls.Add(this.comboBoxDriveletter);
            this.groupBoxKeyfileContainer.Controls.Add(this.checkBoxRemovable);
            this.groupBoxKeyfileContainer.Controls.Add(this.checkBoxReadonly);
            this.groupBoxKeyfileContainer.Controls.Add(this.labelKeyfilecontainer);
            this.groupBoxKeyfileContainer.Controls.Add(this.textBoxContainerPath);
            this.groupBoxKeyfileContainer.Controls.Add(this.buttonContainerPath);
            this.groupBoxKeyfileContainer.Controls.Add(this.labelDriveletter);
            this.groupBoxKeyfileContainer.Location = new System.Drawing.Point(9, 60);
            this.groupBoxKeyfileContainer.Name = "groupBoxKeyfileContainer";
            this.groupBoxKeyfileContainer.Size = new System.Drawing.Size(449, 99);
            this.groupBoxKeyfileContainer.TabIndex = 4;
            this.groupBoxKeyfileContainer.TabStop = false;
            this.groupBoxKeyfileContainer.Text = "Keyfile Kontainer Optionen";
            // 
            // labelHash
            // 
            this.labelHash.AutoSize = true;
            this.labelHash.Location = new System.Drawing.Point(351, 55);
            this.labelHash.Name = "labelHash";
            this.labelHash.Size = new System.Drawing.Size(29, 12);
            this.labelHash.TabIndex = 17;
            this.labelHash.Text = "hash";
            // 
            // comboBoxHash
            // 
            this.comboBoxHash.FormattingEnabled = true;
            this.comboBoxHash.Location = new System.Drawing.Point(354, 68);
            this.comboBoxHash.Name = "comboBoxHash";
            this.comboBoxHash.Size = new System.Drawing.Size(87, 20);
            this.comboBoxHash.TabIndex = 16;
            // 
            // checkBoxPim
            // 
            this.checkBoxPim.AutoSize = true;
            this.checkBoxPim.Location = new System.Drawing.Point(256, 53);
            this.checkBoxPim.Name = "checkBoxPim";
            this.checkBoxPim.Size = new System.Drawing.Size(42, 16);
            this.checkBoxPim.TabIndex = 15;
            this.checkBoxPim.Text = "PIM";
            this.checkBoxPim.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutomount
            // 
            this.checkBoxAutomount.AutoSize = true;
            this.checkBoxAutomount.Location = new System.Drawing.Point(256, 73);
            this.checkBoxAutomount.Name = "checkBoxAutomount";
            this.checkBoxAutomount.Size = new System.Drawing.Size(78, 16);
            this.checkBoxAutomount.TabIndex = 14;
            this.checkBoxAutomount.Text = "Automount";
            this.checkBoxAutomount.UseVisualStyleBackColor = true;
            // 
            // comboBoxDriveletter
            // 
            this.comboBoxDriveletter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxDriveletter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDriveletter.FormattingEnabled = true;
            this.comboBoxDriveletter.Location = new System.Drawing.Point(34, 68);
            this.comboBoxDriveletter.Name = "comboBoxDriveletter";
            this.comboBoxDriveletter.Size = new System.Drawing.Size(44, 22);
            this.comboBoxDriveletter.TabIndex = 6;
            this.comboBoxDriveletter.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxDriveletter_DrawItem);
            this.comboBoxDriveletter.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ComboBoxDriveletter_MeasureItem);
            // 
            // checkBoxRemovable
            // 
            this.checkBoxRemovable.AutoSize = true;
            this.checkBoxRemovable.Location = new System.Drawing.Point(124, 73);
            this.checkBoxRemovable.Name = "checkBoxRemovable";
            this.checkBoxRemovable.Size = new System.Drawing.Size(114, 16);
            this.checkBoxRemovable.TabIndex = 8;
            this.checkBoxRemovable.Text = "Wechsellaufwerk";
            this.checkBoxRemovable.UseVisualStyleBackColor = true;
            // 
            // checkBoxReadonly
            // 
            this.checkBoxReadonly.AutoSize = true;
            this.checkBoxReadonly.Location = new System.Drawing.Point(124, 53);
            this.checkBoxReadonly.Name = "checkBoxReadonly";
            this.checkBoxReadonly.Size = new System.Drawing.Size(120, 16);
            this.checkBoxReadonly.TabIndex = 7;
            this.checkBoxReadonly.Text = "Schreibgeschützt";
            this.checkBoxReadonly.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(302, 266);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 21);
            this.buttonOk.TabIndex = 18;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBoxTruecryptPath
            // 
            this.groupBoxTruecryptPath.Controls.Add(this.labelTruecryptPath);
            this.groupBoxTruecryptPath.Controls.Add(this.textBoxTruecryptPath);
            this.groupBoxTruecryptPath.Controls.Add(this.buttonTruecryptPath);
            this.groupBoxTruecryptPath.Location = new System.Drawing.Point(9, 3);
            this.groupBoxTruecryptPath.Name = "groupBoxTruecryptPath";
            this.groupBoxTruecryptPath.Size = new System.Drawing.Size(449, 58);
            this.groupBoxTruecryptPath.TabIndex = 2;
            this.groupBoxTruecryptPath.TabStop = false;
            // 
            // groupBoxUsesettings
            // 
            this.groupBoxUsesettings.Controls.Add(this.checkBox_startwithwin);
            this.groupBoxUsesettings.Controls.Add(this.checkBoxNoKeyfilecontainer);
            this.groupBoxUsesettings.Location = new System.Drawing.Point(9, 159);
            this.groupBoxUsesettings.Name = "groupBoxUsesettings";
            this.groupBoxUsesettings.Size = new System.Drawing.Size(449, 51);
            this.groupBoxUsesettings.TabIndex = 9;
            this.groupBoxUsesettings.TabStop = false;
            this.groupBoxUsesettings.Text = "Benutzungseinstellungen";
            // 
            // checkBox_startwithwin
            // 
            this.checkBox_startwithwin.AutoSize = true;
            this.checkBox_startwithwin.Location = new System.Drawing.Point(209, 20);
            this.checkBox_startwithwin.Name = "checkBox_startwithwin";
            this.checkBox_startwithwin.Size = new System.Drawing.Size(132, 16);
            this.checkBox_startwithwin.TabIndex = 12;
            this.checkBox_startwithwin.Text = "start with windows";
            this.checkBox_startwithwin.UseVisualStyleBackColor = true;
            // 
            // checkBoxNoKeyfilecontainer
            // 
            this.checkBoxNoKeyfilecontainer.AutoSize = true;
            this.checkBoxNoKeyfilecontainer.Checked = true;
            this.checkBoxNoKeyfilecontainer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNoKeyfilecontainer.Location = new System.Drawing.Point(9, 20);
            this.checkBoxNoKeyfilecontainer.Name = "checkBoxNoKeyfilecontainer";
            this.checkBoxNoKeyfilecontainer.Size = new System.Drawing.Size(204, 16);
            this.checkBoxNoKeyfilecontainer.TabIndex = 11;
            this.checkBoxNoKeyfilecontainer.Text = "Keyflekontainer nicht benutzen";
            this.checkBoxNoKeyfilecontainer.UseVisualStyleBackColor = true;
            this.checkBoxNoKeyfilecontainer.CheckedChanged += new System.EventHandler(this.checkBoxKeinKeyfilekontainer_CheckedChanged);
            // 
            // groupBoxLanguage
            // 
            this.groupBoxLanguage.Controls.Add(this.comboBoxLanguage);
            this.groupBoxLanguage.Location = new System.Drawing.Point(9, 302);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.Size = new System.Drawing.Size(138, 40);
            this.groupBoxLanguage.TabIndex = 13;
            this.groupBoxLanguage.TabStop = false;
            this.groupBoxLanguage.Text = "Sprache";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(9, 14);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(119, 20);
            this.comboBoxLanguage.TabIndex = 14;
            // 
            // groupBoxConfigPath
            // 
            this.groupBoxConfigPath.Controls.Add(this.buttonShowConfig);
            this.groupBoxConfigPath.Controls.Add(this.textBoxConfigPath);
            this.groupBoxConfigPath.Location = new System.Drawing.Point(9, 209);
            this.groupBoxConfigPath.Name = "groupBoxConfigPath";
            this.groupBoxConfigPath.Size = new System.Drawing.Size(449, 39);
            this.groupBoxConfigPath.TabIndex = 19;
            this.groupBoxConfigPath.TabStop = false;
            this.groupBoxConfigPath.Text = "ConfigPath";
            // 
            // buttonShowConfig
            // 
            this.buttonShowConfig.Location = new System.Drawing.Point(366, 13);
            this.buttonShowConfig.Name = "buttonShowConfig";
            this.buttonShowConfig.Size = new System.Drawing.Size(75, 21);
            this.buttonShowConfig.TabIndex = 1;
            this.buttonShowConfig.Text = "Show config";
            this.buttonShowConfig.UseVisualStyleBackColor = true;
            this.buttonShowConfig.Click += new System.EventHandler(this.buttonShowConfig_Click);
            // 
            // textBoxConfigPath
            // 
            this.textBoxConfigPath.Location = new System.Drawing.Point(5, 15);
            this.textBoxConfigPath.Name = "textBoxConfigPath";
            this.textBoxConfigPath.ReadOnly = true;
            this.textBoxConfigPath.Size = new System.Drawing.Size(355, 21);
            this.textBoxConfigPath.TabIndex = 0;
            // 
            // Mainsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 295);
            this.Controls.Add(this.groupBoxConfigPath);
            this.Controls.Add(this.groupBoxLanguage);
            this.Controls.Add(this.groupBoxUsesettings);
            this.Controls.Add(this.groupBoxTruecryptPath);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxKeyfileContainer);
            this.Controls.Add(this.groupBoxDebug);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Mainsettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mainsettings";
            this.Load += new System.EventHandler(this.MainsettingsLoad);
            this.groupBoxDebug.ResumeLayout(false);
            this.groupBoxDebug.PerformLayout();
            this.groupBoxKeyfileContainer.ResumeLayout(false);
            this.groupBoxKeyfileContainer.PerformLayout();
            this.groupBoxTruecryptPath.ResumeLayout(false);
            this.groupBoxTruecryptPath.PerformLayout();
            this.groupBoxUsesettings.ResumeLayout(false);
            this.groupBoxUsesettings.PerformLayout();
            this.groupBoxLanguage.ResumeLayout(false);
            this.groupBoxConfigPath.ResumeLayout(false);
            this.groupBoxConfigPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog select_truecrypt;
        private System.Windows.Forms.TextBox textBoxTruecryptPath;
        private System.Windows.Forms.Button buttonTruecryptPath;
        private System.Windows.Forms.TextBox textBoxContainerPath;
        private System.Windows.Forms.Button buttonContainerPath;
        private System.Windows.Forms.Label labelTruecryptPath;
        private System.Windows.Forms.Label labelKeyfilecontainer;
        private System.Windows.Forms.OpenFileDialog select_konpath;
        private System.Windows.Forms.Label labelDriveletter;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxDebug;
        private System.Windows.Forms.CheckBox checkBoxSilentMode;
        private System.Windows.Forms.GroupBox groupBoxKeyfileContainer;
        private System.Windows.Forms.CheckBox checkBoxRemovable;
        private System.Windows.Forms.CheckBox checkBoxReadonly;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBoxTruecryptPath;
        private System.Windows.Forms.GroupBox groupBoxUsesettings;
        private System.Windows.Forms.CheckBox checkBoxNoKeyfilecontainer;
        private System.Windows.Forms.ComboBox comboBoxDriveletter;
        private System.Windows.Forms.GroupBox groupBoxLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.CheckBox checkBoxAutomount;
        private System.Windows.Forms.CheckBox checkBoxPim;
        private System.Windows.Forms.ComboBox comboBoxHash;
        private System.Windows.Forms.Label labelHash;
        private System.Windows.Forms.GroupBox groupBoxConfigPath;
        private System.Windows.Forms.Button buttonShowConfig;
        private System.Windows.Forms.TextBox textBoxConfigPath;
        private System.Windows.Forms.CheckBox checkBox_startwithwin;
    }
}