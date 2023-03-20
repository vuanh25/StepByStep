using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using PagedList.Mvc;
using PagedList;

namespace WebApp.Controllers
{
    public class LuyenCodeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: LuyenCode
        public ActionResult Index(int? page)
        {

            if (page == null) page = 1;
            var all_sach = (from s in db.LuyenTaps select s).OrderBy(m => m.Id);
            int pageSize = 6;
            int pageNum = page ?? 1;
            return View(all_sach.ToPagedList(pageNum, pageSize));

        }

        
        [Authorize]
        public ActionResult ChiTiet(int? id)
        {
            if (id != null)
            foreach (var item in db.LuyenTaps.ToList())
            {
                if (item.Id == id)
                {

                        ViewBag.TenBaiLuyen = item.TenLuyenTap;
                }
            }
            var BT = db.ChiTietBaiLuyens.Where(a => a.LuyenCode.Id == id);
            return View(BT);
        }

    }
    public class ChiTietBaiHocController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

    }
}