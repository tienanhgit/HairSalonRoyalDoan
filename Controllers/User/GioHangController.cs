using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Controllers;
using HairSalonRoyalDoan.Models.Dictionary;
using HairSalonRoyalDoan.Repository;

namespace HairSalonRoyalDoan.Controllers.User
{
    public class GioHangController : Controller
    {
        DonDatHangModel donDatHangModel = new DonDatHangModel();
        ChiTietDonDatModel chiTietDonDatModel = new ChiTietDonDatModel();

        // GET: GioHang
        public ActionResult Index()
        {
            var cart = Session["CART_SESSION"];
            var list = new List<GioHangItem>();
            if (cart != null)
            {
                list = (List<GioHangItem>)cart;
            }
      
            return View(list);
        }

        [HttpPost]
        public ActionResult ThemSanPhamGioHang(int SanPhamID)
        {
            //Bắt đầu khởi tạo session
            var message = ""; 
            var Soluong = 1;
            var sanpham = new ProductModel().GetSanPhamByMa(SanPhamID);
            var cart = Session["CART_SESSION"];
            if (cart != null)
            {
                var list = (List<GioHangItem>)cart;
                
                if (list.Exists(x => x.sanpham.MaSanPham == SanPhamID))
                {
                    foreach (var item in list)
                    {
                        if (item.sanpham.MaSanPham == SanPhamID)
                        {
                            item.SoLuong += Soluong;
                        }
                    }
                }
                else
                {
                  
                var item = new GioHangItem();
                item.sanpham = sanpham;
                item.SoLuong = Soluong;
                list.Add(item);
                Session["CART_SESSION"] = list;
                }
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new GioHangItem();
                item.sanpham = sanpham;
                item.SoLuong = Soluong;
                var list = new List<GioHangItem>();
                list.Add(item);
                //Gán vào session
                Session["CART_SESSION"] = list;
            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }



        [HttpPost]
        public JsonResult Update(string SanPhamID,string SoLuongMoi)
        {
                var cart = Session["CART_SESSION"]; 
                int spid = Convert.ToInt32(SanPhamID);
                int slm = Convert.ToInt32(SoLuongMoi);  
                var list = (List<GioHangItem>)cart;
           
           
                foreach (var item in list)
                {

                    if (item.sanpham.MaSanPham == spid)
                    {
                        item.SoLuong = slm;
                    }
                }
                Session["CART_SESSION"] = list;

                return Json(new
                {
                    status = true
                }); 
        }


        [HttpPost]
        public JsonResult XoaSanPhamGioHang(int SanPhamID)
        {
           
            var sessionCart = (List<GioHangItem>)Session["CART_SESSION"]; 
            sessionCart.RemoveAll(x => x.sanpham.MaSanPham == SanPhamID);
            Session["CART_SESSION"] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult ThanhToanGioHang()
        {
            var cart = Session["CART_SESSION"];
            var list = new List<GioHangItem>();
            if (cart != null)
            {
                list = (List<GioHangItem>)cart;
            }

            return View(list);
            

        }
        public ActionResult DatHang()
        {
            string makh = "";
            DonDatHang donDatHang = new DonDatHang();

            if (Session["USER_SESSION"] != null)
            {
                var sdtkh = Session["USER_SESSION"].ToString();
                int sdtkhc = Convert.ToInt32(sdtkh);
                Khachhang kh = new KhachHangModel().GetKhachHangBySDT(sdtkhc);
                makh = kh.MaKH.ToString();
            }
            var cart = Session["CART_SESSION"];
            var list = new List<GioHangItem>();
            if (cart != null)
            {
                list = (List<GioHangItem>)cart;
            }
            if (makh != "" & makh != null)
            {
                donDatHang.MaKH = Convert.ToInt32(makh);

            }

            donDatHang.NgayTao = DateTime.Now;
            donDatHang.DiaChiNhanHang = "1";
            donDatHang.HoTenNguoiNhan = "1";

            string madondathang = donDatHangModel.ThemDonDatHang(donDatHang);


            if (madondathang != null)
            {
                foreach (var item in list)
                {
                    ChiTietDonDat chiTietDonDat = new ChiTietDonDat();

                    chiTietDonDat.MaDonDatHang = Convert.ToInt32(madondathang);
                    chiTietDonDat.SoLuong = item.SoLuong;
                    chiTietDonDat.MaSanPham = item.sanpham.MaSanPham;

                    chiTietDonDatModel.ThemChiTietDonDat(chiTietDonDat);

                }
            }
            return View();

        }









        }
}