using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Controllers
{
    public class DefaultController : SecurityController
    {
        // GET: Default
        barbecue db = new barbecue();
        public ActionResult Index()
        {
            ViewBag.page = "trang_chu";
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