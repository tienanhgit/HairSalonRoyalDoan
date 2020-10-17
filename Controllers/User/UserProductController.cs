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

        public ActionResult Index(int page = 1, int pagesize = 9)
        {

            ProductModel productModel = new ProductModel();
            List<SanPham> listsp = productModel.GetData();

            return Request.IsAjaxRequest()
                      ? (ActionResult)PartialView("SanPham", listsp.ToPagedList(page, pagesize))
                      : View(listsp.ToPagedList(page, pagesize));
        }
        public ActionResult GioHang ()
        {


            return View();
        }




        public ActionResult ProductDetail()
        {
            ViewBag.IdSanPham = Request.QueryString["id"];


            return View();
        }


    }
}