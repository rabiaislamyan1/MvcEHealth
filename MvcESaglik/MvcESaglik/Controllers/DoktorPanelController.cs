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
    public class DoktorPanelController : Controller
    {
        // GET: DoktorPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["DoktorMail"];
            var degerler = c.DoktorProfils.FirstOrDefault(x => x.DoktorMail == mail);
            ViewBag.ma = mail;
            return View(degerler);
        }

        [Authorize]
        public ActionResult RandevuGecmis(int sayfa = 1)
        {
            var mail = (string)Session["DoktorMail"];
            var id = c.DoktorProfils.Where(x => x.DoktorMail == mail.ToString()).Select(y => y.DoktorID).FirstOrDefault();

            var degerler = c.Randevus.Where(x => x.RandevuNo == id).ToList().ToPagedList(sayfa, 5);

            var kul = c.DoktorProfils.Where(x => x.DoktorID == id).Select(y => y.DoktorAd + " " + y.DoktorSoyad).FirstOrDefault();
            ViewBag.hbak = kul;

            return View(degerler);
        }

        Context x = new Context();
        [Authorize]
        public ActionResult Index2()
        {
            var mail = (string)Session["DoktorMail"];
            var degerler = c.DoktorProfils.FirstOrDefault(x => x.DoktorMail == mail);
            ViewBag.ma = mail;
            return View(degerler);
        }

        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["DoktorMail"];

            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();

            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;

            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View(mesajlar);
        }

        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["DoktorMail"];

            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(x => x.MesajID).ToList();

            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;

            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View(mesajlar);
        }

        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();

            var mail = (string)Session["DoktorMail"];

            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;

            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View(degerler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["DoktorMail"];

            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;

            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["DoktorMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
    }
}