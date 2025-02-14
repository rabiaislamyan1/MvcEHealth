﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcESaglik.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AnaSayfa()
        {
            return View();
        }

        public ActionResult Hakkımızda()
        {
            return View();
        }

        public ActionResult Hizmet()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }
    }
}