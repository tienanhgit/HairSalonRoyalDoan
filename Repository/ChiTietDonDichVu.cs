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
        private int _MaNV;
        private DateTime _NgayDat;
        private DateTime _GioDat;
        public ChiTietDonDichVu()
        {

        }

        public ChiTietDonDichVu(int maDonDatHang, int maDV, int maNV, DateTime ngayDat, DateTime gioDat)
        {
            MaDonDatHang = maDonDatHang;
            MaDV = maDV;
            MaNV = maNV;
            NgayDat = ngayDat;
            GioDat = gioDat;
        }

        public int MaDonDatHang { get => _MaDonDatHang; set => _MaDonDatHang = value; }
        public int MaDV { get => _MaDV; set => _MaDV = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public DateTime NgayDat { get => _NgayDat; set => _NgayDat = value; }
        public DateTime GioDat { get => _GioDat; set => _GioDat = value; }
    }
}