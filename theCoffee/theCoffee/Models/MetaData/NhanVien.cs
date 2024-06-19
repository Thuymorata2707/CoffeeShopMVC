using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theCoffee.Models.MetaData
{
    public class NhanVien
    {
        [DisplayName("Mã nhân viên")]
        public int MaNV { get; set; }
        [DisplayName("Tên nhân viên")]
        [Required(ErrorMessage = "Tên nhân viên không được để trống!")]
        public string TenNV { get; set; }
        [DisplayName("Hình ảnh")]
        public string Avt { get; set; }
        [DisplayName("Ngày sinh")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        public string sdt { get; set; }
        [DisplayName("Mail")]
        public string Mail { get; set; }
        [DisplayName("Số lương")]
        public Nullable<double> Luong { get; set; }
        [DisplayName("Chức vụ")]
        public string ChucVu { get; set; }
    }
}