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
        private string _TenSanPham;
        private string _HinhAnh;
        private float _Gia;
  
          
    public ChiTietDonDat()
        {

        }

        public ChiTietDonDat(int maDonDatHang, int maSanPham, int soLuong,string tenSanPham,string hinhAnh,float gia)
        {
            MaDonDatHang = maDonDatHang;
            MaSanPham = maSanPham;
            SoLuong = soLuong;
            TenSanPham = tenSanPham;
            HinhAnh = hinhAnh;
            Gia = gia;
          
        }

        public int MaDonDatHang { get => _MaDonDatHang; set => _MaDonDatHang = value; }
        public int MaSanPham { get => _MaSanPham; set => _MaSanPham = value; }
        public int SoLuong { get => _SoLuong; set => _SoLuong = value; }
        public string TenSanPham { get => _TenSanPham; set => _TenSanPham = value; }
        public string HinhAnh { get => _HinhAnh; set => _HinhAnh = value; }
        public float Gia { get => _Gia; set => _Gia = value; }
     
    }
}