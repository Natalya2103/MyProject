using System;
using System.Collections.Generic;
using System.Text;
using ModelsDAL.Filters;
using NHibernate;

namespace ModelsDAL.Repositories
{
    [Repository]
    public class BinaryFileRepository : Repository<BinaryFile, BinaryFileFilter>
    {
        public BinaryFileRepository(ISession session) : base(session)
        {
        }
    }
}
