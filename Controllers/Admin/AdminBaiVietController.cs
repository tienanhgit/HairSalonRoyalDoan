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
            NhanVien nhanVien1 = new NhanVienModel().GetNhanVienByMa(1);
         List<NhanVien> lsnv= new NhanVienModel().GetData();
            //BaiViet bv = new BaiViet();
            //    std.MaNV = 1;
            //std.NgayTao = DateTime.Now;

            //baiVietModel.ThemBaiViet(std);
            string message = nhanVien1.MaNV.ToString();
            return Json(new { data= lsnv, JsonRequestBehavior.AllowGet });


        }
        public ActionResult SuaBaiViet(string MaBaiViet,string TenBaiViet,string TrangThaiHienThi,string DanhGia)
        {




            return View();
        }






    }
}