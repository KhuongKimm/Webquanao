using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_BanQuanAo.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View("ThongKeHoaDon");
        }
        public ActionResult ThongKeHoaDon()
        {
            return View();
        }
        public ActionResult ThemSanPham()
        {
            return View();
        }
        public ActionResult Sua_Xoa_SP()
        {
            return View();
        }
        public ActionResult IndexSP()
        {
            return View();

        }
        public ActionResult KhachHang()
        {
            return View();
        }
    }
}