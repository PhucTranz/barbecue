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
        public ActionResult getFood()
        {
            var v = from f in db.Food
                    join tf in db.TypeFood on f.idTypeFood equals tf.idTypeFood
                    select new
                    {
                        idfood = f.idFood,
                        fName = f.name,
                        tfName = tf.name,
                        des = f.description,
                        img = f.img,
                        fPrice = f.price
                    };
            
            List<String[]> list = new List<String[]>();   
            foreach (var i in v.ToList())
            {
                String[] array = new String[6];
                array[0] = Convert.ToString(i.idfood);
                array[1] = i.fName;
                array[2] = i.tfName;
                array[3] = i.des;
                array[4] = i.img;
                array[5] = i.fPrice;
                list.Add(array);
            }
            ViewBag.Food = list;
            return PartialView();
        }
    }
}