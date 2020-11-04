using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using PagedList;


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
                        sanpham.MaThuongHieu = String.IsNullOrEmpty(row["MaThuongHieu"].ToString()) ? 0 : int.Parse(row["MaThuongHieu"].ToString());
                        sanpham.TenSanPham = String.IsNullOrEmpty(row["TenSanPham"].ToString()) ? "" : row["TenSanPham"].ToString();
                        sanpham.HinhAnh = String.IsNullOrEmpty(row["HinhAnh"].ToString()) ? "" : row["HinhAnh"].ToString();
                        sanpham.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
                        sanpham.MoTa = String.IsNullOrEmpty(row["MoTa"].ToString()) ? "" : row["MoTa"].ToString();
                        sanpham.DanhGia = String.IsNullOrEmpty(row["DanhGia"].ToString()) ? "" : row["DanhGia"].ToString();
                        sanpham.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                        sanpham.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);                 
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
        //GetData Danh Muc
        public List<SanPham> GetDataDVTH(string MaDanhMuc)
        {
            try
            {
                List<SanPham> dsSanPham = new List<SanPham>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_SanPham_GetData", new object[] { MaDanhMuc }, new List<string>() { "MaDanhMuc" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        SanPham sanpham = new SanPham();
                        sanpham.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
                        sanpham.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
                        sanpham.MaThuongHieu = String.IsNullOrEmpty(row["MaThuongHieu"].ToString()) ? 0 : int.Parse(row["MaThuongHieu"].ToString());
                        sanpham.TenSanPham = String.IsNullOrEmpty(row["TenSanPham"].ToString()) ? "" : row["TenSanPham"].ToString();
                        sanpham.HinhAnh = String.IsNullOrEmpty(row["HinhAnh"].ToString()) ? "" : row["HinhAnh"].ToString();
                        sanpham.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
                        sanpham.MoTa = String.IsNullOrEmpty(row["MoTa"].ToString()) ? "" : row["MoTa"].ToString();
                        sanpham.DanhGia = String.IsNullOrEmpty(row["DanhGia"].ToString()) ? "" : row["DanhGia"].ToString();
                        sanpham.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                        sanpham.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
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
        //GetData Thuong Hieu
        public List<SanPham> GetDataTH(string MaThuongHieu)
        {
            try
            {
                List<SanPham> dsSanPham = new List<SanPham>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_SanPham_GetData", new object[] { MaThuongHieu }, new List<string>() { "MaThuongHieu" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        SanPham sanpham = new SanPham();
                        sanpham.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
                        sanpham.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
                        sanpham.MaThuongHieu = String.IsNullOrEmpty(row["MaThuongHieu"].ToString()) ? 0 : int.Parse(row["MaThuongHieu"].ToString());
                        sanpham.TenSanPham = String.IsNullOrEmpty(row["TenSanPham"].ToString()) ? "" : row["TenSanPham"].ToString();
                        sanpham.HinhAnh = String.IsNullOrEmpty(row["HinhAnh"].ToString()) ? "" : row["HinhAnh"].ToString();
                        sanpham.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
                        sanpham.MoTa = String.IsNullOrEmpty(row["MoTa"].ToString()) ? "" : row["MoTa"].ToString();
                        sanpham.DanhGia = String.IsNullOrEmpty(row["DanhGia"].ToString()) ? "" : row["DanhGia"].ToString();
                        sanpham.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                        sanpham.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
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


        public SanPham GetSanPhamByMa(int MaSanPham)
        {
            try
            {
                SanPham sanpham = null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_SanPham_GetData", new object[] { MaSanPham}, new List<string>() { "MaSanPham" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    sanpham = new SanPham();
                    sanpham.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
                    sanpham.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
                    sanpham.MaThuongHieu = String.IsNullOrEmpty(row["MaThuongHieu"].ToString()) ? 0 : int.Parse(row["MaThuongHieu"].ToString());
                    sanpham.TenSanPham = String.IsNullOrEmpty(row["TenSanPham"].ToString()) ? "" : row["TenSanPham"].ToString();
                    sanpham.HinhAnh = String.IsNullOrEmpty(row["HinhAnh"].ToString()) ? "" : row["HinhAnh"].ToString();
                    sanpham.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
                    sanpham.MoTa = String.IsNullOrEmpty(row["MoTa"].ToString()) ? "" : row["MoTa"].ToString();
                    sanpham.DanhGia = String.IsNullOrEmpty(row["DanhGia"].ToString()) ? "" : row["DanhGia"].ToString();
                    sanpham.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                    sanpham.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                }
                return sanpham;
            }
            catch (Exception ex)
            {
                return null;
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
               
                int kq = dataProvider.ExecuteNonQuery("Proc_SanPham_Update", new object[] { sanPham.MaSanPham,sanPham.MaDanhMuc,sanPham.MaThuongHieu,sanPham.TenSanPham,sanPham.HinhAnh, sanPham.MoTa, sanPham.DanhGia, sanPham.NgaySua },
                  new List<string>() {
                      "@MaSanPham",
                      "@MaDanhMuc" ,
                      "@MaThuongHieu",
              "@TenSanPham" ,
          
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