using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using Karaokidex.ApplicationControllers;
using System.IO;

namespace Karaokidex
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (NativeMethods.IsReallyVista && !NativeMethods.IsElevated)
            {
                ProcessStartInfo theStartInfo =
                    new ProcessStartInfo("KaraokidexUACElevationCheckHelper.exe");
                theStartInfo.UseShellExecute = true;

                Process.Start(theStartInfo);
                return;
            } 
            
            Controller theController = new Controller();
            theController.StartApp();
        }
    }
}