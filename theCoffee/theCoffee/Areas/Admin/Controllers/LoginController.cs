using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace theCoffee.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        Models.theCoffeeEntities db = new Models.theCoffeeEntities();
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.TaiKhoan obj, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Kiểm tra đăng nhập của người dùng
                var crrObj = db.TaiKhoan.FirstOrDefault(m => m.username == obj.username && m.passwords == obj.passwords);
                if (crrObj == null)
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(crrObj.username, false); 
                    if (ReturnUrl == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }

                }
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}