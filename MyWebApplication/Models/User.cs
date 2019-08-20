using FluentNHibernate.Mapping;
using System;

namespace Models
{
    public class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
        public UserGroup Group { get; set; }
    }

    public class UserMap : ClassMap<User> 
    {
        public UserMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100L"); 
            Map(u => u.FIO).Length(100);
            Map(u => u.Login).Length(30);
            Map(u => u.Password).Length(30);
            HasOne(u => u.Group);
        }
    }
}
