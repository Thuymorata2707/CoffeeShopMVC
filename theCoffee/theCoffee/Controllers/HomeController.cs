using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace theCoffee.Controllers
{
    public class HomeController : Controller
    {
        Models.theCoffeeEntities db = new Models.theCoffeeEntities();
        // GET: Home
        public ActionResult Index()
        {
            List<Models.menu> listHotItem = db.menu.Take(4).ToList();
            ViewBag.listHotItem = listHotItem;

            return View();
        }
    }
}