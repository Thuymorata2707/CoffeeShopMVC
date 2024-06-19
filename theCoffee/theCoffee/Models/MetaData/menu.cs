using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theCoffee.Models.MetaData
{
    public class menu
    {
        [DisplayName("Mã sản phẩm")]
        public int MaSP { get; set; }
        [DisplayName("Mã danh mục sản phẩm")]
        [Required(ErrorMessage = "Mã danh mục không được để trống!")]
        public Nullable<int> MaDanhMuc { get; set; }
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống!")]
        public string TenSP { get; set; }
        [DisplayName("Hình ảnh sản phẩm")]
        public string HinhAnh { get; set; }
        [DisplayName("Giá bán")]
        [Required(ErrorMessage = "Giá bán không được để trống!")]
        public Nullable<double> GiaBan { get; set; }
        [DisplayName("Mô tả sản phẩm")]
        public string MoTa { get; set; }
    }
}