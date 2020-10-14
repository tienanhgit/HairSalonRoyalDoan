using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Repository;
using HairSalonRoyalDoan.Models.Dictionary;
using PagedList;

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
        public ActionResult SanPham(int page=1,int pagesize=9)
        {
            List<SanPham> listsp = new ProductModel().GetData();
            ViewBag.ListSanPham = listsp;
            var links = listsp;

            return Request.IsAjaxRequest()
                   ? (ActionResult)PartialView("SanPham", listsp.ToPagedList(page, pagesize))
                   : View(listsp.ToPagedList(page, pagesize));
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
            string message = "";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });   
        }

        [HttpGet]
        public ActionResult SuaSanPham()
        {
            int MaDanhMuc = Convert.ToInt32(Request.QueryString["MaDanhMuc"]);
            int MaThuongHieu = Convert.ToInt32(Request.QueryString["MaThuongHieu"]);
            if (MaThuongHieu != 0)
            {
                ViewBag.ListDanhMuc = new DanhMucModel().GetDanhMucByMa(MaDanhMuc);
            }
            else
            {
                ViewBag.ListDanhMuc ="";

            }
          ThuongHieu listThuongHieu = new ThuongHieuModel().GetThuongHieuByMa(MaThuongHieu);
            ViewBag.ListThuongHieu = listThuongHieu;

            List<SanPham> listsp = new ProductModel().GetData();
            ViewBag.ListSanPham = listsp;
            return View(listThuongHieu);
        }
       

    }
}