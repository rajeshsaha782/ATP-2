﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace easylife.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Profit_graph()
        {
            return View();
        }

    }
}
