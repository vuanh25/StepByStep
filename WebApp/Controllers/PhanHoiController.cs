using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Entities;
using WebApp.Models;
using System.Data.Entity;

namespace WebApp.Controllers
{
    public class PhanHoiController : Controller
    {
        // GET: PhanHoi
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public JsonResult DsPhanHoiBaiViet(int id)
        {
            try
            {
                var phanHois = db.PhanHois
                    .Where(m => m.BaiViet.IdBaiViet == id)
                    .Include(m => m.User)
                    .OrderByDescending(m=>m.NgayDang)
                    .ToList();
                dynamic data = new { code = 200, sophanhoi=phanHois.Count,ds=phanHois};
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        [HttpPost]
        public JsonResult DsPhanHoiCauHoi(int id)
        {
            try
            {
                var phanHois = db.PhanHois
                    .Where(m => m.CauHoi.IdCauHoi == id)
                    .Include(m => m.User)
                    .OrderByDescending(m=>m.NgayDang) 
                    .ToList();
                dynamic data = new { code = 200, sophanhoi = phanHois.Count, ds=phanHois };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        [HttpPost]
        public JsonResult ThemPhanHoiBaiViet(int id, string noidung)
        {
            try
            {
                if (Session["TenTaiKhoan"] == null || Session["TenTaiKhoan"].ToString() == "")
                    return Json(new { code = 300 }, JsonRequestBehavior.AllowGet);
                var tenuser = Session["TenTaiKhoan"].ToString();
                BaiViet baiViet = db.BaiViets.First(m => m.IdBaiViet == id);
                var user = db.Users.First(u => u.TenTaiKHoan == tenuser);

                PhanHoi phanHoi = new PhanHoi();
                phanHoi.NoiDung = noidung;
                phanHoi.NgayDang = DateTime.Now;
                phanHoi.User = user;
                phanHoi.BaiViet = baiViet;
                db.PhanHois.Add(phanHoi);
                db.SaveChanges();
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        [HttpPost]
        public JsonResult ThemPhanHoiCauHoi(int id, string noidung)
        {
            try
            {
                if (Session["TenTaiKhoan"] == null || Session["TenTaiKhoan"].ToString() == "")
                    return Json(new { code = 300 }, JsonRequestBehavior.AllowGet);
                var tenuser = Session["TenTaiKhoan"].ToString();
                CauHoi cauHoi = db.CauHois.First(m => m.IdCauHoi == id);
                var user = db.Users.First(u => u.TenTaiKHoan == tenuser);

                PhanHoi phanHoi = new PhanHoi();
                phanHoi.NoiDung = noidung;
                phanHoi.NgayDang = DateTime.Now;
                phanHoi.User = user;
                phanHoi.CauHoi = cauHoi;
                db.PhanHois.Add(phanHoi);
                db.SaveChanges();
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }
    }
}