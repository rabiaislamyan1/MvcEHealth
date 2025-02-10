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
    public class İlController : Controller
    {
        // GET: İl
        Context c = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            return View(c.İls.Where(x => x.İlAd.Contains(p) || p == null).ToList().ToPagedList(sayfa, 6));
        }

        [HttpGet]
        public ActionResult İlEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult İlEkle(İl b)
        {
            if (!ModelState.IsValid)
            {
                return View("İlEkle");
            }

            c.İls.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult İlSil(int id)
        {
            var deger = c.İls.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult İlGetir(int id)
        {
            var il = c.İls.Find(id);
            return View("İlGetir", il);
        }

        public ActionResult İlGuncelle(İl b)
        {
            if (!ModelState.IsValid)
            {
                return View("İlGetir");
            }

            var il = c.İls.Find(b.İlID);
            il.İlAd = b.İlAd;
            il.Durum = b.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}