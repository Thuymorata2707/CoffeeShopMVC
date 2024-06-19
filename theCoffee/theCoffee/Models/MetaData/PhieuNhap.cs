using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace theCoffee.Models.MetaData
{
    public class PhieuNhap
    {
        [DisplayName("Mã phiếu nhập")]
        public int MaPN { get; set; }
        [DisplayName("Nhà cung cấp")]
        public Nullable<int> MaNCC { get; set; }
        [DisplayName("Nhân viên")]
        public Nullable<int> MaNV { get; set; }
        [DisplayName("Ngày nhập")]
        public Nullable<System.DateTime> NgayNhap { get; set; }
        [DisplayName("Tổng tiền nhập")]
        public Nullable<double> TongTienNhap { get; set; }
    }
}