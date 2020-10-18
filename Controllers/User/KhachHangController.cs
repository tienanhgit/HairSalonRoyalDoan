using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Models.Dictionary;

namespace HairSalonRoyalDoan.Controllers.User
{
    public class KhachHangController : Controller
    {
        public static string CreateMD5(string input)
        {
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
        public ActionResult DangNhap()
        {
            if (ModelState.IsValid)
            {





            }



            return View();
        }
        [HttpPost]
        public ActionResult DangKy(Khachhang khachhang)
        {
            if(ModelState.IsValid)
            {
                var matkhauhas = CreateMD5(khachhang.MatKhau);
                var check = new KhachHangModel().CheckInsert(Convert.ToString(khachhang.SDTKH));


            }
            else
            {

                ModelState.AddModelError("","Thêm khách hàng không thành công !");
            }

            return View();
        }

        // GET: KhachHang
        public ActionResult Index()
        {
            return View();
        }




    }
}