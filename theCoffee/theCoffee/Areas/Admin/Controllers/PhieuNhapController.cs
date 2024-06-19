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
    public class PhieuNhapController : Controller
    {
        theCoffeeEntities db = new theCoffeeEntities();
        // GET: Admin/PhieuNhap
        public ActionResult Index()
        {
            var lst = db.PhieuNhap.ToList();
            return View(lst);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var NCC = db.NCC.ToList();
            ViewBag.MaNCC = new SelectList(NCC, "MaNCC", "TenNCC");

            var NV = db.NhanVien.ToList();
            ViewBag.MaNV = new SelectList(NV, "MaNV", "TenNV");
            return View();
        }

        [HttpPost]
        public ActionResult Create(PhieuNhap obj)
        {
            try
            {
                db.PhieuNhap.Add(obj);
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
            var obj = db.PhieuNhap.Find(id);
            var NCC = db.NCC.ToList();
            ViewBag.MaNCC = new SelectList(NCC, "MaNCC", "TenNCC", obj.MaNCC);

            var NV = db.NhanVien.ToList();
            ViewBag.MaNV = new SelectList(NV, "MaNV", "TenNV", obj.MaNV);
 
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(PhieuNhap obj)
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
            var obj = db.PhieuNhap.Find(id);
            db.PhieuNhap.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}