using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace theCoffee.Controllers
{
    public class CartController : Controller
    {

        Models.theCoffeeEntities db = new Models.theCoffeeEntities();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddToCart(int ID)
        {
            List<Models.CartModel> listProductInCart;
            if (Session["Cart"] == null)
            {
                listProductInCart = new List<Models.CartModel>();
            }
            else
            {
                listProductInCart = (List<Models.CartModel>)Session["Cart"];
                
            }


            // check
            Models.CartModel checkProduct = listProductInCart.FirstOrDefault(m => m.ProductID == ID);
            if(checkProduct != null)
            {
                checkProduct.Quantity += 1;
                checkProduct.Amount = (float)checkProduct.ProductDetail.GiaBan * checkProduct.Quantity;
                checkProduct.TongTien = (float)listProductInCart.Sum(m => m.Amount);
            }
            else
            {
                Models.menu prod = db.menu.FirstOrDefault(m => m.MaSP == ID);
                Models.CartModel NewCart = new Models.CartModel
                {
                    ProductID = ID,
                    ProductDetail = prod,
                    Quantity = 1,
                    Amount = (float)prod.GiaBan,
                    TongTien = (float)prod.GiaBan,
                };

                listProductInCart.Add(NewCart);
            }
            
            Session["Cart"] = listProductInCart;
            return RedirectToAction("Index");
        }

        public ActionResult DatHang()
        {
            //Kiem tra dang nhap
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "NguoiDung");
            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //Lya gio hang tu sesion

            return RedirectToAction("Index", "Cart");
        }

        private float TongTien()
        {
            float TongTien = 0;
            List<Models.CartModel> listProductInCart = Session["Cart"] as List<Models.CartModel>;
            if(listProductInCart != null )
            {
                TongTien = listProductInCart.Sum(m => m.Amount);
            }

            return TongTien;
        }

        public ActionResult XoaGioHang(int ID)
        {
            List<Models.CartModel> listProductInCart = Session["Cart"] as List<Models.CartModel>;
            if(listProductInCart != null )
            {
                Session["Cart"] = listProductInCart;
            }

            Models.CartModel Product = listProductInCart.SingleOrDefault(m => m.ProductID == ID);
            if(Product != null )
            {
                listProductInCart.RemoveAll(m => m.ProductID == ID);
                return RedirectToAction("Index");
            }
            if(listProductInCart.Count == 0 ) 
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }
    }
}