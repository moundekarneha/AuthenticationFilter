using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationFilter.Models;
using System.Web.Security;

namespace AuthenticationFilter.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User model)
        {
            if (model.Username=="user" && model.Pass == "user")
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return RedirectToAction("Index", "Home"); //home controller index
            }
            return View();
        }

    }
}