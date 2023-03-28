using System;
using System.Collections.Generic;
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
        ApplicationDbContext db=new ApplicationDbContext();
        //public ActionResult Index()
        //{
        //    var all_cauhoi = db.CauHois;
        //    return View(all_cauhoi);
        //}
        //public ActionResult ChiTietCauHoi(int id) 
        //{ 
        //    var cauhoi=db.CauHois.Where(m=>m.IdCauHoi==id).First();
        //    cauhoi.LuotXem++;
        //    UpdateModel(cauhoi);
        //    db.SaveChanges();
        //    return View(cauhoi);
        //}
        //public ActionResult DatCauHoi()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult DatCauHoi(FormCollection collection, CauHoi c)
        //{
        //    var tieude= collection["TieuDe"];
        //    var noidung = collection["NoiDungCauHoi"];
        //    var hinhanh = collection["HinhAnh"];
        //    var ngonngu=  collection["NgonNgu"]; 
        //    var danhmuc= collection["DanhMuc"];
        //    if (string.IsNullOrEmpty(tieude))
        //    {
        //        ViewData["Error"] = "Don't empty!";
        //    }
        //    else
        //    {
        //        c.TieuDe = tieude;
        //        c.NoiDungCauHoi = noidung;
        //        c.HinhAnh = hinhanh;
        //        //c.NgonNgu = ngonngu;
        //        //c.DanhMuc = danhmuc;
        //        db.CauHois.Add(c);
        //        db.SaveChanges();
        //        return RedirectToAction("ListSach");
        //    }
        //    return this.DatCauHoi();
        //}
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath(file.FileName));
            return file.FileName;
        }

        public JsonResult Index(int id)
        {
            try
            {
                CauHoi cauhoi = db.CauHois.First(m => m.IdCauHoi == id);
                return Json(new {code=200,cauhoi=cauhoi,msg="Lấy chi tiết câu hỏi thành công",JsonRequestBehavior.AllowGet});
            }
            catch (Exception)
            {
                return Json(new { code = 200,msg = "Lấy chi tiết câu hỏi thất bại", JsonRequestBehavior.AllowGet });
                throw;
            }
        }
    }
}