using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class Banner
    {
        private int _MaBanner;
        private int _MaNV;
        private string _ViTri;
        private int _TrangThaiHienThi;
        private DateTime _NgayTao;
        private DateTime _NgaySua;

        public Banner()
        {

        }
        public Banner(int maBanner, int maNV, string viTri, int trangThaiHienThi, DateTime ngayTao, DateTime ngaySua)
        {
            MaBanner = maBanner;
            MaNV = maNV;
            ViTri = viTri;
            TrangThaiHienThi = trangThaiHienThi;
            NgayTao = ngayTao;
            NgaySua = ngaySua;
        }

        public int MaBanner { get => _MaBanner; set => _MaBanner = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public string ViTri { get => _ViTri; set => _ViTri = value; }
        public int TrangThaiHienThi { get => _TrangThaiHienThi; set => _TrangThaiHienThi = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }
    }
}