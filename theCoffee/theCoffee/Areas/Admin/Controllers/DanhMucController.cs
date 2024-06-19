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
    public class DanhMucController : Controller
    {
        Models.theCoffeeEntities db = new Models.theCoffeeEntities();
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            var lst = db.DanhMucSP.ToList();
            return View(lst);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DanhMucSP obj)
        {
            try
            {
                db.DanhMucSP.Add(obj);
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
            var obj = db.DanhMucSP.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(DanhMucSP obj)
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
            var obj = db.DanhMucSP.Find(id);
            db.DanhMucSP.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}