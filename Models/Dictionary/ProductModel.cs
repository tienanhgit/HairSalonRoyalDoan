using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;


namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class ProductModel
    {

        DataProvider dataProvider = new DataProvider();
        public List<SanPham> GetData()
        {
            try
            {
                List<SanPham> dsSanPham = new List<SanPham>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_SanPham_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        SanPham sanpham = new SanPham();
                        sanpham.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
                        sanpham.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
                        sanpham.TenSanPham = String.IsNullOrEmpty(row["TenSanPham"].ToString()) ? "" : row["TenSanPham"].ToString();
                        sanpham.HinhAnh = String.IsNullOrEmpty(row["HinhAnh"].ToString()) ? "" : row["HinhAnh"].ToString();
                        sanpham.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
                        sanpham.MoTa = String.IsNullOrEmpty(row["MoTa"].ToString()) ? "" : row["MoTa"].ToString();
                        sanpham.DanhGia = String.IsNullOrEmpty(row["DanhGia"].ToString()) ? "" : row["DanhGia"].ToString();
                        sanpham.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"].ToString());
                        sanpham.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"].ToString());
                        dsSanPham.Add(sanpham);
                    }
                    return dsSanPham;
                }
                return new List<SanPham>();
            }
            catch (Exception ex)
            {
                return new List<SanPham>();
            }
        }

        public string ThemSanPham(SanPham sanPham)
        {
            try
            {
                
                string rs = "";           
                rs = dataProvider.ExecuteScalar("Proc_SanPham_Insert", new object[] {sanPham.MaThuongHieu, sanPham.MaDanhMuc, sanPham.TenSanPham, sanPham.Gia, sanPham.HinhAnh, sanPham.MoTa, sanPham.DanhGia, sanPham.NgayTao },
                  new List<string>() {
                      "@MaThuongHieu",
                      "@MaDanhMuc",
                       "@TenSanPham" ,
                      "@Gia" ,
                         "@HinhAnh" ,
                        "@MoTa",
                         "@DanhGia",
              "@NgayTao" });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhatSanPham(SanPham sanPham)
        {
            try
            {
               
                int kq = dataProvider.ExecuteNonQuery("Proc_SanPham_Update", new object[] { sanPham.MaDanhMuc, sanPham.TenSanPham, sanPham.Gia, sanPham.HinhAnh, sanPham.MoTa, sanPham.DanhGia, sanPham.NgaySua },
                  new List<string>() {"@MaDanhMuc" ,
              "@TenSanPham" ,
              "@Gia" ,
              "@HinhAnh" ,
              "@MoTa",
              "@DanhGia",
              "@NgaySua"  });
                return kq.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }






    }
}