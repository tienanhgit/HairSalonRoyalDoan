using HairSalonRoyalDoan.Models.Dictionary;
using HairSalonRoyalDoan.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class AdminBannerController : Controller
    {
        // GET: AdminBanner
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            List<Banner> lsbn = new BannerModel().GetData();


            return View(lsbn.ToPagedList(page, pagesize));
        }
        public ActionResult ThemMoiBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiBanner(Banner std)
        {

            BannerModel bannerModel = new BannerModel();
            NhanVien nhanVien = new NhanVienModel().GetNhanVienByEmail(Session["ADMIN_SESSION"].ToString());
            std.MaNV = nhanVien.MaNV;
            std.NgayTao = DateTime.Now;


            bannerModel.ThemBaner(std);

            return Json(new { data = "", JsonRequestBehavior.AllowGet });


        }





    }
}