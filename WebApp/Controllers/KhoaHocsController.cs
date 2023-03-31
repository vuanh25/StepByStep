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
    public class KhoaHocsController : KiemTraController
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

        public ActionResult DKKhoaHoc(string id)
        {
            if (KiemTraDangNhap())
            {

                var user = db.Users.Where(p => p.TenUser == id).First();
                var muakhoahoc = db.MuaKhoaHocs.Where(x => x.IdUser == user.IdUser).ToList();
                foreach (var item in muakhoahoc)
                {
                    if (item.IdKhoaHoc == 9)
                    {
                        ViewBag.ThongBao = "Đã mua";
                    }
                    else
                        ViewBag.ThongBao = "";
                }
                return View(/*muakhoahoc*/);


            }
            return RedirectToAction("Login", "User");


        }






    }
}