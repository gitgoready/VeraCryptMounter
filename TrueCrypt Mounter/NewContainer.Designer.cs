namespace TrueCrypt_Mounter
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
            this.openFileDialogKontainer = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenContainer = new System.Windows.Forms.Button();
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxKontainer = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.checkBoxAutomountUsb = new System.Windows.Forms.CheckBox();
            this.groupBoxKyfilename = new System.Windows.Forms.GroupBox();
            this.checkBoxNoKeyfile = new System.Windows.Forms.CheckBox();
            this.textBoxKeyfile = new System.Windows.Forms.TextBox();
            this.groupBoxDrive = new System.Windows.Forms.GroupBox();
            this.checkBoxNoDrive = new System.Windows.Forms.CheckBox();
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.groupBoxDriveletter = new System.Windows.Forms.GroupBox();
            this.comboBoxDriveletter = new System.Windows.Forms.ComboBox();
            this.groupBoxMountoptions = new System.Windows.Forms.GroupBox();
            this.checkBoxAutomountStart = new System.Windows.Forms.CheckBox();
            this.checkBoxRemovable = new System.Windows.Forms.CheckBox();
            this.checkBoxReadonly = new System.Windows.Forms.CheckBox();
            this.checkBoxPim = new System.Windows.Forms.CheckBox();
            this.checkBoxTrueCrypt = new System.Windows.Forms.CheckBox();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.groupBoxKyfilename.SuspendLayout();
            this.groupBoxDrive.SuspendLayout();
            this.groupBoxDriveletter.SuspendLayout();
            this.groupBoxMountoptions.SuspendLayout();
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
            this.buttonOpenContainer.Location = new System.Drawing.Point(6, 45);
            this.buttonOpenContainer.Name = "buttonOpenContainer";
            this.buttonOpenContainer.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenContainer.TabIndex = 5;
            this.buttonOpenContainer.Text = "Öffnen";
            this.buttonOpenContainer.UseVisualStyleBackColor = true;
            this.buttonOpenContainer.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.textBoxDescription);
            this.groupBoxDescription.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(416, 50);
            this.groupBoxDescription.TabIndex = 1;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Beschreibung des Kontainers";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(6, 19);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(404, 20);
            this.textBoxDescription.TabIndex = 2;
            // 
            // textBoxKontainer
            // 
            this.textBoxKontainer.Location = new System.Drawing.Point(6, 19);
            this.textBoxKontainer.Name = "textBoxKontainer";
            this.textBoxKontainer.Size = new System.Drawing.Size(404, 20);
            this.textBoxKontainer.TabIndex = 4;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(122, 334);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Abbruch";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(225, 334);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(90, 23);
            this.buttonOk.TabIndex = 17;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.textBoxKontainer);
            this.groupBoxPath.Controls.Add(this.buttonOpenContainer);
            this.groupBoxPath.Location = new System.Drawing.Point(12, 68);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(416, 80);
            this.groupBoxPath.TabIndex = 3;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "Pfad zum Kontainer";
            // 
            // checkBoxAutomountUsb
            // 
            this.checkBoxAutomountUsb.AutoSize = true;
            this.checkBoxAutomountUsb.Location = new System.Drawing.Point(6, 53);
            this.checkBoxAutomountUsb.Name = "checkBoxAutomountUsb";
            this.checkBoxAutomountUsb.Size = new System.Drawing.Size(116, 17);
            this.checkBoxAutomountUsb.TabIndex = 6;
            this.checkBoxAutomountUsb.Text = "Automount by USB";
            this.checkBoxAutomountUsb.UseVisualStyleBackColor = true;
            // 
            // groupBoxKyfilename
            // 
            this.groupBoxKyfilename.Controls.Add(this.checkBoxNoKeyfile);
            this.groupBoxKyfilename.Controls.Add(this.textBoxKeyfile);
            this.groupBoxKyfilename.Location = new System.Drawing.Point(12, 154);
            this.groupBoxKyfilename.Name = "groupBoxKyfilename";
            this.groupBoxKyfilename.Size = new System.Drawing.Size(205, 70);
            this.groupBoxKyfilename.TabIndex = 6;
            this.groupBoxKyfilename.TabStop = false;
            this.groupBoxKyfilename.Text = "Keyfilename";
            // 
            // checkBoxNoKeyfile
            // 
            this.checkBoxNoKeyfile.AutoSize = true;
            this.checkBoxNoKeyfile.Location = new System.Drawing.Point(6, 45);
            this.checkBoxNoKeyfile.Name = "checkBoxNoKeyfile";
            this.checkBoxNoKeyfile.Size = new System.Drawing.Size(81, 17);
            this.checkBoxNoKeyfile.TabIndex = 8;
            this.checkBoxNoKeyfile.Text = "Kein Keyfile";
            this.checkBoxNoKeyfile.UseVisualStyleBackColor = true;
            this.checkBoxNoKeyfile.CheckedChanged += new System.EventHandler(this.checkBoxNoKeyfile_CheckedChanged);
            // 
            // textBoxKeyfile
            // 
            this.textBoxKeyfile.Location = new System.Drawing.Point(6, 19);
            this.textBoxKeyfile.Name = "textBoxKeyfile";
            this.textBoxKeyfile.Size = new System.Drawing.Size(193, 20);
            this.textBoxKeyfile.TabIndex = 7;
            // 
            // groupBoxDrive
            // 
            this.groupBoxDrive.Controls.Add(this.checkBoxNoDrive);
            this.groupBoxDrive.Controls.Add(this.comboBoxDrives);
            this.groupBoxDrive.Location = new System.Drawing.Point(223, 154);
            this.groupBoxDrive.Name = "groupBoxDrive";
            this.groupBoxDrive.Size = new System.Drawing.Size(205, 70);
            this.groupBoxDrive.TabIndex = 9;
            this.groupBoxDrive.TabStop = false;
            this.groupBoxDrive.Text = "Beinhaltendes Laufwerk";
            // 
            // checkBoxNoDrive
            // 
            this.checkBoxNoDrive.AutoSize = true;
            this.checkBoxNoDrive.Location = new System.Drawing.Point(6, 46);
            this.checkBoxNoDrive.Name = "checkBoxNoDrive";
            this.checkBoxNoDrive.Size = new System.Drawing.Size(94, 17);
            this.checkBoxNoDrive.TabIndex = 11;
            this.checkBoxNoDrive.Text = "Kein Laufwerk";
            this.checkBoxNoDrive.UseVisualStyleBackColor = true;
            this.checkBoxNoDrive.CheckedChanged += new System.EventHandler(this.checkBoxNoDrive_CheckedChanged);
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(6, 19);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(193, 21);
            this.comboBoxDrives.TabIndex = 10;
            // 
            // groupBoxDriveletter
            // 
            this.groupBoxDriveletter.Controls.Add(this.comboBoxDriveletter);
            this.groupBoxDriveletter.Location = new System.Drawing.Point(12, 230);
            this.groupBoxDriveletter.Name = "groupBoxDriveletter";
            this.groupBoxDriveletter.Size = new System.Drawing.Size(205, 54);
            this.groupBoxDriveletter.TabIndex = 12;
            this.groupBoxDriveletter.TabStop = false;
            this.groupBoxDriveletter.Text = "Zuzuweisender Laufwerksbuchstaben";
            // 
            // comboBoxDriveletter
            // 
            this.comboBoxDriveletter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxDriveletter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDriveletter.FormattingEnabled = true;
            this.comboBoxDriveletter.Location = new System.Drawing.Point(80, 19);
            this.comboBoxDriveletter.Name = "comboBoxDriveletter";
            this.comboBoxDriveletter.Size = new System.Drawing.Size(45, 21);
            this.comboBoxDriveletter.TabIndex = 13;
            this.comboBoxDriveletter.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxDriveletter_DrawItem);
            this.comboBoxDriveletter.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ComboBoxDriveletter_MeasureItem);
            // 
            // groupBoxMountoptions
            // 
            this.groupBoxMountoptions.Controls.Add(this.checkBoxTrueCrypt);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxPim);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxAutomountStart);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxRemovable);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxAutomountUsb);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxReadonly);
            this.groupBoxMountoptions.Location = new System.Drawing.Point(223, 230);
            this.groupBoxMountoptions.Name = "groupBoxMountoptions";
            this.groupBoxMountoptions.Size = new System.Drawing.Size(205, 98);
            this.groupBoxMountoptions.TabIndex = 14;
            this.groupBoxMountoptions.TabStop = false;
            this.groupBoxMountoptions.Text = "Mounteinstellungen";
            // 
            // checkBoxAutomountStart
            // 
            this.checkBoxAutomountStart.AutoSize = true;
            this.checkBoxAutomountStart.Location = new System.Drawing.Point(6, 72);
            this.checkBoxAutomountStart.Name = "checkBoxAutomountStart";
            this.checkBoxAutomountStart.Size = new System.Drawing.Size(152, 17);
            this.checkBoxAutomountStart.TabIndex = 7;
            this.checkBoxAutomountStart.Text = "Automount by programstart";
            this.checkBoxAutomountStart.UseVisualStyleBackColor = true;
            // 
            // checkBoxRemovable
            // 
            this.checkBoxRemovable.AutoSize = true;
            this.checkBoxRemovable.Location = new System.Drawing.Point(6, 15);
            this.checkBoxRemovable.Name = "checkBoxRemovable";
            this.checkBoxRemovable.Size = new System.Drawing.Size(80, 17);
            this.checkBoxRemovable.TabIndex = 15;
            this.checkBoxRemovable.Text = "Removable";
            this.checkBoxRemovable.UseVisualStyleBackColor = true;
            // 
            // checkBoxReadonly
            // 
            this.checkBoxReadonly.AutoSize = true;
            this.checkBoxReadonly.Location = new System.Drawing.Point(6, 34);
            this.checkBoxReadonly.Name = "checkBoxReadonly";
            this.checkBoxReadonly.Size = new System.Drawing.Size(108, 17);
            this.checkBoxReadonly.TabIndex = 16;
            this.checkBoxReadonly.Text = "Schreibgeschützt";
            this.checkBoxReadonly.UseVisualStyleBackColor = true;
            // 
            // checkBoxPim
            // 
            this.checkBoxPim.AutoSize = true;
            this.checkBoxPim.Location = new System.Drawing.Point(121, 15);
            this.checkBoxPim.Name = "checkBoxPim";
            this.checkBoxPim.Size = new System.Drawing.Size(45, 17);
            this.checkBoxPim.TabIndex = 17;
            this.checkBoxPim.Text = "PIM";
            this.checkBoxPim.UseVisualStyleBackColor = true;
            // 
            // checkBoxTrueCrypt
            // 
            this.checkBoxTrueCrypt.AutoSize = true;
            this.checkBoxTrueCrypt.Location = new System.Drawing.Point(121, 34);
            this.checkBoxTrueCrypt.Name = "checkBoxTrueCrypt";
            this.checkBoxTrueCrypt.Size = new System.Drawing.Size(72, 17);
            this.checkBoxTrueCrypt.TabIndex = 18;
            this.checkBoxTrueCrypt.Text = "TrueCrypt";
            this.checkBoxTrueCrypt.UseVisualStyleBackColor = true;
            this.checkBoxTrueCrypt.CheckedChanged += new System.EventHandler(this.checkBoxTrueCrypt_CheckedChanged);
            // 
            // NewContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 369);
            this.Controls.Add(this.groupBoxMountoptions);
            this.Controls.Add(this.groupBoxDriveletter);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxDrive);
            this.Controls.Add(this.groupBoxKyfilename);
            this.Controls.Add(this.groupBoxPath);
            this.Controls.Add(this.groupBoxDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewContainer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Neuer Kontainer";
            this.TopMost = true;
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.groupBoxKyfilename.ResumeLayout(false);
            this.groupBoxKyfilename.PerformLayout();
            this.groupBoxDrive.ResumeLayout(false);
            this.groupBoxDrive.PerformLayout();
            this.groupBoxDriveletter.ResumeLayout(false);
            this.groupBoxMountoptions.ResumeLayout(false);
            this.groupBoxMountoptions.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxDrive;
        private System.Windows.Forms.ComboBox comboBoxDrives;
        private System.Windows.Forms.CheckBox checkBoxNoDrive;
        private System.Windows.Forms.GroupBox groupBoxDriveletter;
        private System.Windows.Forms.GroupBox groupBoxMountoptions;
        private System.Windows.Forms.CheckBox checkBoxRemovable;
        private System.Windows.Forms.CheckBox checkBoxReadonly;
        private System.Windows.Forms.ComboBox comboBoxDriveletter;
        private System.Windows.Forms.CheckBox checkBoxAutomountUsb;
        private System.Windows.Forms.CheckBox checkBoxAutomountStart;
        private System.Windows.Forms.CheckBox checkBoxTrueCrypt;
        private System.Windows.Forms.CheckBox checkBoxPim;
    }
}