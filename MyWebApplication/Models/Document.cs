using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Document: Folder
    {
        public virtual string DocumentType { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual User Author { get; set; }
    }
    public class DocumentMap : SubclassMap<Document>
    {
        public DocumentMap()
        {
            Map(u => u.DocumentType).Length(50);
            Map(u => u.CreateDate);
            References(u => u.Author).Cascade.SaveUpdate();
        }
    }
}
