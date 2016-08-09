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
  
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace VeraCrypt_Mounter
{
    ///<summary>
    /// Class prvides all methods to use the config file.
    /// Read, write, remove.
    ///</summary>
    public class Config
    {
        private const string SectionType = "System.Configuration.NameValueSectionHandler, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, Custom=null";

        private readonly Encoding _encoding = Encoding.UTF8;
        private string _mGroupName = "profile";
        private string _xmlPathName;


        /// <summary>
        /// Get or set the path to the xml config file.
        /// </summary>
        public string XmlPathName
        {
            get { return _xmlPathName;}
            set
            {
                if (_xmlPathName == value)
                    return;

                _xmlPathName = value;
            }
                
        }

        /// <summary>
        /// Get or set the group name for the config. Set null for no use. 
        /// </summary>
        public string GroupName
        {
            get { return _mGroupName; }
            set
            {
                if (_mGroupName == value)
                    return;

                _mGroupName = value;
                if (_mGroupName != null)
                {
                    _mGroupName = _mGroupName.Replace(' ', '_');

                    if (_mGroupName.IndexOf(':') >= 0)
                        throw new XmlException("GroupName may not contain a namespace prefix.");
                }
            }
        }

        /// <summary>
        ///   Gets the name of the GroupName plus a slash or an empty string is HasGroupName is false. 
        /// </summary>
        /// <remarks>
        ///   This property helps us when retrieving sections. 
        /// </remarks>
        private string GroupNameSlash
        {
            get { return (HasGroupName ? (_mGroupName + "/") : ""); }
        }


        /// <summary>
        /// Gets whether we have a valid GroupName. 
        /// </summary>
        /// <return>
        /// Returns TRUE if _mGroupName is set.
        /// </return>
        private bool HasGroupName
        {
            get { return !string.IsNullOrEmpty(_mGroupName); }
        }

        /// <summary>
        /// Remove a section from the config file.
        /// </summary>
        /// <param name="section">
        /// The section name to remove ass string
        /// </param>
        public void RemoveSection(string section)
        {
            VerifyAndAdjustSection(ref section);

            // Verify the document exists
            XmlDocument doc = GetXmlDocument();
            if (doc == null)
                return;

            // Get the root node, if it exists
            XmlElement root = doc.DocumentElement;
            if (root == null)
                return;

            // Get the section's node, if it exists
            XmlNode sectionNode = root.SelectSingleNode(GroupNameSlash + section);
            if (sectionNode == null)
                return;
            // Delete the section entry
            sectionNode.ParentNode.RemoveChild(sectionNode);

            // Delete the configSections entry also			
            if (!IsAppSettings(section))
            {
                sectionNode = root.SelectSingleNode("configSections/" + (HasGroupName ? ("sectionGroup[@name=\"" + _mGroupName + "\"]") : "") + "/section[@name=\"" + section + "\"]");
                if (sectionNode == null)
                    return;

                sectionNode.ParentNode.RemoveChild(sectionNode);
            }

            // Save the document 
            doc.Save(_xmlPathName);
        }

        /// <summary>
        /// Remove a entry in a section from the xml config file.
        /// </summary>
        /// <param name="section">The section as string.</param>
        /// <param name="entry">The entry to remove as string</param>
        public void RemoveEntry(string section, string entry)
        {
            VerifyAndAdjustSection(ref section);
            VerifyAndAdjustEntry(ref entry);

            // Verify the document exists
            XmlDocument doc = GetXmlDocument();
            if (doc == null)
                return;

            // Get the entry's node, if it exists
            XmlElement root = doc.DocumentElement;
            if (root != null)
            {
                XmlNode entryNode = root.SelectSingleNode(GroupNameSlash + section + "/add[@key=\"" + entry + "\"]");
                if (entryNode == null)
                    return;

                entryNode.ParentNode.RemoveChild(entryNode);
            }
            doc.Save(_xmlPathName);
        }

        /// <summary>
        /// Set a entry in the xml config file. If the value of the entry is null. The entry will be removed.
        /// </summary>
        /// <param name="section">The Section name as string.</param>
        /// <param name="entry">The entry name as string</param>
        /// <param name="value">The value of the entry.</param>
        public void SetValue(string section, string entry, object value)
        {
            // If the value is null, remove the entry
            if (value == null)
            {
                RemoveEntry(section, entry);
                return;
            }

            VerifyName();
            VerifyAndAdjustSection(ref section);
            VerifyAndAdjustEntry(ref entry);


            bool hasGroupName = HasGroupName;
            bool isAppSettings = IsAppSettings(section);

            // If the file does not exist, use the writer to quickly create it
            if (!File.Exists(_xmlPathName))
            {
                XmlTextWriter writer = null;
                try
                {
                  writer  = new XmlTextWriter(_xmlPathName, _encoding) { Formatting = Formatting.Indented };
                }
                catch (Exception ex)
                {
                    var res = System.Windows.Forms.MessageBox.Show("Config error: " + ex, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    Application.Exit();
                }
                 
                writer.WriteStartDocument();

                writer.WriteStartElement("configuration");
                if (!isAppSettings)
                {
                    writer.WriteStartElement("configSections");
                    if (hasGroupName)
                    {
                        writer.WriteStartElement("sectionGroup");
                        writer.WriteAttributeString("name", null, _mGroupName);
                    }
                    writer.WriteStartElement("section");
                    writer.WriteAttributeString("name", null, section);
                    writer.WriteAttributeString("type", null, SectionType);
                    writer.WriteEndElement();

                    if (hasGroupName)
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                if (hasGroupName)
                    writer.WriteStartElement(_mGroupName);
                writer.WriteStartElement(section);
                writer.WriteStartElement("add");
                writer.WriteAttributeString("key", null, entry);
                //encode string with aes
                writer.WriteAttributeString("value", null, StringCipher.Encrypt(value.ToString(), Password_helper.Password));

                writer.WriteEndElement();
                writer.WriteEndElement();
                if (hasGroupName)
                    writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Close();

                return;
            }

            // The file exists, edit it

            XmlDocument doc = GetXmlDocument();
            XmlElement root = doc.DocumentElement;

            XmlAttribute attribute;
            XmlNode sectionNode = null;

            // Check if we need to deal with the configSections element
            if (!isAppSettings)
            {
                // Get the configSections element and add it if it's not there
                if (root != null)
                {
                    XmlNode sectionsNode = root.SelectSingleNode("configSections");
                    if (sectionsNode == null)
                        sectionsNode = root.AppendChild(doc.CreateElement("configSections"));

                    XmlNode sectionGroupNode = sectionsNode;
                    if (hasGroupName)
                    {
                        // Get the sectionGroup element and add it if it's not there
                        sectionGroupNode = sectionsNode.SelectSingleNode("sectionGroup[@name=\"" + _mGroupName + "\"]");
                        if (sectionGroupNode == null)
                        {
                            XmlElement element = doc.CreateElement("sectionGroup");
                            attribute = doc.CreateAttribute("name");
                            attribute.Value = _mGroupName;
                            element.Attributes.Append(attribute);
                            sectionGroupNode = sectionsNode.AppendChild(element);
                        }
                    }

                    // Get the section element and add it if it's not there
                    sectionNode = sectionGroupNode.SelectSingleNode("section[@name=\"" + section + "\"]");
                    if (sectionNode == null)
                    {
                        XmlElement element = doc.CreateElement("section");
                        attribute = doc.CreateAttribute("name");
                        attribute.Value = section;
                        element.Attributes.Append(attribute);

                        sectionNode = sectionGroupNode.AppendChild(element);
                    }
                }

                // Update the type attribute
                attribute = doc.CreateAttribute("type");
                attribute.Value = SectionType;
                if (sectionNode != null) sectionNode.Attributes.Append(attribute);
            }

            // Get the element with the sectionGroup name and add it if it's not there
            XmlNode groupNode = root;
            if (hasGroupName)
            {
                if (root != null)
                {
                    groupNode = root.SelectSingleNode(_mGroupName) ?? root.AppendChild(doc.CreateElement(_mGroupName));
                }
            }

            // Get the element with the section name and add it if it's not there
            if (groupNode != null)
            {
                sectionNode = groupNode.SelectSingleNode(section) ?? groupNode.AppendChild(doc.CreateElement(section));
            }

            // Get the 'add' element and add it if it's not there
            if (sectionNode != null)
            {
                XmlNode entryNode = sectionNode.SelectSingleNode("add[@key=\"" + entry + "\"]");
                if (entryNode == null)
                {
                    XmlElement element = doc.CreateElement("add");
                    attribute = doc.CreateAttribute("key");
                    attribute.Value = entry;
                    element.Attributes.Append(attribute);

                    entryNode = sectionNode.AppendChild(element);
                }

                // Update the value attribute
                attribute = doc.CreateAttribute("value");
                attribute.Value = StringCipher.Encrypt(value.ToString(), Password_helper.Password);
                entryNode.Attributes.Append(attribute);
            }

            // Save the file
            doc.Save(_xmlPathName);
        }

        /// <summary>
        ///   Retrieves whether we don't have a valid GroupName and a given section is 
        ///   equal to "appSettings". </summary>
        /// <remarks>
        ///   This method helps us determine whether we need to deal with the "configuration\configSections" element. </remarks>
        private bool IsAppSettings(string section)
        {
            return !HasGroupName && section != null && section == "appSettings";
        }

        /// <summary>
        /// Load the xml config file if it exist.
        /// </summary>
        /// <returns>Returns a XmlDocument file with the loaded config</returns>
        protected XmlDocument GetXmlDocument()
        {
            VerifyName();
            if (!File.Exists(_xmlPathName))
                return null;

            var doc = new XmlDocument();
            doc.Load(_xmlPathName);
            return doc;
        }

        /// <summary>
        /// Get the sections from the xml config file.
        /// </summary>
        /// <returns>Return a string array with the names of the sections</returns>
        public string[] GetSectionNames()
        {
            // Verify the document exists
            XmlDocument doc = GetXmlDocument();
            if (doc == null)
                return null;

            // Get the root node, if it exists
            XmlElement root = doc.DocumentElement;
            if (root == null)
                return null;

            // Get the group node
            XmlNode groupNode = (HasGroupName ? root.SelectSingleNode(_mGroupName) : root);
            if (groupNode == null)
                return null;

            // Get the section nodes
            XmlNodeList sectionNodes = groupNode.ChildNodes;

            // Add all section names to the string array			
            var sections = new string[sectionNodes.Count];
            int i = 0;

            foreach (XmlNode node in sectionNodes)
                sections[i++] = node.Name;

            return sections;
        }

        /// <summary>
        /// Test if the the section is in xml config file.
        /// </summary>
        /// <param name="section">The name of the section as string</param>
        /// <returns>true or false</returns>
        public bool HasSection(string section)
        {
            string[] sections = GetSectionNames();

            if (sections == null)
                return false;

            VerifyAndAdjustSection(ref section);
            return Array.IndexOf(sections, section) >= 0;
        }

        /// <summary>
        /// Returns the entrys of a section.
        /// </summary>
        /// <param name="section">The sectionname as string</param>
        /// <returns>A string array of the entrys</returns>
        public string[] GetEntryNames(string section)
        {
            // Verify the section exists
            if (!HasSection(section))
                return null;

            VerifyAndAdjustSection(ref section);
            XmlDocument doc = GetXmlDocument();
            XmlElement root = doc.DocumentElement;

            // Get the entry nodes
            if (root != null)
            {
                XmlNodeList entryNodes = root.SelectNodes(GroupNameSlash + section + "/add[@key]");
                if (entryNodes == null)
                    return null;

                // Add all entry names to the string array			
                var entries = new string[entryNodes.Count];
                int i = 0;

                foreach (XmlNode node in entryNodes)
                    entries[i++] = node.Attributes["key"].Value;

                return entries;
            }
            return null;
        }
        /// <summary>
        /// Test if entry is in section og config
        /// </summary>
        /// <param name="section">Section in XML config</param>
        /// <param name="entry">entry to test</param>
        /// <returns></returns>
        public bool HasEntry(string section, string entry)
        {
            string[] entries = GetEntryNames(section);

            if (entries == null)
                return false;

            VerifyAndAdjustEntry(ref entry);
            return Array.IndexOf(entries, entry) >= 0;
        }

        #region Methods : Verifications

        /// <summary>
        /// Replace whitespace with underscore in section
        /// </summary>
        /// <param name="section">section name</param>
        protected void VerifyAndAdjustSection(ref string section)
        {
            if (section.IndexOf(' ') >= 0)
                section = section.Replace(' ', '_');
        }
        /// <summary>
        /// Trims entry string
        /// </summary>
        /// <param name="entry"></param>
        protected void VerifyAndAdjustEntry(ref string entry)
        {
            if (entry == null)
                throw new ArgumentNullException("entry");

            entry = entry.Trim();
        }
        /// <summary>
        /// check if name is null or empty
        /// </summary>
        protected void VerifyName()
        {
            if (string.IsNullOrEmpty(_xmlPathName))
                throw new InvalidOperationException("Operation not allowed because Name property is null or empty.");
        }

        #endregion

        #region  Methodes: GetValue
        /// <summary>
        /// Get value from XML config for string value
        /// </summary>
        /// <param name="section"></param>
        /// <param name="entry"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string GetValue(string section, string entry, string defaultValue)
        {
            object value = GetValue(section, entry);
            return (value == null ? defaultValue : value.ToString());
        }
        /// <summary>
        /// Get value from XML config for int value
        /// </summary>
        /// <param name="section"></param>
        /// <param name="entry"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public int GetValue(string section, string entry, int defaultValue)
        {
            object value = GetValue(section, entry);
            if (value == null)
                return defaultValue;

            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Get value from XML config for double value
        /// </summary>
        /// <param name="section"></param>
        /// <param name="entry"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public double GetValue(string section, string entry, double defaultValue)
        {
            object value = GetValue(section, entry);
            if (value == null)
                return defaultValue;

            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// get value from XML config for bool value
        /// </summary>
        /// <param name="section"></param>
        /// <param name="entry"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool GetValue(string section, string entry, bool defaultValue)
        {
            object value = GetValue(section, entry);
            if (value == null)
                return defaultValue;

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// get value from XML config for all values
        /// </summary>
        /// <param name="section"></param>
        /// <param name="entry"></param>
        /// <returns></returns>
        public object GetValue(string section, string entry)
        {
            VerifyAndAdjustSection(ref section);
            VerifyAndAdjustEntry(ref entry);

            try
            {
                XmlDocument doc = GetXmlDocument();
                XmlElement root = doc.DocumentElement;

                if (root != null)
                {
                    XmlNode entryNode = root.SelectSingleNode(GroupNameSlash + section + "/add[@key=\"" + entry + "\"]");
                    string value = entryNode.Attributes["value"].Value;
                    //encrypt value
                    value = StringCipher.Decrypt(value, Password_helper.Password);
                    return value;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}