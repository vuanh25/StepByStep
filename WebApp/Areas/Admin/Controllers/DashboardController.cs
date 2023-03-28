using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    public class DashboardController : KiemTraController
    {
        // GET: Admin/Dashboard
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult IndexAdmin() 
        {
            if (KiemTraDangNhapAdmin())
            {
                
                var user = db.Users.ToList();
                ViewBag.user = user.Count() ;

                var baitap = db.ChiTietBaiLuyens.ToList();
                ViewBag.baitap = baitap.Count();

                var khoahoc = db.KhoaHocs.ToList();
                ViewBag.khoahoc = khoahoc.Count;

                return View();
            }
            return RedirectToAction("Login", "User");
        }

       
    }
}