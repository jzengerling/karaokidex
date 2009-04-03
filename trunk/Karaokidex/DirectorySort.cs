using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace Karaokidex
{
    public class DirectorySort : IComparer
    {
        public int Compare(object x, object y)
        {
            DirectoryInfo d1 = x as DirectoryInfo;
            DirectoryInfo d2 = y as DirectoryInfo;
            return d1.Name.CompareTo(d2.Name);
        }
    }
}
