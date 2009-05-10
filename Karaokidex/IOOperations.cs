using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Karaokidex
{
    public static class IOOperations
    {
        public static string GetMD5HashFromFile(
            string theFileName)
        {
            if (File.Exists(theFileName))
            {
                using (MD5 theMD5Provider = new MD5CryptoServiceProvider())
                {
                    using (FileStream theFileStream = new FileStream(theFileName, FileMode.Open))
                    {
                        byte[] theChecksum = theMD5Provider.ComputeHash(theFileStream);

                        theFileStream.Close();

                        return BitConverter.ToString(theChecksum).Replace("-", "");
                    }
                }
            }
            return String.Empty;
        }
    }
}
