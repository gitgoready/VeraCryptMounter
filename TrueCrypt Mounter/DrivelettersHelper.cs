/**
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
using System.IO;

namespace VeraCrypt_Mounter
{
    public static class DrivelettersHelper
    {
        private static Config _config = new Config();

        static DrivelettersHelper()
        {
            _config = Singleton<ConfigManager>.Instance.Init(_config);
        }

        public static string[] GetFreeDriveletters()
        {
            var driveletters = new[]
                                   {
                                       "C:\\", "D:\\", "E:\\", "F:\\", "G:\\", "H:\\", "I:\\", "J:\\", "K:\\", "L:\\",
                                       "M:\\", "N:\\", "O:\\", "P:\\", "Q:\\", "R:\\", "S:\\", "T:\\", "U:\\", "V:\\",
                                       "W:\\", "X:\\", "Y:\\", "Z:\\"
                                   };
            string[] useddriveletters = Directory.GetLogicalDrives();
            int count = 0;

            foreach (string letter in driveletters)
            {
                foreach (string dletter in useddriveletters)
                {
                    if (dletter == letter)
                    {
                        Array.Clear(driveletters, count, 1);
                    }
                }
                count++;
            }
            return driveletters;
        }

        public static string[] GetDriveletters()
        {
            var driveletters = new[]
                                   {
                                       "C:\\", "D:\\", "E:\\", "F:\\", "G:\\", "H:\\", "I:\\", "J:\\", "K:\\", "L:\\",
                                       "M:\\", "N:\\", "O:\\", "P:\\", "Q:\\", "R:\\", "S:\\", "T:\\", "U:\\", "V:\\",
                                       "W:\\", "X:\\", "Y:\\", "Z:\\"
                                   };
            return driveletters;
        }

        public static string[] GetUsedDriveletter()
        {
            return Directory.GetLogicalDrives();
        }

        public static bool IsDriveletterFree(string letter)
        {
            string[] useddriveletters = Directory.GetLogicalDrives();

            foreach (string usedletter in useddriveletters)
            {
                if (usedletter == letter)
                    return false;
            }
            return true;
        }

        

        /// <summary>
        /// Test if the drivletter is used for another drive or container in config file.
        /// </summary>
        /// <param name="driveletter"></param>
        /// <returns>Name of the drive or container they use the drivletter.</returns>
        public static string IsDrivletterUsedByConfig (string driveletter)
        {
            string[] sections = _config.GetSectionNames();

            foreach (string section in sections)
            {
                if(driveletter == _config.GetValue(section, ConfigTrm.Mainconfig.Driveletter, ""))
                {
                    return section;
                }
            }
            return null;
        }
    }
}