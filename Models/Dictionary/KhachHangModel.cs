using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class KhachHangModel
    {
        DataProvider dataProvider = new DataProvider();
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public string DangNhap(string SDTKH, string MatKhau)
        {

            DataTable dt = dataProvider.ExecuteQuery("Proc_NhanVien_DangNhap ", new object[] { SDTKH, MatKhau }, new List<string>() { "@Email", "@MatKhau" });
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
                return "";
        }

        public string CheckInsert(string Email)
        {
            string result = dataProvider.ExecuteScalar("Nhanvien_GetChucVu", new object[] { Email }, new List<string>() { "@Email" });
            if (result != null)
            {

                return result;
            }
            else
                return "";
        }


        //public List<Khachhang> GetData()
        //{
        //    try
        //    {
        //        List<SanPham> dsSanPham = new List<SanPham>();
        //        DataTable dt = dataProvider.ExecuteQuery("Proc_SanPham_GetData", null, null);
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                SanPham sanpham = new SanPham();
        //                sanpham.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
        //                sanpham.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
        //                sanpham.MaThuongHieu = String.IsNullOrEmpty(row["MaThuongHieu"].ToString()) ? 0 : int.Parse(row["MaThuongHieu"].ToString());
        //                sanpham.TenSanPham = String.IsNullOrEmpty(row["TenSanPham"].ToString()) ? "" : row["TenSanPham"].ToString();
        //                sanpham.HinhAnh = String.IsNullOrEmpty(row["HinhAnh"].ToString()) ? "" : row["HinhAnh"].ToString();
        //                sanpham.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
        //                sanpham.MoTa = String.IsNullOrEmpty(row["MoTa"].ToString()) ? "" : row["MoTa"].ToString();
        //                sanpham.DanhGia = String.IsNullOrEmpty(row["DanhGia"].ToString()) ? "" : row["DanhGia"].ToString();
        //                sanpham.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
        //                sanpham.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
        //                dsSanPham.Add(sanpham);

        //            }
        //            return dsSanPham;
        //        }
        //        return new List<Khachhang>();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<SanPham>();
        //    }
        //}

        //public SanPham GetSanPhamByMa(int MaSanPham)
        //{
        //    try
        //    {
        //        SanPham sanpham = null;
        //        DataTable dt = dataProvider.ExecuteQuery("Proc_SanPham_GetData", new object[] { MaSanPham }, new List<string>() { "MaSanPham" });
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            var row = dt.Rows[0];
        //            sanpham = new SanPham();
        //            sanpham.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
        //            sanpham.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
        //            sanpham.TenSanPham = String.IsNullOrEmpty(row["TenSanPham"].ToString()) ? "" : row["TenSanPham"].ToString();
        //            sanpham.HinhAnh = String.IsNullOrEmpty(row["HinhAnh"].ToString()) ? "" : row["HinhAnh"].ToString();
        //            sanpham.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
        //            sanpham.MoTa = String.IsNullOrEmpty(row["MoTa"].ToString()) ? "" : row["MoTa"].ToString();
        //            sanpham.DanhGia = String.IsNullOrEmpty(row["DanhGia"].ToString()) ? "" : row["DanhGia"].ToString();
        //            sanpham.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
        //            sanpham.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
        //        }
        //        return sanpham;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        //public string ThemSanPham(SanPham sanPham)
        //{
        //    try
        //    {

        //        string rs = "";
        //        rs = dataProvider.ExecuteScalar("Proc_SanPham_Insert", new object[] { sanPham.MaThuongHieu, sanPham.MaDanhMuc, sanPham.TenSanPham, sanPham.Gia, sanPham.HinhAnh, sanPham.MoTa, sanPham.DanhGia, sanPham.NgayTao },
        //          new List<string>() {
        //              "@MaThuongHieu",
        //              "@MaDanhMuc",
        //               "@TenSanPham" ,
        //              "@Gia" ,
        //              "@HinhAnh" ,
        //                "@MoTa",
        //                 "@DanhGia",
        //                "@NgayTao" });
        //        return rs;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}

        //public string CapNhatSanPham(SanPham sanPham)
        //{
        //    try
        //    {

        //        int kq = dataProvider.ExecuteNonQuery("Proc_SanPham_Update", new object[] { sanPham.MaSanPham, sanPham.MaDanhMuc, sanPham.TenSanPham, sanPham.Gia, sanPham.HinhAnh, sanPham.MoTa, sanPham.DanhGia, sanPham.NgaySua },
        //          new List<string>() {
        //              "@MaSanPham",
        //              "@MaDanhMuc" ,
        //      "@TenSanPham" ,
        //      "@Gia" ,
        //      "@HinhAnh" ,
        //      "@MoTa",
        //      "@DanhGia",
        //      "@NgaySua"  });
        //        return kq.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}








    }
}