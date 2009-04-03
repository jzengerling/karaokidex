using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Collections;
using System.Globalization;

namespace Karaokidex
{
    public sealed class RegistryAgent
    {
        #region Constants
        private const string KEY_LAST_DATABASE = "Last Database";
        #endregion

        #region Properties
        public static RegistryKey SettingsKey
        {
            get
            {
                RegistryKey theSettingsKey =
                    Registry.LocalMachine.OpenSubKey("Software\\www.ne0ge0.com\\Karaokidex", true);
                if (null == theSettingsKey)
                {
                    RegistryKey theSoftwareKey =
                        Registry.LocalMachine.OpenSubKey("Software", true);
                    RegistryKey theComputaKey =
                        theSoftwareKey.CreateSubKey("www.ne0ge0.com");
                    theSettingsKey =
                        theComputaKey.CreateSubKey("Karaokidex");
                }
                return theSettingsKey;
            }
        }

        public static string LastDatabase
        {
            get
            {
                if (null == RegistryAgent.SettingsKey.GetValue(RegistryAgent.KEY_LAST_DATABASE))
                {
                    RegistryAgent.SettingsKey.SetValue(
                        RegistryAgent.KEY_LAST_DATABASE,
                        String.Empty);
                }
                return RegistryAgent.SettingsKey.GetValue(RegistryAgent.KEY_LAST_DATABASE).ToString();
            }
            set
            {
                RegistryAgent.SettingsKey.SetValue(RegistryAgent.KEY_LAST_DATABASE, value);
            }
        }
        #endregion
    }
}
