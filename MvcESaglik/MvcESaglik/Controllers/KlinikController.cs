using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace MvcESaglik.Controllers
{
    public class KlinikController : Controller
    {
        // GET: Klinik
        Context c = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            return View(c.Kliniks.Where(x => x.KlinikAd.Contains(p) || p == null).ToList().ToPagedList(sayfa, 6));
        }

        [HttpGet]
        public ActionResult KlinikEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KlinikEkle(Klinik k)
        {
            if (!ModelState.IsValid)
            {
                return View("KlinikEkle");
            }

            c.Kliniks.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KlinikSil(int id)
        {
            var deger = c.Kliniks.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KlinikGetir(int id)
        {
            var klnk = c.Kliniks.Find(id);
            return View("KlinikGetir", klnk);
        }

        public ActionResult KlinikGuncelle(Klinik d)
        {
            if (!ModelState.IsValid)
            {
                return View("KlinikGetir");
            }

            var dk = c.Kliniks.Find(d.KlinikID);
            dk.KlinikAd = d.KlinikAd;
            dk.Durum = d.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}