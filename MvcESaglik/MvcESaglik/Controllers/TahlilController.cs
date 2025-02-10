using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;

namespace MvcESaglik.Controllers
{
    public class TahlilController : Controller
    {
        // GET: Tahlil
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Tahlils.ToList();
            return View(degerler);
        }

        Context a = new Context();
        public ActionResult Index2()
        {
            var degerler = a.Tahlils.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult TahlilEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kurums.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KurumAd,
                                               Value = x.KurumID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.KullaniciProfils.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KullaniciAd + " " + x.KullaniciSoyad,
                                               Value = x.TcNo.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }

        [HttpPost]
        public ActionResult TahlilEkle(Tahlil p)
        {
            c.Tahlils.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        Context x = new Context();
        public ActionResult Index3()
        {
            var degerler = x.Tahlils.ToList();
            return View(degerler);
        }
    }
}