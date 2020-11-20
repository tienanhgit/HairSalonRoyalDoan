using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class NhanVien
    {
        private int _MaNV;
        private string _HoTenNV;
        private string _Email;
        private string _MatKhau;
        private string _SDTNV;
        private string _QueQuan;
        private string _CMND;
        private DateTime _NgaySinh;
        private string _HinhThucLam;
        private int _MaChucVu;
        private int _TrangThaiHienThi;
        private DateTime _NgayTao;
        private DateTime _NgaySua;
        public NhanVien()
        {

        }
        public NhanVien(int maNV, string hoTenNV, string email, string matKhau, string sDTNV, string queQuan, string cMND, DateTime ngaySinh, string hinhThucLam, int maChucVu, int trangThaiHienThi, DateTime ngayTao, DateTime ngaySua)
        {
            MaNV = maNV;
            HoTenNV = hoTenNV;
            Email = email;
            MatKhau = matKhau;
            SDTNV = sDTNV;
            QueQuan = queQuan;
            CMND = cMND;
            NgaySinh = ngaySinh;
            HinhThucLam = hinhThucLam;
            MaChucVu = maChucVu;
            TrangThaiHienThi = trangThaiHienThi;
            NgayTao = ngayTao;
            NgaySua = ngaySua;
        }

        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public string HoTenNV { get => _HoTenNV; set => _HoTenNV = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string MatKhau { get => _MatKhau; set => _MatKhau = value; }
        public string SDTNV { get => _SDTNV; set => _SDTNV = value; }
        public string QueQuan { get => _QueQuan; set => _QueQuan = value; }
        public string CMND { get => _CMND; set => _CMND = value; }
        public DateTime NgaySinh { get => _NgaySinh; set => _NgaySinh = value; }
        public string HinhThucLam { get => _HinhThucLam; set => _HinhThucLam = value; }
        public int MaChucVu { get => _MaChucVu; set => _MaChucVu = value; }
        public int TrangThaiHienThi { get => _TrangThaiHienThi; set => _TrangThaiHienThi = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }
    }
}