using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.Models.Enums;

namespace WebApp.Areas.Admin.Controllers
{
    public class LuyenCodeAdminController : KiemTraController
    {
        // GET: Admin/LuyenCode
        private ApplicationDbContext db = new ApplicationDbContext();

        //[Authorize]

        public ActionResult Index(string TenBaiTap)
        {
            if (KiemTraDangNhapAdmin())
            {             
                return View();
            }
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public JsonResult DsBT(string TenBaiTap)
        {
            try
            {
                if (TenBaiTap != null)
                {
                    var BaiTap = db.LuyenTaps.Where(p => p.TenLuyenTap.Contains(TenBaiTap)).ToList();
                    foreach (var item in BaiTap)
                    {
                        if (Equals(item.TenLuyenTap, TenBaiTap))
                        {
                            var ds = (from l in db.LuyenTaps.Where(x => x.Id == item.Id) // Laays danh sach
                                      select new
                                      {
                                          Id = l.Id,
                                          TenLuyenTap = l.TenLuyenTap,
                                          YeuThich = l.YeuThich,
                                          NgonNgu = l.NgonNgu.ToString(),
                                          CapDo = l.DoKho.ToString()
                                      }).ToList();
                            return Json(new { code = 200, ds = ds }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                else
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
                    return Json(new { code = 200, ds = ds }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Loi!" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }



        //              THÊM BÀI TẬP 


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

        [HttpPost]
        public JsonResult AddCTBT(string tenDB, string yeuCau, string dauVao, string dauRa,string viDuVao, string viDuRa, int diem)
        {
            try
            {
                var l = new ChiTietBaiLuyen();
                l.DeBai = tenDB;
                l.YeuCauDauVao = yeuCau;
                l.DauVao = dauVao;
                l.DauRa = dauRa;
                l.ViduVao = viDuVao;
                l.ViduRa = viDuRa;
                l.Diem = diem;
         
                

                db.ChiTietBaiLuyens.Add(l);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Thêm mới chi tiết bài tập thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm mới chi tiết bài tập thất bại! Lỗi: " + ex.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }



        //                  CHỈNH SỬA

        // PHẦN LẤY DỮ LIỆU
        [HttpGet]
        public JsonResult Edit(int id)
        {
            try
            {
                  
                var l = db.LuyenTaps.SingleOrDefault(x=>x.Id == id);
                
                return Json(new { code = 200, L = l, msg = "Lấy thông tin thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy thông tin thất bại" +ex.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }

        [HttpGet]
        public JsonResult EditCTBT(int id)
        {
            try
            {

                var l = db.ChiTietBaiLuyens.SingleOrDefault(x => x.Id == id);
             //   l.LuyenCode = db.LuyenTaps.Where(m => m.Id == id).First();
                return Json(new { code = 200, L = l, msg = "Lấy thông tin thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy thông tin thất bại" + ex.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }

        //          ĐỔ DỮ LIỆU ĐỂ --- CẬP NHẬP 

        [HttpPost]
        public JsonResult CapNhap(int id, string TenLuyenTap, int YeuThich, int NgonNgu, int DoKho)
        {
            try
            {
                var l = db.LuyenTaps.SingleOrDefault(x => x.Id == id);
                l.TenLuyenTap = TenLuyenTap;
                l.YeuThich = YeuThich;
                l.NgonNgu = (Models.Enums.NgonNgu)NgonNgu;
                l.DoKho = (Models.Enums.DoKho)DoKho;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Cập nhập bài tập thành công!" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { code = 200, msg = "Cập nhập bài tập thất bại!" }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        [HttpPost]
        public JsonResult CapNhapCTBT(int id, string DeBai, string YeuCau, string DauVao, string DauRa, string ViDuVao,string ViDuRa, int Diem)
        {
            try
            {
                var l = db.ChiTietBaiLuyens.SingleOrDefault(x => x.Id == id);
                l.DeBai = DeBai;
                l.YeuCauDauVao = YeuCau;
                l.DauVao = DauVao;
                l.DauRa = DauRa;
                l.ViduVao = ViDuVao;
                l.ViduRa = ViDuRa;
                l.Diem = Diem;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Cập nhập chi tiết bài tập thành công!" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { code = 200, msg = "Cập nhập chi tiết bài tập thất bại!" }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }


        //                  XOA BÀI TẬP
        [HttpDelete]
        public JsonResult Xoa(int id)
        {
            try
            {
                var l = db.LuyenTaps.SingleOrDefault(x => x.Id == id);
                var m = db.ChiTietBaiLuyens.SingleOrDefault(x => x.Id == id);

                if (l != null)
                {
                    db.LuyenTaps.Remove(l);
                }
                if (m != null)
                {
                    db.ChiTietBaiLuyens.Remove(m);
                }

                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa bài tập thành công!" }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Xóa bài tập thất bại!" + e.Message }, JsonRequestBehavior.AllowGet);

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