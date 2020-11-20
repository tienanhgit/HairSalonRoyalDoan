using HairSalonRoyalDoan.Models.Common;
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
    

        public string UpdateTrangThai(string MaDonDathang,string TrangThaiDonSanPham,string TrangThaiDonDichVu)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_DonDatHang_UpdateTT", new object[] {MaDonDathang,TrangThaiDonSanPham,TrangThaiDonDichVu },
                  new List<string>() {
                      "@MaDonDatHang",
                      "@TrangThaiDonSanPham" ,
                      "@TrangThaiDonDichVu",
             });
                return kq.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }


    


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
          
                        donDatHang.SoDTGiaoHang = String.IsNullOrEmpty(row["SoDTGiaoHang"].ToString()) ? "" : row["SoDTGiaoHang"].ToString();
                        donDatHang.HinhThucThanhToan = String.IsNullOrEmpty(row["HinhThucTT"].ToString()) ? "" : row["HinhThucTT"].ToString();
                        donDatHang.TrangThaiDonSanPham = String.IsNullOrEmpty(row["TrangThaiDonSanPham"].ToString()) ? 0 : int.Parse(row["TrangThaiDonSanPham"].ToString());
                        donDatHang.TrangThaiDonDichVu = String.IsNullOrEmpty(row["TrangThaiDonDichVu"].ToString()) ? 0 : int.Parse(row["TrangThaiDonDichVu"].ToString());
                        donDatHang.HoTenNguoiNhan = String.IsNullOrEmpty(row["HoTenNguoiNhan"].ToString()) ? "" : row["HoTenNguoiNhan"].ToString();
                        donDatHang.DiaChiNhanHang = String.IsNullOrEmpty(row["DiaChiNhanHang"].ToString()) ? "" : row["DiaChiNhanHang"].ToString();
                        donDatHang.TongTien = String.IsNullOrEmpty(row["TongTien"].ToString()) ? 0 : float.Parse(row["TongTien"].ToString());
                        donDatHang.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
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


        public List<DonDatHang> GetDataByTrangThai(int TrangThaiDonSanPham,int TrangThaiDonDichVu)
        {
            try
            {
                List<DonDatHang> dsDonDatHang = new List<DonDatHang>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_DonDatHang_GetData", new object[] { TrangThaiDonSanPham,TrangThaiDonDichVu }, new List<string>() {"TrangThaiDonSanPham","TrangThaiDonDichVu"});
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DonDatHang donDatHang = new DonDatHang();
                        donDatHang.MaDonDatHang = String.IsNullOrEmpty(row["MaDonDatHang"].ToString()) ? 0 : int.Parse(row["MaDonDatHang"].ToString());
                        donDatHang.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                        donDatHang.MaKH = String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());

                        donDatHang.SoDTGiaoHang = String.IsNullOrEmpty(row["SoDTGiaoHang"].ToString()) ? "" : row["SoDTGiaoHang"].ToString();
                        donDatHang.HinhThucThanhToan = String.IsNullOrEmpty(row["HinhThucTT"].ToString()) ? "" : row["HinhThucTT"].ToString();
                        donDatHang.TrangThaiDonSanPham = String.IsNullOrEmpty(row["TrangThaiDonSanPham"].ToString()) ? 0 : int.Parse(row["TrangThaiDonSanPham"].ToString());
                        donDatHang.TrangThaiDonDichVu = String.IsNullOrEmpty(row["TrangThaiDonDichVu"].ToString()) ? 0 : int.Parse(row["TrangThaiDonDichVu"].ToString());
                        donDatHang.HoTenNguoiNhan = String.IsNullOrEmpty(row["HoTenNguoiNhan"].ToString()) ? "" : row["HoTenNguoiNhan"].ToString();
                        donDatHang.DiaChiNhanHang = String.IsNullOrEmpty(row["DiaChiNhanHang"].ToString()) ? "" : row["DiaChiNhanHang"].ToString();
                        donDatHang.TongTien = String.IsNullOrEmpty(row["TongTien"].ToString()) ? 0 : float.Parse(row["TongTien"].ToString());
                        donDatHang.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
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
                    donDatHang.SoDTGiaoHang = String.IsNullOrEmpty(row["SoDTGiaoHang"].ToString()) ? "" : row["SoDTGiaoHang"].ToString();
                    donDatHang.HinhThucThanhToan = String.IsNullOrEmpty(row["HinhThucTT"].ToString()) ? "" : row["HinhThucTT"].ToString();
                    donDatHang.TrangThaiDonSanPham = String.IsNullOrEmpty(row["TrangThaiDonSanPham"].ToString()) ? 0 : int.Parse(row["TrangThaiDonSanPham"].ToString());
                    donDatHang.TrangThaiDonDichVu = String.IsNullOrEmpty(row["TrangThaiDonDichVu"].ToString()) ? 0 : int.Parse(row["TrangThaiDonDichVu"].ToString());
                    donDatHang.HoTenNguoiNhan = String.IsNullOrEmpty(row["HoTenNguoiNhan"].ToString()) ? "" : row["HoTenNguoiNhan"].ToString();
                    donDatHang.DiaChiNhanHang = String.IsNullOrEmpty(row["DiaChiNhanHang"].ToString()) ? "" : row["DiaChiNhanHang"].ToString();
                    donDatHang.TongTien = String.IsNullOrEmpty(row["TongTien"].ToString()) ? 0 : float.Parse(row["TongTien"].ToString());
                    donDatHang.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                   
                }
                return donDatHang;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DonDatHang> GetDataByMaKH(int MaKH)
        {
            try
            {
                List<DonDatHang> dsDonDatHang = new List<DonDatHang>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_DonDatHang_GetData", new object[] { MaKH }, new List<string>() { "MaKH" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DonDatHang donDatHang = new DonDatHang();
                        donDatHang.MaDonDatHang = String.IsNullOrEmpty(row["MaDonDatHang"].ToString()) ? 0 : int.Parse(row["MaDonDatHang"].ToString());
                        donDatHang.MaNV = String.IsNullOrEmpty(row["MaNV"].ToString()) ? 0 : int.Parse(row["MaNV"].ToString());
                        donDatHang.MaKH = String.IsNullOrEmpty(row["MaKH"].ToString()) ? 0 : int.Parse(row["MaKH"].ToString());
                        donDatHang.SoDTGiaoHang = String.IsNullOrEmpty(row["SoDTGiaoHang"].ToString()) ? "" : row["SoDTGiaoHang"].ToString();
                        donDatHang.HinhThucThanhToan = String.IsNullOrEmpty(row["HinhThucTT"].ToString()) ? "" : row["HinhThucTT"].ToString();
                        donDatHang.TrangThaiDonSanPham = String.IsNullOrEmpty(row["TrangThaiDonSanPham"].ToString()) ? 0 : int.Parse(row["TrangThaiDonSanPham"].ToString());
                        donDatHang.TrangThaiDonDichVu = String.IsNullOrEmpty(row["TrangThaiDonDichVu"].ToString()) ? 0 : int.Parse(row["TrangThaiDonDichVu"].ToString());             
                        donDatHang.HoTenNguoiNhan = String.IsNullOrEmpty(row["HoTenNguoiNhan"].ToString()) ? "" : row["HoTenNguoiNhan"].ToString();
                        donDatHang.DiaChiNhanHang = String.IsNullOrEmpty(row["DiaChiNhanHang"].ToString()) ? "" : row["DiaChiNhanHang"].ToString();
                        donDatHang.TongTien = String.IsNullOrEmpty(row["TongTien"].ToString()) ? 0 : float.Parse(row["TongTien"].ToString());
                        donDatHang.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);  
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


        public string ThemDonDatHang(DonDatHang donDatHang)
        {
            try
            {
                string rs = "";
           rs = dataProvider.ExecuteScalar("Proc_DonDatHang_Insert", new object[] { donDatHang.MaNV, donDatHang.MaKH,donDatHang.SoDTGiaoHang, donDatHang.HinhThucThanhToan, donDatHang.TrangThaiDonSanPham, donDatHang.TrangThaiDonDichVu, donDatHang.HoTenNguoiNhan, donDatHang.DiaChiNhanHang,donDatHang.NgayTao },
               new List<string>() {
            "@MaNV",
            "@MaKH" ,    
            "@SoDTGiaoHang",
            "@HinhThucTT" ,
            "@TrangThaiDonSanPham" ,
            "@TrangThaiDonDichVu",
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


        public string CapNhatTongTien(int MaDonDatHang)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("proc_getdata_tongtien", new object[] {MaDonDatHang},
                  new List<string>() {
                      "@MaDonDatHang"
         });
                return kq.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public string CapNhatTongTienDichVu(int MaDonDatHang)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("proc_getadata_tongtien_dichvu", new object[] { MaDonDatHang },
                  new List<string>() {
                      "@MaDonDatHang"
         });
                return kq.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public float GetDataBieuDo(int Thang,int TrangThaiDonDichVu,int TrangThaiDonSanPham)
        {
            try
            {
                float tongtien = 0;
                DataTable dt = dataProvider.ExecuteQuery("BieuDo", new object[] { Thang,TrangThaiDonSanPham,TrangThaiDonDichVu }, new List<string>() { "Thang","TrangThaiDonSanPham","TrangThaiDonDichVu" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    tongtien = String.IsNullOrEmpty(row["TongTien"].ToString()) ? 0 : float.Parse(row["TongTien"].ToString());
                    return tongtien;
                }
                return tongtien ;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }





    }














}
