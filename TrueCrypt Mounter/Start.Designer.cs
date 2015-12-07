namespace VeraCrypt_Mounter
{
    partial class Automount
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Automount));
            this.progressBarStart = new System.Windows.Forms.ProgressBar();
            this.richTextBoxView = new System.Windows.Forms.RichTextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCacheOk = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBarStart
            // 
            this.progressBarStart.Location = new System.Drawing.Point(12, 240);
            this.progressBarStart.Name = "progressBarStart";
            this.progressBarStart.Size = new System.Drawing.Size(354, 23);
            this.progressBarStart.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarStart.TabIndex = 1;
            // 
            // richTextBoxView
            // 
            this.richTextBoxView.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBoxView.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBoxView.Location = new System.Drawing.Point(12, 13);
            this.richTextBoxView.Name = "richTextBoxView";
            this.richTextBoxView.ReadOnly = true;
            this.richTextBoxView.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxView.Size = new System.Drawing.Size(354, 150);
            this.richTextBoxView.TabIndex = 2;
            this.richTextBoxView.Text = "";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(12, 184);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(172, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(199, 169);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCacheOk
            // 
            this.buttonCacheOk.Location = new System.Drawing.Point(199, 198);
            this.buttonCacheOk.Name = "buttonCacheOk";
            this.buttonCacheOk.Size = new System.Drawing.Size(75, 23);
            this.buttonCacheOk.TabIndex = 5;
            this.buttonCacheOk.Text = "Cache";
            this.buttonCacheOk.UseVisualStyleBackColor = true;
            this.buttonCacheOk.Click += new System.EventHandler(this.buttonCacheOk_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(291, 184);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Visible = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Automount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 275);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonCacheOk);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.richTextBoxView);
            this.Controls.Add(this.progressBarStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Automount";
            this.Text = "Start";
            this.Shown += new System.EventHandler(this.Start_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarStart;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCacheOk;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RichTextBox richTextBoxView;
        private System.Windows.Forms.Timer timer1;
    }
}