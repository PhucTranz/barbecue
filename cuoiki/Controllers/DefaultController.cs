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
            var v = from t in db.About
                    where t.hide == false
                    select t;
            ViewBag.page = "trang_chu";
            return View(v.FirstOrDefault());
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
            ViewBag.sl = v.ToList().Count();
            return PartialView(v.ToList());
        }

        public ActionResult getFooter()
        {
            var footer = from t in db.Footer
                         where t.hide == false
                         select t;
            return PartialView(footer.FirstOrDefault());
        }
    }
}