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
    public class AdminNhanVienController : Controller
    {
        // GET: AdminNhanVien
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            NhanVien nhanVien = new NhanVien();
            NhanVienModel nhanVienModel = new NhanVienModel();
            List<NhanVien> lsnv = nhanVienModel.GetData();
            //ViewBag.NhanVien = nhanVienModel.GetNhanVienByEmail("ngocdoan@gmail.com");
            ViewBag.NhanVien = nhanVienModel.GetNhanVienByMa(1);
            ViewBag.ListNV = lsnv;
            return View(lsnv.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public ActionResult ThemMoiNhanVien()
        {
            ChucVuModel chucVuModel = new ChucVuModel();
            ViewBag.ChucVu = chucVuModel.GetData();


            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiNhanVien(ChucVu std)
        {
            ChucVuModel chucVuModel = new ChucVuModel();
            ViewBag.ChucVu = chucVuModel.GetData();
            return View();
        }

        public ActionResult SuaNhanVien()
        {
            return View();
        }


    }
}