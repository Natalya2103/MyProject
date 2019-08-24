using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL
{
    public class UserGroup
    {
        public virtual long Id { get; set; }
        public virtual string GroupName { get; set; }
       // public User[] Users { get; set; }
        public virtual IList<User> Users { get; set; }
        
    }

    public class UserGroupMap : ClassMap<UserGroup> 
    {
        public UserGroupMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100L");
            Map(u => u.GroupName).Length(100);
            HasMany(u => u.Users).Inverse();
        }
    }
}
