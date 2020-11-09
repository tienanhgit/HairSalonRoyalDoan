using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class LichHenModel
    {

        DataProvider dataProvider = new DataProvider();
        public List<LichHen> GetData()
        {
            try
            {
                List<LichHen> dsLichHen = new List<LichHen>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_LichHen_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        LichHen lichHen = new LichHen();
                           lichHen.MaLichHen= String.IsNullOrEmpty(row["MaLichHen"].ToString()) ? 0 : int.Parse(row["MaLichHen"].ToString());
                        lichHen.MaKH= String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                        lichHen.MaNV= String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                        lichHen.NgayHen= String.IsNullOrEmpty(row["NgayHen"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayHen"]);
                        lichHen.GioHen= String.IsNullOrEmpty(row["GioHen"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["GioHen"]);
                        lichHen.TrangThai= String.IsNullOrEmpty(row["TrangThai"].ToString()) ? 0 : int.Parse(row["TrangThai"].ToString());   
                        dsLichHen.Add(lichHen);
                    }
                    return dsLichHen;
                }
                return new List<LichHen>();
            }
            catch (Exception ex)
            {
                return new List<LichHen>();
            }
        }


        public string ThemLichHen(LichHen lichHen)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_LichHen_Insert", new object[] { lichHen.MaKH,lichHen.MaNV,lichHen.NgayHen,lichHen.GioHen,lichHen.TrangThai},
                  new List<string>() {
                      "@MaKH",
                      "@MaNV",
                      "@NgayHen",
                      "@GioHen",
                      "@TrangThai"
                     
                   });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhatDichVu(LichHen lichHen)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_LichHen_Update", new object[] { lichHen.MaKH, lichHen.MaNV, lichHen.NgayHen, lichHen.GioHen, lichHen.TrangThai },
                  new List<string>() {
                          "@MaKH",
                      "@MaNV",
                      "@NgayHen",
                      "@GioHen",
                      "@TrangThai"
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