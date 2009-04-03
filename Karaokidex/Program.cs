using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using Karaokidex.ApplicationControllers;

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
            Controller theController = new Controller();
            theController.StartApp();
        }
    }
}