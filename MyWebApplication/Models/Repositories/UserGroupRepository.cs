﻿using Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    [Repository]
    public class UserGroupRepository : Repository<UserGroup>
    {
        public UserGroupRepository(ISession session)
            : base(session)
        {
        }

        public IList<UserGroup> GetList()
        {
            return session.CreateCriteria<UserGroup>().List<UserGroup>();
        }

        public UserGroup Get(long userGroupId)
        {
            return session.Get<UserGroup>(userGroupId);
        }

    }
}