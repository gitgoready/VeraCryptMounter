/***
 * <VeraCryptMounter. Programm to use Truecrypt drives and containers easier.>
 * Copyright (C) <2009>  <Rafael Grothmann>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * **/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Form for selecting Partiton 
    /// </summary>
    public partial class SelectPartition : Form
    {
        private readonly Config _config = new Config();
        private WmiDriveInfo _wmidriveinfo;
        private static string[] _driveinfosnames = { "MediaType: ", "Model: ", "Serial: ", "Interface: ", "Partitions: ", "Index: ", "PNPDeviceID: " };
        private static string[] _partitioninfonames = { "Description: ", "DeviceId: ", "DiskIndex: ", "Index: ", "Name: ", "Size: ", "Type: " };
        private Dictionary<string, string> _drives;
        private const string LanguageRegion = "SelectPartition";
        private readonly string _language;       

        /// <summary>
        /// Modelstring
        /// </summary>
        public string _diskmodel { get; set; }
        /// <summary>
        /// Number of disk in System
        /// </summary>
        public string _disknummber { get; set; }
        /// <summary>
        /// serialnumber of disk
        /// </summary>
        public string _diskserial { get; set; }
        /// <summary>
        /// Partitionumber
        /// </summary>
        public string _partnummber { get; set; }
        /// <summary>
        /// PNPDeviceID
        /// </summary>
        public string _pNPDeviceID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SelectPartition()
        {
            InitializeComponent();
            _config = Singleton<ConfigManager>.Instance.Init(_config);
            _language = _config.GetValue(ConfigTrm.Mainconfig.Section, ConfigTrm.Mainconfig.Language, "");
            _wmidriveinfo = new WmiDriveInfo();
            _drives = _wmidriveinfo.GetDrives();
            int i = 0;
            foreach (var item in _drives.Keys)
            {
                comboBoxDisks.Items.Add(item.ToString());
                i++;
            }
            LanguageFill();

        }

        private void LanguageFill()
        {
            buttonOK.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonOK", _language);
            buttonCancel.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "buttonCancel", _language);
            labelDisk.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "labelDisk", _language);
            labelPartition.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "labelPartition", _language);
            this.Text = LanguagePool.GetInstance().GetString(LanguageRegion, "SelectPartition", _language);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxDisks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pnpdid;
            _drives.TryGetValue(comboBoxDisks.Text, out pnpdid);

            string test = comboBoxDisks.Text;
            string tmp = test.Substring(0, test.Length - 3);

            List<DriveInfo> driveinfo = _wmidriveinfo.GetDriveinfo(pnpdid);
            string index = driveinfo[0].Index;
            comboBoxPartitions.Items.Clear();
            treeViewInfos.Nodes.Clear();

            TreeNode[] drivenodestree = new TreeNode[7];

            var i = 0;
            foreach (Partition part in _wmidriveinfo.GetPartitionInfo(index))
            {

                int intpartindex = int.Parse(part.Index) + 1;
                comboBoxPartitions.Items.Add(intpartindex.ToString());
                string dletter = _wmidriveinfo.GetDriveLetter(pnpdid, part.Index);
                TreeNode[] partitionnodestree = { new TreeNode(_partitioninfonames[0] + part.Description),
                                        new TreeNode(_partitioninfonames[1] + part.DeviceId),
                                        new TreeNode(_partitioninfonames[2] + part.DiskIndex),
                                        new TreeNode(_partitioninfonames[3] + intpartindex.ToString()),
                                        new TreeNode(_partitioninfonames[4] + part.Name),
                                        new TreeNode(_partitioninfonames[5] + part.Size),
                                        new TreeNode(_partitioninfonames[6] + part.Type),
                                        new TreeNode("Driveletter: " + dletter),};
                treeViewInfos.Nodes.Add(new TreeNode("Partition" + intpartindex.ToString(), partitionnodestree));
            }
            foreach (var info in _wmidriveinfo.GetDriveinfo(pnpdid))
            {
                foreach (var infovalue in info)
                {
                    drivenodestree.SetValue(new TreeNode(_driveinfosnames[i] + infovalue), i);
                    i++;
                }
                
            }
            treeViewInfos.Nodes.Add(new TreeNode("Drive", drivenodestree));
        }

        private void SelectPartition_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBoxPartitions.Dispose();
            comboBoxDisks.Dispose();
            treeViewInfos.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //TODO Fehlerbahandlung

            string pnpdid;
            string partnummber;
  
            try
            {
                _drives.TryGetValue(comboBoxDisks.Text, out pnpdid);
                partnummber = comboBoxPartitions.SelectedItem.ToString();
            }
            catch (Exception)
            {
                DialogResult res = MessageBox.Show(LanguagePool.GetInstance().GetString(LanguageRegion, "MessageSelectPartition", _language), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DriveInfo> dlist = _wmidriveinfo.GetDriveinfo(pnpdid);
            DriveInfo info = dlist[0];

            _diskmodel = info.Model;
            _disknummber = info.Index;
            _diskserial = info.SerialNumber;
            _partnummber = partnummber;
            _pNPDeviceID = info.PNPDeviceID;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
