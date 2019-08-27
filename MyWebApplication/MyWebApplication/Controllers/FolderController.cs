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

        public ActionResult Create(long? parent)
        {
            var model = new FolderModel
            {
                ParentFolderId = parent
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FolderModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Folder parent = null;
            if (model.ParentFolderId.HasValue)
            {
                parent = folderRepository.Load(model.ParentFolderId.Value);
            }
            var folder = new Folder
            {
                FolderName = model.FolderName,
                ParentFolder = parent,
                CreationDate = DateTime.Now
            };
            folderRepository.Save(folder);
            return RedirectToAction("Index", new { parent = model.ParentFolderId });
        }
        
        public ActionResult Index(long? parent)
        {
            Folder parentFolder = null;
            if (parent.HasValue)
            {
                parentFolder = folderRepository.Load(parent.Value);
            }
            var model = new FolderListModel
            {
                Items = folderRepository.Find(new FolderFilter { ParentFolderId = parentFolder != null ? parentFolder.Id : (long?)null}),
                CurrentFolder = parentFolder,
                FolderParent = parentFolder != null ? parentFolder.ParentFolder : null
            };
            model.IsRootFolder = parent == null && model.FolderParent == null;
            return View("List", model);
        }
    }
}