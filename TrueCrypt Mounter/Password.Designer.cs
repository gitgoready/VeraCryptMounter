namespace TrueCrypt_Mounter
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
            this.labelState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPassword_first
            // 
            this.textBoxPassword_first.Location = new System.Drawing.Point(12, 29);
            this.textBoxPassword_first.Name = "textBoxPassword_first";
            this.textBoxPassword_first.Size = new System.Drawing.Size(257, 20);
            this.textBoxPassword_first.TabIndex = 0;
            this.textBoxPassword_first.UseSystemPasswordChar = true;
            // 
            // textBoxPassword_second
            // 
            this.textBoxPassword_second.Location = new System.Drawing.Point(12, 66);
            this.textBoxPassword_second.Name = "textBoxPassword_second";
            this.textBoxPassword_second.Size = new System.Drawing.Size(257, 20);
            this.textBoxPassword_second.TabIndex = 1;
            this.textBoxPassword_second.UseSystemPasswordChar = true;
            this.textBoxPassword_second.TextChanged += new System.EventHandler(this.textBoxPassword_second_TextChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(113, 106);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(194, 106);
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
            this.labelPassword_first.Location = new System.Drawing.Point(9, 13);
            this.labelPassword_first.Name = "labelPassword_first";
            this.labelPassword_first.Size = new System.Drawing.Size(53, 13);
            this.labelPassword_first.TabIndex = 5;
            this.labelPassword_first.Text = "Password";
            // 
            // labelPassword_second
            // 
            this.labelPassword_second.AutoSize = true;
            this.labelPassword_second.Location = new System.Drawing.Point(9, 52);
            this.labelPassword_second.Name = "labelPassword_second";
            this.labelPassword_second.Size = new System.Drawing.Size(53, 13);
            this.labelPassword_second.TabIndex = 6;
            this.labelPassword_second.Text = "Password";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(13, 106);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.ForeColor = System.Drawing.Color.Red;
            this.labelState.Location = new System.Drawing.Point(234, 89);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(20, 13);
            this.labelState.TabIndex = 7;
            this.labelState.Text = "fail";
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 143);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelPassword_second);
            this.Controls.Add(this.labelPassword_first);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxPassword_second);
            this.Controls.Add(this.textBoxPassword_first);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Password";
            this.Text = "Password";
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
        private System.Windows.Forms.Label labelState;
    }
}