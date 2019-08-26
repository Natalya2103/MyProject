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
        public ActionResult Create(FolderFilter folderFilter)
        {
            var model = new FolderModel();
            if (folderFilter.ParentFolderId != null)
            {
                model.ParentFolderId = Convert.ToString(folderFilter.ParentFolderId);
            }
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
                FolderName = model.FolderName,
                ParentFolder = folderRepository.Load(Convert.ToInt64(model.ParentFolderId))
            };
            folderRepository.Save(folder);
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult List(FolderFilter filter)
        {
            var model = new FolderListModel
            {
                Items = folderRepository.Find(filter),
                FolderParentId = filter.ParentFolderId != null ? filter.ParentFolderId.ToString() : ""
            };
            return View(model);
        }
    }
}