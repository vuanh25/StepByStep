using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LuyenCodeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: LuyenCode
        public ActionResult Index()
        {
            var all_baitap = from tt in db.LuyenTaps select tt;
            return View(all_baitap);
        }

    }
}