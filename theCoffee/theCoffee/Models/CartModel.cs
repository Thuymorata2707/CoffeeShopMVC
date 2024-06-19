using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace theCoffee.Models
{
    public class CartModel
    {
        public int ProductID { get; set; }

        public menu ProductDetail { get; set; }

        public int Quantity { get; set; }

        public float Amount { get; set; }

        public float TongTien { get; set; }
    }
}