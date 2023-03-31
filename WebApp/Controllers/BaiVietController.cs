using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Entities;
using WebApp.Models;
using WebApp.Models.Enums;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;
using System.Web.UI;

namespace WebApp.Controllers
{
    public class BaiVietController : Controller
    {
        // GET: BaiViet
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var all_baiviet = db.BaiViets
                .Where(i => i.IdBaiViet > 0)
                .Include(i => i.User)
                .ToList();
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(all_baiviet.ToPagedList(pageNum, pageSize));
        }
        public ActionResult ChiTietBaiViet(int id)
        {
            var baiviet = db.BaiViets.Where(m => m.IdBaiViet == id).First();
            baiviet.LuotXem++;
            Session["BaiViet"] = baiviet;
            ViewBag.TenTaiKhoan = baiviet.User.TenTaiKHoan;
            UpdateModel(baiviet);
            db.SaveChanges();
            return View(baiviet);
        }
        public ActionResult TaoBaiViet()
        {
            if (Session["TenTaiKhoan"] == null || Session["TenTaiKhoan"].ToString() == "")
                return RedirectToAction("Login", "User");
            else return View();
        }
        [HttpPost]
        public ActionResult TaoBaiViet(FormCollection collection, BaiViet v)
        {
            var ten_user = Session["TenTaiKhoan"].ToString();
            var user = db.Users.Single(u => u.TenTaiKHoan == ten_user);
            var tieude = collection["TieuDe"];
            var noidung = collection["NoiDungBaiViet"];
            var hinhanh = collection["HinhAnh"];
            var ngonngu = Convert.ToInt32(collection["NgonNgu"]);
            if (string.IsNullOrEmpty(tieude))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                v.TieuDe = tieude;
                v.NoiDungBaiViet = noidung;
                v.HinhAnh = hinhanh;
                v.NgayDang = DateTime.Now;
                v.NgonNgu = (Models.Enums.NgonNgu)ngonngu;
                v.User = user;
                db.BaiViets.Add(v);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.TaoBaiViet();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Public/images/BaiViet/" + file.FileName));
            return "/Public/images/BaiViet/" + file.FileName;
        }

        [HttpPost]
        public JsonResult Thich(int idBaiViet, bool attr)
        {
            try
            {
                if (Session["TenTaiKhoan"] == null || Session["TenTaiKhoan"].ToString() == "")
                    return Json(new { code = 500, JsonRequestBehavior.AllowGet });
                var baiviet = db.BaiViets.Where(m => m.IdBaiViet == idBaiViet).First();
                if (attr)
                    baiviet.LuotThich++;
                else
                    baiviet.LuotThich--;
                Session["BaiViet"] = baiviet;
                UpdateModel(baiviet);
                db.SaveChanges();
                return Json(new { code = 200, JsonRequestBehavior.AllowGet });
            }
            catch (Exception)
            {
                return Json(new { code = 500, JsonRequestBehavior.AllowGet });
                throw;
            }
        }

        [HttpPost]
        public JsonResult LuotThich(int idBaiViet)
        {
            try
            {
                var baiviet = db.BaiViets.Where(m => m.IdBaiViet == idBaiViet).First();
                return Json(new { code = 200, luotthich = baiviet.LuotThich, JsonRequestBehavior.AllowGet });
            }
            catch (Exception)
            {
                return Json(new { code = 500, JsonRequestBehavior.AllowGet });
                throw;
            }
        }
    }
}