using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelsDAL.Repositories;
using MyWebApplication.Models;

namespace MyWebApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
        
        }

        // GET: Home
        public ActionResult Index()
        {
            var model = new HomeModel 
            { 
                Title = "Крутое приложение!",
                Time = DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeModel model)
        { 
            model.Time = DateTime.Now;
            return View(model);
        }
    }
}