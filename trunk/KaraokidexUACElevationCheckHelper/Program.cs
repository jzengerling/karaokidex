using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace KaraokidexUACElevationCheckHelper
{
    static class Program
    {
        static void Main(string[] args)
        {
            string theApplicationExecutable = 
                Environment.GetFolderPath(Environment.SpecialFolder.Programs) + 
                @"\www.ne0ge0.com\Karaokidex.appref-ms";
            
            Process.Start(theApplicationExecutable);
        }
    }
}
