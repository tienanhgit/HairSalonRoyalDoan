using HairSalonRoyalDoan.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Repository;

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
        
            if(!String.IsNullOrEmpty(result))
            {
               
               return RedirectToAction("Index","UserHome");
        }
            return View();

    }
        [HttpGet]
        public ActionResult DangKy()
        {




            return View("DangNhap");
        }

        [HttpPost]
        public ActionResult DangKy (NhanVien nhanVien)
        {




            return View("DangNhap");
        }
      



    }
}