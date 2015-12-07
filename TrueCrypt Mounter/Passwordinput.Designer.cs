namespace VeraCrypt_Mounter
{
    partial class Passwordinput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Passwordinput));
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxPim = new System.Windows.Forms.TextBox();
            this.labelPim = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(11, 29);
            this.textBoxPassword.MaxLength = 100;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(227, 20);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswortEingabe_KexDown);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(8, 13);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(121, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Bitte Passwort eingeben";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(162, 55);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // textBoxPim
            // 
            this.textBoxPim.Location = new System.Drawing.Point(40, 57);
            this.textBoxPim.Name = "textBoxPim";
            this.textBoxPim.Size = new System.Drawing.Size(116, 20);
            this.textBoxPim.TabIndex = 2;
            this.textBoxPim.UseSystemPasswordChar = true;
            this.textBoxPim.Visible = false;
            this.textBoxPim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPim_KeyPress);
            // 
            // labelPim
            // 
            this.labelPim.AutoSize = true;
            this.labelPim.Location = new System.Drawing.Point(8, 60);
            this.labelPim.Name = "labelPim";
            this.labelPim.Size = new System.Drawing.Size(26, 13);
            this.labelPim.TabIndex = 4;
            this.labelPim.Text = "PIM";
            this.labelPim.Visible = false;
            // 
            // Passwordinput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 93);
            this.Controls.Add(this.labelPim);
            this.Controls.Add(this.textBoxPim);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Passwordinput";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Passwordinput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxPim;
        private System.Windows.Forms.Label labelPim;
    }
}