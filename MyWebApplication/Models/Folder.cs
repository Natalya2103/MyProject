using FluentNHibernate.Mapping;
using ModelsDAL.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL
{
    public class Folder
    {
        public virtual long Id { get; set; }
        [FastSearch]
        public virtual string FolderName { get; set; }
        public virtual Folder ParentFolder { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual User CreationAuthor { get; set; }
    }

    public class FolderMap : ClassMap<Folder>
    {
        public FolderMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100L");
            Map(u => u.FolderName).Length(200);
            References(u => u.ParentFolder).Cascade.SaveUpdate();
            Map(u => u.CreationDate);
            References(u => u.CreationAuthor);
        }
    }
}
