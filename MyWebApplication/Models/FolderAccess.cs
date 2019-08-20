using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FolderAccess
    {
        public Folder Folder { get; set; }
        public string Permission { get; set; }
        public UserGroup UserGroup { get; set; }
        public User User { get; set; }
    }

    public class FolderAccessMap : ClassMap<FolderAccess>
    {
        public FolderAccessMap()
        {
            HasOne(u => u.Folder);
            Map(u => u.Permission).Length(100);
            HasOne(u => u.UserGroup);
            HasOne(u => u.User);
        }
    }
}
