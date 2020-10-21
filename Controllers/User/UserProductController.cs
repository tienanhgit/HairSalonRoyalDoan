using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

using HairSalonRoyalDoan.Models.Dictionary;
using HairSalonRoyalDoan.Repository;

namespace HairSalonRoyalDoan.Controllers
{
    public class UserProductController : Controller
    {

        public ActionResult Index(int page = 1, int pagesize = 6)
        {

            ProductModel productModel = new ProductModel();
            List<SanPham> listsp = productModel.GetData();
            var ls = listsp.ToPagedList(page, pagesize);
            return View(ls);
        }
     



        public ActionResult ProductDetail()
        {
            ViewBag.IdSanPham = Request.QueryString["id"];
            return View();
        }


    }
}