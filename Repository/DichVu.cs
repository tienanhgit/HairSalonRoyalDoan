using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class DichVu
    {
        private int _MaDV;
        private string _TenDichVu;
        private float _Gia;
        private int _TrangThaiHienThi;
        private DateTime _NgayTao;
        private DateTime _NgaySua;

        public int MaDV { get => _MaDV; set => _MaDV = value; }
        public string TenDichVu { get => _TenDichVu; set => _TenDichVu = value; }
        public float Gia { get => _Gia; set => _Gia = value; }
     
        public int TrangThaiHienThi { get => _TrangThaiHienThi; set => _TrangThaiHienThi = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }

        public DichVu(int maDV, string tenDichVu, float gia, int trangThaiHienThi, DateTime ngayTao, DateTime ngaySua)
        {
            MaDV = maDV;
            TenDichVu = tenDichVu;
            Gia = gia;  
            TrangThaiHienThi = trangThaiHienThi;
            NgayTao = ngayTao;
            NgaySua = ngaySua;
        }
        public DichVu(string tenDichVu, float gia, int trangThaiHienThi, DateTime ngayTao)
        {
       
            TenDichVu = tenDichVu;
            Gia = gia;
            TrangThaiHienThi = trangThaiHienThi;
            NgayTao = ngayTao;
         
        }
        public DichVu()
        {

        }
      
    }
}