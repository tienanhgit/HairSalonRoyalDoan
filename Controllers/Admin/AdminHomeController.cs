using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairSalonRoyalDoan.Repository;
using HairSalonRoyalDoan.Models.Dictionary;
using PagedList;

namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome

        ProductModel productModel = new ProductModel();
        public int CheckQuyen()
        {
            if (Session["ADMIN_SESSION"] != null)
            {
                NhanVienModel nhanVienModel = new NhanVienModel();
                string macv=nhanVienModel.GetQuyen(Session["ADMIN_SESSION"].ToString());
                if (macv == "1")
                {
                    return 1;
                }
                else if(macv=="2")
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return 0;
            }

        }
       
        public ActionResult Index()
        {
            if (Session["ADMIN_SESSION"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");
            }
        }
        public ActionResult SanPham(int page = 1, int pagesize = 9)
        {
            
            List<SanPham> listsp = new ProductModel().GetData();
            ViewBag.ListSanPham = listsp;
            var links = listsp;

            if (CheckQuyen()==1)
            {
                return
                 Request.IsAjaxRequest()
                ? (ActionResult)PartialView("SanPham", listsp.ToPagedList(page, pagesize))
                : View(listsp.ToPagedList(page, pagesize));
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");


            }
        }

        [HttpGet]
        public ActionResult ThemSanPham()
        {
            if (CheckQuyen() == 1)
            {

                ViewBag.ListDanhMuc = new DanhMucModel().GetData();
                List<ThuongHieu> listThuongHieu = new ThuongHieuModel().GetData();
                ViewBag.ListThuongHieu = listThuongHieu;
                return View();
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");
            }

        }
        [HttpPost]
        public ActionResult ThemSanPham(SanPham std)
        {
           
            std.NgayTao =DateTime.Now;
            productModel.ThemSanPham(std);
            string message = "";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });   
        }

        [HttpGet]
        public ActionResult SuaSanPham()
        {
            if (CheckQuyen() == 1)
            {
                int MaSanPham = Convert.ToInt32(Request.QueryString["MaSanPham"]);
                int MaDanhMuc = Convert.ToInt32(Request.QueryString["MaDanhMuc"]);
                int MaThuongHieu = Convert.ToInt32(Request.QueryString["MaThuongHieu"]);

                ViewBag.MaDanhMuc = MaDanhMuc;
                ViewBag.MaThuongHieu = MaThuongHieu;

                List<ThuongHieu> listThuongHieu = new ThuongHieuModel().GetData();
                ViewBag.ListThuongHieu = listThuongHieu;

                List<DanhMuc> listDanhMuc = new DanhMucModel().GetData();
                ViewBag.ListDanhMuc = listDanhMuc;
                SanPham sp = new ProductModel().GetSanPhamByMa(MaSanPham);
                ViewBag.SanPham = sp;
                if (Session["ADMIN_SESSION"] != null)
                {
                    return View();
                }
                else
                {
                    return Redirect("/NhanVien/DangNhap");

                }
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");
            }

        }
        [HttpPost]
        public ActionResult SuaSanPham(SanPham std)
        {
            std.NgaySua = DateTime.Now;
            productModel.CapNhatSanPham(std);
            string message = "";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

   
        //Danh muc
        public ActionResult DanhMuc (int page = 1, int pagesize = 9)
        {
            if (CheckQuyen() == 1)
            {
                List<DanhMuc> lisdm = new DanhMucModel().GetData();



                return View(lisdm.ToPagedList(page, pagesize));

            }

            else
            {
                return Redirect("/NhanVien/DangNhap");


            }

        }
        [HttpGet]
        public ActionResult ThemDanhMuc()
        {
            if (CheckQuyen() == 1)
            {

                return View();
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");


            }

        }
        [HttpPost]
        public ActionResult ThemDanhMuc(DanhMuc std)
        {
            std.NgayTao = DateTime.Now;
           string a = new DanhMucModel().ThemDanhMuc(std);
            string message = "Thêm danh mục oke";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });


        }
        [HttpGet]
        public ActionResult SuaDanhMuc(string MaDanhMuc)
        {
            if (CheckQuyen() == 1)
            {
                DanhMucModel danhMucModel = new DanhMucModel();
                DanhMuc danhMuc = danhMucModel.GetDanhMucByMa(Convert.ToInt32(MaDanhMuc));
                ViewBag.DanhMuc = danhMuc;
                return View();
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");


            }

        }
        [HttpPost]
        public ActionResult SuaDanhMuc(DanhMuc std)
        {
            std.NgaySua = DateTime.Now;
            string a = new DanhMucModel().CapNhatDanhMuc(std);
            string message = "";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }


        //Thương hiệu
        public ActionResult ThuongHieu(int page = 1, int pagesize = 9)
        {
            if (CheckQuyen() == 1)
            {
                List<ThuongHieu> lstt = new ThuongHieuModel().GetData();

                return View(lstt.ToPagedList(page, pagesize));
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");


            }


        }
        [HttpGet]
        public ActionResult ThemThuongHieu()
        {
            if (CheckQuyen() == 1)
            {
                return View();
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");


            }
        }
        [HttpPost]
        public ActionResult ThemThuongHieu(ThuongHieu std)
        {
            std.NgayTao = DateTime.Now;
            string a = new ThuongHieuModel().ThemThuongHieu(std);
            string message = "Thêm danh mục oke";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });


        }
        [HttpGet]
        public ActionResult SuaThuongHieu(string MaThuongHieu)
        {
            if (CheckQuyen() == 1)
            {
                ThuongHieuModel thuongHieuModel = new ThuongHieuModel();
                ThuongHieu thuongHieu = thuongHieuModel.GetThuongHieuByMa(Convert.ToInt32(MaThuongHieu));
                ViewBag.ThuongHieu = thuongHieu;
                return View();
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");


            }
        }
        [HttpPost]
        public ActionResult SuaThuongHieu(ThuongHieu std)
        {
            std.NgaySua = DateTime.Now;
            string a = new ThuongHieuModel().CapNhatThuongHieu(std);
            string message = "";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        //Dich Vu

        public ActionResult DichVu(int page = 1, int pagesize =9)
        {
            if (CheckQuyen() == 1)
            {

                List<DichVu> lsdv = new DichVuModel().GetDataByTrangThai(2);//get all


                return View(lsdv.ToPagedList(page, pagesize));
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");


            }

        }

        public JsonResult UpdateTrangThaiDichVu(string MaDV, string TrangThaiDichVu)
        {
            if (MaDV != null && TrangThaiDichVu != null)
            {
                string a = new DichVuModel().CapNhatDichVu(MaDV, Convert.ToInt32(TrangThaiDichVu), DateTime.Now);
            }

            return Json(new
            {
                status = true
            });
        }

        public ActionResult ThemDichVu()
        {
            if (CheckQuyen() == 1)
            {


                return View();
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");


            }

        }
        [HttpPost]
        public JsonResult ThemDichVu(DichVu std)
        {
            std.NgayTao = DateTime.Now;
            DichVu dv = new DichVu();
            string a = new DichVuModel().ThemDichVu(std);
        
            return Json(new { Message = std, JsonRequestBehavior.AllowGet });

        }
        [HttpGet]
        public ActionResult ThemChiTietDichVu(string MaDV)
        {
            if (CheckQuyen() == 1)
            {


                DichVu dv = new DichVuModel().GetDichVuByMa(Convert.ToInt32(MaDV));
                ViewBag.DichVu = dv;
                return View();
            }
            else
            {
                return Redirect("/NhanVien/DangNhap");


            }

        }


            [HttpPost]
        public JsonResult ThemChiTietDichVu(string MaDV,string Buoc)
        {
           ChiTietDichVu chiTietDichVu=new ChiTietDichVu();
            chiTietDichVu.MaDV = Convert.ToInt32(MaDV);
            chiTietDichVu.Buoc = Buoc;
            ChiTietDichVuModel chiTietDichVuModel = new ChiTietDichVuModel();
            chiTietDichVuModel.ThemChiTietDichVu(chiTietDichVu);

            return Json(new { Message ="", JsonRequestBehavior.AllowGet });

        }

        








    }
}