using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class Khachhang
    {
        private int _MaKH;
        private string _HoTenKH;
        private int _SDTKH;
        private string _Email;
        private string _DiaChi;
        private string _MatKhau;

        public int MaKH { get => _MaKH; set => _MaKH = value; }
        public string HoTenKH { get => _HoTenKH; set => _HoTenKH = value; }
        public int SDTKH { get => _SDTKH; set => _SDTKH = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string MatKhau { get => _MatKhau; set => _MatKhau = value; }

        public Khachhang()
        {
        }
        public Khachhang(int maKH, string hoTenKH, int sDTKH, string email, string diaChi, string matKhau)
        {
            _MaKH = maKH;
            _HoTenKH = hoTenKH;
            _SDTKH = sDTKH;
            _Email = email;
            _DiaChi = diaChi;
            _MatKhau = matKhau;
        }

        public Khachhang(string hoTenKH, int sDTKH, string email, string diaChi, string matKhau)
        {
            _HoTenKH = hoTenKH;
            _SDTKH = sDTKH;
            _Email = email;
            _DiaChi = diaChi;
            _MatKhau = matKhau;
        }


    }
}