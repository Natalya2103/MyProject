using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Folder
    {
        public long Id { get; set; }
        public string FolderName { get; set; }
        public Folder ParentFolder { get; set; }
    }

    public class FolderMap : ClassMap<Folder>
    {
        public FolderMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100L");
            Map(u => u.FolderName).Length(200);
            HasOne(u => u.ParentFolder);
        }
    }
}
