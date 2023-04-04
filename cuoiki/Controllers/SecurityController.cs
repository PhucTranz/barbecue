using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cuoiki.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public SecurityController()
        {
            if(System.Web.HttpContext.Current.Session["User"].Equals("")) {
                System.Web.HttpContext.Current.Response.Redirect("~/Login");
            }
        }
    }
}