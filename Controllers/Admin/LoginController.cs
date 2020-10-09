using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Repository;
using HairSalonRoyalDoan.Models.Dictionary;
using System.Text;

namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class LoginController : Controller
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
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //Set login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Index(string Email,string PassWord)
        {
            
            var Passhash = CreateMD5(PassWord);
            NhanVienModel nhanVienModel = new NhanVienModel();
            var result =nhanVienModel.DangNhap(Email,PassWord);
            
            if(!String.IsNullOrEmpty(result))
            {
                SessionHelper.SetSession(new UserSession() { UserName = Email });   
               return RedirectToAction("Index","UserHome");

            }
            return View();

        }


    }
}