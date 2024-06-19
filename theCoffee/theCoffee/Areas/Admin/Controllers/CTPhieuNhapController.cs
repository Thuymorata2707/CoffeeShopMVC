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
    public class CTPhieuNhapController : Controller
    {
        theCoffeeEntities db = new theCoffeeEntities();
        // GET: Admin/CTPhieuNhap
        public ActionResult Index()
        {
            var lst = db.CTPhieuNhap.ToList();
            return View(lst);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var PN = db.PhieuNhap.ToList();
            ViewBag.MaPN = new SelectList(PN, "MaPN", "MaPN");
            return View();
        }

        [HttpPost]
        public ActionResult Create(CTPhieuNhap obj)
        {
            try
            {
                db.CTPhieuNhap.Add(obj);
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
            var obj = db.CTPhieuNhap.Find(id);
            var PN = db.PhieuNhap.ToList();
            ViewBag.MaPN = new SelectList(PN, "MaPN", "MaPN", obj.MaPN);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(CTPhieuNhap obj)
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
            var obj = db.CTPhieuNhap.Find(id);
            db.CTPhieuNhap.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}