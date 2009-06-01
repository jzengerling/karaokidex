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
        private const string KEY_LAST_KARAOKE_DATABASE = "Last Karaoke Database";
        private const string KEY_LAST_MUSIC_DATABASE = "Last Music Database";
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

        public static string LastKaraokeDatabase
        {
            get
            {
                if (null == RegistryAgent.SettingsKey.GetValue(RegistryAgent.KEY_LAST_KARAOKE_DATABASE))
                {
                    RegistryAgent.SettingsKey.SetValue(
                        RegistryAgent.KEY_LAST_KARAOKE_DATABASE,
                        String.Empty);
                }
                return RegistryAgent.SettingsKey.GetValue(RegistryAgent.KEY_LAST_KARAOKE_DATABASE).ToString();
            }
            set
            {
                RegistryAgent.SettingsKey.SetValue(RegistryAgent.KEY_LAST_KARAOKE_DATABASE, value);
            }
        }

        public static string LastMusicDatabase
        {
            get
            {
                if (null == RegistryAgent.SettingsKey.GetValue(RegistryAgent.KEY_LAST_MUSIC_DATABASE))
                {
                    RegistryAgent.SettingsKey.SetValue(
                        RegistryAgent.KEY_LAST_MUSIC_DATABASE,
                        String.Empty);
                }
                return RegistryAgent.SettingsKey.GetValue(RegistryAgent.KEY_LAST_MUSIC_DATABASE).ToString();
            }
            set
            {
                RegistryAgent.SettingsKey.SetValue(RegistryAgent.KEY_LAST_MUSIC_DATABASE, value);
            }
        }
        
        public static bool IsKaraFunInstalled
        {
            get { return null != Registry.ClassesRoot.OpenSubKey("KaraFun.File\\Shell\\Enqueue\\Command", false); }
        }

        public static string KaraFunExecutablePath
        {
            get
            {
                if (RegistryAgent.IsKaraFunInstalled)
                {
                    string[] theCommand =
                        RegistryAgent.KaraFunPlayCommand
                            .Split(new Char[] { '"' }, 3, StringSplitOptions.RemoveEmptyEntries);

                    return theCommand[0];
                }
                return String.Empty;
            }
        }
        
        public static string KaraFunEnqueueCommand
        {
            get
            {
                if (RegistryAgent.IsKaraFunInstalled)
                {

                    return Registry.ClassesRoot.OpenSubKey("KaraFun.File\\Shell\\Enqueue\\Command", false)
                        .GetValue("").ToString();
                }
                return String.Empty;
            }
        }
        
        public static string KaraFunPlayCommand
        {
            get
            {
                if (RegistryAgent.IsKaraFunInstalled)
                {
                    return Registry.ClassesRoot.OpenSubKey("KaraFun.File\\Shell\\Play\\Command", false)
                        .GetValue("").ToString();
                }
                return String.Empty;
            }
        }
        #endregion
    }
}
