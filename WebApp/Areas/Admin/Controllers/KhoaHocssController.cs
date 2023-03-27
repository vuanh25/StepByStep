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

namespace WebApp.Areas.Admin.Controllers
{
    public class KhoaHocssController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/KhoaHocs
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult DsKH()
        {
            try
            {

                var ds = (from l in db.KhoaHocs.Where(x => x.IDKhoaHoc != 1) // Laays danh sach
                          select new
                          {
                              Id = l.IDKhoaHoc,
                              TenKhoaHoc = l.TenKhoaHoc,
                              IdNgonNgu = l.IDNgonNgu
                          }).ToList();
                return Json(new { code = 200, ds = ds }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Loi!" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        public JsonResult AddKH(string tenKH,int ngonngu)
        {
            try
            {
                var l = new KhoaHoc();
                l.TenKhoaHoc = tenKH;
                l.IDNgonNgu = (int)(Models.Enums.NgonNgu)ngonngu;
                db.KhoaHocs.Add(l);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Thêm mới khoá học thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm mới khoá học thất bại! Lỗi: " + ex.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }


        [HttpGet]
        public JsonResult Edit(int id)
        {
            try
            {

                var l = db.KhoaHocs.SingleOrDefault(x => x.IDKhoaHoc == id);

                return Json(new { code = 200, L = l, msg = "Lấy thông tin thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy thông tin thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }

        [HttpDelete]
        public JsonResult Xoa(int id)
        {
            try
            {
                var l = db.KhoaHocs.SingleOrDefault(x => x.IDKhoaHoc == id);
                var m = db.BaiHocs.SingleOrDefault(x => x.IdKhoaHoc == id);
                if (m!=null)
                {
                    var c = db.ChiTietBaiHocs.SingleOrDefault(x => x.IdBaiHoc == m.IdBaiHoc);
                    if (c != null)
                    {
                        db.ChiTietBaiHocs.Remove(c);
                    }
                }
                else
                {
                    if (l != null)
                    {
                        db.KhoaHocs.Remove(l);
                    }
                    if (m != null)
                    {
                        db.BaiHocs.Remove(m);
                    }
                }
                
              

              
               

                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa thành công!" }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Xóa thất bại!" + e.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }





    }
}
