using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class BaiViet
    {
        private int _MaBaiViet;
        private int _MaNV;
        private string _TenBaiViet;
        private string _NoiDung;
        private int _TrangThaiHienThi;
        private DateTime _NgayTao;
        private DateTime _NgaySua;
        public BaiViet()
        {

        }
        public BaiViet(int maBaiViet, int maNV, string tenBaiViet, string noiDung, int trangThaiHienThi, DateTime ngayTao, DateTime ngaySua)
        {
            MaBaiViet = maBaiViet;
            MaNV = maNV;
            TenBaiViet = tenBaiViet;
            NoiDung = noiDung;
            TrangThaiHienThi = trangThaiHienThi;
            NgayTao = ngayTao;
            NgaySua = ngaySua;
        }

        public int MaBaiViet { get => _MaBaiViet; set => _MaBaiViet = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public string TenBaiViet { get => _TenBaiViet; set => _TenBaiViet = value; }
        public string NoiDung { get => _NoiDung; set => _NoiDung = value; }
        public int TrangThaiHienThi { get => _TrangThaiHienThi; set => _TrangThaiHienThi = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }
    }
}