using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Web.Http;
using Web_BanQuanAo.Models;
namespace Web_BanQuanAo.Controllers
{
    public class TTHDController : ApiController
    {
        WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
        [HttpGet]
        // thong tin chi tiet hoa don
        public List<View_ThongTinHoaDon> GetAllCustomersInfo()
        {
            
            return db.View_ThongTinHoaDon.Where(n=>n.STT >0).OrderByDescending(n => n.MaHD).ToList();
            
        }     
        [HttpGet]
        //tim kiem cthd
        public List<View_ThongTinHoaDon> GetCustomersInfo(string TenNguoiDung)
        {
            WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
            List<View_ThongTinHoaDon> lstKQ = db.View_ThongTinHoaDon.Where(n => n.TenNguoiDung.Contains(TenNguoiDung)).ToList();
            return lstKQ;
        }

        [HttpGet]
        [Route("api/TTHD/GetCustomersInfoDate")]
        //liệt kê theo ngày
        public List<SP_BanDuocTheoNgay_Result> GetCustomersInfoDate(DateTime ngay)
        {
            WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
            var lstKQ = db.SP_BanDuocTheoNgay(ngay).Where(n=>n.STT>0).OrderBy(n=>n.MaHD).ToList();
            return lstKQ;
        }
        
        [HttpGet]
        //thông kê hóa đơn 
        [Route("api/TTHD/GetCustomersSum")]
        public List<View_TKHD> GetCustomersSum()
        {
            WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
            return db.View_TKHD.OrderByDescending(n => n.TongTien).ToList();
        }

        [HttpGet]
        // tìm kiếm
        [Route("api/TTHD/GetCustomersSum")]
        public List<View_TKHD> GetCustomersSum(string TenNguoiDung)
        {
            WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
            List<View_TKHD> lstKQ = db.View_TKHD.Where(n => n.TenNguoiDung.Contains(TenNguoiDung)).ToList();
            return lstKQ;
        }
        [HttpGet]
        //xem theo top ..
        [Route("api/TTHD/GetCustomersSumTop")]
        public List<View_TKHD> GetCustomersSumTop5(string top)
        {
            WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
            int top1 = Convert.ToInt32(top);           
            var lstKQ = db.View_TKHD.OrderByDescending(p => p.TongTien).Take(top1);
            return lstKQ.ToList();
        }
        [HttpDelete]
        //hủy đơn
        [Route("api/TTHD/DeleteCustomer")]
        public bool DeleteCustomer(string MaHD,string MaSP)
        {
            try
            {
                int MaHD1 = Convert.ToInt32(MaHD);
                //Lấy mã khách đã có   
                tblChiTietHoaDon customer =
                db.tblChiTietHoaDons.SingleOrDefault(x => x.MaHD == MaHD1 && x.MaSP==MaSP);
                if (customer == null) return false;
                db.tblChiTietHoaDons.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        // thông tin sản phẩm bán chạy
        [Route("api/TTHD/GetCustomersProduct")]
        public List<View_SanPhamBanChay> GetCustomersProduct()
        {
            WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
            return db.View_SanPhamBanChay.OrderByDescending(n => n.SLBan).ToList();
        }
        [HttpGet]
        // tìm kiếm theo tên
        [Route("api/TTHD/GetCustomersProduct")]
        public List<View_SanPhamBanChay> GetCustomersProduct(string TenSP)
        {
            WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
            List<View_SanPhamBanChay> lstKQ = db.View_SanPhamBanChay.Where(n => n.TenSP.Contains(TenSP)).ToList();
            return lstKQ;
        }

        [HttpGet]
        // liệt kê theo top
        [Route("api/TTHD/GetCustomersProductTop")]
        public List<View_SanPhamBanChay> GetCustomersProductTop(string top)
        {
            WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
            int top1 = Convert.ToInt32(top);
            var lstKQ = db.View_SanPhamBanChay.OrderByDescending(p => p.SLBan).Take(top1);
            return lstKQ.ToList();
        }

    }
}
