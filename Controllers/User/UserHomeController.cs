using System;
using System.Collections.Generic;
using System.Globalization;
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
        public ActionResult XemDichVu()
        {

            List<DichVu> listdv = new DichVuModel().GetData();
            ViewBag.listdv = listdv;

            return View(listdv);
        }

        public ActionResult BaiViet()
        {



            return View();
        }



      [HttpPost]
        public JsonResult DatDichVu(string NgayCat,string IdKhungThoiGian,string GhiChu,string[] ListIdDichVu)
        {
            if (Session["USER_SESSION"] != null)
            {
                var makh = "";
            if (IdKhungThoiGian != null && GhiChu != null && ListIdDichVu != null)
            {
                    var sdtkh = Session["USER_SESSION"].ToString();
                    Khachhang khachhang = new KhachHangModel().GetKhachHangBySDT(Convert.ToInt32(sdtkh));
                    makh = khachhang.MaKH.ToString();
                   
                    DonDatHang donDatHang = new DonDatHang();
                    DonDatHangModel donDatHangModel = new DonDatHangModel();
                    ChiTietDonDichVu chiTietDonDichVu = new ChiTietDonDichVu();
                     ChiTietDonDichVuModel chiTietDonDichVuModel = new ChiTietDonDichVuModel();
                    donDatHang.MaKH = Convert.ToInt32(makh);
                
                    donDatHang.NgayTao = DateTime.Now;
    
                    
                    string MaDonDatHang = donDatHangModel.ThemDonDatHang(donDatHang);
                    if (MaDonDatHang != null)
                    {
                        foreach (var item in ListIdDichVu)
                        {
                            chiTietDonDichVu.MaDV = Convert.ToInt32(item);
                            chiTietDonDichVu.MaDonDatHang = Convert.ToInt32(MaDonDatHang);
                            chiTietDonDichVuModel.ThemChiTietDonDichVu(chiTietDonDichVu);

                        }

                    }


                }




            }


            return Json(new { Message = NgayCat, JsonRequestBehavior.AllowGet });
        }
  







    }
}