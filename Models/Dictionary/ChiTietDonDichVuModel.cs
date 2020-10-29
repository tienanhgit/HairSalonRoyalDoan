using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class ChiTietDonDichVuModel
    {

        DataProvider dataProvider = new DataProvider();
        public List<ChiTietDonDichVu> GetData()
        {
            try
            {
                List<ChiTietDonDichVu> dsChiTietDonDichVu = new List<ChiTietDonDichVu>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_ChiTietDonDichVu_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ChiTietDonDichVu chiTietDonDichVu = new ChiTietDonDichVu();
                        chiTietDonDichVu.MaDonDatHang = String.IsNullOrEmpty(row["MaDonDatHang"].ToString()) ? 0 : int.Parse(row["MaDonDatHang"].ToString());
                        chiTietDonDichVu.MaDV = String.IsNullOrEmpty(row["MaDV"].ToString()) ? 0 : int.Parse(row["MaDV"].ToString()); ;
                        chiTietDonDichVu.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString()); ;
                        chiTietDonDichVu.NgayDat = String.IsNullOrEmpty(row["NgayDat"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayDat"]);
                        chiTietDonDichVu.GioDat = String.IsNullOrEmpty(row["GioDat"].ToString()) ? 0 : int.Parse(row["GioDat"].ToString());
                        dsChiTietDonDichVu.Add(chiTietDonDichVu);
                    }
                    return dsChiTietDonDichVu;
                }
                return new List<ChiTietDonDichVu>();
            }
            catch (Exception ex)
            {
                return new List<ChiTietDonDichVu>();
            }
        }


        public string ThemDichVu(ChiTietDonDichVu chiTietDonDichVu)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_ChiTietDonDichVu_Insert", new object[] {chiTietDonDichVu.MaDonDatHang, chiTietDonDichVu.MaDV,chiTietDonDichVu.MaNV,chiTietDonDichVu.NgayDat,chiTietDonDichVu.GioDat},
                  new List<string>() {
                      "@MaDonDatHang",
                      "@MaDichVu",
                      "@MaNV",
                      "@NgayDat",
                      "@GioDat"
                   });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }



    }
}