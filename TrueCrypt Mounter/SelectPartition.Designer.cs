namespace TrueCrypt_Mounter
{
    partial class SelectPartition
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
            this.comboBoxDisks = new System.Windows.Forms.ComboBox();
            this.comboBoxPartitions = new System.Windows.Forms.ComboBox();
            this.treeViewInfos = new System.Windows.Forms.TreeView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelDisk = new System.Windows.Forms.Label();
            this.labelPartition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxDisks
            // 
            this.comboBoxDisks.FormattingEnabled = true;
            this.comboBoxDisks.Location = new System.Drawing.Point(12, 25);
            this.comboBoxDisks.Name = "comboBoxDisks";
            this.comboBoxDisks.Size = new System.Drawing.Size(268, 21);
            this.comboBoxDisks.TabIndex = 0;
            this.comboBoxDisks.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisks_SelectedIndexChanged);
            // 
            // comboBoxPartitions
            // 
            this.comboBoxPartitions.FormattingEnabled = true;
            this.comboBoxPartitions.Location = new System.Drawing.Point(12, 65);
            this.comboBoxPartitions.Name = "comboBoxPartitions";
            this.comboBoxPartitions.Size = new System.Drawing.Size(268, 21);
            this.comboBoxPartitions.TabIndex = 1;
            // 
            // treeViewInfos
            // 
            this.treeViewInfos.Location = new System.Drawing.Point(12, 149);
            this.treeViewInfos.Name = "treeViewInfos";
            this.treeViewInfos.Size = new System.Drawing.Size(268, 337);
            this.treeViewInfos.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(124, 492);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(205, 492);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // labelDisk
            // 
            this.labelDisk.AutoSize = true;
            this.labelDisk.Location = new System.Drawing.Point(12, 9);
            this.labelDisk.Name = "labelDisk";
            this.labelDisk.Size = new System.Drawing.Size(33, 13);
            this.labelDisk.TabIndex = 5;
            this.labelDisk.Text = "Disks";
            // 
            // labelPartition
            // 
            this.labelPartition.AutoSize = true;
            this.labelPartition.Location = new System.Drawing.Point(9, 49);
            this.labelPartition.Name = "labelPartition";
            this.labelPartition.Size = new System.Drawing.Size(50, 13);
            this.labelPartition.TabIndex = 6;
            this.labelPartition.Text = "Partitions";
            // 
            // SelectPartition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 575);
            this.Controls.Add(this.labelPartition);
            this.Controls.Add(this.labelDisk);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.treeViewInfos);
            this.Controls.Add(this.comboBoxPartitions);
            this.Controls.Add(this.comboBoxDisks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SelectPartition";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectPartition";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDisks;
        private System.Windows.Forms.ComboBox comboBoxPartitions;
        private System.Windows.Forms.TreeView treeViewInfos;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelDisk;
        private System.Windows.Forms.Label labelPartition;
    }
}