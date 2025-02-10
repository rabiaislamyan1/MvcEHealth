using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;

namespace MvcESaglik.Controllers
{
    public class RaporController : Controller
    {
        // GET: Rapor
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Rapors.ToList();
            return View(degerler);
        }

        public ActionResult RaporDetay(int id)
        {
            var degerler = c.Rapors.Where(x => x.RaporNo == id).ToList();
            return View(degerler);
        }

        Context a = new Context();
        public ActionResult Index2()
        {
            var degerler = a.Rapors.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult RaporEkle()
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
        public ActionResult RaporEkle(Rapor p)
        {
            c.Rapors.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        Context x = new Context();
        public ActionResult Index3()
        {
            var degerler = x.Rapors.ToList();
            return View(degerler);
        }

        public ActionResult RaporDetay2(int id)
        {
            var degerler = c.Rapors.Where(x => x.RaporNo == id).ToList();
            return View(degerler);
        }
    }
}