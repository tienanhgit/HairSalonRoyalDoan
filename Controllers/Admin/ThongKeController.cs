using HairSalonRoyalDoan.Models.Dictionary;
using HairSalonRoyalDoan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        public ActionResult Index()
        {
            
           
            return View();
        }
        [HttpPost]
        public JsonResult ThongKeAll(string LoaiThongKe)
        {
            
            BieuDo bd = new BieuDo();
            DonDatHangModel donDatHangModel = new DonDatHangModel();
            List<BieuDo> lsbd= new List<BieuDo>();
            string LoaiBieuDo = "";
            for(int i=1;i<=12;i++)
            {
                bd = new BieuDo();
                bd.Thang = i;
                if(LoaiThongKe=="1")
                {
                    LoaiBieuDo = "tổng";
                    bd.TongTien = donDatHangModel.GetDataBieuDo(i, 0, 0);

                    lsbd.Add(bd);

                }
                if (LoaiThongKe == "2")
                {

                    LoaiBieuDo = "sản phẩm";
                    bd.TongTien = donDatHangModel.GetDataBieuDo(i, 0, 4);

                    lsbd.Add(bd);

                }
                if (LoaiThongKe == "3")
                {
                    LoaiBieuDo = "dịch vụ";
                    bd.TongTien = donDatHangModel.GetDataBieuDo(i, 4, 0);

                    lsbd.Add(bd);

                }



            }    
            return Json(new { data = lsbd,LBD=LoaiBieuDo}, JsonRequestBehavior.AllowGet);
        }

    }
}