using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace cuoiki
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Menu", "{type}",
                new { controller = "Menu", action = "index", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    {"type", "thuc_don"}
                },
                new[] { "cuoiki.Controllers" });

            routes.MapRoute("MenuAllFood", "{type}/{meta}",
                new { controller = "Menu", action = "getAllFood", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    {"type", "thuc_don"}
                },
                new[] { "cuoiki.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"cuoiki.Controllers"});
        }
    }
}
