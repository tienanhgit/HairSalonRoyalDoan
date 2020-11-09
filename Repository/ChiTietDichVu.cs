using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class ChiTietDichVu
    {
        private int _MaCTDV;
        private int _MaDV;
        private string _Buoc;
        public ChiTietDichVu()
        {

        }

        public ChiTietDichVu(int maCTDV, int maDV, string buoc)
        {
            MaCTDV = maCTDV;
            MaDV = maDV;
            Buoc = buoc;
        }

        public int MaCTDV { get => _MaCTDV; set => _MaCTDV = value; }
        public int MaDV { get => _MaDV; set => _MaDV = value; }
        public string Buoc { get => _Buoc; set => _Buoc = value; }
    }
}