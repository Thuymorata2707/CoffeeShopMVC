using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace theCoffee.Models.MetaData
{
    public class TaiKhoanMetaData
    {
        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được để trống!")]
        public string username { get; set; }
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [MinLength(3, ErrorMessage = "Mật khẩu trên 3 kí tự")]
        public string passwords { get; set; }
    }
}