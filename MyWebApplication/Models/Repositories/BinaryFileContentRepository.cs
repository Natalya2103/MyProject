//using ModelsDAL.Filters;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ModelsDAL.Repositories
//{
//    public class BinaryFileContentRepository: Repository<BinaryFile, BinaryFileFilter>
//    {
//        public BinaryFileRepository(ISession session) : base(session)
//        {
//        }
//        public BinaryFileContent GetByBinaryFile(BinaryFile file)
//        {
//            var crit = sesion.CreateCriteria<BinaryFileContent>()
//                .Add(Restrictions.Eq("BinaryFile", file));
//            return crit.UniqueResult<BinaryFile>();
//        }
//    }
//}