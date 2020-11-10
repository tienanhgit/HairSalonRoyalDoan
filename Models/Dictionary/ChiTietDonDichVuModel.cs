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


        public string ThemChiTietDonDichVu(ChiTietDonDichVu chiTietDonDichVu)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_ChiTietDonDichVu_Insert", new object[] {chiTietDonDichVu.MaDonDatHang, chiTietDonDichVu.MaDV},
                  new List<string>() {
                      "@MaDonDatHang",
                      "@MaDV"
                              
                   });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public List<ChiTietDonDichVu> GetDataDichVu(int MaDonDatHang)
        {
            try
            {
                List<ChiTietDonDichVu> dsChiTietDonDatDichVu = new List<ChiTietDonDichVu>();
                DataTable dt = dataProvider.ExecuteQuery("proc_getdata_chitietdondat_dichvu", new object[] { MaDonDatHang }, new List<string>() { "MaDonDatHang" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ChiTietDonDichVu chiTietDonDichVu = new ChiTietDonDichVu();
                        chiTietDonDichVu.MaDonDatHang = String.IsNullOrEmpty(row["MaDonDatHang"].ToString()) ? 0 : int.Parse(row["MaDonDatHang"].ToString());
                        chiTietDonDichVu.TenDichVu = String.IsNullOrEmpty(row["TenDV"].ToString()) ? "" : row["TenDV"].ToString();
                        chiTietDonDichVu.MaDV = String.IsNullOrEmpty(row["MaDV"].ToString()) ? 0 : int.Parse(row["MaDV"].ToString());
                        chiTietDonDichVu.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());

                        dsChiTietDonDatDichVu.Add(chiTietDonDichVu);

                    }
                    return dsChiTietDonDatDichVu;
                }
                return new List<ChiTietDonDichVu>();
            }
            catch (Exception ex)
            {
                return new List<ChiTietDonDichVu>();
            }
        }

    }
}