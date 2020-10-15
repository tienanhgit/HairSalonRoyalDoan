using HairSalonRoyalDoan.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HairSalonRoyalDoan.Repository;
using System.Data;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class DanhMucModel
    {
        DataProvider dataProvider = new DataProvider();
        public List<DanhMuc> GetData()
        {
            try
            {
                List<DanhMuc> dsDanhMuc = new List<DanhMuc>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_DanhMuc_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DanhMuc danhMuc = new DanhMuc();
                        danhMuc.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
                        danhMuc.TenDanhMuc = String.IsNullOrEmpty(row["TenDanhMuc"].ToString()) ? "" : row["TenDanhMuc"].ToString();
                        dsDanhMuc.Add(danhMuc);
                    }
                    return dsDanhMuc;
                }
                return new List<DanhMuc>();
            }
            catch (Exception ex)
            {
                return new List<DanhMuc>();
            }
        }

        public DanhMuc GetDanhMucByMa(int MaDanhMuc)
        {
            try
            {
                DanhMuc danhMuc = null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_DanhMuc_GetData", new object[] { MaDanhMuc }, new List<string>() { "MaDanhMuc" });
                if (dt != null && dt.Rows.Count > 0)
                {
               
                    var row = dt.Rows[0];
                    danhMuc = new DanhMuc();
                    danhMuc.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
                    danhMuc.TenDanhMuc = String.IsNullOrEmpty(row["TenDanhMuc"].ToString()) ? "" : row["TenDanhMuc"].ToString();

                }
                return danhMuc;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




    }
}
