using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Provides the automount functionality 
    /// </summary>
    class UsbEvent
    {
        private delegate string UsbAnalysisDelegate(EventArrivedEventArgs e);

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
        private static string UsbEventAnalysing(EventArrivedEventArgs e)
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
                                return test;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private static void UsbCallback(IAsyncResult result)
        {
            var ausresult = (UsbAnalysisDelegate)result.AsyncState;
            string res = ausresult.EndInvoke(result);
            if (res != null)
            {
                try
                {
                    Automountusb.MountUsb(res);
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
