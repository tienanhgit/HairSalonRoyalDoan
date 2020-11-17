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
        [HttpGet]
        public ActionResult Index()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Index(string searchString, int? page)
        {

            int pageSize = 10;
            List<LichHen> data = new LichHenModel().GetDataByTrangThai(2);

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int start = (int)(page - 1) * pageSize;
            ViewBag.pageCurrent = page;
            if (searchString != null && searchString != "")
            {

                data = new List<LichHen>(data.Where(p => p.SoDTKH.ToLower().Contains(searchString)));
            }
            int totalPage = data.Count();
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            var dataPost = data.OrderByDescending(x => x.MaLichHen).Skip(start).Take(pageSize);


            // return Json(listPost);
            return Json(new { data = dataPost, pageCurrent = page, numSize = numSize, ss = searchString }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult LichHenLamMoi()
        {

            LichHenModel lichHenModel = new LichHenModel();
            List<LichHen> lslh = lichHenModel.GetDataByTrangThai(1);

            return Json(lslh, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateTrangThai(string MaLichHen, string TrangThai)
        {

            if (MaLichHen != null && TrangThai != null)
            {
                string a = new LichHenModel().UpdateTrangThai(Convert.ToInt32(MaLichHen), Convert.ToInt32(TrangThai));
            }

            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult SuaLichHen(string NgayCat, string GioHen, string MaLichHen, string MaNV)
        {
            if (NgayCat != null && GioHen != null && MaNV != null)
            {
             
                LichHen lichHen = new LichHen();
                LichHenModel lichHenModel = new LichHenModel(); 
                lichHen.NgayHen = NgayCat;
                lichHen.GioHen = GioHen;
                lichHen.MaLichHen = Convert.ToInt32(MaLichHen);
                lichHen.MaNV = Convert.ToInt32(MaNV);            
                lichHenModel.CapNhatLichHen(lichHen);
            }

            return Json(new
            {
                status = true
            });

        }





    }
}