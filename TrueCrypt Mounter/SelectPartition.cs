using System;
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{
    public partial class SelectPartition : Form
    {
        private WmiDriveInfo _driveInfo;
        
        public SelectPartition()
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
            foreach (Partition part in _driveInfo.PartitonInfos)
            {
                comboBoxPartitions.Items.Add(part.DeviceId);
            }
        }
    }
}
