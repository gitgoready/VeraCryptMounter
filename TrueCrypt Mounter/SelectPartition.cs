using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    public partial class SelectPartition : Form
    {
        private WmiDriveInfo _wmidriveinfo;
        private static string[] _driveinfosnames = { "MediaType: ", "Model: ", "Serial: ", "Interface: ", "Partitions: ", "Index: ", "PNPDeviceID: " };
        private static string[] _partitioninfonames = { "Description: ", "DeviceId: ", "DiskIndex: ", "Index: ", "Name: ", "Size: ", "Type: " };
        //private Dictionary<string, List<DriveInfo>> dd;
        private NewDrive _root;
        private Dictionary<string, string> _drives;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public SelectPartition(NewDrive root)
        {
            InitializeComponent();
            _root = root;
            _wmidriveinfo = new WmiDriveInfo();
            _drives = _wmidriveinfo.GetDrives();
            int i = 0;
            foreach (var item in _drives.Keys)
            {
                comboBoxDisks.Items.Add(item.ToString());
                i++;
            }

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
                TreeNode[] partitionnodestree = { new TreeNode(_partitioninfonames[0] + part.Description),
                                        new TreeNode(_partitioninfonames[1] + part.DeviceId),
                                        new TreeNode(_partitioninfonames[2] + part.DiskIndex),
                                        new TreeNode(_partitioninfonames[3] + intpartindex.ToString()),
                                        new TreeNode(_partitioninfonames[4] + part.Name),
                                        new TreeNode(_partitioninfonames[5] + part.Size),
                                        new TreeNode(_partitioninfonames[6] + part.Type), };
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
            string pnpdid;
            _drives.TryGetValue(comboBoxDisks.Text, out pnpdid);
            string test = comboBoxDisks.Text;
            string tmp = test.Substring(0, test.Length - 3);
            List<DriveInfo> dlist = _wmidriveinfo.GetDriveinfo(pnpdid);

            DriveInfo info = dlist[0];
            string partnummber = comboBoxPartitions.SelectedItem.ToString();

            _root.Diskmodel = info.Model;
            _root.Disknummber = info.Index;
            _root.Diskserial = info.SerialNumber;
            _root.Partnummber = partnummber;
            _root.PNPDeviceID = info.PNPDeviceID;
            Close();
        }
    }
}
