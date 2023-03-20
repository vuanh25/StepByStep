using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BaiHocController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: BaiHoc
        public ActionResult Index(int? IdKhoaHoc)
        {
            var BaiHocss = db.BaiHocs.Where(p => p.IdKhoaHoc == IdKhoaHoc ).ToList();
            var KhoaHoc = db.KhoaHocs.Where(p => p.IDKhoaHoc == IdKhoaHoc).ToList();
            foreach (var item in KhoaHoc)
            {
                ViewBag.NameKhoaHoc = item.TenKhoaHoc;
            }
            return View(BaiHocss);
        }



        /* public ActionResult BaiHoc(int id)
         {
             ViewBag.IdBaiHoc = id;
             foreach (var item in db.BaiHocs.ToList())
             {
                 if (item.IdBaiHoc == id)
                 {
                     return View(id);
                 }
             }
         }*/
    }
}