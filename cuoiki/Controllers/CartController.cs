using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        barbecue db = new barbecue();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult getCart()
        {
            var query = from f in db.Food
                        join tf in db.TypeFood on f.idTypeFood equals tf.idTypeFood
                        join dc in db.DetailCart on f.idFood equals dc.idFood
                        join c in db.Cart on dc.idCart equals c.idCart
                        select new { tfmeta = tf.meta, FoodName = f.name, Price = f.price, TotalPrice = c.tongtien, Quantity = dc.soluong, img = f.img };

            String p = "";
            List<String[]> list = new List<String[]>();
            foreach (var i in query.ToList())
            {
                String[] array = new String[6];
                array[0] = i.tfmeta;
                array[1] = i.FoodName;
                array[2] = i.Price;
                array[3] = Convert.ToString(i.TotalPrice);
                p = array[3];
                array[4] = Convert.ToString(i.Quantity);
                array[5] = Convert.ToString(i.img);
                list.Add(array);
            }
            ViewBag.m = p;
            ViewBag.list = list;
            return PartialView();
        }

    }

}