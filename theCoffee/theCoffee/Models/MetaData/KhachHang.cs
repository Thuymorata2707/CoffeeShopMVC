using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theCoffee.Models.MetaData
{
    public class KhachHang
    {
        [DisplayName("Mã khách hàng")]
        public int MaKH { get; set; }
        [DisplayName("Tên khách hàng")]
        [Required(ErrorMessage = "Tên khách hàng không được để trống!")]
        public string TenKH { get; set; }
        [DisplayName("Ảnh đại diện")]
        public string Anh { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email được để trống!")]
        public string Email { get; set; }
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        public string sdt { get; set; }
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        public string DiaChi { get; set; }
    }
}