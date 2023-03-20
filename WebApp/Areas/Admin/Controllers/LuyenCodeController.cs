using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Areas.Admin.Controllers
{
    public class LuyenCodeController : Controller
    {
        // GET: Admin/LuyenCode
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            List<LuyenCode> BaiLuyen = db.LuyenTaps.ToList();
            return View(BaiLuyen);

          
        }
    }
}