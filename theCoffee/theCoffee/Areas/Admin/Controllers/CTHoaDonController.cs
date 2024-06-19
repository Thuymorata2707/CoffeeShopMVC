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
    public class CTHoaDonController : Controller
    {
        theCoffeeEntities db = new theCoffeeEntities();
        // GET: Admin/CTHoaDon
        public ActionResult Index()
        {
            var lst = db.CTHoaDon.ToList();
            return View(lst);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var HD = db.HoaDon.ToList();
            ViewBag.MaHD = new SelectList(HD, "MaHD", "MaHD");

            var SP = db.menu.ToList();
            ViewBag.MaSP = new SelectList(SP, "MaSP", "TenSP");
            return View();
        }

        [HttpPost]
        public ActionResult Create(CTHoaDon obj)
        {
            try
            {
                db.CTHoaDon.Add(obj);
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
            var obj = db.CTHoaDon.Find(id);

            var HD = db.HoaDon.ToList();
            ViewBag.MaHD = new SelectList(HD, "MaHD", "MaHD", obj.MaHD);

            var SP = db.menu.ToList();
            ViewBag.MaSP = new SelectList(SP, "MaSP", "TenSP", obj.MaSP);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(CTHoaDon obj)
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
            var obj = db.CTHoaDon.Find(id);
            db.CTHoaDon.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}