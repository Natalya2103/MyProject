using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Document
    {
        public string DocumentType { get; set; }
        public DateTime CreateDate { get; set; }
        public User Author { get; set; }
        public Folder Folder { get; set; }
    }
    public class DocumentMap : ClassMap<Document>
    {
        public DocumentMap()
        {
            Map(u => u.DocumentType).Length(50);
            Map(u => u.CreateDate);
            HasOne(u => u.Author);
            HasOne(u => u.Folder);
        }
    }
}
