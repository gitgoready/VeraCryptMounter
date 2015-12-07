namespace VeraCrypt_Mounter
{
    partial class AutomountConfig
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
            this.checkBoxUseAutomount = new System.Windows.Forms.CheckBox();
            this.groupBoxUsbAutomount = new System.Windows.Forms.GroupBox();
            this.checkBoxContainer = new System.Windows.Forms.CheckBox();
            this.checkBoxDrives = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUsbAutomount = new System.Windows.Forms.TabPage();
            this.tabPageStartAutomount = new System.Windows.Forms.TabPage();
            this.groupBoxStartAutomount = new System.Windows.Forms.GroupBox();
            this.checkBoxSartContainer = new System.Windows.Forms.CheckBox();
            this.checkBoxStartDrives = new System.Windows.Forms.CheckBox();
            this.checkBoxUseStartAutomount = new System.Windows.Forms.CheckBox();
            this.groupBoxUsbAutomount.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageUsbAutomount.SuspendLayout();
            this.tabPageStartAutomount.SuspendLayout();
            this.groupBoxStartAutomount.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxUseAutomount
            // 
            this.checkBoxUseAutomount.AutoSize = true;
            this.checkBoxUseAutomount.Location = new System.Drawing.Point(6, 6);
            this.checkBoxUseAutomount.Name = "checkBoxUseAutomount";
            this.checkBoxUseAutomount.Size = new System.Drawing.Size(121, 17);
            this.checkBoxUseAutomount.TabIndex = 0;
            this.checkBoxUseAutomount.Text = "Use Usb Automount";
            this.checkBoxUseAutomount.UseVisualStyleBackColor = true;
            this.checkBoxUseAutomount.CheckedChanged += new System.EventHandler(this.checkBoxUseAutomount_CheckedChanged);
            // 
            // groupBoxUsbAutomount
            // 
            this.groupBoxUsbAutomount.Controls.Add(this.checkBoxContainer);
            this.groupBoxUsbAutomount.Controls.Add(this.checkBoxDrives);
            this.groupBoxUsbAutomount.Location = new System.Drawing.Point(6, 29);
            this.groupBoxUsbAutomount.Name = "groupBoxUsbAutomount";
            this.groupBoxUsbAutomount.Size = new System.Drawing.Size(213, 83);
            this.groupBoxUsbAutomount.TabIndex = 1;
            this.groupBoxUsbAutomount.TabStop = false;
            this.groupBoxUsbAutomount.Text = "Usb Automount settings";
            // 
            // checkBoxContainer
            // 
            this.checkBoxContainer.AutoSize = true;
            this.checkBoxContainer.Location = new System.Drawing.Point(7, 51);
            this.checkBoxContainer.Name = "checkBoxContainer";
            this.checkBoxContainer.Size = new System.Drawing.Size(127, 17);
            this.checkBoxContainer.TabIndex = 1;
            this.checkBoxContainer.Text = "Mount container auto";
            this.checkBoxContainer.UseVisualStyleBackColor = true;
            // 
            // checkBoxDrives
            // 
            this.checkBoxDrives.AutoSize = true;
            this.checkBoxDrives.Location = new System.Drawing.Point(7, 28);
            this.checkBoxDrives.Name = "checkBoxDrives";
            this.checkBoxDrives.Size = new System.Drawing.Size(111, 17);
            this.checkBoxDrives.TabIndex = 0;
            this.checkBoxDrives.Text = "Mount drives auto";
            this.checkBoxDrives.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(37, 162);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(130, 161);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageUsbAutomount);
            this.tabControl1.Controls.Add(this.tabPageStartAutomount);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(233, 155);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageUsbAutomount
            // 
            this.tabPageUsbAutomount.Controls.Add(this.checkBoxUseAutomount);
            this.tabPageUsbAutomount.Controls.Add(this.groupBoxUsbAutomount);
            this.tabPageUsbAutomount.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsbAutomount.Name = "tabPageUsbAutomount";
            this.tabPageUsbAutomount.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsbAutomount.Size = new System.Drawing.Size(225, 129);
            this.tabPageUsbAutomount.TabIndex = 0;
            this.tabPageUsbAutomount.Text = "Usb Automount";
            this.tabPageUsbAutomount.UseVisualStyleBackColor = true;
            // 
            // tabPageStartAutomount
            // 
            this.tabPageStartAutomount.Controls.Add(this.groupBoxStartAutomount);
            this.tabPageStartAutomount.Controls.Add(this.checkBoxUseStartAutomount);
            this.tabPageStartAutomount.Location = new System.Drawing.Point(4, 22);
            this.tabPageStartAutomount.Name = "tabPageStartAutomount";
            this.tabPageStartAutomount.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStartAutomount.Size = new System.Drawing.Size(225, 129);
            this.tabPageStartAutomount.TabIndex = 1;
            this.tabPageStartAutomount.Text = "Start Automount";
            this.tabPageStartAutomount.UseVisualStyleBackColor = true;
            // 
            // groupBoxStartAutomount
            // 
            this.groupBoxStartAutomount.Controls.Add(this.checkBoxSartContainer);
            this.groupBoxStartAutomount.Controls.Add(this.checkBoxStartDrives);
            this.groupBoxStartAutomount.Location = new System.Drawing.Point(6, 29);
            this.groupBoxStartAutomount.Name = "groupBoxStartAutomount";
            this.groupBoxStartAutomount.Size = new System.Drawing.Size(213, 82);
            this.groupBoxStartAutomount.TabIndex = 1;
            this.groupBoxStartAutomount.TabStop = false;
            this.groupBoxStartAutomount.Text = "Start Automount settings";
            // 
            // checkBoxSartContainer
            // 
            this.checkBoxSartContainer.AutoSize = true;
            this.checkBoxSartContainer.Location = new System.Drawing.Point(6, 50);
            this.checkBoxSartContainer.Name = "checkBoxSartContainer";
            this.checkBoxSartContainer.Size = new System.Drawing.Size(153, 17);
            this.checkBoxSartContainer.TabIndex = 1;
            this.checkBoxSartContainer.Text = "Mount Container automatic";
            this.checkBoxSartContainer.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartDrives
            // 
            this.checkBoxStartDrives.AutoSize = true;
            this.checkBoxStartDrives.Location = new System.Drawing.Point(6, 27);
            this.checkBoxStartDrives.Name = "checkBoxStartDrives";
            this.checkBoxStartDrives.Size = new System.Drawing.Size(138, 17);
            this.checkBoxStartDrives.TabIndex = 0;
            this.checkBoxStartDrives.Text = "Mount Drives automatic";
            this.checkBoxStartDrives.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseStartAutomount
            // 
            this.checkBoxUseStartAutomount.AutoSize = true;
            this.checkBoxUseStartAutomount.Location = new System.Drawing.Point(6, 6);
            this.checkBoxUseStartAutomount.Name = "checkBoxUseStartAutomount";
            this.checkBoxUseStartAutomount.Size = new System.Drawing.Size(124, 17);
            this.checkBoxUseStartAutomount.TabIndex = 0;
            this.checkBoxUseStartAutomount.Text = "Use Start Automount";
            this.checkBoxUseStartAutomount.UseVisualStyleBackColor = true;
            this.checkBoxUseStartAutomount.CheckedChanged += new System.EventHandler(this.checkBoxUseStartAutomount_CheckedChanged);
            // 
            // AutomountConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 194);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AutomountConfig";
            this.Text = "AutomountConfig";
            this.Load += new System.EventHandler(this.AutomountConfig_Load);
            this.groupBoxUsbAutomount.ResumeLayout(false);
            this.groupBoxUsbAutomount.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageUsbAutomount.ResumeLayout(false);
            this.tabPageUsbAutomount.PerformLayout();
            this.tabPageStartAutomount.ResumeLayout(false);
            this.tabPageStartAutomount.PerformLayout();
            this.groupBoxStartAutomount.ResumeLayout(false);
            this.groupBoxStartAutomount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxUseAutomount;
        private System.Windows.Forms.GroupBox groupBoxUsbAutomount;
        private System.Windows.Forms.CheckBox checkBoxContainer;
        private System.Windows.Forms.CheckBox checkBoxDrives;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUsbAutomount;
        private System.Windows.Forms.TabPage tabPageStartAutomount;
        private System.Windows.Forms.GroupBox groupBoxStartAutomount;
        private System.Windows.Forms.CheckBox checkBoxSartContainer;
        private System.Windows.Forms.CheckBox checkBoxStartDrives;
        private System.Windows.Forms.CheckBox checkBoxUseStartAutomount;
    }
}