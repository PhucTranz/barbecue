using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        barbecue db = new barbecue();
        public ActionResult Index()
        {
            if (Session["User"].Equals(""))
                return RedirectToAction("Index","Login");
            return View();
        }

        public ActionResult getMenu()
        {
            var v = from t in db.MenuBar
                    where t.hide == false
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }


        public ActionResult getSlideShow()
        {
            var v = from t in db.SlidesShow
                    where t.hide == false
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}