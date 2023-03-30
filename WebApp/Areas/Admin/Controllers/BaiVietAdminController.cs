using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.Models.Enums;

namespace WebApp.Areas.Admin.Controllers
{
    public class BaiVietAdminController : KiemTraController
    {
        // GET: Admin/BaiViet
        private ApplicationDbContext db = new ApplicationDbContext();

        //[Authorize]

        public ActionResult Index()
        {
            if (KiemTraDangNhapAdmin())
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public JsonResult DsBaiViet()
        {
            try
            {
            //    var ds = db.BaiViets
            //        .Where(b => b.IdBaiViet > 0)
            //        .Include(b => b.User);

                var ds = (from baiviet in db.BaiViets.Where(x => x.IdBaiViet != 0) // Laays danh sach
                          select new
                          {
                              IdBaiViet = baiviet.IdBaiViet,
                              TieuDe = baiviet.TieuDe,
                              LuotXem = baiviet.LuotXem,
                              LuotThich =baiviet.LuotThich,
                              NgayDang = baiviet.NgayDang.ToString(),
                              NgonNgu = baiviet.NgonNgu.ToString()
                          }).ToList();

                return Json(new { code = 200, ds = ds }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Loi!" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public JsonResult DsPhanHoi(int id)
        {
            try
            {
                var phanHois = db.PhanHois
                    .Where(m => m.BaiViet.IdBaiViet == id)
                    .Include(m => m.User)
                    .OrderByDescending(m => m.NgayDang)
                    .ToList();
                dynamic data = new { code = 200, sophanhoi = phanHois.Count, ds = phanHois };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Loi!" + ex.Message }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        [HttpDelete]
        public JsonResult Xoa(int id)
        {
            try
            {
                var baiviet = db.BaiViets.SingleOrDefault(x => x.IdBaiViet == id);

                if (baiviet != null)
                {
                    var listPhanHoi = db.PhanHois.Where(p => p.BaiViet.IdBaiViet == id).ToList();
                    db.PhanHois.RemoveRange(listPhanHoi);
                    db.BaiViets.Remove(baiviet);
                }

                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa bài viết thành công!" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Xóa bài viết thất bại!" + e.Message }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        [HttpGet]
        public JsonResult Details(int id)
        {
            try
            {

                var baiviet = db.BaiViets.SingleOrDefault(x => x.IdBaiViet == id);

                return Json(new { code = 200, baiviet = baiviet, msg = "Lấy thông tin thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy thông tin thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }
    }
}