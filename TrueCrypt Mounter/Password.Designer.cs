namespace VeraCrypt_Mounter
{
    partial class Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Password));
            this.textBoxPassword_first = new System.Windows.Forms.TextBox();
            this.textBoxPassword_second = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelPassword_first = new System.Windows.Forms.Label();
            this.labelPassword_second = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.textBoxOldPassword = new System.Windows.Forms.TextBox();
            this.labelOldPassword = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPassword_first
            // 
            this.textBoxPassword_first.Location = new System.Drawing.Point(12, 58);
            this.textBoxPassword_first.Name = "textBoxPassword_first";
            this.textBoxPassword_first.PasswordChar = '*';
            this.textBoxPassword_first.Size = new System.Drawing.Size(257, 20);
            this.textBoxPassword_first.TabIndex = 0;
            this.textBoxPassword_first.UseSystemPasswordChar = true;
            this.textBoxPassword_first.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_first_KeyPress);
            // 
            // textBoxPassword_second
            // 
            this.textBoxPassword_second.Location = new System.Drawing.Point(12, 95);
            this.textBoxPassword_second.Name = "textBoxPassword_second";
            this.textBoxPassword_second.PasswordChar = '*';
            this.textBoxPassword_second.Size = new System.Drawing.Size(257, 20);
            this.textBoxPassword_second.TabIndex = 1;
            this.textBoxPassword_second.UseSystemPasswordChar = true;
            this.textBoxPassword_second.TextChanged += new System.EventHandler(this.textBoxPassword_second_TextChanged);
            this.textBoxPassword_second.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_second_KeyPress);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(113, 150);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(194, 150);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelPassword_first
            // 
            this.labelPassword_first.AutoSize = true;
            this.labelPassword_first.Location = new System.Drawing.Point(9, 44);
            this.labelPassword_first.Name = "labelPassword_first";
            this.labelPassword_first.Size = new System.Drawing.Size(88, 13);
            this.labelPassword_first.TabIndex = 5;
            this.labelPassword_first.Text = "Master Password";
            // 
            // labelPassword_second
            // 
            this.labelPassword_second.AutoSize = true;
            this.labelPassword_second.Location = new System.Drawing.Point(9, 81);
            this.labelPassword_second.Name = "labelPassword_second";
            this.labelPassword_second.Size = new System.Drawing.Size(125, 13);
            this.labelPassword_second.TabIndex = 6;
            this.labelPassword_second.Text = "Retype Master Password";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 150);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 178);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Location = new System.Drawing.Point(12, 121);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(103, 23);
            this.buttonChangePassword.TabIndex = 9;
            this.buttonChangePassword.Text = "Password change";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.Location = new System.Drawing.Point(12, 22);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.PasswordChar = '*';
            this.textBoxOldPassword.Size = new System.Drawing.Size(257, 20);
            this.textBoxOldPassword.TabIndex = 10;
            // 
            // labelOldPassword
            // 
            this.labelOldPassword.AutoSize = true;
            this.labelOldPassword.Location = new System.Drawing.Point(9, 9);
            this.labelOldPassword.Name = "labelOldPassword";
            this.labelOldPassword.Size = new System.Drawing.Size(107, 13);
            this.labelOldPassword.TabIndex = 11;
            this.labelOldPassword.Text = "Old Master Password";
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 200);
            this.Controls.Add(this.labelOldPassword);
            this.Controls.Add(this.textBoxOldPassword);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelPassword_second);
            this.Controls.Add(this.labelPassword_first);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxPassword_second);
            this.Controls.Add(this.textBoxPassword_first);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Password";
            this.Text = "Input Master Password";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword_first;
        private System.Windows.Forms.TextBox textBoxPassword_second;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelPassword_first;
        private System.Windows.Forms.Label labelPassword_second;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.TextBox textBoxOldPassword;
        private System.Windows.Forms.Label labelOldPassword;
    }
}