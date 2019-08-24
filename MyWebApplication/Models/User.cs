using FluentNHibernate.Mapping;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ModelsDAL.Filters;

namespace ModelsDAL
{
    public class User
    {
        public virtual long Id { get; set; }

        [FastSearch]
        public virtual string Login { get; set; }

        [FastSearch]
        public virtual string FIO { get; set; }

        public virtual string Password { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual User CreationAuthor { get; set; }

        [FastSearch]
        public virtual string Email { get; set; }

        [FastSearch(FieldType = FieldType.Int)]
        public virtual int Age { get; set; }
        public virtual UserGroup UserGroup { get; set; }
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
            References(u => u.UserGroup).Cascade.SaveUpdate();
            Map(u => u.CreationDate);
            Map(u => u.Email);
            Map(u => u.Age);
            References(u => u.CreationAuthor).Cascade.SaveUpdate();
        }
    }
}
