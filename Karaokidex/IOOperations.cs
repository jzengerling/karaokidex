using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Checksums;

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

        public static long CalculateCRC32(
            string theFileName)
        {
            using (FileStream theFileStream = File.OpenRead(theFileName))
            {
                Crc32 theCRC32Provider = new Crc32();

                byte[] theBuffer = new byte[theFileStream.Length];

                theFileStream.Read(theBuffer, 0, theBuffer.Length);

                theCRC32Provider.Reset();

                theCRC32Provider.Update(theBuffer);

                return theCRC32Provider.Value;
            }
        }
    }
}
