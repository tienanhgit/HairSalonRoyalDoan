using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class ChiTietDonDatModel
    {
        DataProvider dataProvider = new DataProvider();

        public List<ChiTietDonDat> GetData()
        {
            try
            {
                List<ChiTietDonDat> dsChiTietDonDat = new List<ChiTietDonDat>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_ChiTietDonDat_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ChiTietDonDat chiTietDonDat = new ChiTietDonDat();
                        chiTietDonDat.MaDonDatHang = String.IsNullOrEmpty(row["MaDonDatHang"].ToString()) ? 0 : int.Parse(row["MaDonDatHang"].ToString());
                        chiTietDonDat.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
                        chiTietDonDat.SoLuong = String.IsNullOrEmpty(row["SoLuong"].ToString()) ? 0 : int.Parse(row["SoLuong"].ToString());
                        chiTietDonDat.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : int.Parse(row["Gia"].ToString());
                        dsChiTietDonDat.Add(chiTietDonDat);
                    }
                    return dsChiTietDonDat;
                }
                return new List<ChiTietDonDat>();
            }
            catch (Exception ex)
            {
                return new List<ChiTietDonDat>();
            }
        }
        public List<ChiTietDonDat> GetDataSanPham(int MaDonDatHang)
        {
            try
            {
                List<ChiTietDonDat> dsChiTietDonDat = new List<ChiTietDonDat>();
                DataTable dt = dataProvider.ExecuteQuery("proc_getdata_chitietdondat_sanpham", new object[] { MaDonDatHang }, new List<string>() { "MaDonDatHang" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ChiTietDonDat chiTietDonDat = new ChiTietDonDat();
                        chiTietDonDat.MaDonDatHang = String.IsNullOrEmpty(row["MaDonDatHang"].ToString()) ? 0 : int.Parse(row["MaDonDatHang"].ToString());
                        chiTietDonDat.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
                        chiTietDonDat.SoLuong = String.IsNullOrEmpty(row["SoLuong"].ToString()) ? 0 : int.Parse(row["SoLuong"].ToString());              
                        chiTietDonDat.TenSanPham = String.IsNullOrEmpty(row["TenSanPham"].ToString()) ? "" : row["TenSanPham"].ToString();
                        chiTietDonDat.HinhAnh = String.IsNullOrEmpty(row["HinhAnh"].ToString()) ? "" : row["HinhAnh"].ToString();
                        chiTietDonDat.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
                        dsChiTietDonDat.Add(chiTietDonDat);

                    }
                    return dsChiTietDonDat;
                }
                return new List<ChiTietDonDat>();
            }
            catch (Exception ex)
            {
                return new List<ChiTietDonDat>();
            }
        }
  






        public ChiTietDonDat GetChiTietDonDatByMa(int MaDonDatHang)
        {
            try
            {
                ChiTietDonDat chiTietDonDat = null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_ChiTietDonDat_GetData", new object[] { MaDonDatHang }, new List<string>() { "MaDonDatHang" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    chiTietDonDat.MaDonDatHang = String.IsNullOrEmpty(row["MaDonDatHang"].ToString()) ? 0 : int.Parse(row["MaDonDatHang"].ToString());
                    chiTietDonDat.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
                    chiTietDonDat.SoLuong = String.IsNullOrEmpty(row["SoLuong"].ToString()) ? 0 : int.Parse(row["SoLuong"].ToString());
                    chiTietDonDat.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());

                }
                return chiTietDonDat;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public string ThemChiTietDonDat(ChiTietDonDat chiTietDonDat)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_ChiTietDonDat_Insert", new object[] { chiTietDonDat.MaDonDatHang,chiTietDonDat.MaSanPham,chiTietDonDat.SoLuong,chiTietDonDat.Gia},
                  new List<string>() {
                      "@MaDonDatHang",
                      "@MaSanPham",
                      "@SoLuong",
                      "@Gia"
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