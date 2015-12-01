using System;
using System.Collections.Generic;
using System.Management;

namespace TrueCrypt_Mounter
{
    class WmiDriveInfo
    {
        private readonly string[] _driveInfoNames = {"MediaType", "Model", "SerialNumber", "InterfaceType", "Partitions", "Index"};

        private readonly string[] _partitionInfoNames = {
                                                            "Description", "DeviceID", "DiskIndex", "Index", "Name", "Size"
                                                            , "Type"
                                                        };
        private string _mediaType;
        private string _model;
        private string _serial;
        private string _interface;
        private string _partitions;
        private string _index;
        private string _drive;
        private static List<string> _drives = new List<string>();
        private static List<Partition> _partitionInfos = new List<Partition>();
        private List<string> _driveInfos = new List<string>();

        /// <summary>
        /// Returns generic list (MediaType,model,serial,interface,partitions,index)
        /// </summary>
        public List<string> DriveInfos
        {
            get
            { 
                return _driveInfos;
            }
        }

        /// <summary>
        /// The name of the drive where the info is requested from.
        /// </summary>
        public string Drive
        {
            get
            {
                TestVariable(_drive);
                return _drive;
            }
        }

        /// <summary>
        /// The list of the drives.
        /// </summary>
        public List<string> DriveList
        {
            get { return _drives; }
        }
        /// <summary>
        /// Retrun a List of type Partition.
        /// </summary>
        public List<Partition> PartitonInfos
        {
            get
            {
                //TestVariable(_partitionInfos);
                return _partitionInfos;
            }
        }
        public string MediaType
        {
            get 
            {
                TestVariable(_mediaType);
                return _mediaType; 
            }
        }

        public string Model
        {
            get
            {
                //TestVariable(_model);
                return _model;
            }
        }

        public string Serial
        {
            get
            {
                //TestVariable(_serial);
                return _serial;
            }
        }

        public string Interface
        {
            get
            {
                //TestVariable(_interface);
                return _interface;
            }
        }

        public string Partitions
        {
            get
            {
                //TestVariable(_partitions);
                return _partitions;
            }
        }

        public string Index
        {
            get
            {
                //TestVariable(_index);
                return _index;
            }
        }

        public WmiDriveInfo()
        {
            GetDrives();
        }

        public void Refresh()
        {
            GetDrives();

            if (_drive != null)
            {
                if(_drives.Contains(_drive))
                {
                    Driveinfo(_drive);
                }
            }
        }

        private static void GetDrives()
        {
            // Get all the disk drives

            var mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            // Loop through each object (disk) retrieved by WMI

            foreach (ManagementObject moDisk in mosDisks.Get())
            {
                string drivename;
                // Add the HDD to the list (use the Model field as the item's caption)
                try
                {
                    drivename = moDisk["Model"].ToString();
                }
                catch (Exception ex)
                {              
                    throw new Exception("Error getting drivenames (" + ex.Message + ")");
                }
                if (!_drives.Contains(drivename))
                    _drives.Add(drivename);
            }
        }

        public void Driveinfo(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Variable is null or empty (Method: GetDriveinfo)");
            }
  
            _drive = name;
            ManagementObjectSearcher mosDisks;
            try
            {
                // Get all the disk drives from WMI that match the Model name
                mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE Model = '" + name + "'");

            }
            catch (Exception ex)
            {             
                throw new Exception("Error in GetDriveinfo (" + ex.Message + ")");
            }
         
            foreach (ManagementObject moDisk in mosDisks.Get())
            {
                FillDriveinfo(moDisk);
            }

            mosDisks.Dispose();
        }

        private void FillDriveinfo(ManagementObject moDisk)
        {
            object[] data = new object[6];
            for (int i = 0 ; i <= _driveInfoNames.Length-1 ; i++)
            {
                try
                {
                    data[i] = moDisk[_driveInfoNames[i]];
                    if (data[i] == null)
                    {
                        data[i] = "no value";
                    }
                }
                catch (Exception)
                {
                    data[i] = "no value";
                }

                switch (i)
                {
                    case 0:
                        _mediaType = data[i].ToString();
                        break;

                    case 1:
                        _model = data[i].ToString();
                        break;

                    case 2:
                        _serial = data[i].ToString();
                        break;

                    case 3:
                        _interface = data[i].ToString();
                        break;

                    case 4:
                        _partitions = data[i].ToString();
                        break;

                    case 5:
                        _index = data[i].ToString();
                        break;

                }
                
            }
            _driveInfos.Clear();
            _driveInfos.AddRange(new List<String> { _mediaType, _model, _serial, _interface, _partitions, _index });
            GetPartitionInfo();
        }

        private void GetPartitionInfo()
        {
            ManagementObjectSearcher mosPart;
            try
            {
                // Get all the Partitions that catch the diskindex
                mosPart =
                    new ManagementObjectSearcher("SELECT * FROM Win32_DiskPartition WHERE DiskIndex ='" + _index + "'");

            }
            catch (Exception ex)
            {

                throw new Exception("Error in GetPartitionInfo (" + ex.Message + ")");
            }
            _partitionInfos.Clear();
            foreach (ManagementObject moPart in mosPart.Get())
            {
                _partitionInfos.Add(FillPartitionInfo(moPart));              
            }
        }

        private Partition FillPartitionInfo(ManagementObject moPart)
        {
            Partition part = new Partition();
            for (int i = 0; i <= _partitionInfoNames.Length - 1; i++)
            {
                try
                {
                   switch (i)
                    {
                        case 0:
                            part.Description = moPart[_partitionInfoNames[i]].ToString();
                            break;
                        case 1:
                            part.DeviceId = moPart[_partitionInfoNames[i]].ToString();
                            break;
                        case 2:
                            part.DiskIndex = moPart[_partitionInfoNames[i]].ToString();
                            break;
                        case 3:
                            part.Index = moPart[_partitionInfoNames[i]].ToString();
                            break;
                        case 4:
                            part.Name = moPart[_partitionInfoNames[i]].ToString();
                            break;
                        case 5:
                            part.Size = moPart[_partitionInfoNames[i]].ToString();
                            break;
                        case 6:
                            part.Type = moPart[_partitionInfoNames[i]].ToString();
                            break;
                    }
                }
                catch (Exception)
                {
                    switch (i)
                    {
                        case 0:
                            part.Description = "no value";
                            break;
                        case 1:
                            part.DeviceId = "no value";
                            break;
                        case 2:
                            part.DiskIndex = "no value";
                            break;
                        case 3:
                            part.Index = "no value";
                            break;
                        case 4:
                            part.Name = "no value";
                            break;
                        case 5:
                            part.Size = "no value";
                            break;
                        case 6:
                            part.Type = "no value";
                            break;
                    }
                }            
            }
            return part;
        }

        private void TestVariable(string var)
        {
            if(string.IsNullOrEmpty(var))
            {
                throw new Exception("DriveInfo not initialized");
            }
        }
    }

    class Partition
    {
        private string _description;
        private string _deviceId;
        private string _diskIndex;
        private string _index;
        private string _name;
        private string _size;
        private string _type;

        public string DeviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        public string DiskIndex
        {
            get { return _diskIndex; }
            set { _diskIndex = value; }
        }

        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
