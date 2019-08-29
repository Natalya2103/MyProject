//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ModelsDAL
//{
//    public class BinaryFileContent
//    {
//        public virtual long Id { get; set; }
//        public virtual BinaryFile BinaryFile { get; set; }
//        public virtual byte[] Content { get; set; }
//    }
//    public class BinaryFileContentMap: ClassMap<BinaryFileContent>
//    {
//        public BinaryFileContentMap()
//        {
//            Id(f => f.Id).GeneratedBy.HiLo("100");
//            Map(f => f.Content).Length(int.MaxValue);


//        }
//    }
//}
