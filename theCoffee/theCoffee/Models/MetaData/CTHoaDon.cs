using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theCoffee.Models.MetaData
{
    public class CTHoaDon
    {
        [DisplayName("Mã chi tiết hóa đơn")]
        public int MaCTHD { get; set; }
        [DisplayName("Mã hóa đơn")]
        public Nullable<int> MaHD { get; set; }
        [DisplayName("Mã sản phẩm")]
        public Nullable<int> MaSP { get; set; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Số lượng không được để trống!")]
        public Nullable<long> SoLuong { get; set; }
        [DisplayName("Tiền bán")]
        public Nullable<double> TienBan { get; set; }
    }
}