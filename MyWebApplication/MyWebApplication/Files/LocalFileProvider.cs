//using ModelsDAL;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Web;

//namespace MyWebApplication.Files
//{
//    public class LocalFileProvider: IFileProvider
//    {
//        private string GetRootPath()
//        {
//            var rootKey = ConfigurationManager.AppSettings["FileProvider.LocalPath"];
//            if (string.IsNullOrWhiteSpace(rootKey) || !Directory.Exists(rootKey))
//            {
//                throw new Exception("Не задана локальная папка хранения для файлов");
//            }
//            return rootKey;
//        }

//        private string GetFileName(BinaryFile file)
//        {
//            var ext = Path.GetExtension(file.Name);
//            return $"{file.Id}.{ext}";
//        }
//        public string Name => "Local";
//        public Stream Load(BinaryFile file)
//        {
//            var root = GetRootPath();
//            var fileName = GetFileName(file);
//            var stream = new FileStream(Path.Combine(root, fileName), FileMode.Open);
//            return stream;
//        }
//        public void Stream Save(BinaryFile file)
//        {
//            var root = GetRootPath();
//            var fileName = GetFileName(file);
//            using (var stream = new FileStream(Path.Combine(root, fileName), FileMode.CreateNew))
//            {
//                content.CopyTo(stream);
//            }
//        }
//    }
//}