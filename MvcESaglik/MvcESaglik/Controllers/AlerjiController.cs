using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;

namespace MvcESaglik.Controllers
{
    public class AlerjiController : Controller
    {
        // GET: Alerji
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var degerler = c.Alerjis.ToList();
            return View(degerler);
        }

        Context a = new Context();
        public ActionResult Index2()
        {
            var degerler = a.Alerjis.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AlerjiEkle()
        {
            List<SelectListItem> deger1 = (from x in c.KullaniciProfils.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KullaniciAd +" " + x.KullaniciSoyad,
                                               Value = x.TcNo.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }

        [HttpPost]
        public ActionResult AlerjiEkle(Alerji p)
        {
            c.Alerjis.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult AlerjiSil(int id)
        {
            var alrj = c.Alerjis.Find(id);
            c.Alerjis.Remove(alrj);
            c.SaveChanges();
            return RedirectToAction("Index2");
        }

        Context x = new Context();
        public ActionResult Index3()
        {
            var degerler = c.Alerjis.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AlerjiEkle2()
        {
            List<SelectListItem> deger1 = (from x in c.KullaniciProfils.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KullaniciAd + " " + x.KullaniciSoyad,
                                               Value = x.TcNo.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }

        [HttpPost]
        public ActionResult AlerjiEkle2(Alerji p)
        {
            c.Alerjis.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index3");
        }

        public ActionResult AlerjiSil2(int id)
        {
            var alrj = c.Alerjis.Find(id);
            c.Alerjis.Remove(alrj);
            c.SaveChanges();
            return RedirectToAction("Index3");
        }
    }
}