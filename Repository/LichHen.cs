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
        private DateTime _NgayHen;
        private DateTime _GioHen;
        private int _TrangThai;

        public int MaLichHen { get => _MaLichHen; set => _MaLichHen = value; }
        public int MaKH { get => _MaKH; set => _MaKH = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public DateTime NgayHen { get => _NgayHen; set => _NgayHen = value; }
        public DateTime GioHen { get => _GioHen; set => _GioHen = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }

        public LichHen(int maLichHen, int maKH, int maNV, DateTime ngayHen, DateTime gioHen, int trangThai)
        {
            MaLichHen = maLichHen;
            MaKH = maKH;
            MaNV = maNV;
            NgayHen = ngayHen;
            GioHen = gioHen;
            TrangThai = trangThai;
        }
        public LichHen()
        {

        }
    }
}