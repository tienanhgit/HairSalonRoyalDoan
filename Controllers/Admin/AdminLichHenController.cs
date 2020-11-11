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
    public class AdminLichHenController : Controller
    {
        // GET: AdminLichHen
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            List<LichHen> lslh = new LichHenModel().GetDataAll();

             lslh.Reverse();


            return View(lslh.ToPagedList(page, pagesize));
        }

        public JsonResult LichHenLamMoi()
        {

            LichHenModel lichHenModel = new LichHenModel();
            List<LichHen> lslh = lichHenModel.GetDataByTrangThai(1);
             
                return Json(lslh, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateTrangThai(string MaLichHen,string TrangThai)
        {
         
            if (MaLichHen != null && TrangThai != null)
            {
                string a = new LichHenModel().UpdateTrangThai(Convert.ToInt32(MaLichHen),Convert.ToInt32(TrangThai));
            }

            return Json(new
            {
                status = true
            });
        }



    }
}