using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace KaraokidexUACElevationCheckHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            string appExe = 
                Environment.GetFolderPath(Environment.SpecialFolder.Programs) + 
                @"\www.ne0ge0.com\Karaokidex.appref-ms";
            Process.Start(appExe);
        }
    }
}
