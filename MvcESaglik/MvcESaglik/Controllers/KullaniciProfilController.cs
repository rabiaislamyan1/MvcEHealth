using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;

namespace MvcESaglik.Controllers
{
    public class KullaniciProfilController : Controller
    {
        // GET: KullaniciProfil
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.KullaniciProfils.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        public ActionResult KullaniciDetay(string id)
        {
            var degerler = c.KullaniciProfils.Where(x => x.TcNo == id).ToList();

            var kul = c.KullaniciProfils.Where(x => x.TcNo == id).Select(y => y.KullaniciAd + " " + y.KullaniciSoyad).FirstOrDefault();
            ViewBag.klnc = kul;

            return View(degerler);
        }
    }
}