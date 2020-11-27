using HairSalonRoyalDoan.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Repository;
using HairSalonRoyalDoan.Controllers.Common;
using System.Text;

namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class NhanVienController : Controller
    {
        [HttpGet]
        public ActionResult DangNhap()
        {

            return View("DangNhap");
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


        // GET: NhanVien
        [HttpPost]
        public ActionResult DangNhap(string Email, string MatKhau) {
            NhanVienModel nhanVienModel = new NhanVienModel();


            var result = nhanVienModel.DangNhap(Email, CreateMD5(MatKhau));
            if (!String.IsNullOrEmpty(result))
            {

                Session.Add(SessionHelper.ADMIN_SESSION, Email);

                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View();

        }

        public ActionResult DangXuat()
        {

            Session[SessionHelper.ADMIN_SESSION] = null;

            return RedirectToAction("DangNhap", "NhanVien");



        }

        public ActionResult SuaTaiKhoan() {
           



            return View();
        }

        [HttpPost]
        public JsonResult SuaTaiKhoan(string MatKhau,string MatKhauCu)
        {
            string mess = "Sửa mật khẩu thất bại";
            if (Session["ADMIN_SESSION"] != null)
            {
            
                NhanVienModel nhanVienModel = new NhanVienModel();
                NhanVien nhanVien = new NhanVienModel().GetNhanVienByEmail(Session["ADMIN_SESSION"].ToString());
                if (nhanVienModel.CreateMD5(MatKhauCu)==nhanVien.MatKhau)
                {


                    nhanVienModel.CapNhatMatKhau(nhanVien.MaNV.ToString(), CreateMD5(MatKhau));
                    mess = "Sửa mật khẩu thành công";
                }
                else
                {
                    mess = "Mật khẩu cũ không đúng";
                    
                }
            }

            return Json(new { Message = mess, JsonRequestBehavior.AllowGet });
        } 


        }
}