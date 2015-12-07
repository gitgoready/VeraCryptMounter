using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Provides the automount functionality 
    /// </summary>
    class UsbEvent
    {
        private Config _config = new Config();
        private List<string> _drives = new List<string>();
        private List<string> _containers = new List<string>();
        private delegate bool UsbAnalysisDelegate(EventArrivedEventArgs e);

        public void Initialize()
        {
            // Get Singelton for config
            _config = Singleton<ConfigManager>.Instance.Init(_config);
           
        }

        /// <summary>
        /// Event method if a usbdevice is pluged in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void UsbEventArrived(object sender, EventArrivedEventArgs e)
        {
            UsbAnalysisDelegate aus = UsbEventAnalysing;
            aus.BeginInvoke(e, UsbCallback, aus);
        }


        /// <summary>
        /// Analyse if the usbdevice is a sorrage device.
        /// </summary>
        /// <param name="e"></param>
        /// <returns>true if it is a storage device</returns>
        private static bool UsbEventAnalysing(EventArrivedEventArgs e)
        {
            // Get the Event Object.
            foreach (PropertyData pd in e.NewEvent.Properties)
            {
                ManagementBaseObject mbo = null;
                if ((mbo = pd.Value as ManagementBaseObject) != null)
                {
                    foreach (PropertyData prop in mbo.Properties)
                    {
                        string test = (string)prop.Value;
                        if (test != null)
                        {
                            if (test.Contains("USBSTOR"))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private static void UsbCallback(IAsyncResult result)
        {
            var ausresult = (UsbAnalysisDelegate)result.AsyncState;
            bool res = ausresult.EndInvoke(result);
            if (res)
            {
                try
                {
                    
                    var start = new Automount("usb");
                    start.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.Source);
                    return;
                }

            }
        }   
    }
}
