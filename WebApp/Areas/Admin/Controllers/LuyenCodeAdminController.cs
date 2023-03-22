using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.Models.Enums;

namespace WebApp.Areas.Admin.Controllers
{
    public class LuyenCodeAdminController : Controller
    {
        // GET: Admin/LuyenCode
        private ApplicationDbContext db = new ApplicationDbContext();

        //[Authorize]

        public ActionResult Index()
        {  
            return View();
        }

        [HttpGet]
        public JsonResult DsBT()
        {
             NgonNgu nn = new NgonNgu();
            try
            {

                var ds = (from l in db.LuyenTaps.Where(x => x.Id != 0) // Laays danh sach
                          select new
                          {
                              Id = l.Id,
                              TenLuyenTap = l.TenLuyenTap,
                              YeuThich = l.YeuThich,
                              NgonNgu = l.NgonNgu.ToString(),
                              CapDo = l.DoKho.ToString()
                          }).ToList();
                return Json(new { code = 200, ds = ds }, JsonRequestBehavior.AllowGet );
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Loi!" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        public JsonResult AddBT(string tenBT, int yeuThich, int ngonNgu,int doKho)
        {
            try
            {
                var l = new LuyenCode();
                l.TenLuyenTap = tenBT;
                l.YeuThich = yeuThich;
                l.NgonNgu = (Models.Enums.NgonNgu)ngonNgu;
                l.DoKho = (Models.Enums.DoKho)doKho;

                db.LuyenTaps.Add(l);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Thêm mới bài tập thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm mới bài tập thất bại! Lỗi: " + ex.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }


                     //              SỬA

        //public ActionResult Edit (int id)
        //{
        //    var BaiTap = db.LuyenTaps.Where(m => m.Id == id).First();
        //    return View(BaiTap);
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    var E_sach = db.LuyenTaps.First(m => m.Id == id);
        //    var E_tensach = collection["TenLuyenTap"];
        //    var E_yeuthich = Convert.ToInt32(collection["YeuThich"]);
        //    var E_ngonngu = Convert.ToInt32(collection["NgonNgu"]);
        //    var E_capdo = Convert.ToInt32(collection["DoKho"]);

        //    E_sach.Id = id;
        //    if (string.IsNullOrEmpty(E_tensach))
        //    {
        //        ViewData["Error"] = "Trống!";
        //    }
        //    else
        //    {
        //        E_sach.TenLuyenTap = E_tensach;
        //        E_sach.YeuThich = E_yeuthich;
        //        E_sach.NgonNgu = (Models.Enums.NgonNgu)E_ngonngu;
        //        E_sach.DoKho = (Models.Enums.DoKho)E_capdo;

        //        // Change
        //        UpdateModel(E_sach);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        // XÓA




        //[HttpPost] [HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    var D_sach = db.LuyenTaps.Where(m => m.Id == id).First();

        //    // Xóa sách
        //    db.LuyenTaps.Remove(D_sach);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}



    }
}