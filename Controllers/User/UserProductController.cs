using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HairSalonRoyalDoan.Models.Dictionary;
using RoyalDoanEnitty.Dictionary;

namespace HairSalonRoyalDoan.Controllers
{
    public class UserProductController : Controller
    {
        // GET: UserProduct
        public ActionResult Index()
        {
            SanPham sanPham = new SanPham();
            ProductModel productModel = new ProductModel();
            List<SanPham> sanpham = productModel.GetData();
        
                ViewBag['a'] = sanpham[0].HinhAnh;

        

            return View();
        }
    }
}