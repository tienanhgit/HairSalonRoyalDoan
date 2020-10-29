using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Models.Dictionary;
using HairSalonRoyalDoan.Repository;

namespace HairSalonRoyalDoan.Controllers
{
    public class UserHomeController : Controller
    {
        ProductModel productModel = new ProductModel();
        // GET: UserHome



        public ActionResult Index()
        {

            List<SanPham> listsp = new ProductModel().GetData();
            ViewBag.ListSanPham = listsp;

            return View();
        }
        public ActionResult DatLichCat()
        {
            List<DonDatHang> listdondathang = new DonDatHangModel().GetData();





            return View();
        }







    }
}