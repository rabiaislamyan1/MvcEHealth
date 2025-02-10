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
    public class BransController : Controller
    {
        // GET: Brans
        Context c = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            return View(c.Brans.Where(x => x.BransAd.Contains(p) || p == null).ToList().ToPagedList(sayfa, 6));
        }

        [HttpGet]
        public ActionResult BransEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BransEkle(Brans b)
        {
            if (!ModelState.IsValid)
            {
                return View("BransEkle");
            }

            c.Brans.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BransSil(int id)
        {
            var brns = c.Brans.Find(id);
            c.Brans.Remove(brns);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BransGetir(int id)
        {
            var brans = c.Brans.Find(id);
            return View("BransGetir", brans);
        }

        public ActionResult BransGuncelle(Brans b)
        {
            if (!ModelState.IsValid)
            {
                return View("BransGetir");
            }

            var brns = c.Brans.Find(b.BransID);
            brns.BransAd = b.BransAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}