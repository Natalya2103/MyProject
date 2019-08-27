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
    public class UserController : Controller
    {
        private UserRepository userRepository;
        private UserGroupRepository userGroupRepository;

        public UserController(UserRepository userRepository, UserGroupRepository userGroupRepository)
        {
            this.userRepository = userRepository;
            this.userGroupRepository = userGroupRepository;
        }
       
        // GET: User
        public ActionResult Create()
        {
            var model = new UserModel();
            GetUserGroupSelectList();
            return View(model);
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
                GetUserGroupSelectList();
                return View(model);
            }

            var user = new User
            {
                FIO = model.FIO,
                Login = model.Login,
                Password = model.Password,
                UserGroup = userGroupRepository.Get(Convert.ToInt64(model.UserGroup)) ?? null,
                CreationDate = DateTime.Now,
                Age = model.Age,
                Email = model.Email,
                Avatar = model.Avatar != null && model.Avatar.InputStream != null
                            ? model.Avatar.InputStream.ToByteArray()
                            : null
            };
            userRepository.Save(user);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult List(UserFilter filter, FetchOptions fetchOptions)
        {
            var model = new UserListModel
            {
                Items = userRepository.Find(filter, fetchOptions)
            };
            return View(model);
        }
        public ActionResult GetAvatar(long id)
        {
            var user = userRepository.Load(id);
            return File(user.Avatar, "application/octet-stream", $"{user.Login}.jpeg");
        }
    }
}