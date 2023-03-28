using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    public class PaymentController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult PaymentPage()
        {
            return View();
        }

        public ActionResult ThongTinThanhToan()
        {
            var username = Session["TenTaiKhoan"];
            if (username == null)
            {
                return RedirectToAction("Login", "User");
            }
          ApplicationDbContext db = new ApplicationDbContext();
            dynamic model = new ExpandoObject();
            model.User = db.Users.FirstOrDefault(x => x.TenTaiKHoan == username);
            var khoahocmuonmua = int.Parse(Session["KhoaHocMuonMua"].ToString());
            model.KhoaHoc = db.KhoaHocs.Find(khoahocmuonmua);
            return View(model);
        }

        public ActionResult ChonPhuongThucThanhToan(int? id)
        {
            id = (id ?? 2);
            Session["KhoaHocMuonMua"] = id;
            return View();
        }

        [HttpPost]
        public void ThongTinThanhToan(FormCollection collection)
        {
            //Get Config Info
            string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
            string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma website
            string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat


            //Get payment input
            ApplicationDbContext db = new ApplicationDbContext();
            int id = int.Parse(Session["KhoaHocMuonMua"].ToString());
            string username = Session["TenTaiKhoan"].ToString();
            var goi = db.KhoaHocs.Find(id);
            var user = db.Users.FirstOrDefault(x => x.TenTaiKHoan == username);


            OrderInfo order = new OrderInfo();
            order.OrderId = DateTime.Now.Ticks;// Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
            order.Amount = (long)goi.GiaGoiKhoaHoc;// Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY giá gói
            order.Status = "0"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending"
            order.OrderDesc = "Thanh toan goi " + goi.TenKhoaHoc;
            order.CreatedDate = DateTime.Now;
            string locale = collection["cboLanguage"];

            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();
            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());
            var cboBankCode = collection["cboBankCode"];
            if (cboBankCode != null && !string.IsNullOrEmpty(cboBankCode))
            {
                vnpay.AddRequestData("vnp_BankCode", cboBankCode);
            }
            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
            if (!string.IsNullOrEmpty(locale))
            {
                vnpay.AddRequestData("vnp_Locale", locale);
            }
            else
            {
                vnpay.AddRequestData("vnp_Locale", "vn");
            }
            var orderCategory = "Thanh toán trực tuyến";
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.OrderId);
            vnpay.AddRequestData("vnp_OrderType", orderCategory); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày
                                                                          //Add Params of 2.1.0 Version


            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            log.InfoFormat("VNPAY URL: {0}", paymentUrl);
            Response.Redirect(paymentUrl);
        }


        public ActionResult Result()
        {
            String s= "Something went wrong. Please go back";
            if (Request.QueryString.Count>0)
            {
                string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"];//chuoi bi mat
                var vnpayData = Request.QueryString;
                VnPayLibrary vnpay = new VnPayLibrary();
                foreach (string ss in vnpayData)
                {
                    //get all querystring data
                    if (!string.IsNullOrEmpty(ss) && ss.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(ss, vnpayData[ss]);
                    }
                }
                //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
                //vnp_TransactionNo: Ma GD tai he thong VNPAY
                //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
                //vnp_SecureHash: HmacSHA512 cua du lieu tra ve
                long orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
                long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                String vnp_SecureHash = Request.QueryString["vnp_SecureHash"];
                String TerminalID = Request.QueryString["vnp_TmnCode"];
                long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                String bankCode = Request.QueryString["vnp_BankCode"];

                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00" && vnp_TransactionStatus=="00")
                    {
                        int k = int.Parse(Session["KhoaHocMuonMua"].ToString());
                        Session["GoiKhoaHoc"] = null;
                        ApplicationDbContext db = new ApplicationDbContext();

                        MuaKhoaHoc muaKhoaHoc = new MuaKhoaHoc();
                        muaKhoaHoc.IdKhoaHoc = k;
                        string tentaikhoan = Session["TenTaiKhoan"].ToString();
                        User user = db.Users.FirstOrDefault(x => x.TenTaiKHoan == tentaikhoan);
                        muaKhoaHoc.IdUser = user.IdUser;
                        muaKhoaHoc.NgayThanhToan = DateTime.Now;
                        muaKhoaHoc.ThanhTien = db.KhoaHocs.Find(k).GiaGoiKhoaHoc;
                        db.MuaKhoaHocs.Add(muaKhoaHoc);
                        db.SaveChanges();
                        Session["VIP"] = k;
                        //Thanh toan thanh cong
                        s = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";

                    }
                    else
                    {
                        //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                        s = "Thanh toan khong thanh cong. Ma loi la: " + vnp_ResponseCode;
                    }
                }
                else
                {
                    s = "Thanh toan khong thanh cong";
                }
            }
            ViewBag.Result = s;
            return View();
        }
        



    }
}