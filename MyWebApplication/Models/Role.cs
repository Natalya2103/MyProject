using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL
{
    public class Role : UserGroup
    {
        public virtual string RoleName { get; set; }
    }
    public class RoleMap: SubclassMap<Role>
    {
        public RoleMap ()
        {
            Map(u => u.RoleName).Length(100);
        }
    }
}
