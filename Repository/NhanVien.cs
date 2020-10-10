using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class NhanVien
    {
        private string _HoTenNV;
        private string _Email;
        private string _MatKhau;
        private int _SDTNV;
        private string _QueQuan;
        private int _CMND;
        private DateTime _NgaySinh;
        private string _HinhThucLam;
        private string _ChucVu;
        private DateTime NgayTao;
        private DateTime _NgaySua;

        public NhanVien(string hoTenNV, string email, string matKhau, int sDTNV, string queQuan, int cMND, DateTime ngaySinh, string hinhThucLam, string chucVu, DateTime ngayTao, DateTime ngaySua)
        {
            _HoTenNV = hoTenNV;
            _Email = email;
            _MatKhau = matKhau;
            _SDTNV = sDTNV;
            _QueQuan = queQuan;
            _CMND = cMND;
            _NgaySinh = ngaySinh;
            _HinhThucLam = hinhThucLam;
            _ChucVu = chucVu;
            NgayTao = ngayTao;
            _NgaySua = ngaySua;
        }



        public string HoTenNV { get => _HoTenNV; set => _HoTenNV = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string MatKhau { get => _MatKhau; set => _MatKhau = value; }
        public int SDTNV { get => _SDTNV; set => _SDTNV = value; }
        public string QueQuan { get => _QueQuan; set => _QueQuan = value; }
        public int CMND { get => _CMND; set => _CMND = value; }
        public DateTime NgaySinh { get => _NgaySinh; set => _NgaySinh = value; }
        public string HinhThucLam { get => _HinhThucLam; set => _HinhThucLam = value; }
        public string ChucVu { get => _ChucVu; set => _ChucVu = value; }
        public DateTime NgayTao1 { get => NgayTao; set => NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }
    }
}