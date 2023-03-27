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
            var TaiKhoan = Session["TenTaiKhoan"].ToString();
            if (TaiKhoan.Equals("admin"))
            {
                return true;
            }
            return false;
        }

        public bool KiemTraDangNhap()
        {
            try
            {
                var TaiKhoan = Session["TenTaiKhoan"].ToString();
                if (Session["TenTaiKhoan"].ToString() == "0")
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }      
        }
    }
}


