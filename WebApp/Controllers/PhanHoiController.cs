using System;
using System.Collections.Generic;
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
        public JsonResult DsPhanHoi(int idBaiViet)
        {
            try
            {
                List<PhanHoi> phanHois = db.PhanHois.Where(m => m.BaiViet.IdBaiViet == idBaiViet).ToList();
                return Json(new { code = 200, ds = phanHois }, JsonRequestBehavior.AllowGet);
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
                PhanHoi phanHoi=new PhanHoi();
                phanHoi.NoiDung = noidung;
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