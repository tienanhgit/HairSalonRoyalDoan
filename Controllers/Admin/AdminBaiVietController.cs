using HairSalonRoyalDoan.Models.Dictionary;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Repository;

namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class AdminBaiVietController : Controller
    {
        // GET: AdminBaiViet
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            
            List<BaiViet> bv = new BaiVietModel().GetData();
            return View(bv.ToPagedList(page, pagesize));



        }
        [HttpGet]
        public ActionResult ThemMoiBaiViet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiBaiViet(BaiViet std)
        {
            
                BaiVietModel baiVietModel = new BaiVietModel();
                NhanVien nhanVien = new NhanVienModel().GetNhanVienByEmail(Session["ADMIN_SESSION"].ToString());
            
  
            std.MaNV = nhanVien.MaNV;
            std.NgayTao = DateTime.Now;

            baiVietModel.ThemBaiViet(std);
     
            return Json(new { data="", JsonRequestBehavior.AllowGet });


        }
        [HttpGet]
        public ActionResult SuaBaiViet(string MaBaiViet)
        {


            BaiVietModel baiVietModel = new BaiVietModel();
            BaiViet baiViet = new BaiViet();
            baiViet = baiVietModel.GetDataByMa(MaBaiViet);

            ViewBag.BaiViet = baiViet;
            return View();
        }
        [HttpPost]
        public JsonResult SuaBaiViet(BaiViet std)
        {
            std.NgaySua = DateTime.Now;
            std.MaNV = 1;
           string baiVietModel = new BaiVietModel().CapNhatBaiViet(std);

            return Json(new { data = "", JsonRequestBehavior.AllowGet });

        }


        }
    }