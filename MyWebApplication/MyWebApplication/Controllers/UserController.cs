using Models;
using Models.Repositories;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
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
                Group = userGroupRepository.Get(Convert.ToInt64(model.UserGroup)) ?? null
            };
            userRepository.Save(user);
            return RedirectToAction("Index", "Home");
            //return View(model);
        }
    }
}