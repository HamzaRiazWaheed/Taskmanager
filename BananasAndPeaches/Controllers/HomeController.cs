﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BananasAndPeaches.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application description";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Apples and Oranges Ltd.";

            return View();
        }
    }
}