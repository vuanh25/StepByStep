using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using PagedList.Mvc;
using PagedList;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    public class LuyenCodeController : KiemTraController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: LuyenCode
        public ActionResult Index(int? page)
        {

            if (page == null) page = 1;
            var BaiTap = (from s in db.LuyenTaps select s).OrderBy(m => m.Id);
            int pageSize = 20;
            int pageNum = page ?? 1;
            return View(BaiTap.ToPagedList(pageNum, pageSize));
        }

        
        
        public ActionResult ChiTiet(int? id)
        {
            if (KiemTraDangNhap())
            {

                var baiviet = db.LuyenTaps.Where(m => m.Id == id).First();
                baiviet.LuotXem++;
                UpdateModel(baiviet);
                db.SaveChanges();
                ViewBag.TenBaiLuyen = baiviet.TenLuyenTap;
                var BT = db.ChiTietBaiLuyens.Where(a => a.Id == id);
                return View(BT);

                if (item.Id == id)
                {
                        item.LuotXem++;
                        UpdateModel(item);
                        db.SaveChanges();
                        ViewBag.TenBaiLuyen = item.TenLuyenTap;
                }

            }
            return RedirectToAction("Login", "User");
        }

        

    }
    public class ChiTietBaiHocController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

    }
}