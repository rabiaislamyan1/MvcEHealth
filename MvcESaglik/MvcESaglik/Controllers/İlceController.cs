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
    public class İlceController : Controller
    {
        // GET: İlce
        Context c = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            return View(c.İlces.Where(x => x.İlceAd.Contains(p) || p == null).ToList().ToPagedList(sayfa, 6));
        }

        [HttpGet]
        public ActionResult İlceEkle()
        {
            List<SelectListItem> deger1 = (from x in c.İls.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.İlAd,
                                               Value = x.İlID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult İlceEkle(İlce k)
        {
            if (!ModelState.IsValid)
            {
                return View("İlceEkle");
            }

            c.İlces.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult İlceSil(int id)
        {
            var deger = c.İlces.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult İlceGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.İls.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.İlAd,
                                               Value = x.İlID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var dkt = c.İlces.Find(id);
            return View("İlceGetir", dkt);
        }

        public ActionResult İlceGuncelle(İlce d)
        {
            if (!ModelState.IsValid)
            {
                return View("İlceGetir");
            }

            var dk = c.İlces.Find(d.İlceID);
            dk.İlceAd = d.İlceAd;
            dk.İlid = d.İlid;
            dk.Durum = d.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}