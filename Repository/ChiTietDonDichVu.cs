using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class ChiTietDonDichVu
    {
        private int _MaDonDatHang;
        private int _MaDV;

        public ChiTietDonDichVu()
        {

        }

        public ChiTietDonDichVu(int maDonDatHang, int maDV)
        {
            MaDonDatHang = maDonDatHang;
            MaDV = maDV;
      
        }

        public int MaDonDatHang { get => _MaDonDatHang; set => _MaDonDatHang = value; }
        public int MaDV { get => _MaDV; set => _MaDV = value; }

    }
}