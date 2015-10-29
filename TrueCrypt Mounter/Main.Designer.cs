using System;
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    partial class TrueCryptMounter
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrueCryptMounter));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNewDrive = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEditDrive = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRemoveDrive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemNewContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEditContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRemoveContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMainSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.automountConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonMount = new System.Windows.Forms.Button();
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.buttonKeyfileContainerMount = new System.Windows.Forms.Button();
            this.checkBoxClearPassword = new System.Windows.Forms.CheckBox();
            this.progressBarMountDrive = new System.Windows.Forms.ProgressBar();
            this.labelNotification = new System.Windows.Forms.Label();
            this.buttonDismount = new System.Windows.Forms.Button();
            this.groupBoxDrive = new System.Windows.Forms.GroupBox();
            this.groupBoxNotification = new System.Windows.Forms.GroupBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemNotifyKeyfilecontainer = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNotifyMount = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNotifyDismount = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNotifyRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNotifyClose = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxKeyfileContainer = new System.Windows.Forms.GroupBox();
            this.buttonKeyfileContainerDismount = new System.Windows.Forms.Button();
            this.groupBoxContainer = new System.Windows.Forms.GroupBox();
            this.checkBoxClearPasswordContainer = new System.Windows.Forms.CheckBox();
            this.comboBoxContainer = new System.Windows.Forms.ComboBox();
            this.buttonDismountContainer = new System.Windows.Forms.Button();
            this.buttonMountContainer = new System.Windows.Forms.Button();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLabelNotification = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            this.groupBoxDrive.SuspendLayout();
            this.groupBoxNotification.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.groupBoxKeyfileContainer.SuspendLayout();
            this.groupBoxContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile,
            this.ToolStripMenuItemEdit,
            this.toolStripMenuItemSettings,
            this.ToolStripMenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(394, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemFile
            // 
            this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemClose});
            this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            this.ToolStripMenuItemFile.Size = new System.Drawing.Size(46, 20);
            this.ToolStripMenuItemFile.Text = "Datei";
            // 
            // ToolStripMenuItemClose
            // 
            this.ToolStripMenuItemClose.Name = "ToolStripMenuItemClose";
            this.ToolStripMenuItemClose.Size = new System.Drawing.Size(120, 22);
            this.ToolStripMenuItemClose.Text = "Beenden";
            this.ToolStripMenuItemClose.Click += new System.EventHandler(this.ToolStripMenuClose_Click);
            // 
            // ToolStripMenuItemEdit
            // 
            this.ToolStripMenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNewDrive,
            this.ToolStripMenuItemEditDrive,
            this.ToolStripMenuItemRemoveDrive,
            this.toolStripSeparator1,
            this.ToolStripMenuItemNewContainer,
            this.ToolStripMenuItemEditContainer,
            this.ToolStripMenuItemRemoveContainer});
            this.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            this.ToolStripMenuItemEdit.Size = new System.Drawing.Size(75, 20);
            this.ToolStripMenuItemEdit.Text = "Bearbeiten";
            // 
            // ToolStripMenuItemNewDrive
            // 
            this.ToolStripMenuItemNewDrive.Name = "ToolStripMenuItemNewDrive";
            this.ToolStripMenuItemNewDrive.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItemNewDrive.Text = "Neues Laufwerk";
            this.ToolStripMenuItemNewDrive.Click += new System.EventHandler(this.ToolStripMenuDriveNew_Click);
            // 
            // ToolStripMenuItemEditDrive
            // 
            this.ToolStripMenuItemEditDrive.Name = "ToolStripMenuItemEditDrive";
            this.ToolStripMenuItemEditDrive.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItemEditDrive.Text = "Laufwerk bearbeiten";
            this.ToolStripMenuItemEditDrive.Click += new System.EventHandler(this.ToolStripMenuDriveEdit_Click);
            // 
            // ToolStripMenuItemRemoveDrive
            // 
            this.ToolStripMenuItemRemoveDrive.Name = "ToolStripMenuItemRemoveDrive";
            this.ToolStripMenuItemRemoveDrive.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItemRemoveDrive.Text = "Laufwerk löschen";
            this.ToolStripMenuItemRemoveDrive.Click += new System.EventHandler(this.ToolStripMenuDriveDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // ToolStripMenuItemNewContainer
            // 
            this.ToolStripMenuItemNewContainer.Name = "ToolStripMenuItemNewContainer";
            this.ToolStripMenuItemNewContainer.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItemNewContainer.Text = "Neuen Kontainer";
            this.ToolStripMenuItemNewContainer.Click += new System.EventHandler(this.ToolStripMenuContainerNew_Click);
            // 
            // ToolStripMenuItemEditContainer
            // 
            this.ToolStripMenuItemEditContainer.Name = "ToolStripMenuItemEditContainer";
            this.ToolStripMenuItemEditContainer.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItemEditContainer.Text = "Kontainer bearbeiten";
            this.ToolStripMenuItemEditContainer.Click += new System.EventHandler(this.ToolStripMenuContainerEdit_Click);
            // 
            // ToolStripMenuItemRemoveContainer
            // 
            this.ToolStripMenuItemRemoveContainer.Name = "ToolStripMenuItemRemoveContainer";
            this.ToolStripMenuItemRemoveContainer.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItemRemoveContainer.Text = "Kontainer löschen";
            this.ToolStripMenuItemRemoveContainer.Click += new System.EventHandler(this.ToolStripMenuContainerDelete_Click);
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMainSettings,
            this.automountConfigToolStripMenuItem});
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Size = new System.Drawing.Size(90, 20);
            this.toolStripMenuItemSettings.Text = "Einstellungen";
            // 
            // ToolStripMenuItemMainSettings
            // 
            this.ToolStripMenuItemMainSettings.Name = "ToolStripMenuItemMainSettings";
            this.ToolStripMenuItemMainSettings.Size = new System.Drawing.Size(178, 22);
            this.ToolStripMenuItemMainSettings.Text = "Grundeinstellungen";
            this.ToolStripMenuItemMainSettings.Click += new System.EventHandler(this.ToolStripMenuMainconfig_Click);
            // 
            // automountConfigToolStripMenuItem
            // 
            this.automountConfigToolStripMenuItem.Name = "automountConfigToolStripMenuItem";
            this.automountConfigToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.automountConfigToolStripMenuItem.Text = "Automount config";
            this.automountConfigToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuAutomountConfig_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuVersion});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.ToolStripMenuItemHelp.Text = "Hilfe";
            // 
            // toolStripMenuVersion
            // 
            this.toolStripMenuVersion.Name = "toolStripMenuVersion";
            this.toolStripMenuVersion.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuVersion.Text = "Version";
            this.toolStripMenuVersion.Click += new System.EventHandler(this.ToolStripMenuVersion_Click);
            // 
            // buttonMount
            // 
            this.buttonMount.Location = new System.Drawing.Point(271, 20);
            this.buttonMount.Name = "buttonMount";
            this.buttonMount.Size = new System.Drawing.Size(100, 23);
            this.buttonMount.TabIndex = 3;
            this.buttonMount.Text = "Mount";
            this.buttonMount.UseVisualStyleBackColor = true;
            this.buttonMount.Click += new System.EventHandler(this.ButtonMountDrive_Click);
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(4, 22);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(261, 21);
            this.comboBoxDrives.TabIndex = 1;
            this.comboBoxDrives.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_Laufwerke_DrawItem);
            this.comboBoxDrives.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ComboBox_Laufwerke_MeasureItem);
            // 
            // buttonKeyfileContainerMount
            // 
            this.buttonKeyfileContainerMount.Location = new System.Drawing.Point(19, 16);
            this.buttonKeyfileContainerMount.Name = "buttonKeyfileContainerMount";
            this.buttonKeyfileContainerMount.Size = new System.Drawing.Size(168, 24);
            this.buttonKeyfileContainerMount.TabIndex = 11;
            this.buttonKeyfileContainerMount.Text = "Keyfile Kontainer Mount";
            this.buttonKeyfileContainerMount.UseVisualStyleBackColor = true;
            this.buttonKeyfileContainerMount.Click += new System.EventHandler(this.ButtonKeyfileContainerMount_Click);
            // 
            // checkBoxClearPassword
            // 
            this.checkBoxClearPassword.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxClearPassword.AutoSize = true;
            this.checkBoxClearPassword.Location = new System.Drawing.Point(6, 49);
            this.checkBoxClearPassword.Name = "checkBoxClearPassword";
            this.checkBoxClearPassword.Size = new System.Drawing.Size(140, 23);
            this.checkBoxClearPassword.TabIndex = 2;
            this.checkBoxClearPassword.Text = "Passwortspeicher löschen";
            this.checkBoxClearPassword.UseVisualStyleBackColor = true;
            // 
            // progressBarMountDrive
            // 
            this.progressBarMountDrive.Location = new System.Drawing.Point(4, 19);
            this.progressBarMountDrive.MarqueeAnimationSpeed = 0;
            this.progressBarMountDrive.Name = "progressBarMountDrive";
            this.progressBarMountDrive.Size = new System.Drawing.Size(367, 21);
            this.progressBarMountDrive.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarMountDrive.TabIndex = 15;
            this.progressBarMountDrive.Visible = false;
            // 
            // labelNotification
            // 
            this.labelNotification.AutoSize = true;
            this.labelNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotification.Location = new System.Drawing.Point(11, 23);
            this.labelNotification.Name = "labelNotification";
            this.labelNotification.Size = new System.Drawing.Size(96, 17);
            this.labelNotification.TabIndex = 16;
            this.labelNotification.Text = "statusanzeige";
            this.labelNotification.Visible = false;
            // 
            // buttonDismount
            // 
            this.buttonDismount.Location = new System.Drawing.Point(271, 50);
            this.buttonDismount.Name = "buttonDismount";
            this.buttonDismount.Size = new System.Drawing.Size(100, 23);
            this.buttonDismount.TabIndex = 4;
            this.buttonDismount.Text = "Dismount";
            this.buttonDismount.UseVisualStyleBackColor = true;
            this.buttonDismount.Click += new System.EventHandler(this.ButtonDismountDrive_Click);
            // 
            // groupBoxDrive
            // 
            this.groupBoxDrive.Controls.Add(this.buttonDismount);
            this.groupBoxDrive.Controls.Add(this.comboBoxDrives);
            this.groupBoxDrive.Controls.Add(this.checkBoxClearPassword);
            this.groupBoxDrive.Controls.Add(this.buttonMount);
            this.groupBoxDrive.Location = new System.Drawing.Point(7, 24);
            this.groupBoxDrive.Name = "groupBoxDrive";
            this.groupBoxDrive.Size = new System.Drawing.Size(380, 81);
            this.groupBoxDrive.TabIndex = 0;
            this.groupBoxDrive.TabStop = false;
            this.groupBoxDrive.Text = "Laufwerksauswahl";
            // 
            // groupBoxNotification
            // 
            this.groupBoxNotification.Controls.Add(this.labelNotification);
            this.groupBoxNotification.Controls.Add(this.progressBarMountDrive);
            this.groupBoxNotification.Location = new System.Drawing.Point(7, 250);
            this.groupBoxNotification.Name = "groupBoxNotification";
            this.groupBoxNotification.Size = new System.Drawing.Size(380, 58);
            this.groupBoxNotification.TabIndex = 13;
            this.groupBoxNotification.TabStop = false;
            this.groupBoxNotification.Text = "Statusanzeige";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "TrueCrypt Mounter";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNotifyKeyfilecontainer,
            this.ToolStripMenuItemNotifyRestore,
            this.ToolStripMenuItemNotifyClose});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(160, 70);
            // 
            // ToolStripMenuItemNotifyKeyfilecontainer
            // 
            this.ToolStripMenuItemNotifyKeyfilecontainer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNotifyMount,
            this.ToolStripMenuItemNotifyDismount});
            this.ToolStripMenuItemNotifyKeyfilecontainer.Name = "ToolStripMenuItemNotifyKeyfilecontainer";
            this.ToolStripMenuItemNotifyKeyfilecontainer.Size = new System.Drawing.Size(159, 22);
            this.ToolStripMenuItemNotifyKeyfilecontainer.Text = "Keyfilecontainer";
            // 
            // ToolStripMenuItemNotifyMount
            // 
            this.ToolStripMenuItemNotifyMount.Name = "ToolStripMenuItemNotifyMount";
            this.ToolStripMenuItemNotifyMount.Size = new System.Drawing.Size(126, 22);
            this.ToolStripMenuItemNotifyMount.Text = "Mount";
            this.ToolStripMenuItemNotifyMount.Click += new System.EventHandler(this.ButtonKeyfileContainerMount_Click);
            // 
            // ToolStripMenuItemNotifyDismount
            // 
            this.ToolStripMenuItemNotifyDismount.Name = "ToolStripMenuItemNotifyDismount";
            this.ToolStripMenuItemNotifyDismount.Size = new System.Drawing.Size(126, 22);
            this.ToolStripMenuItemNotifyDismount.Text = "Dismount";
            this.ToolStripMenuItemNotifyDismount.Click += new System.EventHandler(this.ButtonKeyfileContainerDismount_Click);
            // 
            // ToolStripMenuItemNotifyRestore
            // 
            this.ToolStripMenuItemNotifyRestore.Name = "ToolStripMenuItemNotifyRestore";
            this.ToolStripMenuItemNotifyRestore.Size = new System.Drawing.Size(159, 22);
            this.ToolStripMenuItemNotifyRestore.Text = "Restore";
            this.ToolStripMenuItemNotifyRestore.Click += new System.EventHandler(this.ContextMenuRestore_Click);
            // 
            // ToolStripMenuItemNotifyClose
            // 
            this.ToolStripMenuItemNotifyClose.Name = "ToolStripMenuItemNotifyClose";
            this.ToolStripMenuItemNotifyClose.Size = new System.Drawing.Size(159, 22);
            this.ToolStripMenuItemNotifyClose.Text = "Close";
            this.ToolStripMenuItemNotifyClose.Click += new System.EventHandler(this.ContextMenuClose_Click);
            // 
            // groupBoxKeyfileContainer
            // 
            this.groupBoxKeyfileContainer.Controls.Add(this.buttonKeyfileContainerDismount);
            this.groupBoxKeyfileContainer.Controls.Add(this.buttonKeyfileContainerMount);
            this.groupBoxKeyfileContainer.Location = new System.Drawing.Point(7, 192);
            this.groupBoxKeyfileContainer.Name = "groupBoxKeyfileContainer";
            this.groupBoxKeyfileContainer.Size = new System.Drawing.Size(380, 52);
            this.groupBoxKeyfileContainer.TabIndex = 10;
            this.groupBoxKeyfileContainer.TabStop = false;
            // 
            // buttonKeyfileContainerDismount
            // 
            this.buttonKeyfileContainerDismount.Location = new System.Drawing.Point(193, 16);
            this.buttonKeyfileContainerDismount.Name = "buttonKeyfileContainerDismount";
            this.buttonKeyfileContainerDismount.Size = new System.Drawing.Size(168, 24);
            this.buttonKeyfileContainerDismount.TabIndex = 12;
            this.buttonKeyfileContainerDismount.Text = "Keyfile Kontainer Dismount";
            this.buttonKeyfileContainerDismount.UseVisualStyleBackColor = true;
            this.buttonKeyfileContainerDismount.Click += new System.EventHandler(this.ButtonKeyfileContainerDismount_Click);
            // 
            // groupBoxContainer
            // 
            this.groupBoxContainer.Controls.Add(this.checkBoxClearPasswordContainer);
            this.groupBoxContainer.Controls.Add(this.comboBoxContainer);
            this.groupBoxContainer.Controls.Add(this.buttonDismountContainer);
            this.groupBoxContainer.Controls.Add(this.buttonMountContainer);
            this.groupBoxContainer.Location = new System.Drawing.Point(7, 105);
            this.groupBoxContainer.Name = "groupBoxContainer";
            this.groupBoxContainer.Size = new System.Drawing.Size(380, 81);
            this.groupBoxContainer.TabIndex = 5;
            this.groupBoxContainer.TabStop = false;
            this.groupBoxContainer.Text = "Kontainerauswahl";
            // 
            // checkBoxClearPasswordContainer
            // 
            this.checkBoxClearPasswordContainer.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxClearPasswordContainer.AutoSize = true;
            this.checkBoxClearPasswordContainer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxClearPasswordContainer.Location = new System.Drawing.Point(6, 49);
            this.checkBoxClearPasswordContainer.Name = "checkBoxClearPasswordContainer";
            this.checkBoxClearPasswordContainer.Size = new System.Drawing.Size(140, 23);
            this.checkBoxClearPasswordContainer.TabIndex = 7;
            this.checkBoxClearPasswordContainer.Text = "Passwortspeicher löschen";
            this.checkBoxClearPasswordContainer.UseVisualStyleBackColor = true;
            // 
            // comboBoxContainer
            // 
            this.comboBoxContainer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxContainer.FormattingEnabled = true;
            this.comboBoxContainer.Location = new System.Drawing.Point(4, 22);
            this.comboBoxContainer.Name = "comboBoxContainer";
            this.comboBoxContainer.Size = new System.Drawing.Size(261, 21);
            this.comboBoxContainer.TabIndex = 6;
            this.comboBoxContainer.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxKontainerDrawItem);
            this.comboBoxContainer.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ComboBoxKontainer_MeasureItem);
            // 
            // buttonDismountContainer
            // 
            this.buttonDismountContainer.Location = new System.Drawing.Point(271, 48);
            this.buttonDismountContainer.Name = "buttonDismountContainer";
            this.buttonDismountContainer.Size = new System.Drawing.Size(100, 23);
            this.buttonDismountContainer.TabIndex = 9;
            this.buttonDismountContainer.Text = "Dismount";
            this.buttonDismountContainer.UseVisualStyleBackColor = true;
            this.buttonDismountContainer.Click += new System.EventHandler(this.ButtonDismountContainer_Click);
            // 
            // buttonMountContainer
            // 
            this.buttonMountContainer.Location = new System.Drawing.Point(271, 19);
            this.buttonMountContainer.Name = "buttonMountContainer";
            this.buttonMountContainer.Size = new System.Drawing.Size(100, 23);
            this.buttonMountContainer.TabIndex = 8;
            this.buttonMountContainer.Text = "Mount";
            this.buttonMountContainer.UseVisualStyleBackColor = true;
            this.buttonMountContainer.Click += new System.EventHandler(this.ButtonMountContainer_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelNotification,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 315);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(394, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripLabelNotification
            // 
            this.toolStripLabelNotification.Name = "toolStripLabelNotification";
            this.toolStripLabelNotification.Size = new System.Drawing.Size(118, 17);
            this.toolStripLabelNotification.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // TrueCryptMounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 337);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxContainer);
            this.Controls.Add(this.groupBoxDrive);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBoxKeyfileContainer);
            this.Controls.Add(this.groupBoxNotification);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "TrueCryptMounter";
            this.Text = "TruecryptMounter";
            this.Load += new System.EventHandler(this.TrueCryptMounter_Load);
            this.Resize += new System.EventHandler(this.TrueCryptMounter_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxDrive.ResumeLayout(false);
            this.groupBoxDrive.PerformLayout();
            this.groupBoxNotification.ResumeLayout(false);
            this.groupBoxNotification.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBoxKeyfileContainer.ResumeLayout(false);
            this.groupBoxContainer.ResumeLayout(false);
            this.groupBoxContainer.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClose;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMainSettings;
        private Button buttonMount;
        private ComboBox comboBoxDrives;
        private Button buttonKeyfileContainerMount;
        private ToolStripMenuItem ToolStripMenuItemHelp;
        private ToolStripMenuItem toolStripMenuVersion;
        private CheckBox checkBoxClearPassword;
        private ToolStripMenuItem ToolStripMenuItemEdit;
        private ToolStripMenuItem ToolStripMenuItemEditDrive;
        private ToolStripMenuItem ToolStripMenuItemNewDrive;
        private ProgressBar progressBarMountDrive;
        private Label labelNotification;
        private Button buttonDismount;
        private GroupBox groupBoxDrive;
        private GroupBox groupBoxNotification;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem ToolStripMenuItemNotifyRestore;
        private ToolStripMenuItem ToolStripMenuItemNotifyClose;
        private ToolStripMenuItem ToolStripMenuItemRemoveDrive;
        private GroupBox groupBoxKeyfileContainer;
        private Button buttonKeyfileContainerDismount;
        private GroupBox groupBoxContainer;
        private ComboBox comboBoxContainer;
        private Button buttonDismountContainer;
        private Button buttonMountContainer;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ToolStripMenuItemNewContainer;
        private ToolStripMenuItem ToolStripMenuItemEditContainer;
        private ToolStripMenuItem ToolStripMenuItemRemoveContainer;
        private ToolStripMenuItem ToolStripMenuItemNotifyKeyfilecontainer;
        private ToolStripMenuItem ToolStripMenuItemNotifyMount;
        private ToolStripMenuItem ToolStripMenuItemNotifyDismount;
        private ToolTip toolTipMain;
        private CheckBox checkBoxClearPasswordContainer;
        private ToolStripMenuItem automountConfigToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripLabelNotification;
        private ToolStripProgressBar toolStripProgressBar;
    }
}

