using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class DichVuModel
    {

        DataProvider dataProvider = new DataProvider();
        public List<DichVu> GetData()
        {
            try
            {
                List<DichVu> dsDichVu = new List<DichVu>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_DichVu_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DichVu dichvu = new DichVu();
                        dichvu.MaDichVu= String.IsNullOrEmpty(row["MaDV"].ToString()) ? 0 : int.Parse(row["MaDV"].ToString());
                        dichvu.TenDichVu= String.IsNullOrEmpty(row["TenDV"].ToString()) ? "" : row["TenDV"].ToString();
                        dichvu.Gia= String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
                        dichvu.TrangThaiHienThi= String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());
                        dichvu.NgaySua= String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                        dichvu.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                        dsDichVu.Add(dichvu);

                    }
                    return dsDichVu;
                }
                return new List<DichVu>();
            }
            catch (Exception ex)
            {
                return new List<DichVu>();
            }
        }

        //public DichVu GetDichVuByMa(int MaDV)
        //{
        //    try
        //    {
        //        DichVu dichvu = null;
        //        DataTable dt = dataProvider.ExecuteQuery("Proc_DichVu_GetData", new object[] { MaDV }, new List<string>() { "MaDV" });
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            var row = dt.Rows[0];
        //            sanpham = new SanPham();
        //            sanpham.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
        //            sanpham.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
        //            sanpham.TenSanPham = String.IsNullOrEmpty(row["TenSanPham"].ToString()) ? "" : row["TenSanPham"].ToString();
        //            sanpham.HinhAnh = String.IsNullOrEmpty(row["HinhAnh"].ToString()) ? "" : row["HinhAnh"].ToString();
        //            sanpham.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
        //            sanpham.MoTa = String.IsNullOrEmpty(row["MoTa"].ToString()) ? "" : row["MoTa"].ToString();
        //            sanpham.DanhGia = String.IsNullOrEmpty(row["DanhGia"].ToString()) ? "" : row["DanhGia"].ToString();
        //            sanpham.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
        //            sanpham.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
        //        }
        //        return sanpham;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public string ThemDichVu(DichVu dichVu)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_Dichvu_Insert", new object[] { dichVu.TenDichVu,dichVu,dichVu.Gia,dichVu.TrangThaiHienThi,dichVu.NgayTao },
                  new List<string>() {
                      "@TenDV",
                      "@Gia",
                      "@TrangThaiHienThi",
                      "@NgayTao"
                   });
                return rs;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string CapNhatDichVu(DichVu dichVu)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_DichVu_Update", new object[] {dichVu.MaDichVu, dichVu.TenDichVu, dichVu, dichVu.Gia, dichVu.TrangThaiHienThi, dichVu.NgayTao },
                  new List<string>() {
                      "@MaDV",
                        "@TenDV",
                      "@Gia",
                      "@TrangThaiHienThi",
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