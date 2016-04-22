using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    public partial class SelectPartition : Form
    {
        private readonly Config _config = new Config();
        private WmiDriveInfo _wmidriveinfo;
        private static string[] _driveinfosnames = { "MediaType: ", "Model: ", "Serial: ", "Interface: ", "Partitions: ", "Index: ", "PNPDeviceID: " };
        private static string[] _partitioninfonames = { "Description: ", "DeviceId: ", "DiskIndex: ", "Index: ", "Name: ", "Size: ", "Type: " };
        private Dictionary<string, string> _drives;
        private const string LanguageRegion = "SelectPartition";
        private readonly string _language;       

        public string _diskmodel { get; set; }
        public string _disknummber { get; set; }
        public string _diskserial { get; set; }
        public string _partnummber { get; set; }
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
            catch (Exception ex)
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
