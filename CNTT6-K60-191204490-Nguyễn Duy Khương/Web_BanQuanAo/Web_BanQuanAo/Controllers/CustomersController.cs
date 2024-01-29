using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Web_BanQuanAo.Models;

namespace Web_BanQuanAo.Controllers
{
    public class CustomersController : ApiController
    {
        WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
        [HttpGet]
        public List<tblSanPham> GetCustomerLists()
        {

            return db.tblSanPhams.ToList();
        }
        [HttpGet]
        public List<tblSanPham> GetCustomerByID(string TenSP)
        {
            if (TenSP == null || TenSP == "") return db.tblSanPhams.ToList();
            else
            {
                List<tblSanPham> list = db.tblSanPhams.Where(n => n.TenSP.Contains(TenSP)).ToList();
                return list;
            }
        }
        [HttpGet]
        public List<tblSanPham> GetCustomerByMa(string MaSP)
        {
            List<tblSanPham> list = db.tblSanPhams.Where(n => n.MaSP.Contains(MaSP)).ToList();
            return list;
        }
        [HttpGet]

        public List<String> GetCustomerLists(int i)
        {
            List<String> a = new List<String>();
            if (i == 1)
            {

                List<tblChatLieu> list = db.tblChatLieux.ToList();
                for (int j = 0; j < list.Count(); j++)
                {
                    a.Add(list[j].MaChatLieu);

                }

            }
            else if (i == 2)
            {

                List<tblLoai> list = db.tblLoais.ToList();
                for (int j = 0; j < list.Count(); j++)
                {
                    a.Add(list[j].MaLoai);

                }

            }
            else if (i == 3)
            {

                List<tblHangSX> list = db.tblHangSXes.ToList();
                for (int j = 0; j < list.Count(); j++)
                {
                    a.Add(list[j].MaHangSX);

                }

            }
            else if (i == 4)
            {

                List<tblDoiTuong> list = db.tblDoiTuongs.ToList();
                for (int j = 0; j < list.Count(); j++)
                {
                    a.Add(list[j].MaDT);

                }

            }


            return a;
        }

        [HttpPost]
        public bool InsertNewCustomer(string maSP, string tenSP,
       string maCL, string maMau, string hangSX, float gia, string maDT, string Anh, string ghiChu, string maLoai, int SoLuong)
        {
            try
            {

                tblSanPham customer = new tblSanPham();
                customer.MaSP = maSP;
                customer.TenSP = tenSP;
                customer.MauSac = maMau;
                customer.MaChatLieu = maCL;
                customer.HangSX = hangSX;
                customer.Gia = gia;
                customer.MaDT = maDT;
                customer.Anh = Anh;
                customer.GhiChu = ghiChu;
                customer.Maloai = maLoai;
                customer.SoLuong = SoLuong;
                db.tblSanPhams.Add(customer);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //4. httpPut để chỉnh sửa thông tin một khách hàng
        [HttpPut]
        public bool UpdateCustomer(string maSP, string tenSP,
       string maCL, string maMau, string hangSX, float gia, string maDT, string Anh, string ghiChu, string maLoai, int SoLuong)
        {
            try
            {
                tblSanPham customer = new tblSanPham();
                customer.MaSP = maSP;
                customer.TenSP = tenSP;
                customer.MauSac = maMau;
                customer.MaChatLieu = maCL;
                customer.HangSX = hangSX;
                customer.Gia = gia;
                customer.MaDT = maDT;
                customer.Anh = Anh;
                customer.GhiChu = ghiChu;
                customer.Maloai = maLoai;
                customer.SoLuong = SoLuong;
                db.tblSanPhams.Add(customer);


                if (ModelState.IsValid)
                {
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool DeleteCustomer(string id)
        {
            try
            {

                //Lấy mã khách đã có
                tblSanPham customer =
                db.tblSanPhams.SingleOrDefault(x => x.MaSP == id);
                if (customer == null) return false;
                db.tblSanPhams.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
