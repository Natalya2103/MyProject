using ModelsDAL.Filters;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDAL.Repositories
{
    [Repository]
    public class DocumentRepository : Repository<Document, FolderFilter>
    {
        public DocumentRepository(ISession session) : base(session)
        {
        }
    }
}
