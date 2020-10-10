using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using HairSalonRoyalDoan.Models.Common;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class NhanVienModel
    {
        DataProvider dataProvider=new DataProvider();
        
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

        //public string GetQuyen(string MaCongChuc)
        //{
        //    DataTable dt = da.ExecuteQuery("Proc_BoPhan_CongChuc_GetData", new object[] { MaCongChuc }, new List<string>() { "@MaCongChuc" });
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        var result = "";
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            result += row[nameof(BoPhan.TenVietTat)] + ";";
        //        }
        //        return result;
        //    }
        //    else
        //        return "";
        //}




    }
}