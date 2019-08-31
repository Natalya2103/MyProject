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
    [Authorize]
    public class UserGroupController : Controller
    {
        private UserGroupRepository userGroupRepository;

        public UserGroupController(UserGroupRepository userGroupRepository)
        {
            this.userGroupRepository = userGroupRepository;
        }
        // GET: User
        public ActionResult Create()
        {
            var model = new UserGroupModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(UserGroupModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userGroup = new UserGroup
            {
               GroupName = model.GroupName
            };
            userGroupRepository.Save(userGroup);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult List(UserGroupFilter filter)
        {
            var model = new UserGroupListModel
            {
                Items = userGroupRepository.Find(filter)
            };
            return View(model);
        }
    }
}