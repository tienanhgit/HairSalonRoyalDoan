using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HairSalonRoyalDoan.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult SanPham()
        {
            return View();

        }
        public ActionResult ThemSanPham()
        {
            return View();

        }
        public ActionResult SuaSanPham()
        {
            return View();
        }


    }
}