using System;
using System.Collections;

namespace UserGenerator.Entities
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
            MarkedForDelete = false;
            CreatedTimestamp = DateTime.Now;
        }

        public Guid Id { get;  set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string MarkerWord { get; set; }
        public bool MarkedForDelete { get; set; }

        public DateTime CreatedTimestamp { get; set; }
    }
}