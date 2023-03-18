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

            var query = from f in db.Food
                         join tf in db.TypeFood on f.idTypeFood equals tf.idTypeFood
                         join dc in db.DetailCart on f.idFood equals dc.idFood
                         join c in db.Cart on dc.idCart equals c.idCart
                         select new { TypeFoodName = tf.name , FoodName = f.name, Price = f.price, TotalPrice =c.tongtien, Quantity= dc.soluong };


            var result = query.ToList();
            

            return View();
        }

        
    }

}