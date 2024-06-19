using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theCoffee.Models;

namespace theCoffee.Controllers
{
    public class NguoiDungController : Controller
    {
        theCoffeeEntities db = new theCoffeeEntities();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangNhap(FormCollection collection)
        {
            //gán các giá trị người dùng nhập cho các biến
            var tenDN = collection["TenDN"];
            var matKhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(tenDN))
            {
                ViewData["Loi1"] = "Tên đăng nhập không được để trống";
            }
            else if (String.IsNullOrEmpty(matKhau))
            {
                ViewData["Loi2"] = "Mật khẩu không được để trống";
            }
            else
            {
                //gán giá trị cho đối tượng được tạo mới
                KhachHang kh = db.KhachHang.SingleOrDefault(m => m.TaiKhoan == tenDN && m.MatKhau == matKhau);
                if(kh != null)
                {
                    Session["TaiKhoan"] = kh;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ThongBao = "Đăng nhập thất bại";
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult DangKi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKi(FormCollection collection, KhachHang kh)
        {
            //gắn các giá trị người dùng nhập liệu
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var matkhaunhaplai = collection["MatKhauNhapLai"];
            var diachi = collection["DiaChi"];
            var email = collection["Email"];
            var sdt = collection["SDT"];

            if(String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống";
            }
            else if(String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được để trống";
            }
            else if(String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật khẩu không được để trống";
            }
            else if(String.IsNullOrEmpty (matkhaunhaplai))
            {
                ViewData["Loi4"] = "Hãy nhập lại mật khẩu";
            }
            else if(String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email không được để trống";
            }
            else if(String.IsNullOrEmpty(sdt))
            {
                ViewData["Loi7"] = "Số điện thoại không để trống";
            }
            else
            {
                //gán các giá trị cho đối tượng kh
                kh.TenKH = hoten;
                kh.Email = email;
                kh.sdt = sdt;
                kh.DiaChi = diachi;
                kh.TaiKhoan = tendn;
                kh.MatKhau = matkhau;

                db.KhachHang.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKi();
        }
    }
}