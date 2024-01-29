using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Web_BanQuanAo.Models;
using System.Web.Http;
using System.Data.Entity;

namespace Web_BanQuanAo.Controllers
{
    public class KhachHangAPIController : ApiController
    {
        WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
        [HttpDelete]
        public bool DeleteKhachHang(int id)
        {
            try
            {

                //Lấy mã khách đã có
                tblKhachHang customer =
                db.tblKhachHangs.SingleOrDefault(x => x.MaKH == id);
                if (customer == null) return false;
                db.tblKhachHangs.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpGet]
        public List<tblKhachHang> GetCustomerListsKH()
        {

            return db.tblKhachHangs.ToList();
        }
        [HttpGet]
        public List<tblKhachHang> GetCustomerByIDKH(string TenNguoidung)
        {
            if (TenNguoidung == null || TenNguoidung == "")
                return db.tblKhachHangs.ToList();
            else
            {
                List<tblKhachHang> list = db.tblKhachHangs.Where(n => n.TenNguoiDung.Contains(TenNguoidung)).ToList();
                return list;
            }
        }

        [HttpPut]
        public bool UpdateKhachHang(int id, string tenNguoiDung, string matKhau, string tenKH, string diaChi, string dienThoai, string email)
        {
            try
            {
                tblKhachHang user = new tblKhachHang();
                user.MaKH = id;
                user.TenNguoiDung = tenNguoiDung;
                user.MatKhau = matKhau;
                user.TenKH = tenKH;
                user.DiaChi = diaChi;
                user.DienThoai = dienThoai;
                user.Email = email;
                user.GioiTinh = true;
                db.tblKhachHangs.Add(user);
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return true;
            }

            catch
            {
                return false;
            }
        }
        [HttpGet]
        public List<SanPham_KH_Result> GetCustomerByIDKH(int maId)
        {
            List<SanPham_KH_Result> list = db.SanPham_KH(maId).ToList();
            return list;
        }

    }
}
