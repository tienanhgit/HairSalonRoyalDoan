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
            if (Session["CART_SESSION"] == null || Session["USER_SESSION"] == null)
            {
                return Redirect("/GioHang/Index");

            }
            else
            {
                var list = new List<GioHangItem>();
                if (cart != null)
                {
                    list = (List<GioHangItem>)cart;
                }

                return View(list);
            }


        }
        [HttpPost]
        public ActionResult DatHang()
        {
            string makh = "";
            string tennguoinhan = Request.Form["shipName"];
            string sodienthoainhanhang = Request.Form["mobile"];
            string diachi = Request.Form["address"];
            string TongTien = Request.Form["total-price-send"];

            DonDatHang donDatHang = new DonDatHang();
            donDatHang.DiaChiNhanHang = diachi;
            donDatHang.SoDTGiaoHang = Convert.ToInt32(sodienthoainhanhang);
            donDatHang.HoTenNguoiNhan = tennguoinhan;
            
            donDatHang.TongTien = Convert.ToDouble(TongTien);

            if (Session["CART_SESSION"] != null)
            {
                if (Session["USER_SESSION"] != null)
                {
                    var sdtkh = Session["USER_SESSION"].ToString();

                    int sdtkhnhan = Convert.ToInt32(sdtkh);


                    Khachhang kh = new KhachHangModel().GetKhachHangBySDT(sdtkhnhan);
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
            }
            Session["CART_SESSION"] = null;
            return View();

        }






        }
}