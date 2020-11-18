using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class BieuDo
    {
        private int _Thang;
        private float _TongTien;

        public int Thang { get => _Thang; set => _Thang = value; }
        public float TongTien { get => _TongTien; set => _TongTien = value; }

        public BieuDo(int thang, float tongTien)
        {
            Thang = thang;
            TongTien = tongTien;
        }

        public BieuDo()
        {

        }
        
    }
}