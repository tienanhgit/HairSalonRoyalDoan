using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class DonDatHang
    {
        private int _MaDonDatHang;
        private int _MaNV;
        private int _MaKH;
        private string _SoDTGiaoHang;
        private string _HinhThucThanhToan;
        private int _TrangThaiDonSanPham;
        private int _TrangThaiDonDichVu;
        private string _HoTenNguoiNhan;
        private string _DiaChiNhanHang;
        private double _TongTien;
        private DateTime _NgayTao;
        public DonDatHang()
        {

        }
        public DonDatHang(int maDonDatHang, int maNV, int maKH, string soDTGiaoHang, string hinhThucThanhToan, int trangThaiDonSanPham, int trangThaiDonDichVu, string hoTenNguoiNhan, string diaChiNhanHang, double tongTien, DateTime ngayTao)
        {
            MaDonDatHang = maDonDatHang;
            MaNV = maNV;
            MaKH = maKH;
            SoDTGiaoHang = soDTGiaoHang;
            HinhThucThanhToan = hinhThucThanhToan;
            TrangThaiDonSanPham = trangThaiDonSanPham;
            TrangThaiDonDichVu = trangThaiDonDichVu;
            HoTenNguoiNhan = hoTenNguoiNhan;
            DiaChiNhanHang = diaChiNhanHang;
            TongTien = tongTien;
            NgayTao = ngayTao;
        }

        public int MaDonDatHang { get => _MaDonDatHang; set => _MaDonDatHang = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public int MaKH { get => _MaKH; set => _MaKH = value; }
        public string SoDTGiaoHang { get => _SoDTGiaoHang; set => _SoDTGiaoHang = value; }
        public string HinhThucThanhToan { get => _HinhThucThanhToan; set => _HinhThucThanhToan = value; }
        public int TrangThaiDonSanPham { get => _TrangThaiDonSanPham; set => _TrangThaiDonSanPham = value; }
        public int TrangThaiDonDichVu { get => _TrangThaiDonDichVu; set => _TrangThaiDonDichVu = value; }
        public string HoTenNguoiNhan { get => _HoTenNguoiNhan; set => _HoTenNguoiNhan = value; }
        public string DiaChiNhanHang { get => _DiaChiNhanHang; set => _DiaChiNhanHang = value; }
        public double TongTien { get => _TongTien; set => _TongTien = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
    }
}