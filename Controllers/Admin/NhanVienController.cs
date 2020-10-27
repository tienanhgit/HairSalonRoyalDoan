using HairSalonRoyalDoan.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Repository;
using HairSalonRoyalDoan.Controllers.Common;

namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class NhanVienController : Controller
    {
        [HttpGet]
        public ActionResult DangNhap()
        {

            return View("DangNhap");
        }


            // GET: NhanVien
            [HttpPost]
        public ActionResult DangNhap(string Email,string MatKhau) {
             NhanVienModel nhanVienModel = new NhanVienModel();
            //string em = Uri.EscapeUriString(Email);
            var result = nhanVienModel.DangNhap(Email, MatKhau);
            var chucvu = nhanVienModel.GetQuyen(Email);
            
            if(!String.IsNullOrEmpty(result))
            {
                Session.Add(SessionHelper.ADMIN_SESSION,Email);

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




    }
}