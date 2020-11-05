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

        public ActionResult Index(string MaDanhMuc,string MaThuongHieu, int page = 1, int pagesize = 6)
        {
            if (MaDanhMuc!= null)
            {
                ProductModel productModel1 = new ProductModel();
                List<SanPham> listsp1 = productModel1.GetDataDVTH(MaDanhMuc);
                var ls1 = listsp1.ToPagedList(page, pagesize);
                return View(ls1);
            }
            if (MaThuongHieu!= null)
            {
                ProductModel productModel2 = new ProductModel();
                List<SanPham> listsp2 = productModel2.GetDataTH(MaThuongHieu);
                var ls2= listsp2.ToPagedList(page, pagesize);
                return View(ls2);

            }

            ProductModel productModel = new ProductModel();
                List<SanPham> listsp = productModel.GetData();
                var ls = listsp.ToPagedList(page, pagesize);
                return View(ls);
            
        }

        

    [HttpGet]
        public ActionResult ProductDetail()
        {
            if (Request.QueryString["id"] != null)
            {
                int IdSanPham = Convert.ToInt32(Request.QueryString["id"]);

              
          SanPham  sp = new ProductModel().GetSanPhamByMa(IdSanPham);



                ViewBag.SanPham = sp;
            }
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
           
          
            List<ChiTietDonDat> listchitietdondat = new ChiTietDonDatModel().GetDataSanPham(Convert.ToInt32(MaDonDatHang));     
            return Json(listchitietdondat,JsonRequestBehavior.AllowGet);
        }



        }
}