using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;

namespace MvcESaglik.Controllers
{
    public class RandevuController : Controller
    {
        // GET: Randevu
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Randevus.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult RandevuOlustur()
        {
            List<SelectListItem> deger1 = (from x in c.DoktorProfils.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DoktorAd+ " " + x.DoktorSoyad,
                                               Value = x.DoktorID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.İls.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.İlAd,
                                               Value = x.İlID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in c.İlces.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.İlceAd,
                                               Value = x.İlceID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            List<SelectListItem> deger4 = (from x in c.Kliniks.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KlinikAd,
                                               Value = x.KlinikID.ToString()
                                           }).ToList();
            ViewBag.dgr4 = deger4;

            List<SelectListItem> deger5 = (from x in c.Kurums.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KurumAd,
                                               Value = x.KurumID.ToString()
                                           }).ToList();
            ViewBag.dgr5 = deger5;

            List<SelectListItem> deger6 = (from x in c.KullaniciProfils.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KullaniciAd +" " + x.KullaniciSoyad,
                                               Value = x.TcNo.ToString()
                                           }).ToList();
            ViewBag.dgr6 = deger6;

            return View();
        }

        [HttpPost]
        public ActionResult RandevuOlustur(Randevu k)
        {
            if (!ModelState.IsValid)
            {
                return View("RandevuOlustur");
            }

            c.Randevus.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RandevuSil(int id)
        {
            var deger = c.Randevus.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RandevuGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.DoktorProfils.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DoktorAd+" "+x.DoktorSoyad,
                                               Value = x.DoktorID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.İls.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.İlAd,
                                               Value = x.İlID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in c.İlces.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.İlceAd,
                                               Value = x.İlceID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            List<SelectListItem> deger4 = (from x in c.Kliniks.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KlinikAd,
                                               Value = x.KlinikID.ToString()
                                           }).ToList();
            ViewBag.dgr4 = deger4;

            List<SelectListItem> deger5 = (from x in c.Kurums.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KurumAd,
                                               Value = x.KurumID.ToString()
                                           }).ToList();
            ViewBag.dgr5 = deger5;

            List<SelectListItem> deger6 = (from x in c.KullaniciProfils.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KullaniciAd +" " + x.KullaniciSoyad,
                                               Value = x.TcNo.ToString()
                                           }).ToList();
            ViewBag.dgr6 = deger6;

            var dkt = c.Randevus.Find(id);
            return View("RandevuGetir", dkt);
        }

        public ActionResult RandevuGuncelle(Randevu d)
        {
            if (!ModelState.IsValid)
            {
                return View("RandevuGetir");
            }

            var dk = c.Randevus.Find(d.RandevuNo);
            dk.Tarih = d.Tarih;
            dk.Doktorid = d.Doktorid;
            dk.İlid = d.İlid;
            dk.İlceid = d.İlceid;
            dk.Klinikid = d.Klinikid;
            dk.Kurumid = d.Kurumid;
            dk.KullaniciProfilTcNo = d.KullaniciProfilTcNo;
            dk.Durum = d.Durum;
            dk.Saat = d.Saat;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RandevuDetay(int id)
        {
            var degerler = c.Randevus.Where(x => x.RandevuNo == id).ToList();

            var krm = c.Kurums.Where(x => x.KurumID == id).Select(y => y.KurumAd).FirstOrDefault();
            ViewBag.kurum = krm;

            return View(degerler);
        }
    }
}