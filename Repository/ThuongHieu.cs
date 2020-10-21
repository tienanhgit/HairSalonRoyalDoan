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
        private DateTime _ngayTao;
        private DateTime _NgaySua;
        public ThuongHieu()
        {

        }
        public ThuongHieu(int maThuongHieu,string tenThuongHieu, DateTime ngayTao,DateTime ngaySua)
        {
            _maThuongHieu = MaThuongHieu;
            _tenThuongHieu = TenThuongHieu;
            _ngayTao = ngayTao;
            _NgaySua = ngaySua;


        }
        public int MaThuongHieu { get => _maThuongHieu; set => _maThuongHieu = value; }
        public string TenThuongHieu { get => _tenThuongHieu; set => _tenThuongHieu = value; }
        public DateTime NgayTao { get => _ngayTao; set => _ngayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }
    }
}