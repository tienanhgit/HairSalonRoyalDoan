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
        public JsonResult DatDichVu(string NgayCat,string GioHen,string MaNV)
        {
            if (Session["USER_SESSION"] != null)
            {
                var makh = "";
            if (NgayCat != null && GioHen != null && MaNV != null)
            {
                    var sdtkh = Session["USER_SESSION"].ToString();
                    Khachhang khachhang = new KhachHangModel().GetKhachHangBySDT(Convert.ToInt32(sdtkh));
                    makh = khachhang.MaKH.ToString();         
                    LichHen lichHen = new LichHen();
                    LichHenModel lichHenModel =new LichHenModel();
                    lichHen.MaKH =Convert.ToInt32(makh);
                    lichHen.NgayHen = Convert.ToDateTime(NgayCat);
                    lichHen.GioHen = Convert.ToDateTime(GioHen);
                    lichHen.MaNV = Convert.ToInt32(MaNV);
                    lichHenModel.ThemLichHen(lichHen);
                }

            }
            return Json(new { Message = NgayCat, JsonRequestBehavior.AllowGet });
        }
  







    }
}