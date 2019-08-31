using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ModelsDAL;
using ModelsDAL.Filters;
using ModelsDAL.Repositories;
using MyWebApplication.Files;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private UserRepository userRepository;
        private UserGroupRepository userGroupRepository;

        public UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
        }

        public UserController(UserRepository userRepository, UserGroupRepository userGroupRepository): base()
        {
            this.userRepository = userRepository;
            this.userGroupRepository = userGroupRepository;
        }

        public ActionResult Create()
        {
            var model = new UserModel();
            return ReturnView(model);
        }

        private void GetUserGroupSelectList()
        {
            SelectList list = new SelectList(userGroupRepository.GetList(), "Id", "GroupName");
            ViewBag.UserGroupList = list;
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return ReturnView(model);
            }

            var user = new User
            {
                FIO = model.FIO,
                Age = model.Age,
                UserName = model.UserName,
                Email = model.Email,
                CreationDate = DateTime.Now,
                BirthDate = model.BirthDate,
                CreationAuthor = GetCurrentUser(),
                UserGroup = userGroupRepository.Get(Convert.ToInt64(model.UserGroup)) ?? null,
                AvatarFile = model.Avatar != null ? model.Avatar.BinaryFile : null
            };
            var res = UserManager.CreateAsync(user, model.Password);
            if (res.Result == IdentityResult.Success)
            {
                if (model.Avatar != null)
                {
                    GetFileProvider().Save(model.Avatar.BinaryFile, model.Avatar.PostedFile.InputStream);
                }
                return RedirectToAction("List");
            }
            return ReturnView(model);
        }

        private ActionResult ReturnView(UserModel model)
        {
            GetUserGroupSelectList();
            return View(model);
        }

        public ActionResult List(UserFilter filter)
        {
            var model = new UserListModel
            {
                Items = userRepository.Find(filter)
            };
            return View(model);
        }

        public ActionResult Details(long id)
        {
            var user = userRepository.Load(id);
            var model = new UserModel
            {
                Entity = user,
                Age = user.Age,
                Avatar = new BinaryFileWrapper
                {
                    BinaryFile = user.AvatarFile
                },
                BirthDate = user.BirthDate,
                Email = user.Email,
                FIO = user.FIO,
                UserName = user.UserName,
                CreationAuthor = user.CreationAuthor
            };
            return View(model);
        }
    }
}