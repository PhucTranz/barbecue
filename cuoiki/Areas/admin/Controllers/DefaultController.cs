﻿using cuoiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cuoiki.Areas.admin.Controllers
{
    public class DefaultController : SecurityController
    {
        // GET: admin/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}