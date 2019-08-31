using ModelsDAL.Filters;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL.Repositories
{
    [Repository]
    public class BinaryFileContentRepository : Repository<BinaryFileContent, BinaryFileContentFilter>
    {
        public BinaryFileContentRepository(ISession session) : base(session)
        {
        }
        public BinaryFileContent GetByBinaryFile(BinaryFile file)
        {
            var crit = session.CreateCriteria<BinaryFileContent>()
                .Add(Restrictions.Eq("BinaryFile", file));
            return crit.UniqueResult<BinaryFileContent>();
        }
    }
}