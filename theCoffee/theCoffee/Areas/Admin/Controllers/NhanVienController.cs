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
    public class NhanVienController : Controller
    {
        theCoffeeEntities db = new theCoffeeEntities();
        // GET: NhanVien
        public ActionResult Index()
        {
            var lst = db.NhanVien.ToList();

            return View(lst);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NhanVien obj)
        {
            try
            {
                var f = Request.Files["favatar"];
                if (f != null && f.ContentLength > 0)
                {
                    string fName = f.FileName;
                    string folder = Server.MapPath("/Assets/Upload/NhanVien") + fName;
                    f.SaveAs(folder);
                    obj.Avt = "/Assets/Upload/NhanVien" + fName;
                }
                db.NhanVien.Add(obj);
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
            var obj = db.NhanVien.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(NhanVien obj)
        {

            try
            {
                var f = Request.Files["favatar"];
                if (f != null && f.ContentLength > 0)
                {
                    string fName = f.FileName;
                    string folder = Server.MapPath("/Assets/Upload/NhanVien") + fName;
                    f.SaveAs(folder);
                    obj.Avt = "/Assets/Upload/NhanVien" + fName;
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
            var sp = db.NhanVien.Find(id);
            db.NhanVien.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}