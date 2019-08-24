using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL
{
    public class DocumentVersion
    {
        public virtual long Id { get; set; }
        public virtual byte[] FileContent { get; set; }
        public virtual User Author { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual Document Document {get; set;}
    }

    public class DocumentVersionMap : ClassMap<DocumentVersion>
    {
        public DocumentVersionMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100L");
            Map(u => u.FileContent).Length(200);
            References(u => u.Author).Cascade.SaveUpdate();
            Map(u => u.CreateDate);          
            References(u => u.Document).Cascade.SaveUpdate();
        }
    }
}
