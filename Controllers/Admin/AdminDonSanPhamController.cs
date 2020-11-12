using HairSalonRoyalDoan.Models.Dictionary;
using HairSalonRoyalDoan.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services.Description;



namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class AdminDonSanPhamController : Controller
    {
        // GET: AdminDonSanPham
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
          
                List<DonDatHang> ddh = new DonDatHangModel().GetData();
                     return View(ddh.ToPagedList(page, pagesize));
            

        }
        [HttpPost]
        public JsonResult ChiTietDonSanPham(string MaDonDatHang)
        {
            List<ChiTietDonDat> listchitietdondat = new ChiTietDonDatModel().GetDataSanPham(Convert.ToInt32(MaDonDatHang));
            return Json(listchitietdondat, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ChiTietDonDichVu(string MaDonDatHang)
        {
            List<ChiTietDonDichVu> listchitietdondichvu = new ChiTietDonDichVuModel().GetDataDichVu(Convert.ToInt32(MaDonDatHang));
            return Json(listchitietdondichvu, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateTrangThai(string MaDonDatHang,string TrangThaiDonSanPham)
        {
            if (MaDonDatHang != null && TrangThaiDonSanPham != null)
            {
                string a = new DonDatHangModel().UpdateTrangThai(MaDonDatHang,TrangThaiDonSanPham,"");
            }

            return Json(new
            {
                status = true
            });
        }

        public ActionResult ThemHoaDon()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ThemHoaDonSanPham(string HoTenNguoiNhan, string SoDienThoaiNguoiNhan, string DiaChiGiaoHang, string HinhThucThanhToan,string TrangThai,List<GioHangItem> cartModel)
        {

            DonDatHangModel donDatHangModel = new DonDatHangModel();
                DonDatHang donDatHang = new DonDatHang();
                donDatHang.HoTenNguoiNhan = HoTenNguoiNhan;
                donDatHang.SoDTGiaoHang = Convert.ToInt32(SoDienThoaiNguoiNhan);
                donDatHang.DiaChiNhanHang = DiaChiGiaoHang;
                donDatHang.HinhThucThanhToan = HinhThucThanhToan;
                donDatHang.TrangThaiDonSanPham = Convert.ToInt32(TrangThai);
                donDatHang.NgayTao = DateTime.Now;
             
                  donDatHang.TrangThaiDonDichVu = 0;
                string MaDonHang = donDatHangModel.ThemDonDatHang(donDatHang);

                ChiTietDonDatModel chiTietDonDatModel = new ChiTietDonDatModel();
        
          
            foreach(var item in cartModel)
            {
                ProductModel productModel = new ProductModel();
              SanPham sp=  productModel.GetSanPhamByMa(item.sanpham.MaSanPham);   
                ChiTietDonDat chiTietDonDat = new ChiTietDonDat();
                chiTietDonDat.MaDonDatHang = Convert.ToInt32(MaDonHang);
                chiTietDonDat.SoLuong = item.SoLuong;
                chiTietDonDat.MaSanPham = item.sanpham.MaSanPham;
                chiTietDonDat.Gia = sp.Gia;
                chiTietDonDatModel.ThemChiTietDonDat(chiTietDonDat);
            }

            donDatHangModel.CapNhatTongTien(Convert.ToInt32(MaDonHang));
            
                       
                 

            string Message = "Thanh cong";
        

            return Json(Message, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult ThemDonDatSanPham()
        {
            return View();
        }



            [HttpPost]
        public ActionResult ThemDonDatSanPham(string Prefix)
        {
            if (Prefix != null)
            {
                ProductModel productModel = new ProductModel();
                List<SanPham> lsProduct = productModel.GetData();
                var ProductList = (from N in lsProduct
                                   where N.TenSanPham.StartsWith(Prefix)
                                   select new { N.TenSanPham, N.MaSanPham });



                return Json(ProductList, JsonRequestBehavior.AllowGet);

            }

            var Message = "Thêm sản phẩm thất bại";
            return Json(Message, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ThemSanPham(string MaSanPham)
        {
           
            if (MaSanPham!=null)
            {
               
                ProductModel productModel = new ProductModel();
                SanPham Product = productModel.GetSanPhamByMa(Convert.ToInt32(MaSanPham));
                return Json(Product, JsonRequestBehavior.AllowGet);

            }
            var Message = "Thêm sản phẩm thất bại";
            return Json(Message, JsonRequestBehavior.AllowGet);

        }

     


        //Đơn dịch vụ
        [HttpGet]
        public ActionResult ThemDonDatDichVu()
        {




            return View();
        }
        [HttpPost]
        public JsonResult ThemDonDatDichVu(string Prefix)
        {
            if (Prefix != null)
            {
                DichVuModel dichVuModel = new DichVuModel();
                List<DichVu> lsDichVu = dichVuModel.GetData();
                var ProductList = (from N in lsDichVu
                                   where N.TenDichVu.StartsWith(Prefix)
                                   select new { N.TenDichVu, N.MaDV });



                return Json(ProductList, JsonRequestBehavior.AllowGet);

            }

            var Message = "Thêm sản phẩm thất bại";
            return Json(Message, JsonRequestBehavior.AllowGet);



  
        }
        [HttpPost]
        public ActionResult ThemDichVu(string MaDV)
        {

            if (MaDV != null)
            {

                DichVuModel dichVuModel = new DichVuModel();
                DichVu dichVu = dichVuModel.GetDichVuByMa(Convert.ToInt32(MaDV));
                return Json(dichVu, JsonRequestBehavior.AllowGet);

            }
            var Message = "Thêm dịch vụ thất bại";
            return Json(Message, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult ThemHoaDonDichVu(string HoTenNguoiNhan, string SoDienThoaiNguoiNhan, string HinhThucThanhToan, string TrangThai, List<GioHangItem> cartModel)
        {

            DonDatHangModel donDatHangModel = new DonDatHangModel();

            DonDatHang donDatHang = new DonDatHang();
            donDatHang.HoTenNguoiNhan = HoTenNguoiNhan;
            donDatHang.SoDTGiaoHang = Convert.ToInt32(SoDienThoaiNguoiNhan);
            donDatHang.HinhThucThanhToan = HinhThucThanhToan;
            donDatHang.NgayTao = DateTime.Now;
            donDatHang.TrangThaiDonSanPham = 0;
            donDatHang.TrangThaiDonDichVu = Convert.ToInt32(TrangThai);
            string MaDonHang = donDatHangModel.ThemDonDatHang(donDatHang);

            ChiTietDonDichVuModel chiTietDonDichVuModel = new ChiTietDonDichVuModel();

            foreach (var item in cartModel)
            {
               
                
                ChiTietDonDichVu chiTietDonDichVu = new ChiTietDonDichVu();
                chiTietDonDichVu.MaDonDatHang = Convert.ToInt32(MaDonHang);
                chiTietDonDichVu.MaDV = item.dichvu.MaDV;
                chiTietDonDichVuModel.ThemChiTietDonDichVu(chiTietDonDichVu);
            }

            donDatHangModel.CapNhatTongTienDichVu(Convert.ToInt32(MaDonHang));


            string Message = "Thanh cong";


            return Json(Message, JsonRequestBehavior.AllowGet);

        }
















    }
}