using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;


namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class ProductModel
    {

        DataProvider dataProvider = new DataProvider();
        public List<SanPham> GetData()
        {
            try
            {
                List<SanPham> dsSanPham = new List<SanPham>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_SanPham_GetData1", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        SanPham sanpham = new SanPham();
                        sanpham.MaSanPham = String.IsNullOrEmpty(row["MaSanPham"].ToString()) ? 0 : int.Parse(row["MaSanPham"].ToString());
                        sanpham.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
                        sanpham.TenSanPham = String.IsNullOrEmpty(row["TenSanPham"].ToString()) ? "" : row["TenSanPham"].ToString();
                        sanpham.HinhAnh = String.IsNullOrEmpty(row["HinhAnh"].ToString()) ? "" : row["HinhAnh"].ToString();
                        sanpham.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
                        sanpham.MoTa = String.IsNullOrEmpty(row["MoTa"].ToString()) ? "" : row["MoTa"].ToString();
                        sanpham.DanhGia = String.IsNullOrEmpty(row["DanhGia"].ToString()) ? "" : row["DanhGia"].ToString();


                        dsSanPham.Add(sanpham);
                    }
                    return dsSanPham;
                }
                return new List<SanPham>();
            }
            catch (Exception ex)
            {
                return new List<SanPham>();
            }

        }






    }
}