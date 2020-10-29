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
                        chitietdichvu.ChiTietCacBuoc = String.IsNullOrEmpty(row["ChiTietCacBuoc"].ToString()) ? "" : row["ChiTietCacBuoc"].ToString();
        
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


        public string ThemChiTietDichVu(ChiTietDichVu chiTietDichVu)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_ChiTietDichVu_Insert", new object[] {chiTietDichVu.MaDV,chiTietDichVu.Buoc,chiTietDichVu.ChiTietCacBuoc },
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

                int kq = dataProvider.ExecuteNonQuery("Proc_ChiTietDichVu_Update", new object[] { chiTietDichVu.MaCTDV,chiTietDichVu.MaDV, chiTietDichVu.Buoc, chiTietDichVu.ChiTietCacBuoc },
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