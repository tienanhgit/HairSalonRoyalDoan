using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Models.Dictionary;
using HairSalonRoyalDoan.Controllers.Common;

namespace HairSalonRoyalDoan.Controllers.User
{
    public class KhachHangController : Controller
    {
        KhachHangModel khachHangModel = new KhachHangModel();
         public ActionResult Index()
            {
                return View();
            }

        public static string CreateMD5(string input)
        {
            // GET: KhachHang
           
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static string refere="1";
        public ActionResult DangNhap()
        {
            refere = Request.UrlReferrer.LocalPath.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string SDTDN, string MatKhauDN)
        {
            
                var MKHash = "";
                if (MatKhauDN!=null)
                {MKHash= CreateMD5(MatKhauDN.ToString());
                }    
                var result = khachHangModel.DangNhap(SDTDN, MKHash);
          
            if (!String.IsNullOrEmpty(result))
            {
                Session.Add(SessionHelper.USER_SESSION, SDTDN);
          
          
                if (refere =="/UserHome/Index")
                {
                    return RedirectToAction("Index", "UserHome");
                }
                else

                {

                    return RedirectToAction("Index", "UserProduct");
                }
            }
            else
            {
              
                    ViewBag.dangnhap = "Tên đăng nhập và mật khẩu không đúng";

                
            }

            
           
              
            return View();

        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View("DangNhap");
        }

        public ActionResult DangXuat()
        {
     
            Session[SessionHelper.CART_SESSION] = null;
            Session[SessionHelper.USER_SESSION] = null;
            Session["SLSP_SESSION"] = null;
            string refere = Request.UrlReferrer.LocalPath.ToString();
            if(refere=="/UserHome/Index")
            {
                
                return RedirectToAction("Index", "UserHome");
            }
            else
            {
            
                return RedirectToAction("Index", "UserProduct");
            }
         
        }

        


        [HttpPost]
        public ActionResult DangKy(Khachhang std)
        {
            string message = std.SDTKH.ToString();
            std.MatKhau = CreateMD5(std.MatKhau.ToString());
           
          string check = new KhachHangModel().CheckInsert(std.SDTKH.ToString());
             
                int cvcheck = Convert.ToInt32(check);
            if (cvcheck == 0)
            {

                khachHangModel.ThemKhachHang(std);
            }
            
            return Json(new { data=cvcheck, JsonRequestBehavior.AllowGet });

        }

       




    }
}