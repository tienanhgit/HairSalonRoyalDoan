﻿using HairSalonRoyalDoan.Models.Common;
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
                        dichvu.MaDV= String.IsNullOrEmpty(row["MaDV"].ToString()) ? 0 : int.Parse(row["MaDV"].ToString());
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
        public List<DichVu> GetDataByTrangThai(int TrangThai)
        {
            try
            {
                List<DichVu> dsDichVu = new List<DichVu>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_DichVu_GetData", new object[] {TrangThai},
                  new List<string>() {
                      "@TrangThaiHienThi"
                     
                   });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DichVu dichvu = new DichVu();
                        dichvu.MaDV = String.IsNullOrEmpty(row["MaDV"].ToString()) ? 0 : int.Parse(row["MaDV"].ToString());
                        dichvu.TenDichVu = String.IsNullOrEmpty(row["TenDV"].ToString()) ? "" : row["TenDV"].ToString();
                        dichvu.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
                        dichvu.TrangThaiHienThi = String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());
                        dichvu.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
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


        public string ThemDichVu(DichVu dichVu)
        {
            try
            {

                string rs = "";
                rs = dataProvider.ExecuteScalar("Proc_Dichvu_Insert", new object[] {dichVu.TenDichVu,dichVu.Gia,dichVu.TrangThaiHienThi,dichVu.NgayTao},
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
        public DichVu GetDichVuByMa(int MaDV)
        {
            try
            {
                DichVu dichvu = null;
                DataTable dt = dataProvider.ExecuteQuery("Proc_DichVu_GetData", new object[] { MaDV }, new List<string>() { "MaDV" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];              
                    dichvu= new DichVu();
                    dichvu.MaDV = String.IsNullOrEmpty(row["MaDV"].ToString()) ? 0 : int.Parse(row["MaDV"].ToString());
                    dichvu.TenDichVu = String.IsNullOrEmpty(row["TenDV"].ToString()) ? "" : row["TenDV"].ToString();
                    dichvu.Gia = String.IsNullOrEmpty(row["Gia"].ToString()) ? 0 : float.Parse(row["Gia"].ToString());
                    dichvu.TrangThaiHienThi = String.IsNullOrEmpty(row["TrangThaiHienThi"].ToString()) ? 0 : int.Parse(row["TrangThaiHienThi"].ToString());
                    dichvu.NgaySua = String.IsNullOrEmpty(row["NgaySua"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgaySua"]);
                    dichvu.NgayTao = String.IsNullOrEmpty(row["NgayTao"].ToString()) ? DateTime.Now : Convert.ToDateTime(row["NgayTao"]);
                }
                return dichvu;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string CapNhatDichVu(string MaDV,int TrangThaiHienThi,DateTime NgaySua)
        {
            try
            {

                int kq = dataProvider.ExecuteNonQuery("Proc_DichVu_Update", new object[] {MaDV,TrangThaiHienThi,NgaySua },
                  new List<string>() {
                      "@MaDV",
                   
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