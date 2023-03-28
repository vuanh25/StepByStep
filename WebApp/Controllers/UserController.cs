using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Migrations
{
    public class UserController : KiemTraController
    {


        private string Encode(string originalPassword)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }


        private string requestCookie(string name)
        {
            HttpCookie nameCookie = Request.Cookies[name];
            if (nameCookie != null)
                return nameCookie.Value.ToString();
            else return null;
        }


        private void writeCookie(string name, string value)
        {
            HttpCookie nameCookie = new HttpCookie(name);
            nameCookie.Value = value;
            nameCookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(nameCookie);
        }

        private void disableCookie(string name)
        {
            HttpCookie nameCookie = new HttpCookie(name);
            nameCookie.Expires = DateTime.Now.AddDays(-1);
        }



        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            string tendn = requestCookie("tendn");
            if (!string.IsNullOrEmpty(tendn))
            {
                ViewBag.tendn = tendn;
                ViewBag.matkhau = requestCookie("makhau");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Tendn,string Matkhau,bool ghinho)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var TenDangNhap = Tendn;
            var luumatkhau = Matkhau;
            var MatKhau = Encode(luumatkhau);
            var GhiNho = ghinho;
            if (String.IsNullOrEmpty(Tendn))
            {
                ViewData["Err1"] = "Tên đăng nhập không được bỏ trống!";
            }
            else if (String.IsNullOrEmpty(Matkhau))
            {
                ViewData["Err2"] = "Mật khẩu không được bỏ trống!";
            }
            else
            {
                User user = db.Users.FirstOrDefault(n => n.TenTaiKHoan == Tendn && n.MatKhau == MatKhau);
                if (user!= null)
                {
                    ViewBag.ThongBao = "Đăng nhập thành công!";
                    Session["TenTaiKhoan"] = user.TenTaiKHoan;
                    Session["TenNguoiDung"] = user.TenUser;
                    if (ghinho)
                    {
                        writeCookie("tendn", Tendn);
                        writeCookie("matkhau", Matkhau);
                    }
                    else
                    {
                        disableCookie("tendn");
                        disableCookie("matkhau");
                    }
                    if (KiemTraDangNhapAdmin())
                    {
                        return RedirectToAction("IndexAdmin", "Admin/Dashboard");
                        //return Redirect("Home/MyIndex");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Err2"] = "Sai mật khẩu hoặc tên đăng nhập";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection collection,User user)
        {
            // Gán các giá tị người dùng nhập liệu cho các biến 
            ApplicationDbContext db = new ApplicationDbContext();
            var HoTen = collection["TenUser"];
            var Email = collection["Email"];
            var TenTaiKhoan = collection["TenTaiKhoan"];
            var MatKhau = collection["MatKhau"];
            var NhapLaiMatKhau = collection["NhapLaiMatKhau"];
            var trungMail = db.Users.FirstOrDefault(x => x.Email == Email);
            var trungTenDN = db.Users.FirstOrDefault(x => x.TenTaiKHoan == TenTaiKhoan);
            if (String.IsNullOrEmpty(HoTen))
            {
                ViewData["Err1"] = "Họ tên không được để trống";
            }
            else if (String.IsNullOrEmpty(Email))
            {
                ViewData["Err2"] = "Email không được bỏ trống";
            }
            else if (trungMail != null)
            {
                ViewData["Err2"] = "Email này đã tồn tại";
            }
            else if (String.IsNullOrEmpty(TenTaiKhoan))
            {
                ViewData["Err3"] = "Phải nhập tên đăng nhập";
            }
            else if (trungTenDN != null)
            {
                ViewData["Err3"] = "Tên đăng nhập này đã tồn tại";
            }
            else if (String.IsNullOrEmpty(MatKhau))
            {
                ViewData["Err4"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(NhapLaiMatKhau))
            {
                ViewData["Err5"] = "Phải nhập lại mật khẩu";
            }
            else if (MatKhau != NhapLaiMatKhau)
            {
                ViewData["Err5"] = "Mật khẩu nhập lại không đúng";
            }
            else
            {
                user.TenUser = TenTaiKhoan;
                user.Email = Email;
                user.TenTaiKHoan = TenTaiKhoan;
                user.MatKhau = Encode(MatKhau);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "User");
            }
            return Register();
        }


        public ActionResult ShowInfor(string mode)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (Session["TenTaiKhoan"] == null)
                return RedirectToAction("Login");
            var k = Session["TenTaiKhoan"].ToString();
            User user = db.Users.FirstOrDefault(x => x.TenTaiKHoan == k);
            if (string.IsNullOrEmpty(mode))
                mode = null;
            ViewBag.Mode = mode;
            if (mode == null)
            {
                ViewBag.info = "active";
            }
            if (mode == "changepass")
            {
                ViewBag.pass = "active";
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeInfor(FormCollection collection)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var TenUser = collection["TenUser"];
            var Email = collection["Email"];
            var taikhoan = Session["TenTaiKhoan"].ToString();
            User user = db.Users.FirstOrDefault(x => x.TenTaiKHoan == taikhoan);
            if (String.IsNullOrEmpty(Email))
            {
                ViewData["Err"] = "Email không được bỏ trống";
            }
            else
            {
                user.TenUser = TenUser;
                user.Email = Email;
                db.SaveChanges();
                return RedirectToAction("ShowInfor", 1);
            }
            return PartialView("ChangeInfor");
        }

        public ActionResult ChangePassword()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (Session["TenTaiKhoan"] == null)
                return RedirectToAction("Login");
            var k = Session["TenTaiKhoan"].ToString();
            User user = db.Users.FirstOrDefault(x => x.TenTaiKHoan == k);
            return PartialView(user);
        }

        [HttpPost]
        public ActionResult ChangePassword(FormCollection collection)
        {

            var old_pass = collection["old_pass"].ToString();
            var new_pass = collection["new_pass"].ToString();
            var confirm_pass = collection["confirm_pass"].ToString();
            old_pass = Encode(old_pass);
            new_pass = Encode(new_pass);
            confirm_pass = Encode(confirm_pass);
            ApplicationDbContext db = new ApplicationDbContext();
            var k = Session["TenTaiKhoan"].ToString();
            User user = db.Users.FirstOrDefault(x => x.TenTaiKHoan == k);
            if (old_pass == user.MatKhau)
            {
                user.MatKhau = new_pass;
                db.SaveChanges();
                return RedirectToAction("ShowInfor");
            }
            else
            {
                ViewData["Err"] = "Sai mat khau";
                return RedirectToAction("ShowInfor");
            }

        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //public ActionResult ThongTinTaiKhoan ()

    }
}