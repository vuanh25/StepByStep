using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    public class BaiHocController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();




        public ActionResult Index(int? IdKhoaHoc, string search = "")
        {
            if (!string.IsNullOrEmpty(search))
            {
                var KhoaHoc1 = db.KhoaHocs.FirstOrDefault(p => p.TenKhoaHoc.Contains(search));
                if (KhoaHoc1 != null)
                {
                    ViewBag.Search = search;
                    var BaiHocss = db.BaiHocs.Where(p => p.IdKhoaHoc == KhoaHoc1.IDKhoaHoc).ToList();
                    ViewBag.NameKhoaHoc = KhoaHoc1.TenKhoaHoc;
                    return View(BaiHocss);
                }
            }
            else if (IdKhoaHoc.HasValue)
            {
                var KhoaHoc = db.KhoaHocs.FirstOrDefault(p => p.IDKhoaHoc == IdKhoaHoc.Value);
                if (KhoaHoc != null)
                {
                    ViewBag.NameKhoaHoc = KhoaHoc.TenKhoaHoc;
                    var BaiHocss = db.BaiHocs.Where(p => p.IdKhoaHoc == IdKhoaHoc.Value).ToList();
                    return View(BaiHocss);
                }
            }
            else
            {
                return View();
            }

            return RedirectToAction("Index");
        }




        [HttpPost]
        public JsonResult ListChiTietBaiHoc(int? idBaiHoc)
        {
            try
            {
                var listCTBaiHoc = (from l in db.ChiTietBaiHocs.Where(p => p.IdBaiHoc == idBaiHoc)
                                    select new
                                    {
                                        IdChiTietBaiHoc = l.IdChiTietBaiHoc,
                                        Noidung1 = l.NoiDung1,
                                        idBaiHoc = l.IdBaiHoc,
                                    }).ToList();
                return Json(new { code = 200, listCTBaiHoc = listCTBaiHoc, msg = idBaiHoc }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách bài học thất bại: " + ex.Message, JsonRequestBehavior.AllowGet });
                throw;
            }
        }








    }
}