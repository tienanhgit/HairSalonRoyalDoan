﻿using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class DonDatHangModel
    {

        DataProvider dataProvider = new DataProvider();

        public List<DonDatHang> GetData()
        {
            try
            {
                List<DonDatHang> dsDonDatHang = new List<DonDatHang>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_DonDatHang_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DonDatHang donDatHang = new DonDatHang();

                        donDatHang.MaDonDatHang = String.IsNullOrEmpty(row["MaDonDatHang"].ToString()) ? 0 : int.Parse(row["MaDonDatHang"].ToString());
                        donDatHang.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                        donDatHang.MaKH = String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                        donDatHang.SoDTGiaoHang = String.IsNullOrEmpty(row["SoDTGiaoHang"].ToString()) ? 0 : int.Parse(row["SoDTGiaoHang"].ToString());
                        donDatHang.HinhThucThanhToan = String.IsNullOrEmpty(row["HinhThucTT"].ToString()) ? "" : row["HinhThucTT"].ToString();
                        donDatHang.TrangThaiDonSanPham = String.IsNullOrEmpty(row["TrangThaiDonSanPham"].ToString()) ? 0 : int.Parse(row["TrangThaiDonSanPham"].ToString());
                        donDatHang.TrangThaiDonDichVu = String.IsNullOrEmpty(row["TrangThaiDonDichVu"].ToString()) ? 0 : int.Parse(row["TrangThaiDonDichVu"].ToString());
                        donDatHang.HoTenNguoiNhan = String.IsNullOrEmpty(row["HoTenNguoiNhan"].ToString()) ? "" : row["HoTenNguoiNhan"].ToString();
                        donDatHang.DiaChiNhanHang = String.IsNullOrEmpty(row["DiaChiNhanHang"].ToString()) ? "" : row["DiaChiNhanHang"].ToString();
                        donDatHang.NgayTao= String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                        donDatHang.NgaySua= String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                        dsDonDatHang.Add(donDatHang);
                    }
                    return dsDonDatHang;
                }
                return new List<DonDatHang>();
            }
            catch (Exception ex)
            {
                return new List<DonDatHang>();
            }
        }

        public DonDatHang GetDonDatHangByMa(int MaDonDatHang)
        {
            try
            {
                DonDatHang donDatHang = null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_DonDatHang_GetData", new object[] { MaDonDatHang }, new List<string>() { "MaDonDatHang" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    donDatHang = new DonDatHang();

                    donDatHang.MaDonDatHang = String.IsNullOrEmpty(row["MaDonDatHang"].ToString()) ? 0 : int.Parse(row["MaDonDatHang"].ToString());
                    donDatHang.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                    donDatHang.MaKH = String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                    donDatHang.SoDTGiaoHang = String.IsNullOrEmpty(row["SoDTGiaoHang"].ToString()) ? 0 : int.Parse(row["SoDTGiaoHang"].ToString());
                    donDatHang.HinhThucThanhToan = String.IsNullOrEmpty(row["HinhThucTT"].ToString()) ? "" : row["HinhThucTT"].ToString();
                    donDatHang.TrangThaiDonSanPham = String.IsNullOrEmpty(row["TrangThaiDonSanPham"].ToString()) ? 0 : int.Parse(row["TrangThaiDonSanPham"].ToString());
                    donDatHang.TrangThaiDonDichVu = String.IsNullOrEmpty(row["TrangThaiDonDichVu"].ToString()) ? 0 : int.Parse(row["TrangThaiDonDichVu"].ToString());
                    donDatHang.HoTenNguoiNhan = String.IsNullOrEmpty(row["HoTenNguoiNhan"].ToString()) ? "" : row["HoTenNguoiNhan"].ToString();
                    donDatHang.DiaChiNhanHang = String.IsNullOrEmpty(row["DiaChiNhanHang"].ToString()) ? "" : row["DiaChiNhanHang"].ToString();
                    donDatHang.NgayTao = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                    donDatHang.NgaySua = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                }
                return donDatHang;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ThemDonDatHang(DonDatHang donDatHang)
        {
            try
            {
                string rs = "";
           rs = dataProvider.ExecuteScalar("Proc_DonDatHang_Insert", new object[] { donDatHang.MaNV, donDatHang.MaKH, donDatHang.SoDTGiaoHang, donDatHang.HinhThucThanhToan, donDatHang.TrangThaiDonSanPham, donDatHang.TrangThaiDonDichVu, donDatHang.HoTenNguoiNhan, donDatHang.DiaChiNhanHang, donDatHang.NgayTao },
               new List<string>() {
            "@MaNV",
            "@MaKH" ,
            "@SoDTGiaoHang",
            "@HinhThucTT" ,
            "@TrangThaiDonSanPham" ,
            "@TrangThaiDonDichVu" ,
            "@HoTenNguoiNhan" ,
            "@DiaChiNhanHang" ,
                "@NgayTao"

                       });
                return rs;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string CapNhatDonDatHang(DonDatHang donDatHang)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_DonDatHang_Update", new object[] {donDatHang.MaDonDatHang,donDatHang.MaNV,
                    donDatHang.MaKH,donDatHang.SoDTGiaoHang,donDatHang.HinhThucThanhToan,donDatHang.TrangThaiDonSanPham,donDatHang.TrangThaiDonDichVu
                ,donDatHang.HoTenNguoiNhan,donDatHang.DiaChiNhanHang,donDatHang.NgayTao  },
                  new List<string>() {"@MaDonDatHang",
                       "@MaNV",
            "@MaKH" ,
            "@SoDTGiaoHang",
            "@HinhThucTT" ,
            "@TrangThaiDonSanPham" ,
            "@TrangThaiDonDichVu" ,
            "@HoTenNguoiNhan" ,
            "@DiaChiNhanHang" ,
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