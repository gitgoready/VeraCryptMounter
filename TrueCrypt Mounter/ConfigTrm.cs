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
            /// ???
            /// </summary>
            public const string Hashes = "Hashes";

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
            public const string Partition = "Partition";
            public const string Keyfile = "Keyfile";
            public const string Nokeyfile = "Nokeyfile";
            public const string Readonly = "Readonly";
            public const string Removable = "Removable";
            public const string Type = "Type";
            public const string Typename = "Drive";
            public const string Automountusb = "Automountusb";
            public const string Automountstart = "Automountstart";
            public const string Pimuse = "Pimuse";
            public const string Hash = "Hash";
            public const string Truecrypt = "Truecrypt";
            public const string Diskmodel = "Diskmodel";
            public const string Diskserial = "Diskserial";
            public const string Disknumber = "Disknumber";
            public const string Partnumber = "Partnumber";
            public const string Pnpdeviceid = "PNPDeviceID";
            public const string Password = "Password";
            public const string Pim = "Pim";
        }

        /// <summary>
        /// Class for the string in the container section.
        /// </summary>
        public static class Container
        {
            public const string Driveletter = "Driveletter";
            public const string Pnpid = "Pnpid";
            public const string Partnummber = "Partnummber";
            public const string Keyfile = "Keyfile";
            public const string Nokeyfile = "Nokeyfile";
            public const string Type = "Type";
            public const string Readonly = "Readonly";
            public const string Removable = "Removable";
            public const string Kontainerpath = "Kontainerpath";
            public const string Drive = "Drive";
            public const string Nodrive = "Nodrive";
            public const string Typename = "Container";
            public const string Automountusb = "Automountusb";
            public const string Automountstart = "Automountstart";
            public const string Pimuse = "Pimuse";
            public const string Truecrypt = "Truecrypt";
            public const string Hash = "Hash";
            public const string Password = "Password";
            public const string Pim = "Pim";

        }

        /// <summary>
        /// Class for the strings in the Automount section.
        /// </summary>
        public static class Automount
        {
            public const string Useusbautomount = "Useusbautomount";
            public const string Mountdrivesusb = "Mountdrivesusb";
            public const string Mountcontainersusb = "Mountcontainersusb";
            public const string Type = "Type";
            public const string Typename = "Config";
            public const string Section = "Automount";
            public const string Mountdrivesstart = "Mountdrivesstart";
            public const string Mountcontainerstart = "Mountcontainerstart";
            public const string Usestartautomount = "Usestartautomount";
        }
    }
}
