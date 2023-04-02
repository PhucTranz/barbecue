using cuoiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cuoiki.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: admin/Default
        public ActionResult Index()
        {
            if (!Session["User"].Equals("admin"))
                return RedirectToAction("Index", "Login", new { area = "" });
            return View();
        }
    }
}