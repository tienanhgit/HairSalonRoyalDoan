using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HairSalonRoyalDoan.Repository;
namespace HairSalonRoyalDoan.Models.Dictionary
{
    public class MultipleDonDat
    {
       
        public Khachhang khachhangdetail { get; set; }
        public DonDatHang donDatHangdetail { get; set; }
        public ChiTietDonDat ChiTietDonDatdetail { get; set; }
        public SanPham sanPhamdetail { get; set; }

    }
}