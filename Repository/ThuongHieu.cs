using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class ThuongHieu
    {
        private int _maThuongHieu;
        private string _tenThuongHieu;
        private int _TrangThaiHienThi;
        private DateTime _ngayTao;
        private DateTime _NgaySua;
        public ThuongHieu()
        {

        }
        public ThuongHieu(int maThuongHieu, string tenThuongHieu, int trangThaiHienThi, DateTime ngayTao, DateTime ngaySua)
        {
            MaThuongHieu = maThuongHieu;
            TenThuongHieu = tenThuongHieu;
            TrangThaiHienThi = trangThaiHienThi;
            NgayTao = ngayTao;
            NgaySua = ngaySua;
        }

        public int MaThuongHieu { get => _maThuongHieu; set => _maThuongHieu = value; }
        public string TenThuongHieu { get => _tenThuongHieu; set => _tenThuongHieu = value; }
        public int TrangThaiHienThi { get => _TrangThaiHienThi; set => _TrangThaiHienThi = value; }
        public DateTime NgayTao { get => _ngayTao; set => _ngayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }
    }
}