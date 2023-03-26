using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    public class KiemTraController : Controller
    {
        // GET: KiemTra
        public bool KiemTraDangNhapAdmin()
        {
            var TaiKhoan = Session["TenTaiKhoan"] as User;
            if (TaiKhoan.Equals("admin"))
            {
                return true;
            }
            return false;
        }

        public bool KiemTraDangNhap()
        {
            var TaiKhoan = Session["TenTaiKhoan"].ToString();
            if (TaiKhoan == null)
            {
                return false;
            }
            return true;
        }
    }
}


