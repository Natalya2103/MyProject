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
    public class FolderController : Controller
    {
        private FolderRepository folderRepository;

        public FolderController(FolderRepository folderRepository)
        {
            this.folderRepository = folderRepository;
        }
        // GET: Folder
        public ActionResult Create()
        {
            var model = new FolderModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FolderModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var folder = new Folder
            {
                FolderName = model.FolderName
            };
            folderRepository.Save(folder);
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult List(FolderFilter filter)
        {
            var model = new FolderListModel
            {
                Items = folderRepository.Find(filter)
            };
            return View(model);
        }
    }
}