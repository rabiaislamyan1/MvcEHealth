using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;
using System.IO;

namespace MvcESaglik.Controllers
{
    public class ReceteController : Controller
    {
        // GET: Recete
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Recetes.ToList();
            return View(degerler);
        }

        public ActionResult ReceteDetay(string id)
        {
            var degerler = c.ReceteIlacs.ToList();

            var kul = c.KullaniciProfils.Where(x => x.TcNo == id).Select(y => y.KullaniciAd + " " + y.KullaniciSoyad).FirstOrDefault();
            ViewBag.hbak = kul;

            return View(degerler);
        }

        Context a = new Context();
        public ActionResult Index2()
        {
            var degerler = a.Recetes.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult ReceteEkle()
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
        public ActionResult ReceteEkle(Recete p)
        {
            c.Recetes.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index2");
        }

        [HttpGet]
        public ActionResult ReceteIlacYaz()
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
        public ActionResult ReceteIlacYaz(ReceteIlac p)
        {
           if (Request.Files.Count > 0)
           {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.İlacGorsel = "/image/" + dosyaadi + uzanti;
           }

            c.ReceteIlacs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult ReceteDetayGetir()
        {
            var degerler = c.ReceteIlacs.ToList();
            return View(degerler);
        }

        Context x = new Context();
        public ActionResult Index3()
        {
            var degerler = x.Recetes.ToList();
            return View(degerler);
        }

        public ActionResult ReceteDetay3()
        {
            var degerler = c.ReceteIlacs.ToList();
            return View(degerler);
        }
    }
}