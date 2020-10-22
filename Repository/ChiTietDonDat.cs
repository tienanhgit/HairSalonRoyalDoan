using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class ChiTietDonDat
    {
        private int _MaDonDatHang;
        private int _MaSanPham;
        private int _SoLuong;
        public ChiTietDonDat()
        {

        }

        public ChiTietDonDat(int maDonDatHang, int maSanPham, int soLuong)
        {
            MaDonDatHang = maDonDatHang;
            MaSanPham = maSanPham;
            SoLuong = soLuong;
        }

        public int MaDonDatHang { get => _MaDonDatHang; set => _MaDonDatHang = value; }
        public int MaSanPham { get => _MaSanPham; set => _MaSanPham = value; }
        public int SoLuong { get => _SoLuong; set => _SoLuong = value; }
    }
}