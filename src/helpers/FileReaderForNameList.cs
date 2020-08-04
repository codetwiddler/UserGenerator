using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserGenerator.Helpers
{
    class FileReaderForNameList
    {
        internal static IEnumerable<string> GetNameList(string path)
        {
            return File.ReadLines(path);
        }
    }
}
