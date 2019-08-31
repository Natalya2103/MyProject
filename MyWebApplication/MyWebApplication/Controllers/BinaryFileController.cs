using ModelsDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    public class BinaryFileController : BaseController
    {

        private BinaryFileRepository binaryFileRepository;

        public BinaryFileController(BinaryFileRepository binaryFileRepository)
        {
            this.binaryFileRepository = binaryFileRepository;
        }

        public ActionResult Download(long id)
        {
            var binaryFile = binaryFileRepository.Load(id);
            var stream = GetFileProvider().Load(binaryFile);
            if (stream == null)
            {
                return new EmptyResult();
            }
            return File(stream, binaryFile.ContentType, binaryFile.Name);
        }
    }
}