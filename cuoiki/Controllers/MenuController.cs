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
            //Loc lam di
            return null;
        }
    }
}