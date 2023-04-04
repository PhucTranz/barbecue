using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cuoiki.Controllers
{
    public class BookTableController : Controller
    {
        // GET: BookTable
        public ActionResult Index()
        {
            ViewBag.page = "dat_ban";
            return View();
        }
    }
}