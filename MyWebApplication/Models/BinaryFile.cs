using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL
{
    public class BinaryFile
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ContentType { get; set; }
        public virtual long Length { get; set; }
    }
    public class BinaryFileMap: ClassMap<BinaryFile>
    {
        public BinaryFileMap()
        {
            Id(f => f.Id).GeneratedBy.HiLo("100");
            Map(f => f.Name).Length(255);
            Map(f => f.ContentType).Length(50);
            Map(f => f.Length).Length(255);
        }
    }
}
