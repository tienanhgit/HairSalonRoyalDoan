using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class ChucVu
    {
        private int _MaChucVu;
        private string _TenChucVu;
        
        public ChucVu()
        {

        }

        public ChucVu(int maChucVu, string tenChucVu)
        {
            MaChucVu = maChucVu;
            TenChucVu = tenChucVu;
        }

        public int MaChucVu { get => _MaChucVu; set => _MaChucVu = value; }
        public string TenChucVu { get => _TenChucVu; set => _TenChucVu = value; }
    }
}