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
        private int _ViTri;
        private string _AnhBanner;
        private int _TrangThaiHienThi;
        private DateTime _NgayTao;
        private DateTime _NgaySua;


        public Banner(int maBanner, int maNV, int viTri, string anhBanner, int trangThaiHienThi, DateTime ngayTao, DateTime ngaySua)
        {
            MaBanner = maBanner;
            MaNV = maNV;
            ViTri = viTri;
            AnhBanner = anhBanner;
            TrangThaiHienThi = trangThaiHienThi;
            NgayTao = ngayTao;
            NgaySua = ngaySua;
        }

        public Banner()
        {

        }

        public int MaBanner { get => _MaBanner; set => _MaBanner = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public int ViTri { get => _ViTri; set => _ViTri = value; }
        public string AnhBanner { get => _AnhBanner; set => _AnhBanner = value; }
        public int TrangThaiHienThi { get => _TrangThaiHienThi; set => _TrangThaiHienThi = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }

     
       
    }
}