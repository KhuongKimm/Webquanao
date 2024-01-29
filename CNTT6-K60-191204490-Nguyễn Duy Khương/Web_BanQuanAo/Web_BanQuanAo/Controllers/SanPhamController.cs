using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Web_BanQuanAo.Models;
using PagedList;
using PagedList.Mvc;

namespace Web_BanQuanAo.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham

        WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
        // GET: SanPham
        [HttpGet]
        public ActionResult Index(int? page)
        {
            List<tblSanPham> lsp = db.tblSanPhams.ToList();
            int pagesize = 10;// sản phẩm trên 1 trang 
            int pagenumber = (page ?? 1); // số trang
            return View(lsp.ToPagedList(pagenumber, pagesize));
            //return View();
        }
        public PartialViewResult LoaiPartial()
        {
            return PartialView(db.tblLoais.ToList());
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        public ViewResult SanPhamTheoLoai(int? page, string Maloai = "QuanAoNu")
        {
            int pagesize = 5;//số sản phẩm trên 1 trang
            int pagenumber = (page ?? 1);// số trang
            tblLoai lsp = db.tblLoais.SingleOrDefault(n => n.MaLoai == Maloai);
            if (lsp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<tblSanPham> lstSanpham = db.tblSanPhams.Where(n => n.Maloai == Maloai).OrderBy(n => n.Maloai).ToList();
            if (lstSanpham == null)
            {
                ViewBag.lstSanPham = "Không có sản phẩm nào thuộc loại này";
            }
            //ViewBag.lstSanpham = lstSanpham;
            //return View(lstSanpham);
            ViewBag.Maloai = Maloai;
            return View(lstSanpham.ToPagedList(pagenumber, pagesize));

        }
        public ViewResult ChiTietSanPham(string MaSP = "NGiay01")
        {
            tblSanPham sanpham = db.tblSanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.sanpham = sanpham;
            return View(sanpham);
        }
        public PartialViewResult TopMenu()
        {
            return PartialView();
        }

        public ActionResult Map()
        {

            return View();
        }
    }
}