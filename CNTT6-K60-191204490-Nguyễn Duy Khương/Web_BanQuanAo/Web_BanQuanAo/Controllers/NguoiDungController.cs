using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanQuanAo.Models;

namespace Web_BanQuanAo.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        // GET: NguoiDung
        WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangKy(tblKhachHang kh)
        {

            if (ModelState.IsValid)
            {
                var checkTenTK = db.tblKhachHangs.FirstOrDefault(s => s.TenNguoiDung == kh.TenNguoiDung);
                if (checkTenTK == null)
                {
                    db.tblKhachHangs.Add(kh);
                    db.SaveChanges();

                    ViewBag.success = "Đăng ký thành công";
                    return RedirectToAction("DangNhap");
                }
                else
                {
                    ViewBag.error = " Tên tài khoản đã tồn tại";
                    return View();
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string staikhoan = f["txtTaikhoan"].ToString();
            string smatkhau = f["txtMatkhau"].ToString();
            tblKhachHang kh = db.tblKhachHangs.SingleOrDefault(n => n.TenNguoiDung == staikhoan && n.MatKhau == smatkhau);
            tblAdmin ad = db.tblAdmins.SingleOrDefault(n => n.TenTK == staikhoan && n.MatKhau == smatkhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TaiKhoan"] = kh.TenNguoiDung;
                Session["KhachHang"] = kh;
                return RedirectToAction("Index", "SanPham");

            }
            if (ad != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TaiKhoan"] = ad.TenTK;
                Session["Admin"] = kh;
                return RedirectToAction("index", "Admin");

            }

            ViewBag.ThongBao = "Tên người dùng hoặc mật khẩu sai";
            return View();
        }
        public ActionResult Profile(string TenNguoiDung)
        {
            tblKhachHang kh = db.tblKhachHangs.SingleOrDefault(n => n.TenNguoiDung == TenNguoiDung);
            ViewBag.kh = kh;
            return View(kh);
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            Session["KhachHang"] = null;
            Session["Admin"] = null;
            Session["GioHang"] = null;
            return RedirectToAction("Index", "SanPham");
        }
    }
}