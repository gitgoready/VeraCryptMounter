using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace VeraCrypt_Mounter
{
    class WmiDriveInfo
    {
        private readonly string[] _driveInfoNames = {"MediaType", "Model", "SerialNumber", "InterfaceType", "Partitions", "Index", "DeviceID", "PNPDeviceID", "Name", "CreationClassName" };

        private readonly string[] _partitionInfoNames = {
                                                            "Description", "DeviceID", "DiskIndex", "Index", "Name", "Size"
                                                            , "Type"
                                                        };

        public Dictionary<string, string> GetDrives()
        {
            Dictionary<string, string> ddrives = new Dictionary<string, string>();

            // Get all the disk drives

            var mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            // Loop through each object (disk) retrieved by WMI

            foreach (ManagementObject moDisk in mosDisks.Get())
            {
                string drivename;
                string index;
                // Add the HDD to the list (use the Model field as the item's caption)
                try
                {
                    drivename = moDisk["Model"].ToString();
                    index = moDisk["Index"].ToString();
                }
                catch (Exception ex)
                {              
                    throw new Exception("Error getting drivenames (" + ex.Message + ")");
                }

                ddrives.Add(index, drivename);
            }
            return ddrives;
        }
        /// <summary>
        /// Get info for requested drivename.
        /// </summary>
        /// <param name="name">name from GetDrives</param>
        /// <param name="index">index of the Drive</param>
        /// <returns>List of drive infos</returns>
        public List<DriveInfo> GetDriveinfo(string name, string index)
        {
            List<DriveInfo> dinfo = new List<DriveInfo>();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(index))
            {
                throw new Exception("Variable is null or empty (Method: GetDriveinfo)");
            }

            ManagementObjectSearcher mosDisks;
            try
            {
                // Get all the disk drives from WMI that match the Model name
                mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE Model = '" + name + "' and Index= '" + index + "'");

            }
            catch (Exception ex)
            {             
                throw new Exception("Error in GetDriveinfo (" + ex.Message + ")");
            }
         
            foreach (ManagementObject moDisk in mosDisks.Get())
            {
                dinfo.Add(FillDriveinfo(moDisk));
            }

            mosDisks.Dispose();
            string guid = GetGUID(dinfo[0].PNPDeviceID);
            return dinfo;
        }

        private string GetGUID(string pnpdeviceid)
        {
            ManagementObjectSearcher mosDisks;
            try
            {
                // Get all the disk drives from WMI that match the Model name
                mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE PNPDeviceID = '" + pnpdeviceid + "'");

            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetGUID (" + ex.Message + ")");
            }

            foreach (ManagementObject mo in mosDisks.Get())
            {
                string ret = mo["ClassGuid"].ToString();
                return ret;
            }
            return "";
        }

        private DriveInfo FillDriveinfo(ManagementObject moDisk)
        {
            DriveInfo di = new DriveInfo();
            object[] data = new object[10];
            

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
                        di.MediaType = data[i].ToString();
                        break;

                    case 1:
                        di.Model = data[i].ToString();
                        break;

                    case 2:
                        di.SerialNumber = data[i].ToString();
                        break;

                    case 3:
                        di.InterfaceType = data[i].ToString();
                        break;

                    case 4:
                        di.Partitions = data[i].ToString();
                        break;

                    case 5:
                        di.Index = data[i].ToString();
                        break;
                    case 6:
                        di.DeviceID = data[i].ToString();
                        break;
                    case 7:
                        di.PNPDeviceID = data[i].ToString();
                        break;
                    case 8:
                        di.Name = data[i].ToString();
                        break;
                    case 9:
                        di.CreationClassName = data[i].ToString();
                        break;

                }
                
            }
            return di;
        }

        public bool CheckDiskPresent(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Variable is null or empty (Method: GetDriveinfo)");
            }

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

            ManagementObjectCollection mo = mosDisks.Get();

            if (mo.Count < 1)
                return false;
            return true;
        }

        public List<Partition> GetPartitionInfo(string index)
        {
            if (string.IsNullOrEmpty(index))
            {
                throw new Exception("Variable is null or empty (Method: GetPartitionInfo)");
            }
            List<Partition> partitionInfos = new List<Partition>();

            ManagementObjectSearcher mosPart;
            try
            {
                // Get all the Partitions that catch the diskindex
                mosPart = new ManagementObjectSearcher("SELECT * FROM Win32_DiskPartition WHERE DiskIndex ='" + index + "'");
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetPartitionInfo (" + ex.Message + ")");
            }
            
            foreach (ManagementObject moPart in mosPart.Get())
            {
                partitionInfos.Add(FillPartitionInfo(moPart));              
            }
            return partitionInfos;
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

        private void TestVariable(string[] var)
        {
            if(var.Length <= 0)
            {
                throw new Exception("DriveInfo not initialized");
            }
        }
    }

    class DriveInfo : IEnumerable<string>
    {
        private string _mediaType;
        private string _model;
        private string _serialNumber;
        private string _interfaceType;
        private string _partitions;
        private string _index;
        private string _deviceid;
        private string _pnpdeviceid;
        private string _name;
        private string _creationclassname;

        public string MediaType
        {
            get { return _mediaType; }
            set { _mediaType = value; }
        }
            
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public string SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }
        public string InterfaceType
        {
            get { return _interfaceType; }
            set { _interfaceType = value; }
        }
        public string Partitions
        {
            get { return _partitions; }
            set { _partitions = value; }
        }
        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }
        public string DeviceID
        {
            get { return _deviceid; }
            set { _deviceid = value; }
        }
        public string PNPDeviceID
        {
            get { return _pnpdeviceid; }
            set { _pnpdeviceid = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string CreationClassName
        {
            get { return _creationclassname; }
            set { _creationclassname = value; }
        }
        public IEnumerator<string> GetEnumerator()
        {
            yield return MediaType;
            yield return Model;
            yield return SerialNumber;
            yield return InterfaceType;
            yield return Partitions;
            yield return Index;
            yield return DeviceID;
            yield return PNPDeviceID;
            yield return Name;
            yield return CreationClassName;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    } 

    class Partition : IEnumerable<string>
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

        public IEnumerator<string> GetEnumerator()
        {
            yield return DeviceId;
            yield return DiskIndex;
            yield return Index;
            yield return Name;
            yield return Size;
            yield return Type;
            yield return Description;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
