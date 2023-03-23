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
            return View();
        }

        public ActionResult ManagementMenuBar()
        {
            barbecue db = new barbecue();
            var query = from t in db.MenuBar
                    where t.hide == false
                    orderby t.order ascending
                    select t;
            String p = "";
            List<String[]> list = new List<String[]>();
            foreach (var i in query.ToList())
            {
                String[] array = new String[7];
                array[0] = Convert.ToString(i.idMenuBar);
                array[1] = i.name;
                array[2] = i.link;
                array[3] = i.meta;
                array[4] = Convert.ToString(i.hide);
                array[5] = Convert.ToString(i.order);
                array[6] = Convert.ToString(i.datebegin);
               
                list.Add(array);
            }
            ViewBag.m = p;
            ViewBag.list = list;
            return PartialView();
        }
        public ActionResult ManagementSlidesShow()
        {
            barbecue db = new barbecue();
            var query = from t in db.SlidesShow
                    where t.hide == false
                    orderby t.order ascending
                    select t;
            String p = "";
            List<String[]> list = new List<String[]>();
            foreach (var i in query.ToList())
            {
                String[] array = new String[8];
                array[0] = Convert.ToString(i.idSlidesShow);
                array[1] = i.title;
                array[2] = i.description;
                array[3] = i.link;
                array[4] = i.meta;
                array[5] = Convert.ToString(i.hide);
                array[6] = Convert.ToString(i.order);
                array[7] = Convert.ToString(i.datebegin);

                list.Add(array);
            }
            ViewBag.m = p;
            ViewBag.list = list;
            return PartialView();
        }
    }
}