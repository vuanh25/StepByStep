using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PhanHoiController : Controller
    {
        // GET: PhanHoi
        ApplicationDbContext db=new ApplicationDbContext();
        public JsonResult Index()
        {
            return View();
        }
    }
}