namespace VeraCrypt_Mounter
{
    partial class NewContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewContainer));
            this.openFileDialogKontainer = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenContainer = new System.Windows.Forms.Button();
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxKontainer = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.textBoxSelectedDrive = new System.Windows.Forms.TextBox();
            this.checkBoxAutomountUsb = new System.Windows.Forms.CheckBox();
            this.groupBoxKyfilename = new System.Windows.Forms.GroupBox();
            this.buttonSelectKeyfile = new System.Windows.Forms.Button();
            this.checkBoxNoKeyfile = new System.Windows.Forms.CheckBox();
            this.textBoxKeyfile = new System.Windows.Forms.TextBox();
            this.groupBoxDriveletter = new System.Windows.Forms.GroupBox();
            this.comboBoxDriveletter = new System.Windows.Forms.ComboBox();
            this.groupBoxMountoptions = new System.Windows.Forms.GroupBox();
            this.checkBoxTrueCrypt = new System.Windows.Forms.CheckBox();
            this.checkBoxPim = new System.Windows.Forms.CheckBox();
            this.checkBoxAutomountStart = new System.Windows.Forms.CheckBox();
            this.checkBoxRemovable = new System.Windows.Forms.CheckBox();
            this.checkBoxReadonly = new System.Windows.Forms.CheckBox();
            this.groupBoxHash = new System.Windows.Forms.GroupBox();
            this.comboBoxHash = new System.Windows.Forms.ComboBox();
            this.groupBoxSavePassword = new System.Windows.Forms.GroupBox();
            this.checkBoxPassword = new System.Windows.Forms.CheckBox();
            this.buttonShowPassword = new System.Windows.Forms.Button();
            this.buttonSavePassword = new System.Windows.Forms.Button();
            this.openFileDialogKeyfile = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.groupBoxKyfilename.SuspendLayout();
            this.groupBoxDriveletter.SuspendLayout();
            this.groupBoxMountoptions.SuspendLayout();
            this.groupBoxHash.SuspendLayout();
            this.groupBoxSavePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialogKontainer
            // 
            this.openFileDialogKontainer.CheckFileExists = false;
            this.openFileDialogKontainer.FileName = "openFileDialogKontainer";
            this.openFileDialogKontainer.RestoreDirectory = true;
            this.openFileDialogKontainer.ValidateNames = false;
            this.openFileDialogKontainer.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogKontainerFileOK);
            // 
            // buttonOpenContainer
            // 
            this.buttonOpenContainer.Location = new System.Drawing.Point(8, 55);
            this.buttonOpenContainer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonOpenContainer.Name = "buttonOpenContainer";
            this.buttonOpenContainer.Size = new System.Drawing.Size(101, 28);
            this.buttonOpenContainer.TabIndex = 5;
            this.buttonOpenContainer.Text = "Öffnen";
            this.buttonOpenContainer.UseVisualStyleBackColor = true;
            this.buttonOpenContainer.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.textBoxDescription);
            this.groupBoxDescription.Location = new System.Drawing.Point(16, 15);
            this.groupBoxDescription.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxDescription.Size = new System.Drawing.Size(545, 62);
            this.groupBoxDescription.TabIndex = 1;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Beschreibung des Kontainers";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(8, 23);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(518, 22);
            this.textBoxDescription.TabIndex = 2;
            // 
            // textBoxKontainer
            // 
            this.textBoxKontainer.Location = new System.Drawing.Point(8, 23);
            this.textBoxKontainer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxKontainer.Name = "textBoxKontainer";
            this.textBoxKontainer.Size = new System.Drawing.Size(518, 22);
            this.textBoxKontainer.TabIndex = 4;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(441, 405);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 28);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Abbruch";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(313, 405);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(120, 28);
            this.buttonOk.TabIndex = 17;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.textBoxSelectedDrive);
            this.groupBoxPath.Controls.Add(this.textBoxKontainer);
            this.groupBoxPath.Controls.Add(this.buttonOpenContainer);
            this.groupBoxPath.Location = new System.Drawing.Point(16, 84);
            this.groupBoxPath.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxPath.Size = new System.Drawing.Size(545, 98);
            this.groupBoxPath.TabIndex = 3;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "Pfad zum Kontainer";
            // 
            // textBoxSelectedDrive
            // 
            this.textBoxSelectedDrive.Location = new System.Drawing.Point(117, 59);
            this.textBoxSelectedDrive.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxSelectedDrive.Name = "textBoxSelectedDrive";
            this.textBoxSelectedDrive.ReadOnly = true;
            this.textBoxSelectedDrive.Size = new System.Drawing.Size(409, 22);
            this.textBoxSelectedDrive.TabIndex = 13;
            // 
            // checkBoxAutomountUsb
            // 
            this.checkBoxAutomountUsb.AutoSize = true;
            this.checkBoxAutomountUsb.Location = new System.Drawing.Point(8, 65);
            this.checkBoxAutomountUsb.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxAutomountUsb.Name = "checkBoxAutomountUsb";
            this.checkBoxAutomountUsb.Size = new System.Drawing.Size(149, 21);
            this.checkBoxAutomountUsb.TabIndex = 6;
            this.checkBoxAutomountUsb.Text = "Automount by USB";
            this.checkBoxAutomountUsb.UseVisualStyleBackColor = true;
            // 
            // groupBoxKyfilename
            // 
            this.groupBoxKyfilename.Controls.Add(this.buttonSelectKeyfile);
            this.groupBoxKyfilename.Controls.Add(this.checkBoxNoKeyfile);
            this.groupBoxKyfilename.Controls.Add(this.textBoxKeyfile);
            this.groupBoxKyfilename.Location = new System.Drawing.Point(16, 190);
            this.groupBoxKyfilename.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxKyfilename.Name = "groupBoxKyfilename";
            this.groupBoxKyfilename.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxKyfilename.Size = new System.Drawing.Size(262, 86);
            this.groupBoxKyfilename.TabIndex = 6;
            this.groupBoxKyfilename.TabStop = false;
            this.groupBoxKyfilename.Text = "Keyfilename";
            // 
            // buttonSelectKeyfile
            // 
            this.buttonSelectKeyfile.Location = new System.Drawing.Point(138, 55);
            this.buttonSelectKeyfile.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSelectKeyfile.Name = "buttonSelectKeyfile";
            this.buttonSelectKeyfile.Size = new System.Drawing.Size(101, 28);
            this.buttonSelectKeyfile.TabIndex = 9;
            this.buttonSelectKeyfile.Text = "open";
            this.buttonSelectKeyfile.UseVisualStyleBackColor = true;
            this.buttonSelectKeyfile.Click += new System.EventHandler(this.buttonSelectKeyfile_Click);
            // 
            // checkBoxNoKeyfile
            // 
            this.checkBoxNoKeyfile.AutoSize = true;
            this.checkBoxNoKeyfile.Location = new System.Drawing.Point(8, 55);
            this.checkBoxNoKeyfile.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxNoKeyfile.Name = "checkBoxNoKeyfile";
            this.checkBoxNoKeyfile.Size = new System.Drawing.Size(104, 21);
            this.checkBoxNoKeyfile.TabIndex = 8;
            this.checkBoxNoKeyfile.Text = "Kein Keyfile";
            this.checkBoxNoKeyfile.UseVisualStyleBackColor = true;
            this.checkBoxNoKeyfile.CheckedChanged += new System.EventHandler(this.checkBoxNoKeyfile_CheckedChanged);
            // 
            // textBoxKeyfile
            // 
            this.textBoxKeyfile.Location = new System.Drawing.Point(8, 23);
            this.textBoxKeyfile.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxKeyfile.Name = "textBoxKeyfile";
            this.textBoxKeyfile.Size = new System.Drawing.Size(231, 22);
            this.textBoxKeyfile.TabIndex = 7;
            // 
            // groupBoxDriveletter
            // 
            this.groupBoxDriveletter.Controls.Add(this.comboBoxDriveletter);
            this.groupBoxDriveletter.Location = new System.Drawing.Point(16, 281);
            this.groupBoxDriveletter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxDriveletter.Name = "groupBoxDriveletter";
            this.groupBoxDriveletter.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxDriveletter.Size = new System.Drawing.Size(262, 57);
            this.groupBoxDriveletter.TabIndex = 12;
            this.groupBoxDriveletter.TabStop = false;
            this.groupBoxDriveletter.Text = "Zuzuweisender Laufwerksbuchstaben";
            // 
            // comboBoxDriveletter
            // 
            this.comboBoxDriveletter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxDriveletter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDriveletter.FormattingEnabled = true;
            this.comboBoxDriveletter.Location = new System.Drawing.Point(107, 23);
            this.comboBoxDriveletter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxDriveletter.Name = "comboBoxDriveletter";
            this.comboBoxDriveletter.Size = new System.Drawing.Size(59, 23);
            this.comboBoxDriveletter.TabIndex = 13;
            this.comboBoxDriveletter.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxDriveletter_DrawItem);
            this.comboBoxDriveletter.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ComboBoxDriveletter_MeasureItem);
            this.comboBoxDriveletter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBoxDriveletter_MouseClick);
            // 
            // groupBoxMountoptions
            // 
            this.groupBoxMountoptions.Controls.Add(this.checkBoxTrueCrypt);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxPim);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxAutomountStart);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxRemovable);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxAutomountUsb);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxReadonly);
            this.groupBoxMountoptions.Location = new System.Drawing.Point(288, 190);
            this.groupBoxMountoptions.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxMountoptions.Name = "groupBoxMountoptions";
            this.groupBoxMountoptions.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxMountoptions.Size = new System.Drawing.Size(273, 121);
            this.groupBoxMountoptions.TabIndex = 14;
            this.groupBoxMountoptions.TabStop = false;
            this.groupBoxMountoptions.Text = "Mounteinstellungen";
            // 
            // checkBoxTrueCrypt
            // 
            this.checkBoxTrueCrypt.AutoSize = true;
            this.checkBoxTrueCrypt.Location = new System.Drawing.Point(161, 42);
            this.checkBoxTrueCrypt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxTrueCrypt.Name = "checkBoxTrueCrypt";
            this.checkBoxTrueCrypt.Size = new System.Drawing.Size(93, 21);
            this.checkBoxTrueCrypt.TabIndex = 18;
            this.checkBoxTrueCrypt.Text = "TrueCrypt";
            this.checkBoxTrueCrypt.UseVisualStyleBackColor = true;
            this.checkBoxTrueCrypt.CheckedChanged += new System.EventHandler(this.checkBoxTrueCrypt_CheckedChanged);
            // 
            // checkBoxPim
            // 
            this.checkBoxPim.AutoSize = true;
            this.checkBoxPim.Location = new System.Drawing.Point(161, 18);
            this.checkBoxPim.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxPim.Name = "checkBoxPim";
            this.checkBoxPim.Size = new System.Drawing.Size(53, 21);
            this.checkBoxPim.TabIndex = 17;
            this.checkBoxPim.Text = "PIM";
            this.checkBoxPim.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutomountStart
            // 
            this.checkBoxAutomountStart.AutoSize = true;
            this.checkBoxAutomountStart.Location = new System.Drawing.Point(8, 89);
            this.checkBoxAutomountStart.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxAutomountStart.Name = "checkBoxAutomountStart";
            this.checkBoxAutomountStart.Size = new System.Drawing.Size(202, 21);
            this.checkBoxAutomountStart.TabIndex = 7;
            this.checkBoxAutomountStart.Text = "Automount by programstart";
            this.checkBoxAutomountStart.UseVisualStyleBackColor = true;
            // 
            // checkBoxRemovable
            // 
            this.checkBoxRemovable.AutoSize = true;
            this.checkBoxRemovable.Location = new System.Drawing.Point(8, 18);
            this.checkBoxRemovable.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxRemovable.Name = "checkBoxRemovable";
            this.checkBoxRemovable.Size = new System.Drawing.Size(101, 21);
            this.checkBoxRemovable.TabIndex = 15;
            this.checkBoxRemovable.Text = "Removable";
            this.checkBoxRemovable.UseVisualStyleBackColor = true;
            // 
            // checkBoxReadonly
            // 
            this.checkBoxReadonly.AutoSize = true;
            this.checkBoxReadonly.Location = new System.Drawing.Point(8, 42);
            this.checkBoxReadonly.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxReadonly.Name = "checkBoxReadonly";
            this.checkBoxReadonly.Size = new System.Drawing.Size(139, 21);
            this.checkBoxReadonly.TabIndex = 16;
            this.checkBoxReadonly.Text = "Schreibgeschützt";
            this.checkBoxReadonly.UseVisualStyleBackColor = true;
            // 
            // groupBoxHash
            // 
            this.groupBoxHash.Controls.Add(this.comboBoxHash);
            this.groupBoxHash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxHash.Location = new System.Drawing.Point(16, 341);
            this.groupBoxHash.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxHash.Name = "groupBoxHash";
            this.groupBoxHash.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxHash.Size = new System.Drawing.Size(262, 55);
            this.groupBoxHash.TabIndex = 18;
            this.groupBoxHash.TabStop = false;
            this.groupBoxHash.Text = "Hash";
            // 
            // comboBoxHash
            // 
            this.comboBoxHash.FormattingEnabled = true;
            this.comboBoxHash.Location = new System.Drawing.Point(73, 18);
            this.comboBoxHash.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxHash.Name = "comboBoxHash";
            this.comboBoxHash.Size = new System.Drawing.Size(125, 24);
            this.comboBoxHash.TabIndex = 0;
            this.comboBoxHash.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBoxHash_MouseClick);
            // 
            // groupBoxSavePassword
            // 
            this.groupBoxSavePassword.Controls.Add(this.checkBoxPassword);
            this.groupBoxSavePassword.Controls.Add(this.buttonShowPassword);
            this.groupBoxSavePassword.Controls.Add(this.buttonSavePassword);
            this.groupBoxSavePassword.Location = new System.Drawing.Point(288, 318);
            this.groupBoxSavePassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxSavePassword.Name = "groupBoxSavePassword";
            this.groupBoxSavePassword.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxSavePassword.Size = new System.Drawing.Size(273, 79);
            this.groupBoxSavePassword.TabIndex = 19;
            this.groupBoxSavePassword.TabStop = false;
            this.groupBoxSavePassword.Text = "groupBox1";
            // 
            // checkBoxPassword
            // 
            this.checkBoxPassword.AutoSize = true;
            this.checkBoxPassword.Location = new System.Drawing.Point(9, 52);
            this.checkBoxPassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxPassword.Name = "checkBoxPassword";
            this.checkBoxPassword.Size = new System.Drawing.Size(98, 21);
            this.checkBoxPassword.TabIndex = 4;
            this.checkBoxPassword.Text = "checkBox1";
            this.checkBoxPassword.UseVisualStyleBackColor = true;
            this.checkBoxPassword.CheckedChanged += new System.EventHandler(this.checkBoxPassword_CheckedChanged);
            // 
            // buttonShowPassword
            // 
            this.buttonShowPassword.Location = new System.Drawing.Point(139, 18);
            this.buttonShowPassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonShowPassword.Name = "buttonShowPassword";
            this.buttonShowPassword.Size = new System.Drawing.Size(101, 28);
            this.buttonShowPassword.TabIndex = 3;
            this.buttonShowPassword.Text = "show";
            this.buttonShowPassword.UseVisualStyleBackColor = true;
            this.buttonShowPassword.Click += new System.EventHandler(this.buttonShowPassword_Click);
            // 
            // buttonSavePassword
            // 
            this.buttonSavePassword.Location = new System.Drawing.Point(9, 18);
            this.buttonSavePassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSavePassword.Name = "buttonSavePassword";
            this.buttonSavePassword.Size = new System.Drawing.Size(101, 28);
            this.buttonSavePassword.TabIndex = 0;
            this.buttonSavePassword.Text = "Save Password";
            this.buttonSavePassword.UseVisualStyleBackColor = true;
            this.buttonSavePassword.Click += new System.EventHandler(this.buttonSavePassword_Click);
            // 
            // openFileDialogKeyfile
            // 
            this.openFileDialogKeyfile.FileName = "openFileDialogKeyfile";
            this.openFileDialogKeyfile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogKeyfile_FileOk);
            // 
            // NewContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 441);
            this.Controls.Add(this.groupBoxSavePassword);
            this.Controls.Add(this.groupBoxHash);
            this.Controls.Add(this.groupBoxMountoptions);
            this.Controls.Add(this.groupBoxDriveletter);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxKyfilename);
            this.Controls.Add(this.groupBoxPath);
            this.Controls.Add(this.groupBoxDescription);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewContainer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Neuer Kontainer";
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.groupBoxKyfilename.ResumeLayout(false);
            this.groupBoxKyfilename.PerformLayout();
            this.groupBoxDriveletter.ResumeLayout(false);
            this.groupBoxMountoptions.ResumeLayout(false);
            this.groupBoxMountoptions.PerformLayout();
            this.groupBoxHash.ResumeLayout(false);
            this.groupBoxSavePassword.ResumeLayout(false);
            this.groupBoxSavePassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogKontainer;
        private System.Windows.Forms.Button buttonOpenContainer;
        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxKontainer;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.GroupBox groupBoxKyfilename;
        private System.Windows.Forms.TextBox textBoxKeyfile;
        private System.Windows.Forms.CheckBox checkBoxNoKeyfile;
        private System.Windows.Forms.GroupBox groupBoxDriveletter;
        private System.Windows.Forms.GroupBox groupBoxMountoptions;
        private System.Windows.Forms.CheckBox checkBoxRemovable;
        private System.Windows.Forms.CheckBox checkBoxReadonly;
        private System.Windows.Forms.ComboBox comboBoxDriveletter;
        private System.Windows.Forms.CheckBox checkBoxAutomountUsb;
        private System.Windows.Forms.CheckBox checkBoxAutomountStart;
        private System.Windows.Forms.CheckBox checkBoxTrueCrypt;
        private System.Windows.Forms.CheckBox checkBoxPim;
        private System.Windows.Forms.GroupBox groupBoxHash;
        private System.Windows.Forms.ComboBox comboBoxHash;
        private System.Windows.Forms.GroupBox groupBoxSavePassword;
        private System.Windows.Forms.Button buttonSavePassword;
        private System.Windows.Forms.TextBox textBoxSelectedDrive;
        private System.Windows.Forms.CheckBox checkBoxPassword;
        private System.Windows.Forms.Button buttonShowPassword;
        private System.Windows.Forms.Button buttonSelectKeyfile;
        private System.Windows.Forms.OpenFileDialog openFileDialogKeyfile;
    }
}