using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theCoffee.Models.MetaData
{
    public class HoaDon
    {
        [DisplayName("Mã hóa đơn")]
        public int MaHD { get; set; }
        [DisplayName("Mã khách hàng")]
        public Nullable<int> MaKH { get; set; }
        [DisplayName("Ngày mua")]
        [Required(ErrorMessage = "Ngày mua không được để trống!")]
        public Nullable<System.DateTime> NgayMua { get; set; }
        [DisplayName("Tổng tiền")]
        public Nullable<double> TongTien { get; set; }
        [DisplayName("Trạng thái đơn hàng")]
        public Nullable<bool> TrangThai { get; set; }
    }
}