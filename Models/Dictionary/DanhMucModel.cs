using HairSalonRoyalDoan.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HairSalonRoyalDoan.Repository;
using System.Data;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class DanhMucModel
    {
        DataProvider dataProvider = new DataProvider();
        public List<DanhMuc> GetData()
        {
            try
            {
                List<DanhMuc> dsDanhMuc = new List<DanhMuc>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_DanhMuc_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DanhMuc danhMuc = new DanhMuc();
                        danhMuc.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
                        danhMuc.TenDanhMuc = String.IsNullOrEmpty(row["TenDanhMuc"].ToString()) ? "" : row["TenDanhMuc"].ToString();
                        danhMuc.TrangThaiHienThi = String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());
                        danhMuc.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                        danhMuc.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                        dsDanhMuc.Add(danhMuc);
                    }
                    return dsDanhMuc;
                }
                return new List<DanhMuc>();
            }
            catch (Exception ex)
            {
                return new List<DanhMuc>();
            }
        }
        public List<DanhMuc> GetDataByTrangThai(int TrangThai)
        {
            try
            {
                List<DanhMuc> dsDanhMuc = new List<DanhMuc>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_DanhMuc_GetData", new object[] { TrangThai }, new List<string>() { "TrangThaiHienThi" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DanhMuc danhMuc = new DanhMuc();
                        danhMuc.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
                        danhMuc.TenDanhMuc = String.IsNullOrEmpty(row["TenDanhMuc"].ToString()) ? "" : row["TenDanhMuc"].ToString();
                        danhMuc.TrangThaiHienThi = String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());
                        danhMuc.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                        danhMuc.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                        dsDanhMuc.Add(danhMuc);
                    }
                    return dsDanhMuc;
                }
                return new List<DanhMuc>();
            }
            catch (Exception ex)
            {
                return new List<DanhMuc>();
            }
        }
        public DanhMuc GetDanhMucByMa(int MaDanhMuc)
        {
            try
            {
                DanhMuc danhMuc = null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_DanhMuc_GetData", new object[] { MaDanhMuc }, new List<string>() { "MaDanhMuc" });
                if (dt != null && dt.Rows.Count > 0)
                {
               
                    var row = dt.Rows[0];
                    danhMuc = new DanhMuc();
                    danhMuc.MaDanhMuc = String.IsNullOrEmpty(row["MaDanhMuc"].ToString()) ? 0 : int.Parse(row["MaDanhMuc"].ToString());
                    danhMuc.TenDanhMuc = String.IsNullOrEmpty(row["TenDanhMuc"].ToString()) ? "" : row["TenDanhMuc"].ToString();
                    danhMuc.TrangThaiHienThi = String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());
                    danhMuc.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                    danhMuc.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);

                }
                return danhMuc;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public string ThemDanhMuc(DanhMuc danhMuc)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_DanhMuc_Insert", new object[] {danhMuc.TenDanhMuc,danhMuc.TrangThaiHienThi,danhMuc.NgayTao},
                  new List<string>() {
                      "@TenDanhMuc",
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

        public string CapNhatDanhMuc(DanhMuc danhMuc)
        {
            try
            {

               int kq = dataProvider.ExecuteNonQuery("Proc_DanhMuc_Update", new object[] {danhMuc.MaDanhMuc,danhMuc.TenDanhMuc,danhMuc.TrangThaiHienThi,danhMuc.NgaySua},
                  new List<string>() {
                    "@MaDanhMuc",
                    "@TenDanhMuc",
                    "@TrangThaiHienThi",
                      "@NgaySua"
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
