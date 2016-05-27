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

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Class for classes they contains the strings for the config file. 
    /// </summary>
    public static class ConfigTrm
    {
        /// <summary>
        /// Class for all string in the mainconfig section.
        /// </summary>
        public static class Mainconfig
        {
            /// <summary>
            /// Default langugage string
            /// </summary>
            public const string Defaultlanguage = "Defaultlanguage";
            /// <summary>
            /// Driveletter for the keyfilekontainer
            /// </summary>
            public const string Driveletter = "Driveletter";
            /// <summary>
            /// Path to the keyfilekontainer
            /// </summary>
            public const string Kontainerpath = "Kontainerpath";
            /// <summary>
            /// Selected language
            /// </summary>
            public const string Language = "Language";
            /// <summary>
            /// nokeyfilekontainer string
            /// </summary>
            public const string Nokeyfile = "Nokeyfile";
            /// <summary>
            /// keyfilekontainer mount readonly
            /// </summary>
            public const string Readonly = "Readonly";
            /// <summary>
            /// keyfilekontainer mount as removable device
            /// </summary>
            public const string Removable = "Removable";
            /// <summary>
            /// use silent mode for mounting
            /// </summary>
            public const string Silentmode = "Silentmode";
            /// <summary>
            /// Path to truecrypt (veracrypt exe)
            /// </summary>
            public const string Truecryptpath = "Truecryptpath";
            /// <summary>
            /// section name in config
            /// </summary>
            public const string Section = "Grundeinstellungen";
            /// <summary>
            /// type string
            /// </summary>
            public const string Type = "Type";
            /// <summary>
            /// name of languagefile
            /// </summary>
            public const string Languagefile = "Languagefile";
            /// <summary>
            /// typename in XML config
            /// </summary>
            public const string Typename = "config";
            /// <summary>
            /// mount keyfilekontainer at programm start
            /// </summary>
            public const string Automount = "Automount";
            /// <summary>
            /// Testpassword for encryption test
            /// </summary>
            public const string Passwordtest = "Passwordtest";
            /// <summary>
            /// pim for keyfilekontainer
            /// </summary>
            public const string Pim = "Pim";
            /// <summary>
            /// hash for keyfilekontainer
            /// </summary>
            public const string Hash = "Hash";
            /// <summary>
            /// Hash used for keyfilekontainer
            /// </summary>
            public const string Hashes = "Hashes";
            /// <summary>
            /// start with windows
            /// </summary>
            public const string AutostartWithWindows = "AutostartWithWindows";

        }

        /// <summary>
        /// Class for the string in the drive section.
        /// </summary>
        public static class Drive
        {
            /// <summary>
            /// driveletter to mount the drive
            /// </summary>
            public const string Driveletter = "Driveletter";
            /// <summary>
            /// Partition to mount on the drive
            /// </summary>
            public const string Partition = "Partition";
            /// <summary>
            /// keyfile for the drive
            /// </summary>
            public const string Keyfile = "Keyfile";
            /// <summary>
            /// bool for indikate if keyfile is used
            /// </summary>
            public const string Nokeyfile = "Nokeyfile";
            /// <summary>
            /// bool mount readonly
            /// </summary>
            public const string Readonly = "Readonly";
            /// <summary>
            /// bool mount removable
            /// </summary>
            public const string Removable = "Removable";
            /// <summary>
            /// string type
            /// </summary>
            public const string Type = "Type";
            /// <summary>
            /// string typename
            /// </summary>
            public const string Typename = "Drive";
            /// <summary>
            /// bool automountusb
            /// </summary>
            public const string Automountusb = "Automountusb";
            /// <summary>
            /// bool automountstart
            /// </summary>
            public const string Automountstart = "Automountstart";
            /// <summary>
            /// boll use pim
            /// </summary>
            public const string Pimuse = "Pimuse";
            /// <summary>
            /// string hash for mounting
            /// </summary>
            public const string Hash = "Hash";
            /// <summary>
            /// bool use truecryptmode
            /// </summary>
            public const string Truecrypt = "Truecrypt";
            /// <summary>
            /// string diskmodel
            /// </summary>
            public const string Diskmodel = "Diskmodel";
            /// <summary>
            /// string disk serial
            /// </summary>
            public const string Diskserial = "Diskserial";
            /// <summary>
            /// string disknumber
            /// </summary>
            public const string Disknumber = "Disknumber";
            /// <summary>
            /// ???
            /// </summary>
            public const string Partnumber = "Partnumber";
            /// <summary>
            /// string pnpdeviceid
            /// </summary>
            public const string Pnpdeviceid = "PNPDeviceID";
            /// <summary>
            /// string password
            /// </summary>
            public const string Password = "Password";
            /// <summary>
            /// string pim
            /// </summary>
            public const string Pim = "Pim";
        }

        /// <summary>
        /// Class for the string in the container section.
        /// </summary>
        public static class Container
        {
            /// <summary>
            /// Driveltter to mount to
            /// </summary>
            public const string Driveletter = "Driveletter";
            /// <summary>
            /// pnpdeviceid for containing drive
            /// </summary>
            public const string Pnpid = "Pnpid";
            /// <summary>
            /// partitionnumber for containing drive
            /// </summary>
            public const string Partnummber = "Partnummber";
            /// <summary>
            /// keyfile for container
            /// </summary>
            public const string Keyfile = "Keyfile";
            /// <summary>
            /// bool use keyfile
            /// </summary>
            public const string Nokeyfile = "Nokeyfile";
            /// <summary>
            /// string type
            /// </summary>
            public const string Type = "Type";
            /// <summary>
            /// bool mount redonly
            /// </summary>
            public const string Readonly = "Readonly";
            /// <summary>
            /// bool mount removable
            /// </summary>
            public const string Removable = "Removable";
            /// <summary>
            /// path to kontainer
            /// </summary>
            public const string Kontainerpath = "Kontainerpath";
            /// <summary>
            /// ???
            /// </summary>
            public const string Drive = "Drive";
            /// <summary>
            /// bool test containing drive
            /// </summary>
            public const string Nodrive = "Nodrive";
            /// <summary>
            /// kontainer name
            /// </summary>
            public const string Typename = "Container";
            /// <summary>
            /// bool automount from usb
            /// </summary>
            public const string Automountusb = "Automountusb";
            /// <summary>
            /// bool automount by programm start
            /// </summary>
            public const string Automountstart = "Automountstart";
            /// <summary>
            /// bool use pim
            /// </summary>
            public const string Pimuse = "Pimuse";
            /// <summary>
            /// bool use truecrypt mode
            /// </summary>
            public const string Truecrypt = "Truecrypt";
            /// <summary>
            /// hash for container
            /// </summary>
            public const string Hash = "Hash";
            /// <summary>
            /// string password
            /// </summary>
            public const string Password = "Password";
            /// <summary>
            /// string pim
            /// </summary>
            public const string Pim = "Pim";

        }

        //public static class Automount
        //{
        //    public const string Useusbautomount = "Useusbautomount";
        //    public const string Mountdrivesusb = "Mountdrivesusb";
        //    public const string Mountcontainersusb = "Mountcontainersusb";
        //    public const string Type = "Type";
        //    public const string Typename = "Config";
        //    public const string Section = "Automount";
        //    public const string Mountdrivesstart = "Mountdrivesstart";
        //    public const string Mountcontainerstart = "Mountcontainerstart";
        //    public const string Usestartautomount = "Usestartautomount";
        //}
    }
}
