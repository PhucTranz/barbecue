using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cuoiki.Areas.kitchen.Controllers
{
    public class DefaultController : Controller
    {
        // GET: kitchen/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}