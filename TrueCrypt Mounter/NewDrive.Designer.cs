using System.Windows.Forms;

namespace TrueCrypt_Mounter
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
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.lableDescription = new System.Windows.Forms.Label();
            this.lablePartition = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxPartition = new System.Windows.Forms.TextBox();
            this.lableDriveletter = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.lableKeyfile = new System.Windows.Forms.Label();
            this.textBoxKeyfile = new System.Windows.Forms.TextBox();
            this.checkBoxNoKeyfile = new System.Windows.Forms.CheckBox();
            this.checkBoxRemovable = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxMountoptions = new System.Windows.Forms.GroupBox();
            this.checkBoxAutomountStart = new System.Windows.Forms.CheckBox();
            this.checkBoxAutomountUsb = new System.Windows.Forms.CheckBox();
            this.checkBoxReadonly = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxDriveletter = new System.Windows.Forms.ComboBox();
            this.buttonChosePartition = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxMountoptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(10, 32);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(223, 20);
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
            this.buttonOk.Location = new System.Drawing.Point(139, 350);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.erstellen_Click);
            // 
            // textBoxPartition
            // 
            this.textBoxPartition.Location = new System.Drawing.Point(10, 71);
            this.textBoxPartition.Name = "textBoxPartition";
            this.textBoxPartition.Size = new System.Drawing.Size(142, 20);
            this.textBoxPartition.TabIndex = 2;
            this.textBoxPartition.Text = "Partition";
            // 
            // lableDriveletter
            // 
            this.lableDriveletter.AutoSize = true;
            this.lableDriveletter.Location = new System.Drawing.Point(7, 16);
            this.lableDriveletter.Name = "lableDriveletter";
            this.lableDriveletter.Size = new System.Drawing.Size(55, 13);
            this.lableDriveletter.TabIndex = 6;
            this.lableDriveletter.Text = "Driveletter";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(28, 350);
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
            this.lableKeyfile.Location = new System.Drawing.Point(10, 94);
            this.lableKeyfile.Name = "lableKeyfile";
            this.lableKeyfile.Size = new System.Drawing.Size(97, 13);
            this.lableKeyfile.TabIndex = 8;
            this.lableKeyfile.Text = "Keyfile for the drive";
            // 
            // textBoxKeyfile
            // 
            this.textBoxKeyfile.Location = new System.Drawing.Point(10, 110);
            this.textBoxKeyfile.Name = "textBoxKeyfile";
            this.textBoxKeyfile.Size = new System.Drawing.Size(223, 20);
            this.textBoxKeyfile.TabIndex = 3;
            // 
            // checkBoxNoKeyfile
            // 
            this.checkBoxNoKeyfile.AutoSize = true;
            this.checkBoxNoKeyfile.Location = new System.Drawing.Point(10, 131);
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
            this.checkBoxRemovable.Location = new System.Drawing.Point(10, 19);
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
            this.groupBox1.Size = new System.Drawing.Size(239, 162);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // groupBoxMountoptions
            // 
            this.groupBoxMountoptions.Controls.Add(this.checkBoxAutomountStart);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxAutomountUsb);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxReadonly);
            this.groupBoxMountoptions.Controls.Add(this.checkBoxRemovable);
            this.groupBoxMountoptions.Location = new System.Drawing.Point(2, 168);
            this.groupBoxMountoptions.Name = "groupBoxMountoptions";
            this.groupBoxMountoptions.Size = new System.Drawing.Size(239, 103);
            this.groupBoxMountoptions.TabIndex = 12;
            this.groupBoxMountoptions.TabStop = false;
            this.groupBoxMountoptions.Text = "Mountoptions";
            // 
            // checkBoxAutomountStart
            // 
            this.checkBoxAutomountStart.AutoSize = true;
            this.checkBoxAutomountStart.Location = new System.Drawing.Point(10, 79);
            this.checkBoxAutomountStart.Name = "checkBoxAutomountStart";
            this.checkBoxAutomountStart.Size = new System.Drawing.Size(152, 17);
            this.checkBoxAutomountStart.TabIndex = 14;
            this.checkBoxAutomountStart.Text = "Automount by programstart";
            this.checkBoxAutomountStart.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutomountUsb
            // 
            this.checkBoxAutomountUsb.AutoSize = true;
            this.checkBoxAutomountUsb.Location = new System.Drawing.Point(10, 59);
            this.checkBoxAutomountUsb.Name = "checkBoxAutomountUsb";
            this.checkBoxAutomountUsb.Size = new System.Drawing.Size(77, 17);
            this.checkBoxAutomountUsb.TabIndex = 8;
            this.checkBoxAutomountUsb.Text = "Automount";
            this.checkBoxAutomountUsb.UseVisualStyleBackColor = true;
            // 
            // checkBoxReadonly
            // 
            this.checkBoxReadonly.AutoSize = true;
            this.checkBoxReadonly.Location = new System.Drawing.Point(10, 39);
            this.checkBoxReadonly.Name = "checkBoxReadonly";
            this.checkBoxReadonly.Size = new System.Drawing.Size(71, 17);
            this.checkBoxReadonly.TabIndex = 13;
            this.checkBoxReadonly.Text = "Readonly";
            this.checkBoxReadonly.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxDriveletter);
            this.groupBox2.Controls.Add(this.lableDriveletter);
            this.groupBox2.Location = new System.Drawing.Point(2, 277);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 67);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // comboBoxDriveletter
            // 
            this.comboBoxDriveletter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxDriveletter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDriveletter.FormattingEnabled = true;
            this.comboBoxDriveletter.Location = new System.Drawing.Point(10, 32);
            this.comboBoxDriveletter.Name = "comboBoxDriveletter";
            this.comboBoxDriveletter.Size = new System.Drawing.Size(43, 21);
            this.comboBoxDriveletter.TabIndex = 7;
            this.comboBoxDriveletter.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxDriveletter_DrawItem);
            this.comboBoxDriveletter.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ComboBoxDriveletter_MeasureItem);
            // 
            // buttonChosePartition
            // 
            this.buttonChosePartition.Location = new System.Drawing.Point(158, 69);
            this.buttonChosePartition.Name = "buttonChosePartition";
            this.buttonChosePartition.Size = new System.Drawing.Size(75, 23);
            this.buttonChosePartition.TabIndex = 10;
            this.buttonChosePartition.Text = "Select";
            this.buttonChosePartition.UseVisualStyleBackColor = true;
            this.buttonChosePartition.Click += new System.EventHandler(this.buttonChosePartition_Click);
            // 
            // NewDrive
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 385);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxMountoptions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewDrive";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Drive";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxMountoptions.ResumeLayout(false);
            this.groupBoxMountoptions.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label lableDescription;
        private System.Windows.Forms.Label lablePartition;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxPartition;
        private System.Windows.Forms.Label lableDriveletter;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label lableKeyfile;
        private System.Windows.Forms.TextBox textBoxKeyfile;
        private CheckBox checkBoxNoKeyfile;
        private CheckBox checkBoxRemovable;
        private GroupBox groupBox1;
        private GroupBox groupBoxMountoptions;
        private CheckBox checkBoxReadonly;
        private GroupBox groupBox2;
        private ComboBox comboBoxDriveletter;
        private CheckBox checkBoxAutomountUsb;
        private CheckBox checkBoxAutomountStart;
        private Button buttonChosePartition;
    }
}