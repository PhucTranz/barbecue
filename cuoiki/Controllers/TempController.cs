using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Controllers
{
    public class TempController : Controller
    {
        // GET: Temp
        Model2 db = new Model2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getMenu()
        {
            var v = from t in db.MenuBar
                where t.hide==false
                orderby t.order ascending
                select t;
            return PartialView(v.ToList());
        }
    }
}