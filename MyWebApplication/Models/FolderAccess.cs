using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FolderAccess
    {
        public virtual long Id { get; set; }
        public virtual Folder Folder { get; set; }
        public virtual string Permission { get; set; }
        public virtual UserGroup UserGroup { get; set; }
        public virtual User User { get; set; }
    }

    public class FolderAccessMap : ClassMap<FolderAccess>
    {
        public FolderAccessMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100L");
            References(u => u.Folder).Cascade.Delete();
            Map(u => u.Permission).Length(100);
            References(u => u.UserGroup).Cascade.Delete();
            References(u => u.User).Cascade.Delete();
        }
    }
}
