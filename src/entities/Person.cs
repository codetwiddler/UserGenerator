using System;

namespace UserGenerator.Entities
{
    public class Person
    {
        public Guid Id { get;  set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string MarkerWordOne { get; set; }
        public string MarkerWordTwo { get; set; }
        public bool MarkedForDelete { get; set; }
    }
}