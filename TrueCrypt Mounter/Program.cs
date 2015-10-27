/**
 * <TruecryptMounter. Programm to use Truecrypt drives and containers easier.>
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
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TrueCrypt_Mounter
{

    internal class Program
    {

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private static ManagementScope scope = new ManagementScope("root\\CIMV2");
        private static ManagementOperationObserver observer = new ManagementOperationObserver();

        private static string[] _driveliste;

        public string[] Drivelist
        {
            get { return _driveliste; }
            set { _driveliste = value; }
        }


        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            //ManagementEventWatcher w = null;
            //WqlEventQuery q = new WqlEventQuery();
            
            //// Bind to local machine
            
            //scope.Options.EnablePrivileges = true; //sets required privilege
            //try
            //{
            //    q.EventClassName = "__InstanceCreationEvent";
            //    q.WithinInterval = new TimeSpan(0, 0, 10);

            //    q.Condition = @"TargetInstance ISA 'Win32_USBControllerDevice' ";
            //    w = new ManagementEventWatcher(scope, q);

            //    w.EventArrived += UsbEvent.UsbEventArrived;
            //    w.Start();

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            _driveliste = DrivelettersHelper.GetUsedDriveletter();
            bool createdNew;
            using (var mutex = new Mutex(true, "TrueCryptMounter", out createdNew))
            {
                if (createdNew)
                {
                    var dirKon = new DirectoryInfo(Path.Combine(Application.StartupPath, "Kontainer"));
                    if (!dirKon.Exists)
                        Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Kontainer"));

                    var dirTrue = new DirectoryInfo(Path.Combine(Application.StartupPath, "TrueCrypt"));
                    if (!dirTrue.Exists)
                        Directory.CreateDirectory(Path.Combine(Application.StartupPath, "TrueCrypt"));

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    
                    //show password form to decrypt config
                    var dialogBox = new Password();
                    var result = dialogBox.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Application.Run(new TrueCryptMounter());
                    }
                    else
                    {
                        Application.Exit();
                    }
                    //w.EventArrived -= UsbEvent.UsbEventArrived;
                    //w.Stop();
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
        }       
    }
}