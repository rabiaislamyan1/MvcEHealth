using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;

namespace MvcESaglik.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Brans.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.İls.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.İlces.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Kliniks.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Kurums.Count().ToString();
            ViewBag.d5 = deger5;

            var yapilacaklar = c.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
    }
}