#region Usings
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Deployment.Application;
using System.IO;
using System.Collections;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
#endregion

namespace Karaokidex.ApplicationControllers
{
    public partial class Controller : IDisposable
    {
        #region Members
        private ApplicationContext _AppContext;
        private IntPtr _NativeResource;
        #endregion

        #region Methods
        /// <summary>
        /// Start controlling the application
        /// </summary>
        public void StartApp()
        {
            this._NativeResource = Marshal.AllocHGlobal(100);

            // Enable XP styles
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            // Setup unhandled exception handlers
            AppDomain.CurrentDomain.UnhandledException += // CLR
               new UnhandledExceptionEventHandler(OnUnhandledException);
            Application.ThreadException += // Windows Forms
                new ThreadExceptionEventHandler(OnGuiUnhandedException);

            // Create an application Context
            this._AppContext = new ApplicationContext();

            // Start by showing the main application screen
            this.MainView_Show();

            // Single instance checked
            bool IsFirstInstance;
            Mutex theMutex = new Mutex(false, "Local\\Karaokidex", out IsFirstInstance);

            /* If IsFirstInstance is now true, we're the first instance of the application; 
             * otherwise another instance is running.
             */
            if (IsFirstInstance)
            {
                Application.Run(this._AppContext);
            }
            theMutex.Close();
            Application.Exit(); 
        }

        #region Handle Exceptions
        // CLR unhandled exception
        private void OnUnhandledException(
            Object sender, UnhandledExceptionEventArgs e)
        {
            this._MainView.Cursor =
                Cursors.Default;

            HandleUnhandledException(e.ExceptionObject);
        }

        // Windows Forms unhandled exception
        private void OnGuiUnhandedException(
            Object sender, ThreadExceptionEventArgs e)
        {
            if (null != this._MainView)
            {
                this._MainView.Cursor =
                    Cursors.Default;
            }

            HandleUnhandledException(e.Exception);
        }

        /// <summary>
        /// Handle the Application_ThreadException event
        /// </summary>
        /// <param name="sender">Application</param>
        /// <param name="e">ThreadExceptionEventArgs</param>
        private static void HandleUnhandledException(Object sender)
        {
            Exception theException =
                sender as Exception;

            EventLog theApplicationLog = new EventLog();
            theApplicationLog.Source = "Karaokidex";
            theApplicationLog.WriteEntry(
                String.Format(
                    CultureInfo.CurrentCulture,
                    "Exception: {0}",
                    theException.Message
                ),
                EventLogEntryType.Error);

            MessageBox.Show(
                "An error report has been written to the Event Log",
                "Error Occurred",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button1);
        }
        #endregion

        #region IDisposable Members
        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // NOTE: Leave out the finalizer altogether if this class doesn't 
        // own unmanaged resources itself, but leave the other methods
        // exactly as they are. 
        ~Controller()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (_MainView != null)
                {
                    _MainView.Dispose();
                    _MainView = null;
                }
                if (_AppContext != null)
                {
                    _AppContext.Dispose();
                    _AppContext = null;
                }
            }
            // free native resources if there are any.
            if (_NativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_NativeResource);
                _NativeResource = IntPtr.Zero;
            }
        }
        #endregion
        #endregion
    }
}
