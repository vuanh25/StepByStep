using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BaiHocController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: BaiHoc
        public ActionResult Index()
        {
           
            return View(db.BaiHocs.ToList());
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
            if (id == null)
            {
                id = 28;
            }
            
            ViewBag.IdbaiHoc = id;
            return View(db.BaiHocs.ToList());
        }


       /* public ActionResult BaiHoc(int id)
        {
            ViewBag.IdBaiHoc = id;
            foreach (var item in db.BaiHocs.ToList())
            {
                if (item.IdBaiHoc == id)
                {
                    return View(id);
                }
            }
        }*/
    }
}