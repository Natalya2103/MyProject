using FluentNHibernate.Mapping;
using System;

namespace Models
{
    public class User
    {
        public virtual long Id { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string FIO { get; set; }
        public virtual UserGroup Group { get; set; }
    }

    public class UserMap : ClassMap<User> 
    {
        public UserMap()
        {
            //Table("TableUser");
            Id(u => u.Id).GeneratedBy.HiLo("100L"); 
            Map(u => u.FIO).Length(100);
            Map(u => u.Login).Length(30);
            Map(u => u.Password).Length(500);
            References(u => u.Group).Cascade.SaveUpdate();
        }
    }
}
