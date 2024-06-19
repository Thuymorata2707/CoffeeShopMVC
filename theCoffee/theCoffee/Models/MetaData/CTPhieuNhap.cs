using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theCoffee.Models.MetaData
{
    public class CTPhieuNhap
    {
        [DisplayName("Mã chi tiết phiếu nhập")]
        public int MaCTPN { get; set; }
        [DisplayName("Mã phiếu nhập")]
        public Nullable<int> MaPN { get; set; }
        [DisplayName("Tên hàng nhập")]
        [Required(ErrorMessage = "Tên hàng nhập không được để trống!")]
        public string TenHang { get; set; }
        [DisplayName("Đơn vị tính")]
        [Required(ErrorMessage = "Đơn vị tính không được để trống!")]
        public string DonViTinh { get; set; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Số lượng không được để trống!")]
        public Nullable<long> SoLuong { get; set; }
        [DisplayName("Giá nhập 1 sản phẩm")]
        [Required(ErrorMessage = "Giá nhập 1 sản phẩm không được để trống!")]
        public Nullable<double> Gia { get; set; }
        [DisplayName("Tổng giá nhập")]
        public Nullable<double> TongGia { get; set; }
    }
}