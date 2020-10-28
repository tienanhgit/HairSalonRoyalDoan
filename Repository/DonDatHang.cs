using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class DonDatHang
    {
        private int _MaDonDatHang;
        private int _MaNhanVien;
        private int _MaKH;
        private int _SoDTGiaoHang;
        private string _HinhThucThanhToan;
        private int _TrangThaiDonDatSanPham;
        private int _TrangThaiDonDichVu;
        private string _HoTenNguoiNhan;
        private string _DiaChiNhanHang;
        private DateTime _NgayTao;
        private DateTime _NgaySua;

        public DonDatHang()
        {

        }

        public DonDatHang(int maDonDatHang, int maNhanVien, int maKH, int soDTGiaoHang, string hinhThucThanhToan, int trangThaiDonDatSanPham, int trangThaiDonDichVu, string hoTenNguoiNhan, string diaChiNhanHang, DateTime ngayTao, DateTime ngaySua)
        {
            _MaDonDatHang = maDonDatHang;
            _MaNhanVien = maNhanVien;
            _MaKH = maKH;
            _SoDTGiaoHang = soDTGiaoHang;
            _HinhThucThanhToan = hinhThucThanhToan;
            _TrangThaiDonDatSanPham = trangThaiDonDatSanPham;
            _TrangThaiDonDichVu = trangThaiDonDichVu;
            _HoTenNguoiNhan = hoTenNguoiNhan;
            _DiaChiNhanHang = diaChiNhanHang;
            _NgayTao = ngayTao;
            _NgaySua = ngaySua;
        }
        public int MaDonDatHang { get => _MaDonDatHang; set => _MaDonDatHang = value; }
        public int MaNV { get => _MaNhanVien; set => _MaNhanVien = value; }
        public int MaKH { get => _MaKH; set => _MaKH = value; }
        public int SoDTGiaoHang { get => _SoDTGiaoHang; set => _SoDTGiaoHang = value; }
        public string HinhThucThanhToan { get => _HinhThucThanhToan; set => _HinhThucThanhToan = value; }
        public int TrangThaiDonSanPham { get => _TrangThaiDonDatSanPham; set => _TrangThaiDonDatSanPham = value; }
        public int TrangThaiDonDichVu { get => _TrangThaiDonDichVu; set => _TrangThaiDonDichVu = value; }
        public string HoTenNguoiNhan { get => _HoTenNguoiNhan; set => _HoTenNguoiNhan = value; }
        public string DiaChiNhanHang { get => _DiaChiNhanHang; set => _DiaChiNhanHang = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }
    }
}