using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_BanQuanAo.Models
{
    [MetadataTypeAttribute(typeof(tblKhachHangMetadata))]
    public partial class tblKhachHang
    {
        internal sealed class tblKhachHangMetadata
        {
            public int MaKH { get; set; }
            [Display(Name = "Tên tài khoản")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [RegularExpression(@"^[a-zA-Z]([._-]?[a-zA-Z0-9]+)*$",
                ErrorMessage = "Tên tài khoản bắt đầu bằng chữ cái")]
            public string TenNguoiDung { get; set; }
            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [DataType(DataType.Password)]
            [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$",
                ErrorMessage = "Mật khẩu có tối tiểu 8 ký tự, có chữ cái, chữ số, ký tự đặc biệt")]
            public string MatKhau { get; set; }
            [Display(Name = "Họ và tên")]
            public string TenKH { get; set; }
            [Display(Name = "Địa chỉ")]
            public string DiaChi { get; set; }

            [Display(Name = "Điện thoại")]
            [DataType(DataType.PhoneNumber)]
            public string DienThoai { get; set; }

            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            public Nullable<bool> GioiTinh { get; set; }
        }
    }
}