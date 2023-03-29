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
            if (Session["TenNguoiDung"] != null &&  Session["TenTaiKhoan"].Equals("admin"))
            {
                return true;
            }
            return false;
        }

        public bool KiemTraDangNhap()
        {
            try
            {
                if (Session["TenNguoiDung"] != null)
                {
                    return true;
                }
                return false;
                
            }
            catch (Exception)
            {
                return false;
            }      
        }
    }
}


