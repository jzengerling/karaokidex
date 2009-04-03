using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace Karaokidex
{
    public class FileSort : IComparer
    {
        public int Compare(object x, object y)
        {
            FileInfo f1 = x as FileInfo;
            FileInfo f2 = y as FileInfo;
            return f1.Name.CompareTo(f2.Name);
        }
    }
}
