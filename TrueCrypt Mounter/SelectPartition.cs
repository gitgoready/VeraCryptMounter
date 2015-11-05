using System;
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    public partial class SelectPartition : Form
    {
        private WmiDriveInfo _driveInfo;
        private static string[] _driveinfosnames = { "MediaType: ", "Model: ", "Serial: ", "Interface: ", "Partitions: ", "Index: " };
        private static string[] _partitioninfonames = { "Description: ", "DeviceId: ", "DiskIndex: ", "Index: ", "Name: ", "Size: ", "Type: " };
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public SelectPartition(object root)
        {
            InitializeComponent();
            _driveInfo = new WmiDriveInfo();

            foreach (string drive in _driveInfo.DriveList)
            {
                comboBoxDisks.Items.Add(drive);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void comboBoxDisks_SelectedIndexChanged(object sender, EventArgs e)
        {
            _driveInfo.Driveinfo(comboBoxDisks.SelectedItem.ToString());
            comboBoxPartitions.Items.Clear();
            treeViewInfos.Nodes.Clear();
            TreeNode[] drivenodestree = new TreeNode[6];
            var i = 0;
            foreach (Partition part in _driveInfo.PartitonInfos)
            {
                comboBoxPartitions.Items.Add(part.DeviceId);
                TreeNode[] partitionnodestree = { new TreeNode(_partitioninfonames[0] + part.Description),
                                        new TreeNode(_partitioninfonames[1] + part.DeviceId),
                                        new TreeNode(_partitioninfonames[2] + part.DiskIndex),
                                        new TreeNode(_partitioninfonames[3] + part.Index),
                                        new TreeNode(_partitioninfonames[4] + part.Name),
                                        new TreeNode(_partitioninfonames[5] + part.Size),
                                        new TreeNode(_partitioninfonames[6] + part.Type), };
                treeViewInfos.Nodes.Add(new TreeNode ("Partition" + part.Index, partitionnodestree));
            }
            foreach (var info in _driveInfo.DriveInfos)
            {

                drivenodestree.SetValue(new TreeNode (_driveinfosnames[i] + info ), i);
                i++;
 
            }
            treeViewInfos.Nodes.Add(new TreeNode ("Drive", drivenodestree));
        }

        private void SelectPartition_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBoxPartitions.Items.Clear();
            comboBoxDisks.Items.Clear();
            treeViewInfos.Nodes.Clear();
        }
    }
}
