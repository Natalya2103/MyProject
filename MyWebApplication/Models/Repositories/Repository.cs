using ModelsDAL.Filters;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDAL.Repositories
{
    public class Repository<T, F>
        where T: class
        where F: BaseFilter //только basefilter и его наследники
    {
        protected ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public virtual T Load(long id)
        {
            return session.Get<T>(id);
        }

        public virtual void Save(T entity)
        {
            using(var tran = session.BeginTransaction())
            {
                try
                {
                    session.Save(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
            }
        } 
        public virtual IList<T> Find (F filter)
        {
            var crit = session.CreateCriteria<T>();
            if (filter != null)
            {
                SetupFilter(crit, filter);
            }
            return crit.List<T>();
        }

        protected virtual void SetupFilter(ICriteria crit, F filter)
        {
            if (filter.Id.HasValue)
            {
                crit.Add(Restrictions.IdEq(filter.Id.Value));
            }
            if (!string.IsNullOrEmpty(filter.SearchString))
            {
                var properties = typeof(T).GetProperties();
                AbstractCriterion clause = null;
                foreach (var property in properties)
                {
                    var fs = property.GetCustomAttribute<FastSearchAttribute>();
                    if (fs == null)
                    {
                        continue;
                    }
                    AbstractCriterion like;
                    switch (fs.FieldType)
                    {
                        case FieldType.Int:
                            var proj = Projections
                                .Cast(NHibernateUtil.Int64,
                                        Projections.Property(property.Name));
                            like = Restrictions.InsensitiveLike(proj, filter.SearchString, MatchMode.Anywhere);
                            break;
                        default:
                            like = Restrictions.InsensitiveLike(property.Name, filter.SearchString, MatchMode.Anywhere);
                            break;
                    }
                    clause = clause == null ?
                        like :
                        Restrictions.Or(clause, like);
                }
                if (clause != null)
                {
                    crit.Add(clause);
                }
            }
        }
    }
}
