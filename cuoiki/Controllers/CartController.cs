using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cuoiki.Models;

namespace cuoiki.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        barbecue db = new barbecue();
        public ActionResult Index()
        {
            return View();
        }
    }
}