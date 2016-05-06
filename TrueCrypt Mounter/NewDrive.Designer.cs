using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    partial class NewDrive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDrive));
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.lableDescription = new System.Windows.Forms.Label();
            this.lablePartition = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxPartition = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.lableKeyfile = new System.Windows.Forms.Label();
            this.textBoxKeyfile = new System.Windows.Forms.TextBox();
            this.checkBoxNoKeyfile = new System.Windows.Forms.CheckBox();
            this.checkBoxRemovable = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonChosePartition = new System.Windows.Forms.Button();
            this.groupBoxMountoptions = new System.Windows.Forms.GroupBox();
            this.checkBoxTruecrypt = new System.Windows.Forms.CheckBox();
            this.checkBoxPim = new System.Windows.Forms.CheckBox();
            this.checkBoxAutomountStart = new System.Windows.Forms.CheckBox();
            this.checkBoxAutomountUsb = new System.Windows.Forms.CheckBox();
            this.checkBoxReadonly = new System.Windows.Forms.CheckBox();
            this.groupBoxDriveletter = new System.Windows.Forms.GroupBox();
            this.comboBoxHash = new System.Windows.Forms.ComboBox();
            this.comboBoxDriveletter = new System.Windows.Forms.ComboBox();
            this.groupBox_PNPDeviceID = new System.Windows.Forms.GroupBox();
            this.textBox_PNPDeviceID = new System.Windows.Forms.TextBox();
            this.groupBoxSavePassword = new System.Windows.Forms.GroupBox();
            this.checkBoxPassword = new System.Windows.Forms.CheckBox();
            this.buttonShowPassword = new System.Windows.Forms.Button();
            this.buttonSavePassword = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxMountoptions.SuspendLayout();
            this.groupBoxDriveletter.SuspendLayout();
            this.groupBox_PNPDeviceID.SuspendLayout();
            this.groupBoxSavePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(7, 32);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(276, 20);
            this.textBoxDescription.TabIndex = 1;
            // 
            // lableDescription
            // 
            this.lableDescription.AutoSize = true;
            this.lableDescription.Location = new System.Drawing.Point(10, 16);
            this.lableDescription.Name = "lableDescription";
            this.lableDescription.Size = new System.Drawing.Size(94, 13);
            this.lableDescription.TabIndex = 2;
            this.lableDescription.Text = "Name for the drive";
            // 
            // lablePartition
            // 
            this.lablePartition.AutoSize = true;
            this.lablePartition.Location = new System.Drawing.Point(10, 55);
            this.lablePartition.Name = "lablePartition";
            this.lablePartition.Size = new System.Drawing.Size(96, 13);
            this.lablePartition.TabIndex = 3;
            this.lablePartition.Text = "Encrypted Partition";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(210, 415);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.erstellen_Click);
            // 
            // textBoxPartition
            // 
            this.textBoxPartition.Location = new System.Drawing.Point(7, 71);
            this.textBoxPartition.Name = "textBoxPartition";
            this.textBoxPartition.Size = new System.Drawing.Size(276, 20);
            this.textBoxPartition.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(129, 415);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.abbruch_Click);
            // 
            // lableKeyfile
            // 
            this.lableKeyfile.AutoSize = true;
            this.lableKeyfile.Location = new System.Drawing.Point(7, 107);
            this.lableKeyfile.Name = "lableKeyfile";
            this.lableKeyfile.Size = new System.Drawing.Size(97, 13);
            this.lableKeyfile.TabIndex = 8;
            this.lableKeyfile.Text = "Keyfile for the drive";
            // 
            // textBoxKeyfile
            // 
            this.textBoxKeyfile.Location = new System.Drawing.Point(7, 123);
            this.textBoxKeyfile.Name = "textBoxKeyfile";
            this.textBoxKeyfile.Size = new System.Drawing.Size(276, 20);
            this.textBoxKeyfile.TabIndex = 3;
            // 
            // checkBoxNoKeyfile
            // 
            this.checkBoxNoKeyfile.AutoSize = true;
            this.checkBoxNoKeyfile.Location = new System.Drawing.Point(7, 146);
            this.checkBoxNoKeyfile.Name = "checkBoxNoKeyfile";
            this.checkBoxNoKeyfile.Size = new System.Drawing.Size(81, 17);
            this.checkBoxNoKeyfile.TabIndex = 9;
            this.checkBoxNoKeyfile.Text = "Kein Keyfile";
            this.checkBoxNoKeyfile.UseVisualStyleBackColor = true;
            this.checkBoxNoKeyfile.CheckStateChanged += new System.EventHandler(this.CheckboxNoKeyfileCheckStateChanged);
            // 
            // checkBoxRemovable
            // 
            this.checkBoxRemovable.AutoSize = true;
            this.checkBoxRemovable.Location = new System.Drawing.Point(7, 19);
            this.checkBoxRemovable.Name = "checkBoxRemovable";
            this.checkBoxRemovable.Size = new System.Drawing.Size(80, 17);
            this.checkBoxRemovable.TabIndex = 10;
            this.checkBoxRemovable.Text = "Removable";
            this.checkBoxRemovable.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonChosePartition);
            this.groupBox1.Controls.Add(this.lableDescription);
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.checkBoxNoKeyfile);
            this.groupBox1.Controls.Add(this.lablePartition);
            this.groupBox1.Controls.Add(this.textBoxPartition);
            this.groupBox1.Controls.Add(this.textBoxKeyfile);
            this.groupBox1.Controls.Add(this.lableKeyfile);
            this.groupBox1.Location = new System.Drawing.Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 167);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // buttonChosePartition
            // 
            this.buttonChosePartition.Location = new System.Drawing.Point(208, 94);
            this.buttonChosePartition.Name = "buttonChosePartition";
            this.buttonChosePartition.Size = new System.Drawing.Size(75, 23);
            this.buttonChosePartition.TabIndex = 10;
            this.buttonChosePartition.Text = "Select";
            this.buttonChosePartition.UseVisualStyleBackColor = true;
            this.buttonChosePartition.Click += new System.EventHandler(this.buttonChosePartition_Click);
            // 
            // groupBoxMountoptions
            // 
            this.groupBoxMountoptions.Controls.Add(this.checkBoxTruecrypt);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxPim);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxAutomountStart);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxAutomountUsb);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxReadonly);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxRemovable);
            this.groupBoxMountoptions.Location = new System.Drawing.Point(2, 168);
            this.groupBoxMountoptions.Name = "groupBoxMountoptions";
            this.groupBoxMountoptions.Size = new System.Drawing.Size(292, 103);
            this.groupBoxMountoptions.TabIndex = 12;
            this.groupBoxMountoptions.TabStop = false;
            this.groupBoxMountoptions.Text = "Mountoptions";
            // 
            // checkBoxTruecrypt
            // 
            this.checkBoxTruecrypt.AutoSize = true;
            this.checkBoxTruecrypt.Location = new System.Drawing.Point(179, 39);
            this.checkBoxTruecrypt.Name = "checkBoxTruecrypt";
            this.checkBoxTruecrypt.Size = new System.Drawing.Size(72, 17);
            this.checkBoxTruecrypt.TabIndex = 15;
            this.checkBoxTruecrypt.Text = "TrueCrypt";
            this.checkBoxTruecrypt.UseVisualStyleBackColor = true;
            // 
            // checkBoxPim
            // 
            this.checkBoxPim.AutoSize = true;
            this.checkBoxPim.Location = new System.Drawing.Point(179, 19);
            this.checkBoxPim.Name = "checkBoxPim";
            this.checkBoxPim.Size = new System.Drawing.Size(45, 17);
            this.checkBoxPim.TabIndex = 8;
            this.checkBoxPim.Text = "PIM";
            this.checkBoxPim.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutomountStart
            // 
            this.checkBoxAutomountStart.AutoSize = true;
            this.checkBoxAutomountStart.Location = new System.Drawing.Point(7, 79);
            this.checkBoxAutomountStart.Name = "checkBoxAutomountStart";
            this.checkBoxAutomountStart.Size = new System.Drawing.Size(152, 17);
            this.checkBoxAutomountStart.TabIndex = 14;
            this.checkBoxAutomountStart.Text = "Automount by programstart";
            this.checkBoxAutomountStart.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutomountUsb
            // 
            this.checkBoxAutomountUsb.AutoSize = true;
            this.checkBoxAutomountUsb.Location = new System.Drawing.Point(7, 59);
            this.checkBoxAutomountUsb.Name = "checkBoxAutomountUsb";
            this.checkBoxAutomountUsb.Size = new System.Drawing.Size(77, 17);
            this.checkBoxAutomountUsb.TabIndex = 8;
            this.checkBoxAutomountUsb.Text = "Automount";
            this.checkBoxAutomountUsb.UseVisualStyleBackColor = true;
            // 
            // checkBoxReadonly
            // 
            this.checkBoxReadonly.AutoSize = true;
            this.checkBoxReadonly.Location = new System.Drawing.Point(7, 39);
            this.checkBoxReadonly.Name = "checkBoxReadonly";
            this.checkBoxReadonly.Size = new System.Drawing.Size(71, 17);
            this.checkBoxReadonly.TabIndex = 13;
            this.checkBoxReadonly.Text = "Readonly";
            this.checkBoxReadonly.UseVisualStyleBackColor = true;
            // 
            // groupBoxDriveletter
            // 
            this.groupBoxDriveletter.Controls.Add(this.comboBoxHash);
            this.groupBoxDriveletter.Controls.Add(this.comboBoxDriveletter);
            this.groupBoxDriveletter.Location = new System.Drawing.Point(2, 319);
            this.groupBoxDriveletter.Name = "groupBoxDriveletter";
            this.groupBoxDriveletter.Size = new System.Drawing.Size(292, 48);
            this.groupBoxDriveletter.TabIndex = 13;
            this.groupBoxDriveletter.TabStop = false;
            this.groupBoxDriveletter.Text = "Driveletter";
            // 
            // comboBoxHash
            // 
            this.comboBoxHash.FormattingEnabled = true;
            this.comboBoxHash.Location = new System.Drawing.Point(80, 19);
            this.comboBoxHash.Name = "comboBoxHash";
            this.comboBoxHash.Size = new System.Drawing.Size(144, 21);
            this.comboBoxHash.TabIndex = 11;
            // 
            // comboBoxDriveletter
            // 
            this.comboBoxDriveletter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxDriveletter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDriveletter.FormattingEnabled = true;
            this.comboBoxDriveletter.Location = new System.Drawing.Point(7, 19);
            this.comboBoxDriveletter.Name = "comboBoxDriveletter";
            this.comboBoxDriveletter.Size = new System.Drawing.Size(59, 21);
            this.comboBoxDriveletter.TabIndex = 7;
            this.comboBoxDriveletter.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxDriveletter_DrawItem);
            this.comboBoxDriveletter.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ComboBoxDriveletter_MeasureItem);
            // 
            // groupBox_PNPDeviceID
            // 
            this.groupBox_PNPDeviceID.Controls.Add(this.textBox_PNPDeviceID);
            this.groupBox_PNPDeviceID.Location = new System.Drawing.Point(2, 367);
            this.groupBox_PNPDeviceID.Name = "groupBox_PNPDeviceID";
            this.groupBox_PNPDeviceID.Size = new System.Drawing.Size(292, 42);
            this.groupBox_PNPDeviceID.TabIndex = 14;
            this.groupBox_PNPDeviceID.TabStop = false;
            this.groupBox_PNPDeviceID.Text = "PNPDeviceID";
            // 
            // textBox_PNPDeviceID
            // 
            this.textBox_PNPDeviceID.Location = new System.Drawing.Point(7, 15);
            this.textBox_PNPDeviceID.Name = "textBox_PNPDeviceID";
            this.textBox_PNPDeviceID.ReadOnly = true;
            this.textBox_PNPDeviceID.Size = new System.Drawing.Size(276, 20);
            this.textBox_PNPDeviceID.TabIndex = 0;
            // 
            // groupBoxSavePassword
            // 
            this.groupBoxSavePassword.Controls.Add(this.checkBoxPassword);
            this.groupBoxSavePassword.Controls.Add(this.buttonShowPassword);
            this.groupBoxSavePassword.Controls.Add(this.buttonSavePassword);
            this.groupBoxSavePassword.Location = new System.Drawing.Point(2, 272);
            this.groupBoxSavePassword.Name = "groupBoxSavePassword";
            this.groupBoxSavePassword.Size = new System.Drawing.Size(292, 46);
            this.groupBoxSavePassword.TabIndex = 20;
            this.groupBoxSavePassword.TabStop = false;
            this.groupBoxSavePassword.Text = "groupBox1";
            // 
            // checkBoxPassword
            // 
            this.checkBoxPassword.AutoSize = true;
            this.checkBoxPassword.Location = new System.Drawing.Point(200, 20);
            this.checkBoxPassword.Name = "checkBoxPassword";
            this.checkBoxPassword.Size = new System.Drawing.Size(80, 17);
            this.checkBoxPassword.TabIndex = 2;
            this.checkBoxPassword.Text = "checkBox1";
            this.checkBoxPassword.UseVisualStyleBackColor = true;
            this.checkBoxPassword.CheckedChanged += new System.EventHandler(this.checkBoxPassword_CheckedChanged);
            // 
            // buttonShowPassword
            // 
            this.buttonShowPassword.Location = new System.Drawing.Point(103, 17);
            this.buttonShowPassword.Name = "buttonShowPassword";
            this.buttonShowPassword.Size = new System.Drawing.Size(90, 23);
            this.buttonShowPassword.TabIndex = 1;
            this.buttonShowPassword.Text = "Show";
            this.buttonShowPassword.UseVisualStyleBackColor = true;
            this.buttonShowPassword.Click += new System.EventHandler(this.buttonShowPassword_Click);
            // 
            // buttonSavePassword
            // 
            this.buttonSavePassword.Location = new System.Drawing.Point(7, 17);
            this.buttonSavePassword.Name = "buttonSavePassword";
            this.buttonSavePassword.Size = new System.Drawing.Size(90, 23);
            this.buttonSavePassword.TabIndex = 0;
            this.buttonSavePassword.Text = "Save Password";
            this.buttonSavePassword.UseVisualStyleBackColor = true;
            this.buttonSavePassword.Click += new System.EventHandler(this.buttonSavePassword_Click);
            // 
            // NewDrive
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 446);
            this.Controls.Add(this.groupBoxSavePassword);
            this.Controls.Add(this.groupBox_PNPDeviceID);
            this.Controls.Add(this.groupBoxDriveletter);
            this.Controls.Add(this.groupBoxMountoptions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewDrive";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Drive";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxMountoptions.ResumeLayout(false);
            this.groupBoxMountoptions.PerformLayout();
            this.groupBoxDriveletter.ResumeLayout(false);
            this.groupBox_PNPDeviceID.ResumeLayout(false);
            this.groupBox_PNPDeviceID.PerformLayout();
            this.groupBoxSavePassword.ResumeLayout(false);
            this.groupBoxSavePassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label lableDescription;
        private System.Windows.Forms.Label lablePartition;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxPartition;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label lableKeyfile;
        private System.Windows.Forms.TextBox textBoxKeyfile;
        private CheckBox checkBoxNoKeyfile;
        private CheckBox checkBoxRemovable;
        private GroupBox groupBox1;
        private GroupBox groupBoxMountoptions;
        private CheckBox checkBoxReadonly;
        private GroupBox groupBoxDriveletter;
        private ComboBox comboBoxDriveletter;
        private CheckBox checkBoxAutomountUsb;
        private CheckBox checkBoxAutomountStart;
        private Button buttonChosePartition;
        private CheckBox checkBoxTruecrypt;
        private CheckBox checkBoxPim;
        private ComboBox comboBoxHash;
        private GroupBox groupBox_PNPDeviceID;
        private TextBox textBox_PNPDeviceID;
        private GroupBox groupBoxSavePassword;
        private Button buttonSavePassword;
        private CheckBox checkBoxPassword;
        private Button buttonShowPassword;
    }
}