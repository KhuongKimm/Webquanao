using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanQuanAo.Models
{
    public class GioHang
    {
        WebBanQuanAoEntities1 db = new WebBanQuanAoEntities1();
        public string sMaSP { get; set; }
        public string sTenSp { get; set; }
        public string sHinhAnh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public GioHang(string MaSP)
        {
            sMaSP = MaSP;
            tblSanPham sanpham = db.tblSanPhams.SingleOrDefault(n => n.MaSP == sMaSP);
            sTenSp = sanpham.TenSP;
            sHinhAnh = sanpham.Anh;
            dDonGia = double.Parse(sanpham.Gia.ToString());
            iSoLuong = 1;
        }
    }
}