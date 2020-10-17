using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairSalonRoyalDoan.Repository
{
    public class DanhMuc
    {
        private int _MaDanhMuc;
        private string _TenDanhMuc;

        public DanhMuc()
        {
        }
            public DanhMuc(int maDanhMuc,string tenDanhMuc)
        {
            _MaDanhMuc = maDanhMuc;
            _TenDanhMuc = tenDanhMuc;

        }
       

        public int MaDanhMuc { get => _MaDanhMuc; set => _MaDanhMuc = value; }
        public string TenDanhMuc { get => _TenDanhMuc; set => _TenDanhMuc = value; }
    }
}