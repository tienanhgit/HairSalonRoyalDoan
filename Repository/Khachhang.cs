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
        private string _SDTKH;
        private string _Email;
        private string _DiaChi;
        private string _MatKhau;
        public Khachhang()
        {

        }
        public Khachhang(int maKH, string hoTenKH, string sDTKH, string email, string diaChi, string matKhau)
        {
            MaKH = maKH;
            HoTenKH = hoTenKH;
            SDTKH = sDTKH;
            Email = email;
            DiaChi = diaChi;
            MatKhau = matKhau;
        }

        public int MaKH { get => _MaKH; set => _MaKH = value; }
        public string HoTenKH { get => _HoTenKH; set => _HoTenKH = value; }
        public string SDTKH { get => _SDTKH; set => _SDTKH = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string MatKhau { get => _MatKhau; set => _MatKhau = value; }
    }
}