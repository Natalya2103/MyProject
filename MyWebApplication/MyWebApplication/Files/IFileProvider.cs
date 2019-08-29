using ModelsDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyWebApplication.Files
{
    public interface IFileProvider
    { 
        string Name { get; set; }
        void Save(BinaryFile file, Stream content);
        Stream Load(BinaryFile file);
    }
}