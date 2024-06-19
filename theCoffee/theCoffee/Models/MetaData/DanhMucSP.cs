using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theCoffee.Models.MetaData
{
    public class DanhMucSP
    {
        [DisplayName("Mã danh mục sản phẩm")]
        public int MaDanhMuc { get; set; }
        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục sản phẩm không được để trống!")]
        public string TenDanhMuc { get; set; }
    }
}