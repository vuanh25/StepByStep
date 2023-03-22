using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Entities;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BaiVietController : Controller
    {
        // GET: BaiViet
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var all_baiviet = db.BaiViets;
            return View(all_baiviet);
        }
        public ActionResult ChiTietBaiViet(int id)
        {
            var baiviet = db.BaiViets.Where(m => m.IdBaiViet == id).First();
            baiviet.LuotXem++;
            UpdateModel(baiviet);
            db.SaveChanges();
            return View(baiviet);
        }
        public ActionResult TaoBaiViet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoBaiViet(FormCollection collection, BaiViet v)
        {
            var tieude = collection["TieuDe"];
            var noidung = collection["NoiDungBaiViet"];
            var hinhanh = collection["HinhAnh"];
            var ngonngu = collection["NgonNgu"];
            var danhmuc = collection["DanhMuc"];
            if (string.IsNullOrEmpty(tieude))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                v.TieuDe = tieude;
                v.NoiDungBaiViet = noidung;
                v.HinhAnh = hinhanh;
                //c.NgonNgu = ngonngu;
                //c.DanhMuc = danhmuc;
                db.BaiViets.Add(v);
                db.SaveChanges();
                return RedirectToAction("ListSach");
            }
            return this.TaoBaiViet();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath(file.FileName));
            return file.FileName;
        }
        [HttpGet]
        public JsonResult Thich(int idBaiViet)
        {
            try
            {
                var baiviet = db.BaiViets.Where(m => m.IdBaiViet == idBaiViet).First();
                baiviet.LuotThich++;
                UpdateModel(baiviet);
                db.SaveChanges();
                return Json(new {code=200, luotthich=baiviet.LuotThich,JsonRequestBehavior.AllowGet });
            }
            catch (Exception)
            {
                return Json(new { code = 500, JsonRequestBehavior.AllowGet });
                throw;
            }
        }
    }
}