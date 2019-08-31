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
            var folders = folderRepository.FindAll(
                                new FolderFilter
                                        {
                                            CreationDate = new Range<DateTime>()
                                            { From = dateBegin, To = DateTime.Now }
                                        }
                                );
            var model = new ReportModel
            {
                FolderCount = folders.Where(x => !(x is Document)).Count(),
                DocumentCount = folders.Where(x => (x is Document)).Count(),
                DocumentTotalSize = folders.Where(x => (x is Document))
                                           .Cast<Document>()
                                           .Sum(x => x.DocumentFile != null ? x.DocumentFile.Length : 0)
            };
            return View(model);
        }
    }
}