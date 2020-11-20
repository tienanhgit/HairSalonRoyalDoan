using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class BannerModel
    {
        DataProvider dataProvider = new DataProvider();
        public Banner GetData()
        {
            try
            {
                Banner banner = null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_Banner_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    banner = new Banner();
                    banner.MaBanner = String.IsNullOrEmpty(row["MaBanner"].ToString()) ? 0 : int.Parse(row["MaBanner"].ToString());
                    banner.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                    banner.AnhBanner= String.IsNullOrEmpty(row["AnhBanner"].ToString()) ? "" : row["AnhBanner"].ToString();
                    banner.ViTri= String.IsNullOrEmpty(row["ViTri"].ToString()) ? 0 : int.Parse(row["ViTri"].ToString());
                    banner.TrangThaiHienThi= String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());
                    banner.NgaySua= String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                    banner.NgayTao= String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                }
                return banner;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string ThemBaner(Banner banner)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_Banner_Insert", new object[] { banner.MaNV,banner.ViTri,banner.TrangThaiHienThi,banner.AnhBanner,banner.NgayTao},
                  new List<string>() {
                    "@MaNV",
                    "@ViTri",
                     "@TrangThaiHienThi",
                    "@AnhBanner",               
                        "@NgayTao"
                  });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhatBanner(Banner banner)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_Banner_Update", new object[] { banner.MaBanner, banner.MaNV, banner.ViTri, banner.TrangThaiHienThi, banner.AnhBanner, banner.NgayTao },
                  new List<string>() {
                      "@MaBanner",
                       "@MaNV",
                    "@ViTri",
                     "@TrangThaiHienThi",
                    "@AnhBanner",
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