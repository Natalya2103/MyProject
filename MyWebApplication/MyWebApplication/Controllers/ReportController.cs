using ModelsDAL;
using ModelsDAL.Filters;
using ModelsDAL.Repositories;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    public class ReportController : Controller
    {
        private FolderRepository folderRepository;

        public ReportController(FolderRepository folderRepository) : base()
        {
            this.folderRepository = folderRepository;
        }

        // GET: Report
        public ActionResult Statistics()
        {
            var dateBegin = DateTime.Now.AddDays(-DateTime.Now.Day + 1);//.AddMonths(-1);
            var dateEnd = DateTime.Now;
            IList<Folder> folders = GetFolders(dateBegin, dateEnd);
            ReportModel model = CreateModel(folders, dateBegin, dateEnd);
            return View(model);
        }

        private static ReportModel CreateModel(IList<Folder> folders, DateTime dateBegin, DateTime dateEnd)
        {
            return new ReportModel
            {
                FolderCount = folders.Where(x => !(x is Document)).Count(),
                DocumentCount = folders.Where(x => (x is Document)).Count(),
                DocumentTotalSize = folders.Where(x => (x is Document))
                                           .Cast<Document>()
                                           .Sum(x => x.DocumentFile != null ? x.DocumentFile.Length : 0),
                DateFrom = dateBegin,
                DateTo = dateEnd
            };
        }

        private IList<Folder> GetFolders(DateTime dateBegin, DateTime dateEnd)
        {
            return folderRepository.FindAll(
                                new FolderFilter
                                {
                                    CreationDate = new Range<DateTime>()
                                    { From = dateBegin, To = dateEnd }
                                });
        }

        [HttpPost]
        public ActionResult Statistics(ReportModel model)
        {
            var dateBegin = model.DateFrom ?? DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            var dateEnd = model.DateTo ?? DateTime.Now;
            IList<Folder> folders = GetFolders(dateBegin, dateEnd);
            ReportModel newModel = CreateModel(folders, dateBegin, dateEnd);
            return View(newModel);
        }
    }
}