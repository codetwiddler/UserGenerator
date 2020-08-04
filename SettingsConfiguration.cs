using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserGenerator
{
    public class SettingsConfiguration
    {
        public string AccountName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string DefaultConnection { get; set; }
        public string WordListFilePath { get; set; }
        public string NameFirstFilePath { get; set; }
        public string NameLastFilePath { get; set; }
    }
}
