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
    public class NCCController : Controller
    {
        theCoffeeEntities db = new theCoffeeEntities();
        // GET: NCC
        public ActionResult Index()
        {
            var lst = db.NCC.ToList();

            return View(lst);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NCC obj)
        {
            try
            {
                db.NCC.Add(obj);
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
            var obj = db.NCC.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(NCC obj)
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
            var sp = db.NCC.Find(id);
            db.NCC.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}