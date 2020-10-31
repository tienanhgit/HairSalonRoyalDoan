using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class KhungThoiGianModel
    {
        DataProvider dataProvider = new DataProvider();
        public List<KhungThoiGian> GetData()
        {
            try
            {
                List<KhungThoiGian> dsKhungThoiGian = new List<KhungThoiGian>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_KhungThoiGian_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        KhungThoiGian khungThoiGian = new KhungThoiGian();
                        khungThoiGian.MaKhungThoiGian = String.IsNullOrEmpty(row["MaKhungThoiGian"].ToString()) ? 0 : int.Parse(row["MaKhungThoiGian"].ToString());
                        khungThoiGian.ThoiGianBatDau = String.IsNullOrEmpty(row["ThoiGianBatDau"].ToString()) ? 0 : int.Parse(row["ThoiGianBatDau"].ToString());
                        khungThoiGian.ThoiGianKetThuc = String.IsNullOrEmpty(row["ThoiGianKetThuc"].ToString()) ? 0 : int.Parse(row["ThoiGianKetThuc"].ToString());
                        dsKhungThoiGian.Add(khungThoiGian);
                    }
                    return dsKhungThoiGian;
                }
                return new List<KhungThoiGian>();
            }
            catch (Exception ex)
            {
                return new List<KhungThoiGian>();
            }
        }




    }
}