using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class LichHen
    {
        private int _MaLichHen;
        private int _MaKhachHang;
        private int _MaNV;
        private DateTime NgayHen;
        private DateTime _GioHen;
        private int _TrangThai;
        public LichHen()
        {

        }
        public LichHen(int maLichHen, int maKhachHang, int maNV, DateTime ngayHen, DateTime gioHen, int trangThai)
        {
            MaLichHen = maLichHen;
            MaKhachHang = maKhachHang;
            MaNV = maNV;
            NgayHen1 = ngayHen;
            GioHen = gioHen;
            TrangThai = trangThai;
        }

        public int MaLichHen { get => _MaLichHen; set => _MaLichHen = value; }
        public int MaKhachHang { get => _MaKhachHang; set => _MaKhachHang = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public DateTime NgayHen1 { get => NgayHen; set => NgayHen = value; }
        public DateTime GioHen { get => _GioHen; set => _GioHen = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }
    }
}