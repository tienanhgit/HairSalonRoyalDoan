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

            DataTable dt = dataProvider.ExecuteQuery("Proc_KhachHang_DangNhap ", new object[] { SDTKH, MatKhau }, new List<string>() { "@SDTKH", "@MatKhau" });
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
                return "";
        }
       
        public string CheckInsert(string SDT)
        {
            string result = dataProvider.ExecuteScalar("Proc_KhachHang_CheckTk", new object[] { SDT }, new List<string>() { "@SDT" });
            if (result != null)
            {

                return result;
            }
            else
                return "";
        }


        public List<Khachhang> GetData()
        {
            try
            {
                List<Khachhang> dsKhachHang = new List<Khachhang>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_KhachHang_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Khachhang khachhang = new Khachhang();
                        khachhang.MaKH = String.IsNullOrEmpty(row["MaKhachHang"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                        khachhang.HoTenKH = String.IsNullOrEmpty(row["HoTenKH"].ToString()) ? "" : row["HoTenKH"].ToString();
                        khachhang.SDTKH = String.IsNullOrEmpty(row["SoSTKH"].ToString()) ? 0 : int.Parse(row["SoDTKH"].ToString());
                        khachhang.Email = String.IsNullOrEmpty(row["Email"].ToString()) ? "" : row["Email"].ToString();
                        khachhang.DiaChi = String.IsNullOrEmpty(row["DiaChi"].ToString()) ? "" : row["DiaChi"].ToString();
                        khachhang.MatKhau= String.IsNullOrEmpty(row["MatKhau"].ToString()) ? "" : row["MatKhau"].ToString();
                        dsKhachHang.Add(khachhang);
                    }
                    return dsKhachHang;
                }
                return new List<Khachhang>();
            }
            catch (Exception ex)
            {
                return new List<Khachhang>();
            }
        }

        public Khachhang GetKhachHangByMa(int MaKhachHang)
        {
            try
            {
                Khachhang khachhang= null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_KhachHang_GetData", new object[] { MaKhachHang }, new List<string>() { "MaKH" });
                {
                    var row = dt.Rows[0];
                    khachhang = new Khachhang();
                    khachhang.MaKH = String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                    khachhang.HoTenKH = String.IsNullOrEmpty(row["HoTenKH"].ToString()) ? "" : row["HoTenKH"].ToString();
                    khachhang.SDTKH = String.IsNullOrEmpty(row["SoDTKH"].ToString()) ? 0 : int.Parse(row["SoDTKH"].ToString());
                    khachhang.Email = String.IsNullOrEmpty(row["Email"].ToString()) ? "" : row["Email"].ToString();
                    khachhang.DiaChi = String.IsNullOrEmpty(row["DiaChi"].ToString()) ? "" : row["DiaChi"].ToString();
                    khachhang.MatKhau = String.IsNullOrEmpty(row["MatKhau"].ToString()) ? "" : row["MatKhau"].ToString();

                }
                return khachhang;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Khachhang GetKhachHangBySDT(int SDTKH)
        {
            try
            {
                Khachhang khachhang = null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_KhachHang_GetData", new object[] {"","", SDTKH }, new List<string>() {"MaKH","HoTenKH","SoDTKH"});
                if (dt != null && dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    khachhang = new Khachhang();
                    khachhang.MaKH = String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                    khachhang.HoTenKH = String.IsNullOrEmpty(row["HoTenKH"].ToString()) ? "" : row["HoTenKH"].ToString();
                    khachhang.SDTKH = String.IsNullOrEmpty(row["SoDTKH"].ToString()) ? 0 : int.Parse(row["SoDTKH"].ToString());
                    khachhang.Email = String.IsNullOrEmpty(row["Email"].ToString()) ? "" : row["Email"].ToString();
                    khachhang.DiaChi = String.IsNullOrEmpty(row["DiaChi"].ToString()) ? "" : row["DiaChi"].ToString();
                    khachhang.MatKhau = String.IsNullOrEmpty(row["MatKhau"].ToString()) ? "" : row["MatKhau"].ToString();

                }
                return khachhang;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ThemKhachHang(Khachhang khachhang)
        {
            try
            {
                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_KhachHang_Insert", new object[] { khachhang.HoTenKH,khachhang.SDTKH,khachhang.Email,khachhang.DiaChi,khachhang.MatKhau },
                  new List<string>() {
                  "@HoTenKH",
                  "@SoDTKH",
                   "@Email",
                   "@DiaChi",
                    "@MatKhau" });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhatKhachHang(Khachhang khachhang)
        {
            try
            {

              int kq = dataProvider.ExecuteNonQuery("Proc_KhachHang_Update", new object[] {khachhang.MaKH, khachhang.HoTenKH, khachhang.SDTKH, khachhang.Email, khachhang.DiaChi, khachhang.MatKhau },
                  new List<string>() {
                      "@MaKH",
                           "@HoTenKH",
                  "@SoDTKH",
                   "@Email",
                   "@DiaChi",
                    "@MatKhau"
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