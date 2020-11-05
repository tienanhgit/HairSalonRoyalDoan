using HairSalonRoyalDoan.Models.Dictionary;
using HairSalonRoyalDoan.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

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



        public ActionResult ThemDonDatSanPham()
        {






            return View();
        }
            
            
           
      










    }
}