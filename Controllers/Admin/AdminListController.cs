using HairSalonRoyalDoan.Models.Dictionary;
using HairSalonRoyalDoan.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class AdminListController : Controller
    {
        // GET: AdminList
        public ActionResult Index(int page = 1, int pagesize = 10)
        {

            List<DonDatHang> ddh = new DonDatHangModel().GetData();
   
            List<LichHen> llh = new LichHenModel().GetData();
            ViewBag.LichHen = llh.ToPagedList(page, pagesize);
            ViewBag.DonDatHang = ddh.ToPagedList(page, pagesize);
            return View() ;
        }
        public ActionResult LichHen(int page = 1, int pagesize = 10, string NgayHen = "")
        {

            if(NgayHen!="")
            {
                List<DonDatHang> ddh = new DonDatHangModel().GetData();
                ViewBag.DonDatHang = ddh.ToPagedList(page, pagesize);
                DateTime NH = DateTime.ParseExact(NgayHen,"MM/dd/yyyy", CultureInfo.InvariantCulture); ;
                List<LichHen> llh = new LichHenModel().GetDataByNgayHen(NH);
                ViewBag.LichHen = llh.ToPagedList(page, pagesize);
            }

            else
            {
                List<DonDatHang> ddh = new DonDatHangModel().GetData();
                List<LichHen> llh = new LichHenModel().GetData();
                ViewBag.LichHen = llh.ToPagedList(page, pagesize);
                ViewBag.DonDatHang = ddh.ToPagedList(page, pagesize);

            }


            return View("Index");

        }
        public ActionResult DonDatHang(int page = 1, int pagesize = 10, string NgayDat = "")
        {




            return View("/AdminList/Index");
        }

   
    }
}