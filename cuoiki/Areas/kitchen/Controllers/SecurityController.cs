using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cuoiki.Areas.kitchen.Controllers
{
    public class SecurityController : Controller
    {
        // GET: kitchen/Security
        public SecurityController()
        {
            if (!System.Web.HttpContext.Current.Session["User"].Equals("kitchen"))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Login");
            }
        }
    }
}