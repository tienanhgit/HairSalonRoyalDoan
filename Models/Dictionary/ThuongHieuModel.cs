using HairSalonRoyalDoan.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HairSalonRoyalDoan.Repository;
using System.Data;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class ThuongHieuModel
    {
        DataProvider dataProvider = new DataProvider();
        public List<ThuongHieu> GetData()
        {
            try
            {
                List<ThuongHieu> dsThuongHieu = new List<ThuongHieu>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_ThuongHieu_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ThuongHieu thuongHieu = new ThuongHieu();
                        thuongHieu.MaThuongHieu = String.IsNullOrEmpty(row["MaThuongHieu"].ToString()) ? 0 : int.Parse(row["MaThuongHieu"].ToString());           
                        thuongHieu.TenThuongHieu = String.IsNullOrEmpty(row["TenThuongHieu"].ToString()) ? "" : row["TenThuongHieu"].ToString();
                          thuongHieu.TrangThaiHienThi= String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());
                        thuongHieu.NgaySua= String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"].ToString());
                        thuongHieu.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"].ToString());
                        dsThuongHieu.Add(thuongHieu);
                    }
                    return dsThuongHieu;
                }
                return new List<ThuongHieu>();
            }
            catch (Exception ex)
            {
                return new List<ThuongHieu>();
            }
        }
        public ThuongHieu GetThuongHieuByMa(int MaThuongHieu)
        {
            try
            {
                ThuongHieu thuongHieu = null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_ThuongHieu_GetData", new object[] { MaThuongHieu }, new List<string>() { "MaThuongHieu" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    thuongHieu = new ThuongHieu();
                    var row = dt.Rows[0];
                    thuongHieu.MaThuongHieu = String.IsNullOrEmpty(row["MaThuongHieu"].ToString()) ? 0 : int.Parse(row["MaThuongHieu"].ToString());
                    thuongHieu.TenThuongHieu = String.IsNullOrEmpty(row["TenThuongHieu"].ToString()) ? "" : row["TenThuongHieu"].ToString();
                    thuongHieu.TrangThaiHienThi = String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());
                    thuongHieu.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"].ToString());
                    thuongHieu.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"].ToString());

                }
                return thuongHieu;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public string ThemThuongHieu(ThuongHieu thuongHieu)
        {
            try
            {
                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_ThuongHieu_Insert", new object[] {thuongHieu.TenThuongHieu,thuongHieu.NgayTao,thuongHieu.TrangThaiHienThi },
                  new List<string>() { 
              "@TenThuongHieu" ,
             
              "@NgayTao",
                  "@TrangThaiHienThi"
                  });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhatThuongHieu(ThuongHieu thuongHieu)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_ThuongHieu_Update", new object[] { thuongHieu.TenThuongHieu,thuongHieu.NgaySua,thuongHieu.MaThuongHieu,thuongHieu.TrangThaiHienThi},
                  new List<string>() {"@TenThuongHieu" ,
              "@NgaySua" ,
              "@MaThuongHieu",
                  "@TrangThaiHienThi"
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