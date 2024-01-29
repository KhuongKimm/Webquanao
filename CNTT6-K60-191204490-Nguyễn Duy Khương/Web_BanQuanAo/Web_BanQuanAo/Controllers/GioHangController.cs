using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanQuanAo.Models;

namespace Web_BanQuanAo.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        // GET: GioHang
        WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
        // GET: GioHang
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(string sMaSP, string strUrl)
        {
            tblSanPham sanpham = db.tblSanPhams.SingleOrDefault(n => n.MaSP == sMaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lay session
            List<GioHang> lstGioHang = LayGioHang();
            //ktra sanpham chon co trong gio hang chua
            GioHang spgh = lstGioHang.Find(n => n.sMaSP == sMaSP);
            if (spgh == null)
            {
                spgh = new GioHang(sMaSP);
                lstGioHang.Add(spgh);
                return Redirect(strUrl);
            }
            else
            {
                spgh.iSoLuong++;
                return Redirect(strUrl);
            }
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "SanPham");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        private int TongSoLuong()
        {
            int TongSL = 0;
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang != null)
            {
                TongSL = lstGioHang.Sum(n => n.iSoLuong);
            }
            return TongSL;
        }
        private double TongTien()
        {
            double TongTien = 0;
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang != null)
            {
                TongTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return TongTien;
        }
        public ActionResult TongTienThanhToan()
        {
            if (TongTien() != 0)
            {
                ViewBag.TongTien = TongTien();
            }
            return View();
        }
        public ActionResult partialGioHang()
        {
            if (TongSoLuong() != 0)
            {
                ViewBag.TongSL = TongSoLuong();
            }
            return PartialView();
        }
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "SanPham");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        public ActionResult CapNhatGioHang(string sMaSP, FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.SingleOrDefault(n => n.sMaSP == sMaSP);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang(string sMaSP)
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.RemoveAll(n => n.sMaSP == sMaSP);
            return RedirectToAction("GioHang");
        }
        [HttpPost]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "SanPham");
            }
            tblHoaDon ddh = new tblHoaDon();
            tblKhachHang kh = (tblKhachHang)Session["KhachHang"];
            ddh.MaKH = kh.MaKH;
            ddh.NgayDat = DateTime.Now;
            ddh.TenKH = kh.TenKH;
            ddh.SDT = kh.DienThoai;
            ddh.DiaChi = kh.DiaChi;
            //ddh.TongTien = TongTien();
            db.tblHoaDons.Add(ddh);
            db.SaveChanges();
            List<GioHang> lstGioHang = LayGioHang();
            foreach (var item in lstGioHang)
            {
                tblChiTietHoaDon cthd = new tblChiTietHoaDon();
                cthd.MaHD = ddh.MaHD;
                cthd.MaSP = item.sMaSP;
                cthd.SoLuong = item.iSoLuong;
                cthd.Gia = item.dDonGia *item.iSoLuong;
                db.tblChiTietHoaDons.Add(cthd);
            }
            db.SaveChanges();
            return RedirectToAction("DatHangThanhCong", "GioHang");
        }

        public ActionResult DatHangThanhCong()
        {
            return View();

        }
    }
}