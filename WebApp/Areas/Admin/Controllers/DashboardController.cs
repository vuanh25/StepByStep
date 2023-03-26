using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using WebApp.Controllers;

namespace WebApp.Areas.Admin.Controllers
{
    public class DashboardController : KiemTraController
    {
        // GET: Admin/Dashboard
        [Authorize]
        public ActionResult Index()
        {
            if (KiemTraDangNhapAdmin())
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }
    }
}