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
        public class HoaDonController : Controller
        {
            theCoffeeEntities db = new theCoffeeEntities();
            // GET: Admin/HoaDon
            public ActionResult Index()
            {
                var lst = db.HoaDon.ToList();
                return View(lst);
            }

            [HttpGet]
            public ActionResult Create()
            {
                var KH = db.KhachHang.ToList();
                ViewBag.MaKH = new SelectList(KH, "MaKH", "TenKH");
                return View();
            }

            [HttpPost]
            public ActionResult Create(HoaDon obj)
            {
                try
                {
                    db.HoaDon.Add(obj);
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
                var obj = db.HoaDon.Find(id);
                var KH = db.KhachHang.ToList();
                ViewBag.MaKH = new SelectList(KH, "MaKH", "TenKH", obj.MaKH);
                return View(obj);
            }
            [HttpPost]
            public ActionResult Edit(HoaDon obj)
            {

                try
                {
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
                var obj = db.HoaDon.Find(id);
                db.HoaDon.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }