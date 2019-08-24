using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsDAL;
using ModelsDAL.Filters;
using NHibernate;
using NHibernate.Criterion;

namespace ModelsDAL.Repositories
{
    [Repository]
    public class UserRepository : Repository<User, UserFilter>
    {
        public UserRepository(ISession session) 
            : base(session)
        {
        }
        public bool Exists(string login)
        {
            var crit = session.CreateCriteria<User>()
                .Add(Restrictions.Eq("Login", login))
                .SetProjection(Projections.Count("Id"));
            var count = Convert.ToInt64(crit.UniqueResult());
            return count > 0;
        }
        public IList<User> GeAvgAgeUsers()
        {
            var crit = session.CreateCriteria<User>();
            var detachCriteria = DetachedCriteria.For<User>() //подзапрос
                .SetProjection(Projections.Avg("Age"));
            crit.Add(Subqueries.PropertyGe("Age", detachCriteria));
            return crit.List<User>();
        }
        protected override void SetupFilter(ICriteria crit, UserFilter filter)
        {
            base.SetupFilter(crit, filter);
            if (!string.IsNullOrEmpty(filter.Login))
            {
                crit.Add(Restrictions.Eq("Login", filter.Login));
            }
            if (!string.IsNullOrEmpty(filter.FIO))
            {
                crit.Add(Restrictions.InsensitiveLike("FIO", filter.FIO, MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(filter.Email))
            {
                crit.Add(Restrictions.Eq("Email", filter.Email));
            }
            
            if (filter.CreationDate.From.HasValue)
             {
                 crit.Add(Restrictions.Ge("CreationDate", filter.CreationDate.From.Value));
             }
             if (filter.CreationDate.To.HasValue)
             {
                 crit.Add(Restrictions.Le("CreationDate", filter.CreationDate.To.Value));
             }

            if (filter.Age.From.HasValue)
            {
                crit.Add(Restrictions.Ge("Age", filter.Age.From.Value));
            }
            if (filter.Age.To.HasValue)
            {
                crit.Add(Restrictions.Le("Age", filter.Age.To.Value));
            }

            if (filter.CreationAuthor != null && filter.CreationAuthor.Count >0)
            {
                crit.Add(Restrictions.In("CreationAuthor", filter.CreationAuthor.ToArray()));
            }

        }
    }
}
