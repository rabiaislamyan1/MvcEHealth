using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;

namespace MvcESaglik.Controllers
{
    public class HastalikController : Controller
    {
        // GET: Hastalik
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Hastaliks.ToList();
            return View(degerler);
        }

        public ActionResult HastaDetay(int id)
        {
            var degerler = c.Hastaliks.Where(x => x.HastalikID == id).ToList();

            var hst = c.Hastaliks.Where(x => x.HastalikID == id).Select(y => y.KullaniciProfil.KullaniciAd + " " + y.KullaniciProfil.KullaniciSoyad).FirstOrDefault();
            ViewBag.hasta = hst;

            return View(degerler);
        }

        Context a = new Context();
        public ActionResult Index2()
        {
            var degerler = a.Hastaliks.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult HastalikEkle()
        {
            List<SelectListItem> deger1 = (from x in c.DoktorProfils.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DoktorAd + " " + x.DoktorSoyad,
                                               Value = x.DoktorID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.Kliniks.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KlinikAd,
                                               Value = x.KlinikID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in c.KullaniciProfils.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KullaniciAd + " " + x.KullaniciSoyad,
                                               Value = x.TcNo.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            return View();
        }

        [HttpPost]
        public ActionResult HastalikEkle(Hastalik p)
        {
            c.Hastaliks.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HastalikSil(int id)
        {
            var hst = c.Hastaliks.Find(id);
            c.Hastaliks.Remove(hst);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        Context x = new Context();
        public ActionResult Index3()
        {
            var degerler = x.Hastaliks.ToList();
            return View(degerler);
        }
    }
}