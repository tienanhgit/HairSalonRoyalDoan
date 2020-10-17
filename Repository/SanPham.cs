using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class SanPham
    {
        private int _maSanPham;
        private int _maThuongHieu;
        private int _maDanhMuc;
        private string _tenSanPham;
        private float _gia;
        private string _hinhAnh;
        private string _moTa;
        private string _danhGia;
        private DateTime _ngayTao;
        private DateTime _ngaySua;
        public int MaSanPham { get => _maSanPham; set => _maSanPham = value; }
        public int MaDanhMuc { get => _maDanhMuc; set => _maDanhMuc = value; }
        public int MaThuongHieu { get => _maThuongHieu; set => _maThuongHieu = value; }
        public string TenSanPham { get => _tenSanPham; set => _tenSanPham = value; }
        public float Gia { get => _gia; set => _gia = value; }
        public string HinhAnh { get => _hinhAnh; set => _hinhAnh = value; }
        public string MoTa { get => _moTa; set => _moTa = value; }
        public string DanhGia { get => _danhGia; set => _danhGia = value; }
        public DateTime NgayTao { get => _ngayTao; set => _ngayTao = value; }
        public DateTime NgaySua { get => _ngaySua; set => _ngaySua = value; }
        public SanPham(){ }

  public SanPham(int maSanPham,int maThuongHieu, int maDanhMuc, string tenSanPham,float gia,string hinhAnh,string moTa,string danhGia,DateTime ngayTao,DateTime ngaySua)
        {
            MaSanPham = maSanPham;
            MaThuongHieu = maThuongHieu;
            MaDanhMuc = maDanhMuc;
            TenSanPham = tenSanPham;
            Gia = gia;
            HinhAnh = hinhAnh;
            MoTa = moTa;
            DanhGia = danhGia;
            NgaySua = ngaySua;
            NgayTao = ngayTao;

        }
        public SanPham( int maThuongHieu, int maDanhMuc, string tenSanPham, float gia, string hinhAnh, string moTa, string danhGia, DateTime ngayTao, DateTime ngaySua)
        {
         
            MaThuongHieu = maThuongHieu;
            MaDanhMuc = maDanhMuc;
            TenSanPham = tenSanPham;
            Gia = gia;
            HinhAnh = hinhAnh;
            MoTa = moTa;
            DanhGia = danhGia;
            NgaySua = ngaySua;
            NgayTao = ngayTao;

        }
        public SanPham(int maThuongHieu, int maDanhMuc, string tenSanPham, float gia, string hinhAnh, string moTa, string danhGia, DateTime ngayTao)
        {

            MaThuongHieu = maThuongHieu;
            MaDanhMuc = maDanhMuc;
            TenSanPham = tenSanPham;
            Gia = gia;
            HinhAnh = hinhAnh;
            MoTa = moTa;
            DanhGia = danhGia;
            NgayTao = ngayTao;

        }




    }
}