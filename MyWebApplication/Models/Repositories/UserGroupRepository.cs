using ModelsDAL;
using ModelsDAL.Filters;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDAL.Repositories
{
    [Repository]
    public class UserGroupRepository : Repository<UserGroup, UserGroupFilter>
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

        public bool Exists(string groupName)
        {
            var crit = session.CreateCriteria<UserGroup>()
                .Add(Restrictions.Eq("GroupName", groupName))
                .SetProjection(Projections.Count("Id"));
            var count = Convert.ToInt64(crit.UniqueResult());
            return count > 0;
        }
    }
}
