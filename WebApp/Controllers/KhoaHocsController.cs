using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    public class KhoaHocsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KhoaHocs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Genre()
        {
            var khoahocs = db.KhoaHocs.Take(3).ToList();
            return PartialView(khoahocs);
        }

        public ActionResult DKKhoaHoc (int id)
        {




        return View();
        }


    }
}
