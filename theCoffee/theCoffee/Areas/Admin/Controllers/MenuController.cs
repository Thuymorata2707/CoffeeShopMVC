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
    public class MenuController : Controller
    {
        theCoffeeEntities db = new theCoffeeEntities();
        // GET: SanPham
        public ActionResult Index(string searchString)
        {
            ViewBag.Keyword = searchString;
            var sp = db.menu.Include(b => b.DanhMucSP);
            if (!String.IsNullOrEmpty(searchString))
                sp = sp.Where(b => b.TenSP.ToLower().Contains(searchString));

            return View(sp.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var lst = db.DanhMucSP.ToList();
            ViewBag.MaDanhMuc = new SelectList(lst, "MaDanhMuc", "TenDanhMuc");
            return View();
        }

        [HttpPost]
        public ActionResult Create(menu obj)
        {
            try
            {
                var f = Request.Files["favatar"];
                if (f != null && f.ContentLength > 0)
                {
                    string fName = f.FileName;
                    string folder = Server.MapPath("/Assets/Upload/SanPham/") + fName;
                    f.SaveAs(folder);
                    obj.HinhAnh = "/Assets/Upload/SanPham/" + fName;
                }
                db.menu.Add(obj);
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
            var obj = db.menu.Find(id);
            var lst = db.DanhMucSP.ToList();
            ViewBag.MaDanhMuc = new SelectList(lst, "MaDanhMuc", "TenDanhMuc", obj.MaDanhMuc);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(menu obj)
        {
            try
            {
                var f = Request.Files["favatar"];
                if (f != null && f.ContentLength > 0)
                {
                    string fName = f.FileName;
                    string folder = Server.MapPath("/Assets/Upload/SanPham/") + fName;
                    f.SaveAs(folder);
                    obj.HinhAnh = "/Assets/Upload/SanPham/" + fName;
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
            var obj = db.menu.Find(id);
            db.menu.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}