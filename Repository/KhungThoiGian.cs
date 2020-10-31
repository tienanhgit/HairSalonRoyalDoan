using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class KhungThoiGian
    {
        private int _MaKhungThoiGian;
        private int _ThoiGianBatDau;
        private int _ThoiGianKetThuc;
        public KhungThoiGian()
        {

        }
        public KhungThoiGian(int maKhungThoiGian, int thoiGianBatDau, int thoiGianKetThuc)
        {
            MaKhungThoiGian = maKhungThoiGian;
            ThoiGianBatDau = thoiGianBatDau;
            ThoiGianKetThuc = thoiGianKetThuc;
        }

        public int MaKhungThoiGian { get => _MaKhungThoiGian; set => _MaKhungThoiGian = value; }
        public int ThoiGianBatDau { get => _ThoiGianBatDau; set => _ThoiGianBatDau = value; }
        public int ThoiGianKetThuc { get => _ThoiGianKetThuc; set => _ThoiGianKetThuc = value; }
    }
}