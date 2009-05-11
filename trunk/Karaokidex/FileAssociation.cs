using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Karaokidex
{
    public abstract class FileAssociation
    {
        [DllImport("Shlwapi.dll", SetLastError = true, CharSet=CharSet.Auto)]
        static extern uint AssocQueryString(
            AssocF flags, 
            AssocStr str, 
            string pszAssoc, 
            string pszExtra, 
            [Out] StringBuilder pszOut, 
            [In][Out] ref uint pcchOut);

        public static string Get(
            string theExtension)
        {
            try
            {
                uint pcchOut = 0;
                AssocQueryString(
                    AssocF.Verify, 
                    AssocStr.Executable, 
                    theExtension,
                    null, 
                    null, 
                    ref pcchOut);
                
                StringBuilder pszOut = new StringBuilder((int)pcchOut);

                AssocQueryString(
                    AssocF.Verify, 
                    AssocStr.Executable, 
                    theExtension,
                    null, 
                    pszOut, 
                    ref pcchOut);
                
                string theExecutable = pszOut.ToString();

                if (theExecutable.Contains("shell32.dll"))
                {
                    return String.Empty;
                }
                return theExecutable;
            }
            catch
            {
                throw;
            }
        }
    }

    [Flags]
    public enum AssocF
    {
        Init_NoRemapCLSID = 0x1,
        Init_ByExeName = 0x2,
        Open_ByExeName = 0x2,
        Init_DefaultToStar = 0x4,
        Init_DefaultToFolder = 0x8,
        NoUserSettings = 0x10,
        NoTruncate = 0x20,
        Verify = 0x40,
        RemapRunDll = 0x80,
        NoFixUps = 0x100,
        IgnoreBaseClass = 0x200
    }

    public enum AssocStr
    {
        Command = 1,
        Executable,
        FriendlyDocName,
        FriendlyAppName,
        NoOpen,
        ShellNewValue,
        DDECommand,
        DDEIfExec,
        DDEApplication,
        DDETopic
    }
}