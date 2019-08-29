//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;
//using ModelsDAL;
//using ModelsDAL.Repositories;

//namespace MyWebApplication.Files
//{
//    public class DbFileProvider: IFileProvider
//    {
//        private BinaryFileContentRepository binaryFileContentRepository
//        {
//            this.binaryFileContentRepository = binaryFileContentRepository;
//        }
//        public string Name => "Database";

//        string IFileProvider.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//        public Stream Load(BinaryFile file)
//        {
//            var content = binaryFileContentRepository.GetByBinaryFile(file);
//            if (content == null || content.Content == null)
//            {
//                return null
//            }
//            var memoryStream = new MemoryStream();
//            memoryStream.Write(content.Content, 0, content.Content.Length);
//            return memoryStream;
//        }
//        public Stream Save(BinaryFile file, Stream content)
//        {
//            var contentf = new BinaryFileContent
//            {
//                //
//            }
//        }

//        void IFileProvider.Save(BinaryFile file, Stream content)
//        {
//            throw new NotImplementedException();
//        }

//        Stream IFileProvider.Load(BinaryFile file)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}