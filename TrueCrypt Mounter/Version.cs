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
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Form for showing the Version
    /// </summary>
    public partial class Version : Form
    {
        /// <summary>
        /// constructor for Version
        /// </summary>
        public Version()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Version_Load(object sender, EventArgs e)
        {
            //const string version = "Version: 0.9.10 (Beta)";
            //var test = Assembly.GetEntryAssembly().GetName().Version;
            ////labelAssembly.Text = "Build: " + test.Build.ToString();
            //label2.Text = version;
        }

        private void homepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.365sec.com");//https://blog.lordsandwurm.de/veracryptmounter
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{         
        //    Process.Start("https://github.com/LordSandwurm/VeraCryptMounter");
        //}
    }
}