using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class NhanVienModel
    {
        DataProvider dataProvider=new DataProvider();
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

        public  string DangNhap(string Email, string MatKhau)
        {

            DataTable dt = dataProvider.ExecuteQuery("Proc_NhanVien_DangNhap ", new object[] { Email, MatKhau }, new List<string>() { "@Email", "@MatKhau" });
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
                return "";
        }


        public string GetQuyen(string Email)
        {
            DataTable dt = dataProvider.ExecuteQuery("Nhanvien_GetChucVu", new object[] { Email }, new List<string>() { "@Email"});
            if (dt != null && dt.Rows.Count > 0)
            {
                var result = "";
                foreach (DataRow row in dt.Rows)
                {
                    result += row[nameof(NhanVien.MaChucVu)];
                }
                return result;
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
        public List<NhanVien> GetData()
        {
            try
            {
                List<NhanVien> dsKhachHang = new List<NhanVien>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_NhanVien_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        NhanVien nhanVien = new NhanVien();
                        
                        nhanVien.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                        nhanVien.HoTenNV = String.IsNullOrEmpty(row["HoTenNV"].ToString()) ? "" : row["HoTenNV"].ToString();
                        nhanVien.Email = String.IsNullOrEmpty(row["Email"].ToString()) ? "" : row["Email"].ToString();
                        nhanVien.MatKhau = String.IsNullOrEmpty(row["MatKhau"].ToString()) ? "" : row["MatKhau"].ToString(); 
                       nhanVien.SDTNV = String.IsNullOrEmpty(row["SoDTNV"].ToString()) ? "" : row["SoDTNV"].ToString();
                        nhanVien.QueQuan = String.IsNullOrEmpty(row["QueQuan"].ToString()) ? "" : row["QueQuan"].ToString();
                        nhanVien.CMND = String.IsNullOrEmpty(row["CMND"].ToString()) ? "" : row["CMND"].ToString();
                        nhanVien.NgaySinh = String.IsNullOrEmpty(row["NgaySinh"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySinh"]);
                        nhanVien.HinhThucLam= String.IsNullOrEmpty(row["Hinhthuclam"].ToString()) ? "" : row["Hinhthuclam"].ToString();
                        nhanVien.MaChucVu= String.IsNullOrEmpty(row["MaChucVu"].ToString()) ? 0 : int.Parse(row["MaChucVu"].ToString());
                        nhanVien.NgayTao= String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                        dsKhachHang.Add(nhanVien);
                    }
                    return dsKhachHang;
                }
                return new List<NhanVien>();
            }
            catch (Exception ex)
            {
                return new List<NhanVien>();
            }
        }
        public string ThemNhanVien(NhanVien nhanVien)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_NhanVien_Insert", new object[] { nhanVien.HoTenNV,nhanVien.Email,
                    nhanVien.MatKhau,nhanVien.SDTNV,nhanVien.QueQuan,nhanVien.CMND,
                    nhanVien.NgaySinh,nhanVien.HinhThucLam,nhanVien.MaChucVu,nhanVien.NgayTao,nhanVien.NgaySua},
                  new List<string>() {
                      "@HoTenNhanVien",
                      "@Email",
                      "@MatKhau",
                      "@SoDTNV",
                      "@QueQuan",
                      "@CMND",
                      "@NgaySinh",
                      "@Hinhthuclam",
                      "@MaChucVu",
                      "@NgayTao"                    
                   });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhatNhanVien(NhanVien nhanVien)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_DichVu_Update", new object[] {  nhanVien.HoTenNV,nhanVien.Email,
                    nhanVien.MatKhau,nhanVien.SDTNV,nhanVien.QueQuan,nhanVien.CMND,
                    nhanVien.NgaySinh,nhanVien.HinhThucLam,nhanVien.MaChucVu,nhanVien.NgayTao,nhanVien.NgaySua },
                  new List<string>() {
                    "@HoTenNhanVien",
                      "@Email",
                      "@MatKhau",
                      "@SoDTNV",
                      "@QueQuan",
                      "@CMND",
                      "@NgaySinh",
                      "@Hinhthuclam",
                      "@MaChucVu",
                      "@NgayTao"
                  });
                return kq.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }



    }
}