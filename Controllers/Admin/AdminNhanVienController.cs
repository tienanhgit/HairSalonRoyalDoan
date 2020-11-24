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
        [HttpPost]
        public ActionResult ThemMoiNhanVien()
        {


            return View();
        }

        public ActionResult SuaNhanVien()
        {
            return View();
        }


    }
}