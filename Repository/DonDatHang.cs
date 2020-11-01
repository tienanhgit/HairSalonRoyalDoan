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
        private int _SoDTGiaoHang;
        private string _HinhThucThanhToan;
        private int _TrangThaiDonSanPham;
        private int _TrangThaiDonDichVu;
        private string _HoTenNguoiNhan;
        private string _DiaChiNhanHang;
        private string _GhiChu;
        private int _MaKhungThoiGian;
        private DateTime _NgayCat;
        private DateTime _NgayTao;
        private DateTime _NgaySua;

        public int MaDonDatHang { get => _MaDonDatHang; set => _MaDonDatHang = value; }
        public int MaNV { get => _MaNV; set => _MaNV = value; }
        public int MaKH { get => _MaKH; set => _MaKH = value; }
        public int SoDTGiaoHang { get => _SoDTGiaoHang; set => _SoDTGiaoHang = value; }
        public string HinhThucThanhToan { get => _HinhThucThanhToan; set => _HinhThucThanhToan = value; }
        public int TrangThaiDonSanPham { get => _TrangThaiDonSanPham; set => _TrangThaiDonSanPham = value; }
        public int TrangThaiDonDichVu { get => _TrangThaiDonDichVu; set => _TrangThaiDonDichVu = value; }
        public string HoTenNguoiNhan { get => _HoTenNguoiNhan; set => _HoTenNguoiNhan = value; }
        public string DiaChiNhanHang { get => _DiaChiNhanHang; set => _DiaChiNhanHang = value; }
        public string GhiChu { get => _GhiChu; set => _GhiChu = value; }
        public int MaKhungThoiGian { get => _MaKhungThoiGian; set => _MaKhungThoiGian = value; }
        public DateTime NgayCat { get => _NgayCat; set => _NgayCat = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }

        public DonDatHang(int maDonDatHang, int maNV, int maKH, int soDTGiaoHang, string hinhThucThanhToan, int trangThaiDonSanPham, int trangThaiDonDichVu, string hoTenNguoiNhan, string diaChiNhanHang, string ghiChu, int maKhungThoiGian, DateTime ngayCat, DateTime ngayTao, DateTime ngaySua)
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
            GhiChu = ghiChu;
            MaKhungThoiGian = maKhungThoiGian;
            NgayCat = ngayCat;
            NgayTao = ngayTao;
            NgaySua = ngaySua;
        }

        public DonDatHang()
        {

        }


   

    
  
    }
}