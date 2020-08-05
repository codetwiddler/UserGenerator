using System;
using System.Collections;

namespace UserGenerator.Entities
{
    public class Person
    {
        public Guid Id { get;  set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string MarkerWord { get; set; }
        public bool MarkedForDelete { get; set; }
    }
}