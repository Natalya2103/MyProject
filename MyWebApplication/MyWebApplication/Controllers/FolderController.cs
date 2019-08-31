using ModelsDAL;
using ModelsDAL.Filters;
using ModelsDAL.Repositories;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MyWebApplication.Controllers
{
    [Authorize]
    public class FolderController : BaseController
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
        
        public ActionResult Index(long? parent, FetchOptions fetchOptions)
        {
            Folder parentFolder = null;
            if (parent.HasValue)
            {
                parentFolder = folderRepository.Load(parent.Value);
            }
            var model = new FolderListModel
            {
                Items = folderRepository.Find(new FolderFilter { ParentFolderId = parentFolder != null ? parentFolder.Id : (long?)null}, fetchOptions),
                CurrentFolder = parentFolder,
                FolderParent = parentFolder != null ? parentFolder.ParentFolder : null
            };
            model.IsRootFolder = parent == null && model.FolderParent == null;
            return View("List", model);
        }

        public ActionResult CreateDocument(long? parent)
        {
            var model = new DocumentModel
            {
                ParentFolderId = parent
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateDocument(DocumentModel model)
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
            var folder = new Document
            {
                FolderName = model.DocumentName,
                ParentFolder = parent,
                CreationDate = DateTime.Now,
                DocumentFile = model.Data != null ? model.Data.BinaryFile : null,
                CreationAuthor = GetCurrentUser(),
                DocumentType = model.Data != null ? Path.GetExtension(model.Data.PostedFile.FileName) : null
            };
            if (model.Data != null)
            {
                GetFileProvider().Save(model.Data.BinaryFile, model.Data.PostedFile.InputStream);
            }
            folderRepository.Save(folder);
            return RedirectToAction("Index", new { parent = model.ParentFolderId });
        }
    }
}