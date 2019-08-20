using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class DocumentVersion
    {
        public long Id { get; set; }
        public string File { get; set; }
        public User Author { get; set; }
        public DateTime CreateDate { get; set; }
        public Document Document {get; set;}
    }

    public class DocumentVersionMap : ClassMap<DocumentVersion>
    {
        public DocumentVersionMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100L");
            Map(u => u.File).Length(200);
            HasOne(u => u.Author);
            Map(u => u.CreateDate);
            HasOne(u => u.Document);
        }
    }
}
