using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class ChiTietDichVuModel
    {

        DataProvider dataProvider = new DataProvider();
        public List<ChiTietDichVu> GetData()
        {
            try
            {
                List<ChiTietDichVu> dsDichVu = new List<ChiTietDichVu>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_ChiTietDichVu_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ChiTietDichVu chitietdichvu = new ChiTietDichVu();
                        chitietdichvu.MaCTDV= String.IsNullOrEmpty(row["MaCTDV"].ToString()) ? 0 : int.Parse(row["MaCTDV"].ToString());
                        chitietdichvu.MaDV= String.IsNullOrEmpty(row["MaDV"].ToString()) ? 0 : int.Parse(row["MaDV"].ToString());
                        chitietdichvu.Buoc = String.IsNullOrEmpty(row["Buoc"].ToString()) ? "" : row["Buoc"].ToString();
                        chitietdichvu.ChiTietBuoc = String.IsNullOrEmpty(row["ChiTietBuoc"].ToString()) ? "" : row["ChiTietBuoc"].ToString();
        
                        dsDichVu.Add(chitietdichvu);

                    }
                    return dsDichVu;
                }
                return new List<ChiTietDichVu>();
            }
            catch (Exception ex)
            {
                return new List<ChiTietDichVu>();
            }
        }
        public List<ChiTietDichVu> GetDataByMa(int MaDV)
        {
            try
            {
                List<ChiTietDichVu> dsDichVu = new List<ChiTietDichVu>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_ChiTietDichVu_GetData", new object[] { MaDV }, new List<string>() { "MaDV" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ChiTietDichVu chitietdichvu = new ChiTietDichVu();
                        chitietdichvu.MaCTDV = String.IsNullOrEmpty(row["MaCTDV"].ToString()) ? 0 : int.Parse(row["MaCTDV"].ToString());
                        chitietdichvu.MaDV = String.IsNullOrEmpty(row["MaDV"].ToString()) ? 0 : int.Parse(row["MaDV"].ToString());
                        chitietdichvu.Buoc = String.IsNullOrEmpty(row["Buoc"].ToString()) ? "" : row["Buoc"].ToString();
                        chitietdichvu.ChiTietBuoc = String.IsNullOrEmpty(row["ChiTietBuoc"].ToString()) ? "" : row["ChiTietBuoc"].ToString();
                        dsDichVu.Add(chitietdichvu);

                    }
                    return dsDichVu;
                }
                return new List<ChiTietDichVu>();
            }
            catch (Exception ex)
            {
                return new List<ChiTietDichVu>();
            }
        }





        public string ThemChiTietDichVu(ChiTietDichVu chiTietDichVu)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_ChiTietDichVu_Insert", new object[] {chiTietDichVu.MaDV,chiTietDichVu.Buoc,chiTietDichVu.ChiTietBuoc },
                  new List<string>() {
                      "@MaDV",
                      "@Buoc",
                      "@ChiTietBuoc"         
                   });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhatChiTietDichVu(ChiTietDichVu chiTietDichVu)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_ChiTietDichVu_Update", new object[] { chiTietDichVu.MaCTDV,chiTietDichVu.MaDV, chiTietDichVu.Buoc, chiTietDichVu.ChiTietBuoc },
                  new List<string>() {
                      "@MaCTDV",
                      "@MaDV",
                      "@Buoc",
                      "@ChiTietBuoc"
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