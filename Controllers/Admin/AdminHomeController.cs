using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Repository;
using HairSalonRoyalDoan.Models.Dictionary;

namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        ProductModel productModel = new ProductModel();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult SanPham()
        {
            return View();

        }
        [HttpGet]
        public ActionResult ThemSanPham()
        {
           
            ViewBag.ListDanhMuc = new DanhMucModel().GetData();
            List<ThuongHieu> listThuongHieu = new ThuongHieuModel().GetData();
            ViewBag.ListThuongHieu = listThuongHieu;

            return View();


        }
        [HttpPost]
        public ActionResult ThemSanPham(SanPham std)
        {


            std.NgayTao =DateTime.Now;
            productModel.ThemSanPham(std);

            string message = "SUCCESS hihihi";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        
        }
        public ActionResult SuaSanPham()
        {
            return View();
        }


    }
}