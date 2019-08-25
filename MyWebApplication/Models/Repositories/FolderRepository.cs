using ModelsDAL.Filters;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL.Repositories
{
    [Repository]
    public class FolderRepository : Repository<Folder, FolderFilter>
    {
        public FolderRepository(ISession session)
            : base(session)
        {
        }
        public bool Exists(string folderName)
        {
            var crit = session.CreateCriteria<Folder>()
                .Add(Restrictions.Eq("FolderName", folderName))
                .SetProjection(Projections.Count("Id"));
            var count = Convert.ToInt64(crit.UniqueResult());
            return count > 0;
        }

        protected override void SetupFilter(ICriteria crit, FolderFilter filter)
        {
            base.SetupFilter(crit, filter);
            if (!string.IsNullOrEmpty(filter.FolderName))
            {
                crit.Add(Restrictions.Eq("FolderName", filter.FolderName));
            }
            if (filter.ParentFolderId.HasValue)
            {
                crit.Add(Restrictions.Eq("ParentFolder.Id", filter.ParentFolderId));
            }
            else
            {
                crit.Add(Restrictions.IsNull("ParentFolder.Id"));
            }
        }
    }
}
