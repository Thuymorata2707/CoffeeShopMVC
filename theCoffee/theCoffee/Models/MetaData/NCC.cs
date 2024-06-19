using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theCoffee.Models.MetaData
{
    public class NCC
    {
        [DisplayName("Mã nhà cung cấp")]

        public int MaNCC { get; set; }
        [DisplayName("Tên nhà cung cấp")]
        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống!")]
        public string TenNCC { get; set; }
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        public string sdt { get; set; }
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        public string DiaChi { get; set; }
    }
}