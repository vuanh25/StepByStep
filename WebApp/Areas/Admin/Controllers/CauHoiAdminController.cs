using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    public class CauHoiAdminController : KiemTraController
    {
        // GET: Admin/CauHoi
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
        public JsonResult DsCauHoi()
        {
            try
            {
                //    var ds = db.BaiViets
                //        .Where(b => b.IdBaiViet > 0)
                //        .Include(b => b.User);

                var ds = (from cauhoi in db.CauHois.Where(x => x.IdCauHoi != 0) // Laays danh sach
                          select new
                          {
                              IdBaiViet = cauhoi.IdCauHoi,
                              TieuDe = cauhoi.TieuDe,
                              LuotXem = cauhoi.LuotXem,
                              NgayDang = cauhoi.NgayDang.ToString(),
                              NgonNgu = cauhoi.NgonNgu.ToString()
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
                    .Where(m => m.CauHoi.IdCauHoi == id)
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
                var cauhoi = db.CauHois.SingleOrDefault(x => x.IdCauHoi == id);

                if (cauhoi != null)
                {
                    var listPhanHoi = db.PhanHois.Where(p => p.CauHoi.IdCauHoi == id).ToList();
                    db.PhanHois.RemoveRange(listPhanHoi);
                    db.CauHois.Remove(cauhoi);
                }

                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa câu hỏi thành công!" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Xóa câu hỏi thất bại!" + e.Message }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        [HttpGet]
        public JsonResult Details(int id)
        {
            try
            {

                var cauhoi = db.CauHois.SingleOrDefault(x => x.IdCauHoi == id);

                return Json(new { code = 200, cauhoi = cauhoi, msg = "Lấy thông tin thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy thông tin thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }
    }
}