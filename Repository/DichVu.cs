using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class DichVu
    {
        private int _MaDichVu;
        private string _TenDichVu;
        private float _Gia;
        private string _HoatDong;
        private int _TrangThaiHienThi;
        private DateTime _NgayTao;
        private DateTime _NgaySua;

        public DichVu()
        {

        }
        public DichVu(int maDichVu, string tenDichVu, float gia, string hoatDong, int trangThaiHienThi, DateTime ngayTao, DateTime ngaySua)
        {
            _MaDichVu = maDichVu;
            _TenDichVu = tenDichVu;
            _Gia = gia;
            _HoatDong = hoatDong;
            _TrangThaiHienThi = trangThaiHienThi;
            _NgayTao = ngayTao;
            _NgaySua = ngaySua;
        }

        public int MaDichVu { get => _MaDichVu; set => _MaDichVu = value; }
        public string TenDichVu { get => _TenDichVu; set => _TenDichVu = value; }
        public float Gia { get => _Gia; set => _Gia = value; }
        public string HoatDong { get => _HoatDong; set => _HoatDong = value; }
        public int TrangThaiHienThi { get => _TrangThaiHienThi; set => _TrangThaiHienThi = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }
    }
}