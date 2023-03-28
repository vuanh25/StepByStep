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


        public ActionResult Index(int? IdKhoaHoc)
        {
            var BaiHocss = db.BaiHocs.Where(p => p.IdBaiHoc == IdKhoaHoc).ToList();
            var KhoaHoc = db.KhoaHocs.Where(p => p.IDKhoaHoc == IdKhoaHoc).ToList();
            foreach (var item in KhoaHoc)
            {
                {
                    ViewBag.NameKhoaHoc = item.TenKhoaHoc;
                }
            }
            return View(BaiHocss);
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