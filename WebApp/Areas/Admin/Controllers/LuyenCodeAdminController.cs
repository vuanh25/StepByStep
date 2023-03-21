using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Areas.Admin.Controllers
{
    public class LuyenCodeAdminController : Controller
    {
        // GET: Admin/LuyenCode
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index(string tenBaiTap)
        {
            List<LuyenCode> BaiLuyen = new List<LuyenCode>();
            ViewBag.Ten = tenBaiTap;
            if (tenBaiTap != null)
            {
                LuyenCode a = new LuyenCode();
                foreach (var item in db.LuyenTaps.ToList())
                {
                    if (Equals(item.TenLuyenTap, tenBaiTap))
                    {
                        BaiLuyen.Add(item);
                        return View(BaiLuyen);
                    }
                }
                
            }

            ViewBag.Ten = null;
            BaiLuyen = db.LuyenTaps.ToList();
            return View(BaiLuyen);

          
        }

        public ActionResult Edit (int id)
        {
            var BaiTap = db.LuyenTaps.Where(m => m.Id == id).First();
            return View(BaiTap);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sach = db.LuyenTaps.First(m => m.Id == id);

            
            //use viewbag to pass the dropdownlist from controller to view

            var E_tensach = collection["TenLuyenTap"];
            var E_yeuthich = Convert.ToInt32(collection["YeuThich"]);
            var E_ngonngu = Convert.ToInt32(collection["NgonNgu"]);
            var E_capdo = Convert.ToInt32(collection["DoKho"]);

            E_sach.Id = id;
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Trống!";
            }
            else
            {
                E_sach.TenLuyenTap = E_tensach;
                E_sach.YeuThich = E_yeuthich;
                E_sach.NgonNgu = (Models.Enums.NgonNgu)E_ngonngu;
                E_sach.DoKho = (Models.Enums.DoKho)E_capdo;

                // Change
                UpdateModel(E_sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}