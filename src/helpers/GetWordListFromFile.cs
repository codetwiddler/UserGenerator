using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserGenerator.Helpers
{
    class GetWordListFromFile
    {
        internal static IEnumerable<string> GetModifierWordList(string path)
        {
            Console.WriteLine("Looking for wordlist at: " + path);

            // I just don't want contractions. This may impact some unusual words?
            IEnumerable<string> linesLambda = File.ReadLines(path).Where(line => !line.Contains(@"'") );

            return linesLambda;

            //Could be reduced to this 
            //return File.ReadLines(path).Where(line => !line.Contains(@"'") );
        }
    }
}
