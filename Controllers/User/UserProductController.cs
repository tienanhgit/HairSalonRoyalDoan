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
        [HttpGet]
        public ActionResult QuanLyDonHang()
        {
            if (Session["USER_SESSION"] != null)
            {
                var sdtkh = Session["USER_SESSION"];

                Khachhang kh = new KhachHangModel().GetKhachHangBySDT(Convert.ToInt32(sdtkh));
                List<DonDatHang> ddh = new DonDatHangModel().GetDataByMaKH(kh.MaKH);
                List<ChiTietDonDat> listchitietdondat = new ChiTietDonDatModel().GetData();
                List<SanPham> listsanpham = new ProductModel().GetData();

                return View(ddh);
            }
            return Redirect("/KhachHang/DangNhap");
        }
        [HttpPost]
        public JsonResult QuanLyDonHang(string MaDonDatHang)
        {
           
            List<ChiTietDonDat> listctdd = new ChiTietDonDatModel().GetData();
            List<ChiTietDonDat> listchitietdondat = new ChiTietDonDatModel().GetDataSanPham(Convert.ToInt32(MaDonDatHang));     
            return Json(listchitietdondat,JsonRequestBehavior.AllowGet);
        }



        }
}