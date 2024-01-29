using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanQuanAo.Models;
using PagedList;
using PagedList.Mvc;
namespace Web_BanQuanAo.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string searchkey = f["txtsearchkey"].ToString();

            ViewBag.keyword = searchkey;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            List<tblSanPham> lstKQ = db.tblSanPhams.Where(n => n.TenSP.Contains(searchkey)).ToList();
            if (lstKQ.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.tblSanPhams.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQ.Count + " sản phẩm";
            return View(lstKQ.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page, string searchkey)
        {

            ViewBag.keyword = searchkey;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            List<tblSanPham> lstKQ = db.tblSanPhams.Where(n => n.TenSP.Contains(searchkey)).ToList();
            if (lstKQ.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.tblSanPhams.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQ.Count + " sản phẩm";
            return View(lstKQ.OrderBy(n => n.TenSP).ToPagedList(pageNumber, pageSize));
        }
    }
}