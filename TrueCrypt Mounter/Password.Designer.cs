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
            this.textBoxPassword_first.Location = new System.Drawing.Point(16, 71);
            this.textBoxPassword_first.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword_first.Name = "textBoxPassword_first";
            this.textBoxPassword_first.PasswordChar = '*';
            this.textBoxPassword_first.Size = new System.Drawing.Size(341, 22);
            this.textBoxPassword_first.TabIndex = 0;
            this.textBoxPassword_first.UseSystemPasswordChar = true;
            this.textBoxPassword_first.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_first_KeyPress);
            // 
            // textBoxPassword_second
            // 
            this.textBoxPassword_second.Location = new System.Drawing.Point(16, 117);
            this.textBoxPassword_second.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword_second.Name = "textBoxPassword_second";
            this.textBoxPassword_second.PasswordChar = '*';
            this.textBoxPassword_second.Size = new System.Drawing.Size(341, 22);
            this.textBoxPassword_second.TabIndex = 1;
            this.textBoxPassword_second.UseSystemPasswordChar = true;
            this.textBoxPassword_second.TextChanged += new System.EventHandler(this.textBoxPassword_second_TextChanged);
            this.textBoxPassword_second.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_second_KeyPress);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(151, 185);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 28);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(259, 185);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelPassword_first
            // 
            this.labelPassword_first.AutoSize = true;
            this.labelPassword_first.Location = new System.Drawing.Point(12, 54);
            this.labelPassword_first.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword_first.Name = "labelPassword_first";
            this.labelPassword_first.Size = new System.Drawing.Size(116, 17);
            this.labelPassword_first.TabIndex = 5;
            this.labelPassword_first.Text = "Master Password";
            // 
            // labelPassword_second
            // 
            this.labelPassword_second.AutoSize = true;
            this.labelPassword_second.Location = new System.Drawing.Point(12, 100);
            this.labelPassword_second.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword_second.Name = "labelPassword_second";
            this.labelPassword_second.Size = new System.Drawing.Size(165, 17);
            this.labelPassword_second.TabIndex = 6;
            this.labelPassword_second.Text = "Retype Master Password";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(16, 185);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(100, 28);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 227);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(381, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.AutoSize = true;
            this.buttonChangePassword.Location = new System.Drawing.Point(16, 149);
            this.buttonChangePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(137, 28);
            this.buttonChangePassword.TabIndex = 9;
            this.buttonChangePassword.Text = "Password change";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.Location = new System.Drawing.Point(16, 27);
            this.textBoxOldPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.PasswordChar = '*';
            this.textBoxOldPassword.Size = new System.Drawing.Size(341, 22);
            this.textBoxOldPassword.TabIndex = 10;
            // 
            // labelOldPassword
            // 
            this.labelOldPassword.AutoSize = true;
            this.labelOldPassword.Location = new System.Drawing.Point(12, 10);
            this.labelOldPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOldPassword.Name = "labelOldPassword";
            this.labelOldPassword.Size = new System.Drawing.Size(142, 17);
            this.labelOldPassword.TabIndex = 11;
            this.labelOldPassword.Text = "Old Master Password";
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 252);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelOldPassword);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxOldPassword);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelPassword_second);
            this.Controls.Add(this.labelPassword_first);
            this.Controls.Add(this.textBoxPassword_second);
            this.Controls.Add(this.textBoxPassword_first);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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