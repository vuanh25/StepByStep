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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListBaiHoc()
        {
            try
            {
                var listBaiHoc = db.BaiHocs.ToList();
                return Json(new { code = 200, listBaiHoc = listBaiHoc ,msg="Lấy danh sách thành công!"},JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { code = 500,msg= "Lấy danh sách bài học thất bại: "+ex.Message ,JsonRequestBehavior.AllowGet});
                throw;
            }
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
                                        Noidung2 = l.NoiDung2,
                                        Noidung3 = l.NoiDung3,
                                        Noidung4 = l.NoiDung4,
                                        Noidung5 = l.NoiDung5,
                                        Noidung6 = l.NoiDung6,
                                        Noidung7 = l.NoiDung7,
                                        Noidung8 = l.NoiDung8,
                                        Noidung9 = l.NoiDung9,
                                        Noidung10 = l.NoiDung10,
                                        idBaiHoc = l.IdBaiHoc,
                                    }).ToList();
                return Json(new { code = 200, listCTBaiHoc=listCTBaiHoc, msg = idBaiHoc }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách bài học thất bại: " + ex.Message, JsonRequestBehavior.AllowGet });
                throw;
            }
        }





       
    }
}