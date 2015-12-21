using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    public partial class SelectPartition : Form
    {
        private WmiDriveInfo _wmidriveinfo;
        private static string[] _driveinfosnames = { "MediaType: ", "Model: ", "Serial: ", "Interface: ", "Partitions: ", "Index: " };
        private static string[] _partitioninfonames = { "Description: ", "DeviceId: ", "DiskIndex: ", "Index: ", "Name: ", "Size: ", "Type: " };
        private NewDrive _root;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public SelectPartition(NewDrive root)
        {
            InitializeComponent();
            _root = root;
            _wmidriveinfo = new WmiDriveInfo();
            List<string> drives = _wmidriveinfo.GetDrives();
            drives.ForEach(delegate (string name)
            {
                comboBoxDisks.Items.Add(name);
            });

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxDisks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO Wenn mehr als ein laufwerk mit dem selben namen da ist dies anzeigen

            List<DriveInfo> driveinfo = _wmidriveinfo.GetDriveinfo(comboBoxDisks.SelectedItem.ToString());
            comboBoxPartitions.Items.Clear();
            treeViewInfos.Nodes.Clear();
            TreeNode[] drivenodestree = new TreeNode[6];
            var i = 0;
            foreach (Partition part in _wmidriveinfo.PartitonInfos)
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
                treeViewInfos.Nodes.Add(new TreeNode ("Partition" + intpartindex.ToString(), partitionnodestree));
            }
            foreach (var info in _wmidriveinfo.DriveInfos)
            {

                drivenodestree.SetValue(new TreeNode (_driveinfosnames[i] + info[0] ), i);
                i++;
 
            }
            treeViewInfos.Nodes.Add(new TreeNode ("Drive", drivenodestree));
        }

        private void SelectPartition_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBoxPartitions.Dispose();
            comboBoxDisks.Dispose();
            treeViewInfos.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _wmidriveinfo.Driveinfo(comboBoxDisks.SelectedItem.ToString());
            string partnummber = comboBoxPartitions.SelectedItem.ToString();

            _root.Diskmodel =_wmidriveinfo.Model[0];
            _root.Disknummber = _wmidriveinfo.Index[0];
            _root.Diskserial = _wmidriveinfo.Serial[0];
            _root.Partnummber = partnummber;
            Close();
        }
    }
}
