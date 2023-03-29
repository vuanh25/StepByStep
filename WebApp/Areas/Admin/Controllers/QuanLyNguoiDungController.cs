using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    public class QuanLyNguoiDungController : KiemTraController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/QuanLyNguoiDung
        public ActionResult IndexUser()
        {
            if (KiemTraDangNhapAdmin())
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }


        [HttpGet]
        public JsonResult DsUser()
        {
            try
            {

                var ds = (from l in db.Users.Where(x => x.IdUser != 0) // Laays danh sach
                          select new
                          {
                              Id = l.IdUser ,
                              TenUser = l.TenUser,
                              TenTaiKHoan = l.TenTaiKHoan,
                              Email = l.Email,
                              MatKhau = l.MatKhau
                              
                          }).ToList();
                return Json(new { code = 200, ds = ds }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lỗi lấy danh sách người dùng!" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }


        //                  XOA USER
        [HttpDelete]
        public JsonResult Xoa(int IdUser)
        {
            try
            {
                var l = db.Users.SingleOrDefault(x => x.IdUser == IdUser);

                if (l != null)
                {
                    db.Users.Remove(l);
                }

                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa tài khoản thành công!" }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Xóa tài khoản thất bại!" + e.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }
    }
}