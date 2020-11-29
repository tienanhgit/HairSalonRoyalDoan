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

        public List<LichHen> GetDataAll()
        {
            try
            {
                List<LichHen> dsLichHen = new List<LichHen>();
                DataTable dt = dataProvider.ExecuteQuery("proc_LichHen_get_all", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        LichHen lichHen = new LichHen();
                        lichHen.MaLichHen = String.IsNullOrEmpty(row["MaLichHen"].ToString()) ? 0 : int.Parse(row["MaLichHen"].ToString());
                        lichHen.MaKH = String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                        lichHen.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                        lichHen.GioHen = String.IsNullOrEmpty(row["GioHen"].ToString()) ? "" : row["GioHen"].ToString();
                        lichHen.NgayHen = String.IsNullOrEmpty(row["NgayHen"].ToString()) ? "" : row["NgayHen"].ToString();
                        lichHen.TrangThai = String.IsNullOrEmpty(row["TrangThai"].ToString()) ? 0 : int.Parse(row["TrangThai"].ToString());
                        lichHen.TenKhachHang = String.IsNullOrEmpty(row["HoTenKH"].ToString()) ? "" : row["HoTenKH"].ToString();
                        lichHen.TenNhanVien = String.IsNullOrEmpty(row["HoTenNV"].ToString()) ? "" : row["HoTenNV"].ToString();
                        lichHen.SoDTKH = String.IsNullOrEmpty(row["SoDTKH"].ToString()) ? "" : row["SoDTKH"].ToString();
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
                        lichHen.GioHen = String.IsNullOrEmpty(row["GioHen"].ToString()) ? "" : row["GioHen"].ToString();
                        lichHen.NgayHen = String.IsNullOrEmpty(row["NgayHen"].ToString()) ? "" : row["NgayHen"].ToString();
                        lichHen.TrangThai= String.IsNullOrEmpty(row["TrangThai"].ToString()) ? 0 : int.Parse(row["TrangThai"].ToString());
                        lichHen.TenKhachHang = String.IsNullOrEmpty(row["HoTenKH"].ToString()) ? "" : row["HoTenKH"].ToString();
                        lichHen.TenNhanVien = String.IsNullOrEmpty(row["HoTenNV"].ToString()) ? "" : row["HoTenNV"].ToString();
                        lichHen.SoDTKH= String.IsNullOrEmpty(row["SoDTKH"].ToString()) ? "" : row["SoDTKH"].ToString();
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
        public List<LichHen> GetDataByTrangThai(int TrangThai)
        {
            try
            {
                List<LichHen> dsLichHen = new List<LichHen>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_LichHen_GetData", new object[] { TrangThai }, new List<string>() {"@TrangThai"});
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        LichHen lichHen = new LichHen();
                        lichHen.MaLichHen = String.IsNullOrEmpty(row["MaLichHen"].ToString()) ? 0 : int.Parse(row["MaLichHen"].ToString());
                        lichHen.MaKH = String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                        lichHen.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                        lichHen.GioHen = String.IsNullOrEmpty(row["GioHen"].ToString()) ? "" : row["GioHen"].ToString();
                        lichHen.NgayHen = String.IsNullOrEmpty(row["NgayHen"].ToString()) ? "" : row["NgayHen"].ToString();
                        lichHen.TrangThai = String.IsNullOrEmpty(row["TrangThai"].ToString()) ? 0 : int.Parse(row["TrangThai"].ToString());
                        lichHen.TenKhachHang = String.IsNullOrEmpty(row["HoTenKH"].ToString()) ? "" : row["HoTenKH"].ToString();
                        lichHen.TenNhanVien = String.IsNullOrEmpty(row["HoTenNV"].ToString()) ? "" : row["HoTenNV"].ToString();
                        lichHen.SoDTKH = String.IsNullOrEmpty(row["SoDTKH"].ToString()) ? "" : row["SoDTKH"].ToString();
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
        public List<LichHen> GetDataByNgayHen(DateTime NgayHen)
        {
            try
            {
                List<LichHen> dsLichHen = new List<LichHen>();
                DataTable dt = dataProvider.ExecuteQuery("LichHen_TimKiemTheoThoiGian", new object[] { NgayHen }, new List<string>() { "@NgayHen" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        LichHen lichHen = new LichHen();
                        lichHen.MaLichHen = String.IsNullOrEmpty(row["MaLichHen"].ToString()) ? 0 : int.Parse(row["MaLichHen"].ToString());
                        lichHen.MaKH = String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                        lichHen.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                        lichHen.GioHen = String.IsNullOrEmpty(row["GioHen"].ToString()) ? "" : row["GioHen"].ToString();
                        lichHen.NgayHen = String.IsNullOrEmpty(row["NgayHen"].ToString()) ? "" : row["NgayHen"].ToString();
                        lichHen.TrangThai = String.IsNullOrEmpty(row["TrangThai"].ToString()) ? 0 : int.Parse(row["TrangThai"].ToString());
                        lichHen.TenKhachHang = String.IsNullOrEmpty(row["HoTenKH"].ToString()) ? "" : row["HoTenKH"].ToString();
                        lichHen.TenNhanVien = String.IsNullOrEmpty(row["HoTenNV"].ToString()) ? "" : row["HoTenNV"].ToString();
                        lichHen.SoDTKH = String.IsNullOrEmpty(row["SoDTKH"].ToString()) ? "" : row["SoDTKH"].ToString();
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

        public List<LichHen> GetDataByKhachHang(int MaKH,int TrangThai)
        {
            try
            {
                List<LichHen> dsLichHen = new List<LichHen>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_LichHen_GetData", new object[] {MaKH,TrangThai }, new List<string>() {"@MaKH","@TrangThai"});
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        LichHen lichHen = new LichHen();
                        lichHen.MaLichHen = String.IsNullOrEmpty(row["MaLichHen"].ToString()) ? 0 : int.Parse(row["MaLichHen"].ToString());
                        lichHen.MaKH = String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                        lichHen.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                        lichHen.GioHen = String.IsNullOrEmpty(row["GioHen"].ToString()) ? "" : row["GioHen"].ToString();
                        lichHen.NgayHen = String.IsNullOrEmpty(row["NgayHen"].ToString()) ? "" : row["NgayHen"].ToString();
                        lichHen.TrangThai = String.IsNullOrEmpty(row["TrangThai"].ToString()) ? 0 : int.Parse(row["TrangThai"].ToString());
                        lichHen.TenKhachHang = String.IsNullOrEmpty(row["HoTenKH"].ToString()) ? "" : row["HoTenKH"].ToString();
                        lichHen.TenNhanVien = String.IsNullOrEmpty(row["HoTenNV"].ToString()) ? "" : row["HoTenNV"].ToString();
                        lichHen.SoDTKH = String.IsNullOrEmpty(row["SoDTKH"].ToString()) ? "" : row["SoDTKH"].ToString();
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

        public string CapNhatLichHen(LichHen lichHen)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_LichHen_Update", new object[] {lichHen.MaLichHen, lichHen.MaNV, lichHen.NgayHen, lichHen.GioHen},
                  new List<string>() {
                      "@MaLichHen",
                      "@MaNV",
                      "@NgayHen",
                      "@GioHen"
                    
                  });
                return kq.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string UpdateTrangThai(int MaLichHen,int TrangThai)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_LichHen_UpdateTT", new object[] {MaLichHen,TrangThai},
                  new List<string>() {
                      "@MaLichHen",
                      "@TrangThai"
              
             });
                return kq.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public string SoKhachHangDat( string NgayDat,string GioDat)
        {
            try
            {

                string kq = dataProvider.ExecuteScalar("DemSoNguoiHen", new object[] { NgayDat,GioDat },
                  new List<string>() {     
                      "@NgayHen",
                      "@GioHen"

             });
                return kq.ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }

        }
        public string SoKhachHangDatNhanVien(int MaNV, string NgayDat, string GioDat)
        {
            try
            {

                string kq = dataProvider.ExecuteScalar("DemSoNguoiHen", new object[] { MaNV, NgayDat, GioDat },
                  new List<string>() {
                      "@MaNV",
                      "@NgayHen",
                      "@GioHen"

             });
                return kq.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        //public string KiemTraLichHenKhachHang(int MaKH)
        //{
        //    try
        //    {

        //        string kq = dataProvider.ExecuteScalar("DemSoLichTrenTungKhachHang", new object[] { MaKH},
        //          new List<string>() {
        //              "@MaKH"
                  

        //     });
        //        return kq.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }

        //}



    }
}