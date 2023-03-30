using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    public class CauHoiController : Controller
    {
        // GET: CauHoi
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var all_cauhoi = db.CauHois
                .Where(i => i.IdCauHoi > 0)
                .Include(i => i.User);

            return View(all_cauhoi);
        }
        public ActionResult ChiTietCauHoi(int id)
        {
            var cauhoi = db.CauHois.Where(m => m.IdCauHoi == id).First();
            cauhoi.LuotXem++;
            ViewBag.TenTaiKhoan = cauhoi.User.TenTaiKHoan;
            UpdateModel(cauhoi);
            db.SaveChanges();
            return View(cauhoi);
        }
        public ActionResult DatCauHoi()
        {
            if (Session["TenTaiKhoan"] == null || Session["TenTaiKhoan"].ToString() == "")
                return RedirectToAction("Login", "User");
            else return View();
        }
        [HttpPost]
        public ActionResult DatCauHoi(FormCollection collection, CauHoi c)
        {
            var ten_user = Session["TenTaiKhoan"].ToString();
            var user = db.Users.Single(u => u.TenTaiKHoan == ten_user);
            var tieude = collection["TieuDe"];
            var noidung = collection["NoiDungCauHoi"];
            var hinhanh = collection["HinhAnh"];
            var ngonngu = Convert.ToInt32(collection["NgonNgu"]);
            if (string.IsNullOrEmpty(tieude))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                c.TieuDe = tieude;
                c.NoiDungCauHoi = noidung;
                c.HinhAnh = hinhanh;
                c.NgayDang = DateTime.Now;
                c.NgonNgu = (Models.Enums.NgonNgu)ngonngu;
                c.User = user;
                db.CauHois.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.DatCauHoi();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Public/images/CauHoi/" + file.FileName));
            return "/Public/images/CauHoi/" + file.FileName;
        }

    }
}