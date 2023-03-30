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
    public class PhanHoiController : Controller
    {
        // GET: PhanHoi
        ApplicationDbContext db=new ApplicationDbContext();

        [HttpPost]
        public JsonResult DsPhanHoi(int id,int loai)
        {
            try
            {
                List<PhanHoi> phanHois;
                if (loai==0)
                {
                    phanHois = db.PhanHois
                    .Where(m => m.BaiViet.IdBaiViet == id)
                    .Include(m => m.User)
                    .ToList();
                }
                else
                {
                    phanHois = db.PhanHois
                    .Where(m => m.CauHoi.IdCauHoi == id)
                    .Include(m => m.User)
                    .ToList();
                }
                return Json(new { code = 200, ds = phanHois,sophanhoi=phanHois.Count }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        [HttpPost]
        public JsonResult ThemPhanHoi(int id, string noidung,int loai)
        {
            try
            {
                if (Session["TenTaiKhoan"] == null || Session["TenTaiKhoan"].ToString() == "")
                    return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
                var tenuser = Session["TenTaiKhoan"].ToString();
                PhanHoi phanHoi=new PhanHoi();
                var user = db.Users.First(u => u.TenTaiKHoan == tenuser);
                phanHoi.NoiDung = noidung;
                phanHoi.User = user;
                if (loai == 0)
                {
                    BaiViet baiViet = db.BaiViets.First(m=> m.IdBaiViet==id);
                    phanHoi.BaiViet=baiViet;
                }
                else{
                    CauHoi cauhoi = db.CauHois.First(m => m.IdCauHoi == id);
                    phanHoi.CauHoi=cauhoi;
                }
                db.PhanHois.Add(phanHoi);
                db.SaveChanges();
                return Json(new { code = 200}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }
    }
}