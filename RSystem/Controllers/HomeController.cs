using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSystem.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (User.IsInRole("Recruit"))
                return RedirectToAction("Index", "Home", new {area = "Recruit"});
            else if (User.IsInRole("Admin"))
                return RedirectToAction("Index", "Panel", new {area = "Admin"});
            return RedirectToAction("Login", "Account");
        }
    }
}