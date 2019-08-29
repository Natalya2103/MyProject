using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebApplication.Models;
using Microsoft.AspNet.Identity.Owin;

namespace MyWebApplication.Controllers
{
    public class AccountController : Controller
    {
        public SignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<SignInManager>(); }
        }

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Result == SignInStatus.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            SignInManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}