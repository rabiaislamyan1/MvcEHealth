using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;

namespace MvcESaglik.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.İls.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.İlces.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Kliniks.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Kurums.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Brans.Count().ToString();
            ViewBag.d5 = deger5;

            var deger6 = c.DoktorProfils.Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = c.KullaniciProfils.Count().ToString();
            ViewBag.d7 = deger7;

            return View();
        }

        public ActionResult KolayTablolar()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.DoktorProfils
                         group x by x.Kurum.KurumAd into g
                         select new SinifGrup2
                         {
                             Kurum = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial3()
        {
            var sorgu = c.DoktorProfils.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.DoktorProfils
                        group x by x.Brans.BransAd into g
                        select new SinifGrup3
                        {
                            brans = g.Key,
                            sayi = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }

        public ActionResult KolayTablolar2()
        {
            return View();
        }
    }
}