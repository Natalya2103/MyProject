using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class UserGroup
    {
        public long Id { get; set; }
        public string GroupName { get; set; }
        public User[] Users { get; set; }
    }

    public class UserGroupMap : ClassMap<UserGroup> 
    {
        public UserGroupMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100L"); 
            Map(u => u.GroupName).Length(100);
            HasMany(u => u.Users);
        }
    }
}
