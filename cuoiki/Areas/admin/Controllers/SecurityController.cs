using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cuoiki.Areas.admin.Controllers
{
    public class SecurityController : Controller
    {
        // GET: admin/Security
        public SecurityController()
        {
            if (!System.Web.HttpContext.Current.Session["User"].Equals("admin"))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Login");
            }
        }
    }
}