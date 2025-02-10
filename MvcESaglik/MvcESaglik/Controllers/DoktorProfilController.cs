using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;
using System.IO;

namespace MvcESaglik.Controllers
{
    public class DoktorProfilController : Controller
    {
        // GET: DoktorProfil
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.DoktorProfils.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DoktorEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Brans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BransAd,
                                               Value = x.BransID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.Kurums.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KurumAd,
                                               Value = x.KurumID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }

        [HttpPost]
        public ActionResult DoktorEkle(DoktorProfil k)
        {
            if (!ModelState.IsValid)
            {
                return View("DoktorEkle");
            }

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                k.DoktorGorsel = "/image/" + dosyaadi + uzanti;
            }

            c.DoktorProfils.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DoktorSil(int id)
        {
            var deger = c.DoktorProfils.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DoktorGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Brans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BransAd,
                                               Value = x.BransID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.Kurums.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KurumAd,
                                               Value = x.KurumID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            var dkt = c.DoktorProfils.Find(id);
            return View("DoktorGetir", dkt);
        }

        public ActionResult DoktorGuncelle(DoktorProfil d)
        {
            if (!ModelState.IsValid)
            {
                return View("DoktorGetir");
            }

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                d.DoktorGorsel = "/image/" + dosyaadi + uzanti;
            }

            var dk = c.DoktorProfils.Find(d.DoktorID);
            dk.DoktorAd = d.DoktorAd;
            dk.DoktorSoyad = d.DoktorSoyad;
            dk.DoktorGorsel = d.DoktorGorsel;
            dk.Yas = d.Yas;
            dk.Cinsiyet = d.Cinsiyet;
            dk.DoktorMail = d.DoktorMail;
            dk.TelNo = d.TelNo;
            dk.Bransid = d.Bransid;
            dk.Kurumid = d.Kurumid;
            dk.Durum = d.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DoktorDetay(int id)
        {
            var degerler = c.DoktorProfils.Where(x => x.DoktorID == id).ToList();
            return View(degerler);
        }

        public ActionResult DoktorHastaBakis (int id)
        {
            var degerler = c.Randevus.Where(x => x.RandevuNo == id).ToList();

            var kul = c.DoktorProfils.Where(x => x.DoktorID == id).Select(y => y.DoktorAd + " " + y.DoktorSoyad).FirstOrDefault();
            ViewBag.hbak = kul;

            return View(degerler);
        }

        public ActionResult DoktorListe()
        {
            var sorgu = c.DoktorProfils.ToList();
            return View(sorgu);
        }

        public ActionResult DoktorListe2()
        {
            var sorgu = c.DoktorProfils.ToList();
            return View(sorgu);
        }

        public ActionResult DoktorYorum(int id)
        {
            var degerler = c.Yorums.Where(x => x.YorumID == id).ToList();

            var kul = c.DoktorProfils.Where(x => x.DoktorID == id).Select(y => y.DoktorAd + " " + y.DoktorSoyad).FirstOrDefault();
            ViewBag.hbak = kul;

            return View(degerler);
        }

        public ActionResult DoktorYorum2(int id)
        {
            var degerler = c.Yorums.Where(x => x.YorumID == id).ToList();

            var kul = c.DoktorProfils.Where(x => x.DoktorID == id).Select(y => y.DoktorAd + " " + y.DoktorSoyad).FirstOrDefault();
            ViewBag.hbak = kul;

            return View(degerler);
        }

        [HttpGet]
        public ActionResult DoktorYorumYap()
        {
            List<SelectListItem> deger1 = (from x in c.DoktorProfils.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DoktorAd + " " + x.DoktorSoyad,
                                               Value = x.DoktorID.ToString()
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
        public ActionResult DoktorYorumYap(Yorum k)
        {
            c.Yorums.Add(k);
            c.SaveChanges();
            return RedirectToAction("DoktorListe2");
        }
    }
}