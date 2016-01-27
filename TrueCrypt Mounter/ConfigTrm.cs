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

            public const string Defaultlanguage = "Defaultlanguage";
            public const string Driveletter = "Driveletter";
            public const string Kontainerpath = "Kontainerpath";
            public const string Language = "Language";
            public const string Nokeyfile = "Nokeyfile";
            //public const string Passwordcache = "Passwordcache";
            public const string Readonly = "Readonly";
            public const string Removable = "Removable";
            public const string Silentmode = "Silentmode";
            public const string Truecryptpath = "Truecryptpath";
            public const string Section = "Grundeinstellungen";
            public const string Type = "Type";
            public const string Languagefile = "Languagefile";
            public const string Typename = "config";
            public const string Automount = "Automount";
            public const string Passwordtest = "Passwordtest";
            public const string Pim = "Pim";
            public const string Hash = "Hash";

        }

        /// <summary>
        /// Class for the string in the drive section.
        /// </summary>
        public static class Drive
        {
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
