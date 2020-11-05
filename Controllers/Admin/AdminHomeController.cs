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
            if (Session["ADMIN_SESSION"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");

            }
        }
        public ActionResult SanPham(int page = 1, int pagesize = 9)
        {
            List<SanPham> listsp = new ProductModel().GetData();
            ViewBag.ListSanPham = listsp;
            var links = listsp;

            if (Session["ADMIN_SESSION"] != null)
            {
                return
                 Request.IsAjaxRequest()
                ? (ActionResult)PartialView("SanPham", listsp.ToPagedList(page, pagesize))
                : View(listsp.ToPagedList(page, pagesize));
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");


            }
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
            int MaSanPham = Convert.ToInt32(Request.QueryString["MaSanPham"]);
            int MaDanhMuc = Convert.ToInt32(Request.QueryString["MaDanhMuc"]);
            int MaThuongHieu = Convert.ToInt32(Request.QueryString["MaThuongHieu"]);

            ViewBag.MaDanhMuc = MaDanhMuc;
            ViewBag.MaThuongHieu = MaThuongHieu;

            List<ThuongHieu> listThuongHieu = new ThuongHieuModel().GetData();
            ViewBag.ListThuongHieu = listThuongHieu;

            List<DanhMuc> listDanhMuc = new DanhMucModel().GetData();
            ViewBag.ListDanhMuc = listDanhMuc;
            SanPham sp = new ProductModel().GetSanPhamByMa(MaSanPham);
            ViewBag.SanPham = sp;
            if (Session["ADMIN_SESSION"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");

            }
        }
        [HttpPost]
        public ActionResult SuaSanPham(SanPham std)
        {
            std.NgaySua = DateTime.Now;
            productModel.CapNhatSanPham(std);
            string message = "";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        




       

    }
}