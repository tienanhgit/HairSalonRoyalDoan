using HairSalonRoyalDoan.Models.Common;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class ChucVuModel
    {
        DataProvider dataProvider = new DataProvider();
        public List<ChucVu> GetData()
        {
            try
            {
                List<ChucVu> dsChucVu = new List<ChucVu>();
                DataTable dt = dataProvider.ExecuteQuery("Proc_ChucVu_GetData", null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ChucVu chucVu = new ChucVu();
                        chucVu.MaChucVu = String.IsNullOrEmpty(row["MaChucVu"].ToString()) ? 0 : int.Parse(row["MaChucVu"].ToString());
                        chucVu.TenChucVu = String.IsNullOrEmpty(row["TenChucVu"].ToString()) ? "" : row["TenChucVu"].ToString();
                        dsChucVu.Add(chucVu);
                    }
                    return dsChucVu;
                }
                else
                {
                    return new List<ChucVu>();

                }
            
            }
            catch (Exception ex)
            {
                return new List<ChucVu>();
            }

        }

    }
}