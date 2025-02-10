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
    public class AsiController : Controller
    {
        // GET: Asi
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Asis.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        Context a = new Context();
        public ActionResult Index2()
        {
            var degerler = c.Asis.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AsiEkle()
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
        public ActionResult AsiEkle(Asi p)
        {
            a.Asis.Add(p);
            a.SaveChanges();
            return RedirectToAction("Index");
        }

        Context x = new Context();
        public ActionResult Index3(int sayfa = 1)
        {
            var degerler = x.Asis.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
    }
}