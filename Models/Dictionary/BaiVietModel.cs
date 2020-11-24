using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class BaiVietModel
    {
        DataProvider dataProvider = new DataProvider();
        public BaiViet GetDataByMa(string MaBaiViet)
        {
            try
            {
                BaiViet baiViet = null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_BaiViet_GetData", new object[] {MaBaiViet } ,new List<string>() {
                      "@MaBaiViet" 
                  });
                if (dt != null && dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    baiViet = new BaiViet();
                    baiViet.MaBaiViet = String.IsNullOrEmpty(row["MaBaiViet"].ToString()) ? 0 : int.Parse(row["MaBaiViet"].ToString());
                    baiViet.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                    baiViet.TenBaiViet = String.IsNullOrEmpty(row["TenBaiViet"].ToString()) ? "" : row["TenBaiViet"].ToString();
                    baiViet.NoiDung = String.IsNullOrEmpty(row["NoiDung"].ToString()) ? "" : row["NoiDung"].ToString();
                    baiViet.NgaySua= String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                    baiViet.NgayTao= String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                    baiViet.TrangThaiHienThi = String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());       
                }
                return baiViet;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<BaiViet> GetData()
        {
            try
            {
                List<BaiViet> dsBaiViet = new List<BaiViet>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_BaiViet_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BaiViet baiViet = new BaiViet();
                        baiViet.MaBaiViet = String.IsNullOrEmpty(row["MaBaiViet"].ToString()) ? 0 : int.Parse(row["MaBaiViet"].ToString());
                        baiViet.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                        baiViet.TenBaiViet = String.IsNullOrEmpty(row["TenBaiViet"].ToString()) ? "" : row["TenBaiViet"].ToString();
                        baiViet.NoiDung = String.IsNullOrEmpty(row["NoiDung"].ToString()) ? "" : row["NoiDung"].ToString();
                        baiViet.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                        baiViet.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                        baiViet.TrangThaiHienThi = String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());
                        dsBaiViet.Add(baiViet);
                    }
                    return dsBaiViet;
                }
                return new List<BaiViet>();
            }
            catch (Exception ex)
            {
                return new List<BaiViet>();
            }
        }

        public string ThemBaiViet(BaiViet baiViet)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_BaiViet_Insert", new object[] {baiViet.MaNV,baiViet.TenBaiViet,baiViet.NoiDung,baiViet.TrangThaiHienThi,baiViet.NgayTao },
                  new List<string>() {
                    "@MaNV",
                    "@TenBaiViet",
                    "@NoiDung",
                       "@TrangThaiHienThi",
                        "@NgayTao"            
                  });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhatBaiViet(BaiViet baiViet)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_BaiViet_Update", new object[] {baiViet.MaBaiViet, baiViet.MaNV, baiViet.TenBaiViet, baiViet.NoiDung, baiViet.TrangThaiHienThi, baiViet.NgaySua },
                  new List<string>() {
                      "@MaBaiViet",
                  "@MaNV",
                    "@TenBaiViet",
                    "@NoiDung",
                       "@TrangThaiHienThi",
                        "@NgaySua"
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