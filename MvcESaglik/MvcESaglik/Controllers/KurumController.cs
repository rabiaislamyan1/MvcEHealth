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
    public class KurumController : Controller
    {
        // GET: Kurum
        Context c = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            return View(c.Kurums.Where(x => x.KurumAd.Contains(p) || p == null).ToList().ToPagedList(sayfa, 6));
        }

        [HttpGet]
        public ActionResult KurumEkle()
        {
            List<SelectListItem> deger1 = (from x in c.İlces.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.İlceAd,
                                               Value = x.İlceID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.İls.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.İlAd,
                                               Value = x.İlID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }

        [HttpPost]
        public ActionResult KurumEkle(Kurum k)
        {
            if (!ModelState.IsValid)
            {
                return View("KurumEkle");
            }

            c.Kurums.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KurumSil(int id)
        {
            var deger = c.Kurums.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KurumGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.İlces.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.İlceAd,
                                               Value = x.İlceID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.İls.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.İlAd,
                                               Value = x.İlID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            var kr = c.Kurums.Find(id);
            return View("KurumGetir", kr);
        }

        public ActionResult KurumGuncelle(Kurum d)
        {
            if (!ModelState.IsValid)
            {
                return View("KurumGetir");
            }

            var dk = c.Kurums.Find(d.KurumID);
            dk.KurumAd = d.KurumAd;
            dk.İlceid = d.İlceid;
            dk.İlid = d.İlid;
            dk.Durum = d.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}