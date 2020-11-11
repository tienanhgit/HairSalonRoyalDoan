using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class ChiTietDonDichVu:DichVu
    {
        private int _MaDonDatHang;
      

        public ChiTietDonDichVu()
        {

        }

        public ChiTietDonDichVu(int maDonDatHang, int maDV)
        {
            MaDonDatHang = maDonDatHang;
            MaDV = maDV;
      
        }

        public int MaDonDatHang { get => _MaDonDatHang; set => _MaDonDatHang = value; }
    

    }
}