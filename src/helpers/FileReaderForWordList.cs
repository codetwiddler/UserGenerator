using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserGenerator.Helpers
{
    class FileReaderForWordList
    {
        internal static IEnumerable<string> GetModifierWordList(string path)
        {

            // I just don't want contractions. This may impact some unusual words?
            Console.WriteLine("Looking for wordlist at: " + path);

            IEnumerable<string> linesLambda = File.ReadLines(path).Where(line => !line.Contains(@"'") );

            return linesLambda;

            //Could be reduced to this 
            //return File.ReadLines(path).Where(line => !line.Contains(@"'") );

        }
    }
}
