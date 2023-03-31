using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{

    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            LayBaiTap();
            return View();
        }

        private void LayBaiTap()
        {
            var BT = db.LuyenTaps.ToList();

            Session["products"] = BT;

            var products = Session["products"] as List<LuyenCode>;
        }

        public ActionResult PageNotFound()
        {
            return View();
        }

       
    }
}