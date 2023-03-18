using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        barbecue db = new barbecue();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getTypeFood()
        {
            var v = from t in db.TypeFood
                    where t.hide == false
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getFood(int idTF, string metaTF)
        {
            var v = (from f in db.Food
                    join tf in db.TypeFood on f.idTypeFood equals tf.idTypeFood
                    where tf.meta == metaTF & f.hide == false
                    select f).Take(3);
            ViewBag.meta = metaTF;
            return PartialView(v.ToList());
        }

        public ActionResult getAllFood(string meta)
        {
            var tf = (from t in db.TypeFood
                      where t.meta == meta
                      select t).Take(1);

            var typeFood = tf.FirstOrDefault();

            var f = from t in db.Food
                    where t.idTypeFood == typeFood.idTypeFood
                    select t;

            ViewBag.tfName = typeFood.name;
            ViewBag.meta = typeFood.meta;

            return View(f.ToList());
        }
    }
}