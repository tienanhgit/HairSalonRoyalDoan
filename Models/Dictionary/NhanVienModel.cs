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
                    result += row[nameof(NhanVien.ChucVu)];
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






    }
}