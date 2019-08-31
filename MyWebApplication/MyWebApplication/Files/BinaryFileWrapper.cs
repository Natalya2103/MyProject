using ModelsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApplication.Files
{
    public class BinaryFileWrapper
    {
        public BinaryFile BinaryFile { get; set; }

        public HttpPostedFileBase PostedFile { get; set; }
    }
}
