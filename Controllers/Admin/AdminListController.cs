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
    public class AdminListController : Controller
    {
        // GET: AdminList
        public ActionResult Index(int page = 1, int pagesize = 10)
        {

            List<DonDatHang> ddh = new DonDatHangModel().GetData();
   
            List<LichHen> llh = new LichHenModel().GetData();
            ViewBag.LichHen = llh.ToPagedList(page, pagesize);
            ViewBag.DonDathang = ddh.ToPagedList(page, pagesize);
            return View() ;
        }
        public ActionResult LichHen(int page = 1, int pagesize = 10, string NgayHen = "")
        {

            if(NgayHen!="")
            {

                DateTime NH = DateTime.Parse(NgayHen);
                List<LichHen> llh = new LichHenModel().GetDataByNgayHen(NH);
                ViewBag.LichHen = llh.ToPagedList(page, pagesize);
            }

            else
            {
                List<LichHen> llh = new LichHenModel().GetData();
                ViewBag.LichHen = llh.ToPagedList(page, pagesize);

            }


            return View("/AdminList/Index");

        }
        public ActionResult DonDatHang(int page = 1, int pagesize = 10, string NgayDat = "")
        {




            return View("/AdminList/Index");
        }

   
    }
}