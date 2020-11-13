using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class LichHen
    {
        private int _MaLichHen;
        private int _MaKH;
        private int _MaNV;
        private string _NgayHen;
        private string _GioHen;
        private string _TenKhachHang;
        private string _TenNhanVien;
        private int _TrangThai;
        private string _SoDTKH;
        public LichHen()
        {

        }

        public LichHen(int maLichHen, int maKH, int maNV, string ngayHen, string gioHen, string tenKhachHang, string tenNhanVien, int trangThai, string soDTKH)
        {
            MaLichHen = maLichHen;
            MaKH = maKH;
            MaNV = maNV;
            NgayHen = ngayHen;
            GioHen = gioHen;
            TenKhachHang = tenKhachHang;
            TenNhanVien = tenNhanVien;
            TrangThai = trangThai;
            SoDTKH = soDTKH;
        }

        public int MaLichHen { get => _MaLichHen; set => _MaLichHen = value; }
        public int MaKH { get => _MaKH; set => _MaKH = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public string NgayHen { get => _NgayHen; set => _NgayHen = value; }
        public string GioHen { get => _GioHen; set => _GioHen = value; }
        public string TenKhachHang { get => _TenKhachHang; set => _TenKhachHang = value; }
        public string TenNhanVien { get => _TenNhanVien; set => _TenNhanVien = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }
        public string SoDTKH { get => _SoDTKH; set => _SoDTKH = value; }
    }
}