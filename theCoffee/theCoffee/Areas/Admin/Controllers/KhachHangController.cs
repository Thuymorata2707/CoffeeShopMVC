using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theCoffee.Models;

namespace theCoffee.Areas.Admin.Controllers
{
    [Authorize]
    public class KhachHangController : Controller
    {
        theCoffeeEntities db = new theCoffeeEntities();
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            var lst = db.KhachHang.ToList();
            return View(lst);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KhachHang obj)
        {
            try
            {
                var f = Request.Files["favatar"];
                if (f != null && f.ContentLength > 0)
                {
                    string fName = f.FileName;
                    string folder = Server.MapPath("/Assets/Upload/KhachHang") + fName;
                    f.SaveAs(folder);
                    obj.Anh = "/Assets/Upload/KhachHang" + fName;
                }
                db.KhachHang.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(obj);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var obj = db.KhachHang.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang obj)
        {
            try
            {
                var f = Request.Files["favatar"];
                if (f != null && f.ContentLength > 0)
                {
                    string fName = f.FileName;
                    string folder = Server.MapPath("/Assets/Upload/KhachHang") + fName;
                    f.SaveAs(folder);
                    obj.Anh = "/Assets/Upload/KhachHang" + fName;
                }
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(obj);
            }
        }

        public ActionResult Delete(int id)
        {
            var sp = db.KhachHang.Find(id);
            db.KhachHang.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}