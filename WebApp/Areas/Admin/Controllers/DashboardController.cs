using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace WebApp.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        [Authorize]
        public ActionResult Index()
        {
           
            if (Equals( User.Identity.Name, "admin@gmail.com"))
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}