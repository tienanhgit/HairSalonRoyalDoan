using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class DanhMuc
    {
        private int _MaDanhMuc;
        private string _TenDanhMuc;
        private int _TrangThaiHienThi;
        private DateTime _NgayTao;
        private DateTime _NgaySua;
        public DanhMuc()
        {

        }

        public DanhMuc(int maDanhMuc, string tenDanhMuc, int trangThaiHienThi, DateTime ngayTao, DateTime ngaySua)
        {
            MaDanhMuc = maDanhMuc;
            TenDanhMuc = tenDanhMuc;
            TrangThaiHienThi = trangThaiHienThi;
            NgayTao = ngayTao;
            NgaySua = ngaySua;
        }

        public int MaDanhMuc { get => _MaDanhMuc; set => _MaDanhMuc = value; }
        public string TenDanhMuc { get => _TenDanhMuc; set => _TenDanhMuc = value; }
        public int TrangThaiHienThi { get => _TrangThaiHienThi; set => _TrangThaiHienThi = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }
    }
}