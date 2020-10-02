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

            ProductModel productModel = new ProductModel();
            List<SanPham> dssanpham = productModel.GetData();
               
            return View(dssanpham);
        }
    }
}