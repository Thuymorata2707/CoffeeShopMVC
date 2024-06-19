using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace theCoffee.Controllers
{
    public class MenuController : Controller
    {
        Models.theCoffeeEntities db = new Models.theCoffeeEntities();

        // GET: Menu
        public ActionResult Index()
        {
            List<Models.DanhMucSP> listMaDanhMuc = db.DanhMucSP.ToList();
            ViewBag.listMaDanhMuc = listMaDanhMuc;

            List<List<Models.menu>> Category = new List<List<Models.menu>>();
            //string[] nameDanhMuc = new string[listMaDanhMuc.Count]; 
            foreach (Models.DanhMucSP item in listMaDanhMuc)
            {
                List<Models.menu> MenuTheoDanhMuc = db.menu.Where(m => m.MaDanhMuc == item.MaDanhMuc).ToList();
                Category.Add(MenuTheoDanhMuc);
            }

            ViewBag.Category = Category;
            return View();
        }  


        public ActionResult ProductDetail(int Id)
        {

            //Models.menu Product = new Models.menu();

            //Product = db.menu.Where(m => m.MaSP == Id);
            List<Models.menu> Product = db.menu.Where(m => m.MaSP == Id).ToList();
            ViewBag.Product = Product;
            return View();
        }
    }
}