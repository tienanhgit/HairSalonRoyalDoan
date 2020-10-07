using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HairSalonRoyalDoan.Models.Dictionary;
using HairSalonRoyalDoan.Repository;

namespace HairSalonRoyalDoan.Controllers
{
    public class UserProductController : Controller
    {

        public ActionResult Index()
        {

            ProductModel productModel = new ProductModel();
            List<SanPham> dssanpham = productModel.GetData();
            return View(dssanpham);    
        }
        public ActionResult ProductDetail()
        {
            ViewBag.IdSanPham = Request.QueryString["id"];


            return View();
        }




    }
}